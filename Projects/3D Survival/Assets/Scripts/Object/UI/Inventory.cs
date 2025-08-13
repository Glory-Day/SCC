using System;
using UnityEngine;
using TMPro;
using Backend.Data;
using Backend.Object.Character;
using Random = UnityEngine.Random;

namespace Backend.Object.UI
{
    public class Inventory : MonoBehaviour
    {
        public ItemSlot[] slots;

        public GameObject inventoryWindow;
        public Transform slotPanel;
        public Transform dropPosition;

        [Header("Selected Item")]
        public TextMeshProUGUI selectedItemName;
        public TextMeshProUGUI selectedItemDescription;
        public TextMeshProUGUI selectedItemStatName;
        public TextMeshProUGUI selectedItemStatValue;
        public GameObject useButton;
        public GameObject dropButton;

        private ItemSlot selectedItem;
        private int selectedItemIndex;

        private int curEquipIndex;

        private PlayerCharacterController controller;
        private PlayerCharacterCondition condition;

        private void Start()
        {
            controller = PlayerCharacterManager.Instance.Component.Controller;
            condition = PlayerCharacterManager.Instance.Component.Condition;
            dropPosition = PlayerCharacterManager.Instance.Component.dropPosition;

            controller.inventory += Toggle;
            PlayerCharacterManager.Instance.Component.AddItemCallback += AddItem;

            inventoryWindow.SetActive(false);
            slots = new ItemSlot[slotPanel.childCount];

            for (var i = 0; i < slots.Length; i++)
            {
                slots[i] = slotPanel.GetChild(i).GetComponent<ItemSlot>();
                slots[i].index = i;
                slots[i].inventory = this;
                slots[i].Clear();
            }

            ClearSelectedItemWindow();
        }

        private void ClearSelectedItemWindow()
        {
            selectedItem = null;

            selectedItemName.text = string.Empty;
            selectedItemDescription.text = string.Empty;
            selectedItemStatName.text = string.Empty;
            selectedItemStatValue.text = string.Empty;

            useButton.SetActive(false);
            dropButton.SetActive(false);
        }

        public void Toggle()
        {
            inventoryWindow.SetActive(!IsOpen());
        }

        public bool IsOpen()
        {
            return inventoryWindow.activeInHierarchy;
        }

        public void AddItem()
        {
            var data = PlayerCharacterManager.Instance.Component.ItemData;

            if (data.IsStackable)
            {
                var slot = GetItemStack(data);
                if (slot is null == false)
                {
                    slot.quantity++;
                    UpdateUI();
                    PlayerCharacterManager.Instance.Component.ItemData = null;
                    return;
                }
            }

            var emptySlot = GetEmptySlot();

            if (emptySlot is null == false)
            {
                emptySlot.item = data;
                emptySlot.quantity = 1;
                UpdateUI();
                PlayerCharacterManager.Instance.Component.ItemData = null;
                return;
            }

            ThrowItem(data);
            PlayerCharacterManager.Instance.Component.ItemData = null;
        }

        public void UpdateUI()
        {
            for (var i = 0; i < slots.Length; i++)
            {
                if (slots[i].item is null == false)
                {
                    slots[i].Set();
                }
                else
                {
                    slots[i].Clear();
                }
            }
        }

        private ItemSlot GetItemStack(ItemData data)
        {
            for (var i = 0; i < slots.Length; i++)
            {
                if (slots[i].item == data && slots[i].quantity < data.Capacity)
                {
                    return slots[i];
                }
            }

            return null;
        }

        private ItemSlot GetEmptySlot()
        {
            for (var i = 0; i < slots.Length; i++)
            {
                if (slots[i].item is null)
                {
                    return slots[i];
                }
            }

            return null;
        }

        private void ThrowItem(ItemData data)
        {
            Instantiate(data.Prefab, dropPosition.position, Quaternion.Euler(Vector3.one * Random.value * 360));
        }

        public void SelectItem(int index)
        {
            if (slots[index].item is null)
            {
                return;
            }

            selectedItem = slots[index];
            selectedItemIndex = index;

            selectedItemName.text = selectedItem.item.Label;
            selectedItemDescription.text = selectedItem.item.Description;

            selectedItemStatName.text = string.Empty;
            selectedItemStatValue.text = string.Empty;

            for (var i = 0; i < selectedItem.item.ConsumableItemData.Length; i++)
            {
                var data = selectedItem.item.ConsumableItemData[i];
                selectedItemStatName.text += data.type + "\n";
                selectedItemStatValue.text +=  data.value + "\n";
            }

            useButton.SetActive(selectedItem.item.Type == ItemType.Consumable);
            dropButton.SetActive(true);
        }

        public void OnUseButton()
        {
            if (selectedItem.item.Type == ItemType.Consumable)
            {
                for (var i = 0; i < selectedItem.item.ConsumableItemData.Length; i++)
                {
                    var data = selectedItem.item.ConsumableItemData[i];
                    switch (data.type)
                    {
                        case ConsumableType.Speed:
                            condition.IncreaseSpeed(data.value, data.time);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                RemoveSelectedItem();
            }
        }

        public void OnDropButton()
        {
            ThrowItem(selectedItem.item);
            RemoveSelectedItem();
        }

        void RemoveSelectedItem()
        {
            selectedItem.quantity--;

            if (selectedItem.quantity <= 0)
            {
                selectedItem = null;
                slots[selectedItemIndex].item = null;
                selectedItemIndex = -1;
                ClearSelectedItemWindow();
            }

            UpdateUI();
        }

        public bool HasItem(ItemData item, int quantity)
        {
            return false;
        }
    }
}