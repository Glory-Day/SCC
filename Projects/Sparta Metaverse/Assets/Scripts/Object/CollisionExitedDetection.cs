using UnityEngine;
using UnityEngine.Events;

namespace Backend.Object
{
    public class CollisionExitedDetection :  MonoBehaviour
    {
        private const string Tag = "Player";

        [Header("Event Callbacks")]
        [Space(4f)]
        [SerializeField] public UnityEvent onCollisionExit;
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(Tag))
            {
                onCollisionExit.Invoke();
            }
        }
    }
}