using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

namespace Backend.Object.Item
{
    public class Interaction : MonoBehaviour
    {
        [Header("Collision Settings")]
        public float checkRate = 0.05f;
        public float maxCheckDistance;
        public LayerMask layerMask;

        [Header("Game Object Settings")]
        public GameObject currentInteractive;

        [Header("UI Settings")]
        public TextMeshProUGUI promptText;

        private float _lastCheckTime;

        private IInteractable _currentInteractable;

        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Time.time - _lastCheckTime > checkRate == false)
            {
                return;
            }
            
            _lastCheckTime = Time.time;
                
            var ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
            if (Physics.Raycast(ray, out var hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject == currentInteractive)
                {
                    return;
                }
                    
                currentInteractive = hit.collider.gameObject;
                _currentInteractable = hit.collider.GetComponent<IInteractable>();

                SetPromptText();
            }
            else
            {
                currentInteractive = null;
                _currentInteractable = null;

                promptText.gameObject.SetActive(false);
            }
        }

        private void SetPromptText()
        {
            promptText.gameObject.SetActive(true);
            promptText.text = _currentInteractable.GetInteractPrompt();
        }

        public void OnInteractInput(InputAction.CallbackContext context)
        {
            if (context.phase != InputActionPhase.Started || _currentInteractable is null)
            {
                return;
            }
            
            _currentInteractable.Interact();
            _currentInteractable = null;
            currentInteractive = null;

            promptText.gameObject.SetActive(false);
        }
    }
}
