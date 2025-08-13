using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Backend.Object.Character
{
    public class PlayerCharacterController : MonoBehaviour
    {
        [Header("Movement Settings")]
        public float speed;
        public float force;
        public Vector2 cursor;
        public LayerMask layerMask;

        [Header("Look Settings")]
        public Transform container;
        public float currentRotationX;
        public float minX;
        public float maxX;
        public float sensitivity;

        private Rigidbody _rigidbody;

        private Vector2 _delta;

        private bool _isLooking = true;
        
        public Action inventory;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void LateUpdate()
        {
            if (_isLooking)
            {
                Look();
            }
        }

        private void Move()
        {
            var direction = transform.forward * cursor.y + transform.right * cursor.x;
            direction *= speed;
            direction.y = _rigidbody.velocity.y;

            _rigidbody.velocity = direction;
        }

        public void OnMoveInput(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Performed:
                    cursor = context.ReadValue<Vector2>();
                    break;
                case InputActionPhase.Canceled:
                    cursor = Vector2.zero;
                    break;
            }
        }

        public void OnJumpInput(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Started && IsStanding())
            {
                _rigidbody.AddForce(Vector2.up * force, ForceMode.Impulse);
            }
        }

        public void OnLookInput(InputAction.CallbackContext context)
        {
            _delta = context.ReadValue<Vector2>();
        }

        private void Look()
        {
            currentRotationX += _delta.y * sensitivity;
            currentRotationX = Mathf.Clamp(currentRotationX, minX, maxX);
            container.localEulerAngles = new Vector3(-currentRotationX, 0f, 0f);

            transform.eulerAngles += new Vector3(0f, _delta.x * sensitivity, 0f);
        }

        private bool IsStanding()
        {
            var position = transform.position;
            var rays = new Ray[4]
            {
                new Ray(position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
                new Ray(position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
                new Ray(position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
                new Ray(position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down)
            };

            for (var i = 0; i < 4; i++)
            {
                if (Physics.Raycast(rays[i], 0.1f, layerMask))
                {
                    return true;
                }
            }

            return false;
        }
        
        public void OnInventoryButton(InputAction.CallbackContext callbackContext)
        {
            if (callbackContext.phase == InputActionPhase.Started)
            {
                inventory?.Invoke();
                ToggleCursor();
            }
        }
    
        void ToggleCursor()
        {
            bool toggle = Cursor.lockState == CursorLockMode.Locked;
            Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
            _isLooking = !toggle;
        }
    }
}
