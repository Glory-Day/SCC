using UnityEngine;

namespace Backend.Utils.Management
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get 
            {
                if (_instance is not null)
                {
                    return _instance;
                }
            
                var instances = FindObjectsOfType<T>();
                if(instances.Length > 0)
                {
                    _instance = instances[0];
                
                    DontDestroyOnLoad(_instance.gameObject);
                }

                if(instances.Length > 1)
                {
                    var length =  instances.Length;
                    for (var i = 1; i < length; i++)
                    {
                        Destroy(instances[i].gameObject);
                    }
                }

                if (_instance is not null)
                {
                    return _instance;
                }
            
                var clone = new GameObject(typeof(T).Name);
                DontDestroyOnLoad(clone);
                _instance = clone.AddComponent<T>();
                return _instance;
            }
        }
    }
}
