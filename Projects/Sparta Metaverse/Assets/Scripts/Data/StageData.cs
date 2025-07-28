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
}