using UnityEngine;

namespace Backend.Utils.Data
{
    [CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/Item Data")]
    public class ItemData : ScriptableObject
    {
        [SerializeField] private string id;
    
        [Space(4f)]
        [SerializeField] private float healthPoint;
        [SerializeField] private float attackPoint;
        [SerializeField] private float defencePoint;
    
        [Space(4f)]
        [SerializeField] private Sprite image;

        public string ID => id;
    
        public float HealthPoint => healthPoint;

        public float AttackPoint => attackPoint;
    
        public float DefensePoint => defencePoint;
    
        public Sprite Image => image;
    }
}
