public class Player : Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Defense { get; set; }
    public string job { get; set; }
    public int level { get; set; }
    public int Gold { get; set; }
    public int Mp { get; set; }
    /// <summary>
    /// 이름, 체력, 대미지, 방어력, 직업, 레벨, 골드, 마나를 입력해주세요
    /// </summary>
    /// <param name="name"></param>
    /// <param name="health"></param>
    /// <param name="damage"></param>
    /// <param name="defense"></param>
    /// <param name="_job"></param>
    /// <param name="_level"></param>
    /// <param name="gold"></param>
    /// <param name="mp"></param>
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
        job = "전사";
        level = 1;
        Gold = 1500;
        Mp = 50;
    }
}