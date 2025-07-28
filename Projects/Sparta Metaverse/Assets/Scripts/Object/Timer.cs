using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Backend.Object
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private float duration;
        
        [Header("Event Callbacks")]
        [Space(4f)]
        [SerializeField] private UnityEvent onTick;

        private float _time;
        
        private void Awake()
        {
            _time = 0;
        }

        public void Run()
        {
            StartCoroutine(Running());
        }

        private IEnumerator Running()
        {
            var time = Time.deltaTime;
            
            while (true)
            {
                _time += time;
                if (_time >= duration)
                {
                    onTick.Invoke();
                    
                    _time = 0;
                }
                
                TotalTime += time;
                
                yield return null;
            }
        }

        public void Stop()
        {
            StopAllCoroutines();
        }
        
        public float TotalTime { get; private set; }
    }
}