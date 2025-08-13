using System;
using UnityEngine;
using Backend.Data;

namespace Backend.Object.Character
{
    public class PlayerCharacter : MonoBehaviour
    {
        [SerializeField] private PlayerCharacterCondition condition;
        [SerializeField] private PlayerCharacterController controller;
        [SerializeField] private ItemData itemData;
        
        public Transform dropPosition;
        
        private void Awake()
        {
            condition = GetComponent<PlayerCharacterCondition>();
            controller = GetComponent<PlayerCharacterController>();

            AddItemCallback = null;
            
            PlayerCharacterManager.Instance.Component = this;
        }

        public Action AddItemCallback;

        public PlayerCharacterCondition Condition { get => condition; private set => condition = value; }

        public PlayerCharacterController Controller { get => controller; private set => controller = value; }

        public ItemData ItemData { get => itemData; set => itemData = value; }
    }
}
