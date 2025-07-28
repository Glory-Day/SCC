using UnityEngine;

namespace Backend.Object
{
    public class ObjectMovement :  MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private Vector3 direction;
        [SerializeField] private float speed;

        private void Update()
        {
            var time = Time.deltaTime;
            var translation = direction * (speed * time);
            
            transform.Translate(translation);
        }
    }
}