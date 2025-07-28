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

        private void Awake()
        {
            DataManager.Instance.Load();

            var score = DataManager.Instance.StageData[index].Score.ToString();
            GetComponent<PopUpPanel>().AddContent(score);
        }
    }
}