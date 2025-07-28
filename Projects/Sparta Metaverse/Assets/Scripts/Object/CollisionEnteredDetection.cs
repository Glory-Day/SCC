using UnityEngine;
using UnityEngine.Events;

namespace Backend.Object
{
    public class CollisionEnteredDetection :  MonoBehaviour
    {
        private const string Tag = "Player";

        [Header("Event Callbacks")]
        [Space(4f)]
        [SerializeField] public UnityEvent onCollisionEnter;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Tag))
            {
                onCollisionEnter.Invoke();
            }
        }
    }
}