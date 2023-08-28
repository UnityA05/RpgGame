public class Monster : Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Defense { get; set; }
    public string job { get; set; }
    public int level { get; set; }
    public int Gold { get; set; }
    public int Mp { get; set; }
    public Monster(string name, int health, int damage, int defense, string _job, int _level, int gold, int mp)
    {
        Name = name;
        Health = health;
        Damage = damage;
        Defense = defense;
        job = _job;
        level = _level;
        Gold = gold;
        Mp = mp;
    } 
    public Monster()
    {
        Name = "미니언";
        Health = 15;
        Damage = 1;
        Defense = 1;
        job = "미니언";
        level = 2;
        Gold = 0;
        Mp = 0;
    }
}