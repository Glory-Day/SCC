using System;
using UnityEngine;

namespace Backend.Data
{
    [CreateAssetMenu(fileName = "Skin Data", menuName = "Scriptable Object/Skin Data")]
    public class SkinData : ScriptableObject
    {
        [SerializeField] private Sprite image;
        
        public Sprite Image { get => image; set => image = value; }
    }
}