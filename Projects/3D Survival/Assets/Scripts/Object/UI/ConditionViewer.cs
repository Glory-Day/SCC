using UnityEngine;
using UnityEngine.UI;

namespace Backend.Object.UI
{
    public class ConditionViewer : MonoBehaviour
    {
        [Header("UI Settings")]
        public Image filled;
        public float amount;
        public float current;
        public float min;
        public float max;
        public float passive;

        private void Start()
        {
            current = amount;
        }

        private void Update()
        {
            filled.fillAmount = Percentage;
        }

        public void Add(float value)
        {
            current = Mathf.Min(current + value, max);
        }

        public void Subtract(float value)
        {
            current = Mathf.Max(current - value, min);
        }

        public float Percentage => current / max;
    }
}
