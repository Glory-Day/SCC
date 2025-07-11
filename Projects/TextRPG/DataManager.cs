using TextRPG.Data;

namespace TextRPG;

public class DataManager : Singleton<DataManager>
{
    private static readonly string Path = System.IO.Path.GetDirectoryName(
        System.Reflection.Assembly.GetExecutingAssembly().Location) ?? string.Empty;
    
    protected override void Initialize()
    {
        base.Initialize();
        
        if (File.Exists(GetAbsolutePath(nameof(PlayerData))) == false)
        {
            JsonDataSerializer.Serialize(GetAbsolutePath(nameof(PlayerData)), new PlayerData());
        }
        
        PlayerData = JsonDataSerializer.Deserialize<PlayerData>(GetAbsolutePath(nameof(PlayerData)));
        
        SceneData = JsonDataSerializer.Deserialize<SceneData[]>(GetAbsolutePath(nameof(SceneData)));
        EquipmentData = JsonDataSerializer.Deserialize<EquipmentData[]>(GetAbsolutePath(nameof(EquipmentData)));
    }
    
    private static string GetAbsolutePath(string fileName) => $"{Path}/{fileName}.json";

    public void SaveData()
    {
        JsonDataSerializer.Serialize(GetAbsolutePath(nameof(PlayerData)), PlayerData);
    }
    
    public PlayerData PlayerData { get; private set; }
    
    public SceneData[] SceneData { get; private set; }
    
    public EquipmentData[] EquipmentData { get; private set; }
}