using System;
using Backend.Object.UI;
using UnityEngine;
using Utility;

namespace Backend.Object
{
    public class StageDataLoader : MonoBehaviour
    {
        [Header("Scene Settings")]
        [SerializeField] private int index;

        public void Load()
        {
            DataManager.Instance.Load();

            var score = DataManager.Instance.StageData.Wrapper[index].Score.ToString();
            GetComponent<PopUpPanel>().SetContent(score);
        }
    }
}