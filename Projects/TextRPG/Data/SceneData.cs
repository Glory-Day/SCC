namespace TextRPG.Data;

[Serializable]
public class SceneData
{
    public string Title { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public string[] Contents { get; set; } = Array.Empty<string>();
    
    public string[] Menus { get; set; } =  Array.Empty<string>();

    public int[] Indexes { get; set; } = Array.Empty<int>();
    
    public bool HasExit { get; set; } = false;
}