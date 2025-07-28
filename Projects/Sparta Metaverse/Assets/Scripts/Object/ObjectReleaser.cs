using UnityEngine;

namespace Backend.Object
{
    public class ObjectReleaser : MonoBehaviour
    {
        #region CONSTANT FIELD API

        private const string Tag = "Object";

        #endregion

        private void OnTriggerEnter2D(Collider2D other)
        {
            var parent = other.transform.parent;
            var clone = parent?.gameObject;
            
            if (clone is null || clone.CompareTag(Tag) == false)
            {
                return;
            }
            
            ObjectPool.Release(clone);
        }
    }
}