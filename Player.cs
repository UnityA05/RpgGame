public class Player : Character
{
    public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Damage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Defense { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public string job { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int level { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Gold { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Mp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Player(string name, int health, int damage, int defense, string _job, int _level, int gold, int mp)
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
    public Player()
    {
        Name = "Chad";
        Health = 100;
        Damage = 10;
        Defense = 5;
        job = "ภüป็";
        level = 1;
        Gold = 1500;
        Mp = 50;
    }
}