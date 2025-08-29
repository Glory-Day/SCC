namespace Backend.Object
{
    public class Character
    {
        public Character()
        {
            ID = "Glory Day";
            Level = 1;
            Gold = 20000;
        
            HealthPoint = 100;
            AttackPoint = 200;
            DefensePoint = 300;
        }

        public Character(string id, int level, int gold, float healthPoint, float attackPoint, float defensePoint)
        {
            ID = id;
            Level = level;
            Gold = gold;
        
            HealthPoint = healthPoint;
            AttackPoint = attackPoint;
            DefensePoint = defensePoint;
        }
    
        public string ID { get; private set; }
    
        public int Level { get; private set; }
    
        public int Gold { get; private set; }
    
        public float HealthPoint { get; set; }
    
        public float AttackPoint { get; set; }
    
        public float DefensePoint { get; set; }
    }
}


