using UnityEngine;

namespace Backend.Data
{
    [CreateAssetMenu(fileName = "Vehicle Data", menuName = "Scriptable Object/Vehicle Data")]
    public class VehicleData : ScriptableObject
    {
        [SerializeField] private Sprite image;
        
        public Sprite Image { get => image; set => image = value; }
    }
}