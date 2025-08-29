using TMPro;
using UnityEngine;
using Backend.Utils.Management;

namespace Backend.Object.UI
{
    public class StatusPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text healthPointText;
        [SerializeField] private TMP_Text attackPointText;
        [SerializeField] private TMP_Text defensePointText;

        private void OnEnable()
        {
            HealthPointText = $"{GameManager.Instance.Character.HealthPoint}";
            AttackPointText = $"{GameManager.Instance.Character.AttackPoint}";
            DefensePointText = $"{GameManager.Instance.Character.DefensePoint}";
        }

        public string HealthPointText { get => healthPointText.text; set => healthPointText.text = value; }
    
        public string AttackPointText { get => attackPointText.text; set => attackPointText.text = value; }
    
        public string DefensePointText { get => defensePointText.text; set => defensePointText.text = value; }
    }
}
