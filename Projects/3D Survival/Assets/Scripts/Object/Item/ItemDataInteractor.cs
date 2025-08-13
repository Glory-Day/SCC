using UnityEngine;
using Backend.Data;
using Backend.Object.Character;

namespace Backend.Object.Item
{
    public class ItemDataInteractor : MonoBehaviour, IInteractable
    {
        [Header("Data Settings")]
        public ItemData data;

        public string GetInteractPrompt()
        {
            var prompt = $"{data.Label}\n{data.Description}";

            return prompt;
        }

        public void Interact()
        {
            PlayerCharacterManager.Instance.Component.ItemData = data;
            PlayerCharacterManager.Instance.Component.AddItemCallback?.Invoke();

            Destroy(gameObject);
        }
    }
}
