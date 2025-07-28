using UnityEngine;

namespace Backend.Object
{
    public class ComponentResizer : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private BoxCollider2D _collider;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<BoxCollider2D>();
        }

        /// <summary>
        /// Resize sprite and collider in block object.
        /// </summary>
        /// <param name="height">The height value to resize.</param>
        public void Resize(int height)
        {
            if (_spriteRenderer is null || _collider is null)
            {
                return;
            }
            
            var size = _spriteRenderer.size;
            _spriteRenderer.size = new Vector2(size.x, height);
            
            var factor = _collider.offset.y < 0 ? -1 : 1;
            _collider.offset = new Vector2(0, factor * 0.5f * height);
            _collider.size = new Vector2(size.x, height);
        }
    }
}