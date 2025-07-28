using UnityEngine;

namespace Backend.Object
{
    public class ComponentBatcher : MonoBehaviour
    {
        #region CONSTANT FIELDS API

        private const int MinimumHeight = 1;
        private const int MaximumHeight = 8;

        private const int DefaultHeight = 4;
        
        #endregion
        
        private ComponentResizer[] _resizer;
        
        private Transform _transform;

        private void Awake()
        {
            _resizer = new ComponentResizer[2];
            _resizer[0] = transform.GetChild(0).GetComponent<ComponentResizer>();
            _resizer[1] = transform.GetChild(1).GetComponent<ComponentResizer>();
            
            _transform = transform.GetChild(2);
        }
        
        private void OnEnable()
        {
            var height = Random.Range(MinimumHeight, MaximumHeight);
            
            _resizer[0].Resize(height);
            _resizer[1].Resize(MaximumHeight - height);
            
            var position = transform.position;
            _transform.position = new Vector3(position.x, DefaultHeight - height, position.z);
        }

        private void OnDisable()
        {
            _resizer[0].Resize(DefaultHeight);
            _resizer[1].Resize(DefaultHeight);
            
            var position = transform.position;
            _transform.position = new Vector3(position.x, 0, position.z);
        }
    }
}