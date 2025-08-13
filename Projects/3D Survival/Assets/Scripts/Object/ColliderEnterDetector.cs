using UnityEngine;

namespace Object
{
    public class ColliderEnterDetector : MonoBehaviour
    {
        public float force;
        
        private void OnCollisionEnter(Collision collision)
        {
            var other = collision.gameObject;
            var layer = other.layer;

            if (layer != LayerMask.NameToLayer("Player"))
            {
                return;
            }
            
            var component = other.GetComponent<Rigidbody>();
            component.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}
