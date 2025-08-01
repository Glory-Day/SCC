﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Backend.Data
{
    [CreateAssetMenu(fileName = "Text Data", menuName = "Scriptable Object/Text Data")]
    public class TextData : ScriptableObject
    {
        [SerializeField] private string header;
        
        [TextArea(3, 10)]
        [SerializeField] private string content;
        [SerializeField] private string footer;
        
        public string Header { get => header; set => header = value; }
        
        public string Content { get => content; set => content = value; }
        
        public string Footer { get => footer; set => footer = value; }
    }
}