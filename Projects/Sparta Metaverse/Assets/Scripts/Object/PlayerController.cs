using Backend.Utility.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Backend.Object
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float speed;
        
        private Rigidbody2D _rigidbody;
        
        private Controls _controls;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            
            _controls = new Controls();
        }

        private void OnEnable()
        {
            _controls.Player.Enable();
            _controls.Player.Move.performed += Moving;
            _controls.Player.Move.canceled += Stop;
        }

        private void OnDisable()
        {
            _controls.Player.Move.performed -= Moving;
            _controls.Player.Move.canceled -= Stop;
            _controls.Player.Disable();
        }

        private void Moving(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();

            _rigidbody.velocity = direction * speed;
        }

        private void Stop(InputAction.CallbackContext context)
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }
}