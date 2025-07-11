namespace TextRPG.Data;

public class EquipmentData
{
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public int Type { get; set; } = 0;
    
    public int[] Point { get; set; } = Array.Empty<int>();
    
    public int Price { get; set; } = 0;
}