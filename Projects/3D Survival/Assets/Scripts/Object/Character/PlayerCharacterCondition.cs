using System.Collections;
using UnityEngine;
using Backend.Object.UI;

namespace Backend.Object.Character
{
    public class PlayerCharacterCondition : MonoBehaviour
    {
        [Header("Component Settings")]
        [SerializeField] private ConditionHub hub;
        
        public void Heal(float value)
        {
            hub.Health.Add(value);
        }

        public void IncreaseSpeed(float value, float time)
        {
            StartCoroutine(IncreasingSpeed(value, time));
        }

        private IEnumerator IncreasingSpeed(float value, float time)
        {
            hub.Speed += value;
            
            yield return new WaitForSeconds(time);
            
            hub.Speed -= value;
        }

        public ConditionHub Hub { get => hub; set => hub = value; }
    }
}
