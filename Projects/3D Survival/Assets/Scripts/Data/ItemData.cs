using System;
using UnityEngine;

namespace Backend.Data
{
    public enum ItemType
    {
        Consumable
    }

    public enum ConsumableType
    {
        Speed
    }

    [Serializable]
    public class ConsumableItemData
    {
        public ConsumableType type;
        public float value;
        public float time;
    }

    [CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/Data/Item Data")]
    public class ItemData : ScriptableObject
    {
        [Header("Default Data Information")]
        [SerializeField] private Sprite icon;
        [SerializeField] private string label;
        [SerializeField] private string description;
        [SerializeField] private ItemType type;
        [SerializeField] private GameObject prefab;

        [Header("Stacking Data Information")]
        [SerializeField] private bool isStackable;
        [SerializeField] private int capacity;

        [Header("Consumable Item Data Information")]
        [SerializeField] private ConsumableItemData[] consumableItemData;

        public Sprite Icon { get => icon; set => icon = value; }

        public string Label { get => label; set => label = value; }

        public string Description { get => description; set => description = value; }

        public ItemType Type { get => type; set => type = value; }

        public GameObject Prefab { get => prefab; set => prefab = value; }

        public bool IsStackable { get => isStackable; set => isStackable = value; }

        public int Capacity { get => capacity; set => capacity = value; }

        public ConsumableItemData[] ConsumableItemData { get => consumableItemData; set => consumableItemData = value; }
    }
}
