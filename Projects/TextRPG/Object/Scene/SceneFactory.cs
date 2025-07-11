using TextRPG.Data;

namespace TextRPG.Object.Scene;

public static class SceneFactory
{
    public static Scene Create(int index, SceneData data)
    {
        switch (index)
        {
            case 0:  return new MainScene(data);
            case 1:  return new StatusScene(data);
            case 2:  return new InventoryScene(data);
            case 3:  return new EquipmentManagementScene(data);
            case 4:  return new StoreScene(data);
            case 5:  return new PurchaseScene(data);
            case 6:  return new SaleScene(data);
            case 7:  return new RestScene(data);
            case 8:  return new DungeonMenuScene(data);
            case 9:  return new DungeonClearSuccessScene(data);
            case 10: return new DungeonClearFailedScene(data);
            default: throw new IndexOutOfRangeException();
        }
    }
}