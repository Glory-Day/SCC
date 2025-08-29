using UnityEngine;
using UnityEngine.UI;
using Backend.Utils.Data;

namespace Backend.Object.UI
{
    public class ItemDataLoader : MonoBehaviour
    {
        [SerializeField] public ItemData data;
    
        [Space(4f)]
        [SerializeField] private Image image;
        [SerializeField] private GameObject displayLayoutGroupObject;

        public void SetData()
        {
            image.sprite = data.Image;
        
            displayLayoutGroupObject.SetActive(false);
        }

        public void SetEquipmentStatusDisplayLayoutGroupObjectActive(bool value)
        {
            displayLayoutGroupObject.SetActive(value);
        }
    }
}
