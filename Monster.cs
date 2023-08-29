public class Monster : Character
{
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Damage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Defense { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string job { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int level { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Gold { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Mp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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