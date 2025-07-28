using System.Collections.Generic;
using Backend.Object.UI;
using UnityEngine;

namespace Backend.Object
{
    public class ObjectPool : MonoBehaviour
    {
        [Header("Pool Settings")]
        [SerializeField] private GameObject prefab;
        [SerializeField] private int size = 10;

        [Header("Additional settings")]
        [SerializeField] private List<Transform> spawners;
        
        private Queue<GameObject> _queue;

        private void Awake()
        {
            // Get panel game object.
            var sibling = transform.parent.GetChild(1).GetChild(1).gameObject;
            var panel = sibling.GetComponent<PopUpPanel>();
            var calculator = sibling.GetComponent<ScoreCalculator>();
            
            // Initialize object pool.
            _queue = new Queue<GameObject>();
            for (var i = 0; i < size; i++)
            {
                var clone = Instantiate(prefab, transform);
                var components = clone.GetComponentsInChildren<CollisionEnteredDetection>();
                for (var j = 0; j < components.Length; j++)
                {
                    // Register callback.
                    components[j].onCollisionEnter.AddListener(Action);
                }

                var component = clone.GetComponentInChildren<CollisionExitedDetection>();
                component?.onCollisionExit.AddListener(() => { calculator.Count++; });
                
                clone.SetActive(false);

                _queue.Enqueue(clone);
            }

            return;

            void Action()
            {
                GetComponent<Timer>().Stop();
                
                Clear();
                
                calculator.SetScore();
                panel.TurnOn();
            }
        }

        public void Spawn()
        {
            var count = spawners.Count;
            var index = Random.Range(0, count);
            
            var clone = _queue.Dequeue();
            clone.transform.position = spawners[index].position;
            clone.SetActive(true);
            
            _queue.Enqueue(clone);
        }

        public static void Release(GameObject clone)
        {
            clone.SetActive(false);
        }

        public void Clear()
        {
            while (_queue.Count > 0)
            {
                Destroy(_queue.Dequeue());
            }
        }
    }
}