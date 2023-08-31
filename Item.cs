public class Item
{

    public string item_Name { get; set; }
    public int item_Health { get; set; }
    public int item_Damage { get; set; }
    public int item_Defense { get; set; }
    public int item_Gold { get; set; }
    public int item_Mp { get; set; }
    public int item_CriticalPer { get; set; }
    public int item_AvoidanceRate { get; set; }
    public string item_Discription { get; set; }
    public string item_Job { get; set; }
    public Item()
    {
        
    }
    public class Weapon : Item
    {
        public Weapon(string _item_name, int _item_damage, int _item_defense, int _item_Gold, int _item_CriticalPer, int _item_AvoidanceRate, string _item_discription) : base()
        {
            item_Name = _item_name;
            item_Damage = _item_damage;
            item_Defense = _item_defense;
            item_Gold = _item_Gold;
            item_Discription = _item_discription;
            item_CriticalPer = _item_CriticalPer;
            item_AvoidanceRate = _item_AvoidanceRate;
        }
    }
    public class Armor : Item
    {
        public Armor(string _item_name, int _item_damage, int _item_defense, int _item_Gold, int _item_CriticalPer, int _item_AvoidanceRate, string _item_discription) : base()
        {
            item_Name = _item_name;
            item_Damage = _item_damage;
            item_Defense = _item_defense;
            item_Gold = _item_Gold;
            item_Discription = _item_discription;
            item_CriticalPer = _item_CriticalPer;
            item_AvoidanceRate = _item_AvoidanceRate;
        }
    }

    public class Accessories : Item
    {
        public Accessories(string _item_name, int _item_damage, int _item_defense, int _item_Gold, int _item_CriticalPer, int _item_AvoidanceRate, int _item_Health, int _item_Mp, string _item_discription) : base()
        {
            //Accessories
            item_Name = _item_name;
            item_Damage = _item_damage;
            item_Defense = _item_defense;
            item_Gold = _item_Gold;
            item_Discription = _item_discription;
            item_CriticalPer = _item_CriticalPer;
            item_AvoidanceRate = _item_AvoidanceRate;
            item_Health = _item_Health;
            item_Mp = _item_Mp;
        }
    }
    public class Potion : Item
    {
        public Potion(string _item_name, int _item_health, int _item_Mp, int _item_Gold, string _item_discription) : base()
        {
            //potion
            item_Name = _item_name;
            item_Health = _item_health;
            item_Mp = _item_Mp;
            item_Gold = _item_Gold;
            item_Discription = _item_discription;
        }
    }
}