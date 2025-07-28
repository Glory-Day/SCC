using System;
using UnityEngine;

namespace Backend.Data
{
    [Serializable]
    public class StageData
    {
        [SerializeField] private int score;
        
        public int Score { get => score; set => score = value; }
    }

    [Serializable]
    public class StageDataWrapper
    {
        [SerializeField] private StageData[] wrapper;
        
        public StageData[] Wrapper { get => wrapper; set => wrapper = value; }
    }
}