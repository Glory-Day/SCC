namespace TextRPG.Data
{
    [Serializable]
    public class PlayerData
    {
        public string Name { get; set; } = "Chad";
        
        public int Health { get; set; } = 100;
        
        public int Class { get; set; } = 0;
        
        public int Level { get; set; } = 1;
        
        public int AttackPoint { get; set; } = 100;
        
        public int DefensePoint { get; set; } = 50;

        public List<int> Inventories { get; set; } = new List<int>();
        
        public List<int> Equipments { get; set; } = new List<int>();
        
        public int Gold { get; set; } = 1500;
    }
}