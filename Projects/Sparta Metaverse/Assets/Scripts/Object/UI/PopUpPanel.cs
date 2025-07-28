using System.Text;
using Backend.Data;
using Backend.Utility.Input;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Backend.Object.UI
{
    public class PopUpPanel : MonoBehaviour
    {
        [Header("Text Data Settings")]
        public TextData data;
        
        [Header("Event Callbacks")]
        [Space(4f)]
        [SerializeField] public UnityEvent onClose;
        
        private TMP_Text _header;
        private TMP_Text _content;
        private TMP_Text _footer;

        private Transform _screen;
        
        private Controls _controls;

        private readonly StringBuilder _builder = new ();
        
        private void Awake()
        {
            _screen = transform.GetChild(0);
            _header = _screen.GetChild(1).GetComponent<TMP_Text>();
            _content = _screen.GetChild(2).GetComponent<TMP_Text>();
            _footer = _screen.GetChild(3).GetComponent<TMP_Text>();
            
            _controls = new Controls();
        }
        
        private void OnEnable()
        {
            _header.text = data.Header;
            _content.text = data.Content;
            _footer.text = data.Footer;
            
            _controls.Enable();
            _controls.UI.Press.performed += TurnOff;
        }

        private void OnDisable()
        {
            _controls.UI.Press.performed -= TurnOff;
            _controls.Disable();
        }
        
        public void TurnOn()
        {
            _screen.gameObject.SetActive(true);
        }

        public void TurnOff(InputAction.CallbackContext context)
        {
            if (_screen.gameObject.activeSelf == false)
            {
                return;
            }
            
            _builder.Clear();
            
            onClose.Invoke();
            
            _screen.gameObject.SetActive(false);
        }
        
        public void SetContent(string text)
        {
            _builder.Append(data.Content);
            _builder.Append(text);
            
            _content.text = _builder.ToString();
            
            _builder.Clear();
        }
    }
}
