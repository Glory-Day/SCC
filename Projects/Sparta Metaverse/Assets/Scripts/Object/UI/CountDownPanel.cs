using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

namespace Backend.Object.UI
{
    public class CountDownPanel : MonoBehaviour
    {
        private const float DefaultWaitingTime = 4f;

        [Header("Event Callbacks")]
        [Space(4f)]
        [SerializeField] public UnityEvent onTick;
        
        private TMP_Text _text;
        
        private void Awake()
        {
            _text = transform.GetChild(1).GetComponent<TMP_Text>();
        }
        
        private void OnEnable()
        {
            StartCoroutine(CountDown());
        }
        
        private IEnumerator CountDown()
        {
            var time = DefaultWaitingTime;
            
            while (time > 0)
            {
                _text.text = ((int)time).ToString();
                
                time -= Time.deltaTime;
                
                yield return null;
            }
            
            onTick.Invoke();
            
            gameObject.SetActive(false);
        }
        
        public void Open()
        {
            gameObject.SetActive(true);
        }
    }
}