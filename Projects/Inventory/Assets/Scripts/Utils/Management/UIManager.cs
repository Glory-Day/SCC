using UnityEngine;
using Backend.Object.UI;

namespace Backend.Utils.Management
{
    public class UIManager : Singleton<UIManager>
    {
        [SerializeField] private MainMenuPresenter mainMenuPresenter;
        [SerializeField] private StatusPresenter statusPresenter;
        [SerializeField] private InventoryPresenter inventoryPresenter;

        private void Awake()
        {
            var count = InventoryPresenter.itemSlotData.Count;
            for (var i = 0; i < count; i++)
            {
                var item = InventoryPresenter.itemSlotData[i];
                if (item.isEquipped == false)
                {
                    continue;
                }
            
                GameManager.Instance.Character.HealthPoint += item.data.HealthPoint;
                GameManager.Instance.Character.AttackPoint += item.data.AttackPoint;
                GameManager.Instance.Character.DefensePoint += item.data.DefensePoint;
            }
        }

        public MainMenuPresenter MainMenuPresenter => mainMenuPresenter;
    
        public StatusPresenter StatusPresenter => statusPresenter;
    
        public InventoryPresenter InventoryPresenter => inventoryPresenter;
    }
}


