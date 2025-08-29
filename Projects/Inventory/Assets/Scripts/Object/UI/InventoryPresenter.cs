using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Backend.Utils.Data;
using Backend.Utils.Management;

namespace Backend.Object.UI
{
    public class InventoryPresenter : MonoBehaviour
{
    [SerializeField] public List<ItemSlotData> itemSlotData;
    
    [Space(4f)]
    [SerializeField] private GameObject itemSlotPrefab;
    [SerializeField] private Transform contents;
    
    [Space(4f)]
    [SerializeField] private GameObject equipButtonObject;
    [SerializeField] private GameObject unequipButtonObject;
    
    private Button _equipButton;
    private Button _unequipButton;
    
    private readonly List<ItemDataLoader> _clones = new ();
    
    private void Awake()
    {
        _equipButton = equipButtonObject.GetComponent<Button>();
        _unequipButton = unequipButtonObject.GetComponent<Button>();
        
        var count = itemSlotData.Count;
        for (var i = 0; i < count; i++)
        {
            var clone = Instantiate(itemSlotPrefab, contents);
            var component = clone.GetComponent<ItemDataLoader>();
            component.data = itemSlotData[i].data;
            component.SetData();
            component.SetEquipmentStatusDisplayLayoutGroupObjectActive(itemSlotData[i].isEquipped);
            
            var index = i;
            var button = clone.GetComponent<Button>();
            button.onClick.AddListener(() => { ClickItemSlotButton(index); });
            
            _clones.Add(component);
        }
        
        equipButtonObject.SetActive(false);
        unequipButtonObject.SetActive(false);
    }

    private void ClickItemSlotButton(int index)
    {
        _equipButton.onClick.RemoveAllListeners();
        _unequipButton.onClick.RemoveAllListeners();
        
        equipButtonObject.SetActive(!itemSlotData[index].isEquipped);
        unequipButtonObject.SetActive(itemSlotData[index].isEquipped);
        
        _equipButton.onClick.AddListener(() => { ClickEquipButton(index); });
        _unequipButton.onClick.AddListener(() => { ClickUnequipButton(index); });
    }

    private void ClickEquipButton(int index)
    {
        itemSlotData[index].isEquipped = true;
        
        GameManager.Instance.Character.HealthPoint += _clones[index].data.HealthPoint;
        GameManager.Instance.Character.AttackPoint += _clones[index].data.AttackPoint;
        GameManager.Instance.Character.DefensePoint += _clones[index].data.DefensePoint;
        
        _clones[index].SetEquipmentStatusDisplayLayoutGroupObjectActive(true);
        
        equipButtonObject.SetActive(false);
        unequipButtonObject.SetActive(true);
    }

    private void ClickUnequipButton(int index)
    {
        itemSlotData[index].isEquipped = false;
        
        GameManager.Instance.Character.HealthPoint -= _clones[index].data.HealthPoint;
        GameManager.Instance.Character.AttackPoint -= _clones[index].data.AttackPoint;
        GameManager.Instance.Character.DefensePoint -= _clones[index].data.DefensePoint;
        
        _clones[index].SetEquipmentStatusDisplayLayoutGroupObjectActive(false);
        
        equipButtonObject.SetActive(true);
        unequipButtonObject.SetActive(false);
    }
    
    #region PRIVATE STRUCTURES API

    [Serializable]
    public class ItemSlotData
    {
        [SerializeField] public ItemData data;
        [SerializeField] public bool isEquipped;
    }

    #endregion
}
}

