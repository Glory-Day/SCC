using System;
using UnityEngine;

namespace Backend.Object
{
    public class CameraController : MonoBehaviour
    {
        private const float Factor = 0.2f;
        
        [Header("Target Settings")]
        [SerializeField]
        private Transform target;

        [Header("Camera Settings")]
        [SerializeField]
        private Boundary boundary;
        
        private void FixedUpdate()
        {
            var position = new Vector3(target.position.x, target.position.y, transform.position.z);
            position.x = Mathf.Clamp(position.x, boundary.left, boundary.right);
            position.y = Mathf.Clamp(position.y, boundary.top, boundary.bottom);
            
            transform.position = Vector3.Lerp(transform.position, position, Factor);
        }

        #region SERIALIZABLE STRUCTURE API

        [Serializable]
        private struct Boundary
        {
            public float left;
            public float right;
            public float top;
            public float bottom;
        }

        #endregion
    }
}