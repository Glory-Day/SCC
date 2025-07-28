using Backend.Object.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

namespace Backend.Object
{
    public class ScoreCalculator : MonoBehaviour
    {
        private Timer _timer;
        
        private void Awake()
        {
            var sibling = transform.parent.parent.GetChild(0).gameObject;
            _timer = sibling.GetComponent<Timer>();
            
            Count = 0;
        }

        public void SetScore()
        {
            var score = Count == 0 ? (int)_timer.TotalTime : Count;
            var text = score.ToString();

            // If this is the highest score, save the data.
            var index = SceneManager.GetActiveScene().buildIndex - 1;
            var loaded = DataManager.Instance.StageData.Wrapper[index].Score;
            DataManager.Instance.StageData.Wrapper[index].Score = Mathf.Max(loaded, score);
            DataManager.Instance.Save();
            
            GetComponent<PopUpPanel>().AddContent(text);
        }
        
        public int Count { get; set; }
    }
}