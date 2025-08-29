using TMPro;
using UnityEngine;

namespace Backend.Object.UI
{
    public class MainMenuPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_Text idText;
        [SerializeField] private TMP_Text levelText;
        [SerializeField] private TMP_Text goldText;
    
        public string IDText { get => idText.text; set => idText.text = value; }
    
        public string LevelText { get => levelText.text; set => levelText.text = value; }
    
        public string GoldText { get => goldText.text; set => goldText.text = value; }
    }
}
