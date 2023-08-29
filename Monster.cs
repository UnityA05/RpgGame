/// <summary>
/// 몬스터를 생성합니다. 아무 값도 입력하지 않을 시 디폴트(미니언)이 생성되며
/// 모든 값을(이름, 체력, 대미지, 방어력, 직업, 레벨, 골드, 마나 순)으로 설정이 가능합니다.
/// 또한 직업만 넘길시 직업에 맞는 값을 알아서 설정해줍니다. 예시 : new Monster("Minion");
/// 설정된 직업 Minion, SiegeMinion, Voidling
/// </summary> 
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
        job = MonsterType.Minion.ToString();
        level = 2;
        Gold = 0;
        Mp = 0;
    }
    public Monster(string _job)
    {
        if (_job == MonsterType.Minion.ToString())
        {
            Name = "미니언";
            Health = 15;
            Damage = 1;
            Defense = 1;
            job = MonsterType.Minion.ToString();
            level = 2;
            Gold = 0;
            Mp = 0;
        }
        else if (_job == MonsterType.SiegeMinion.ToString())
        {
            Name = "대포미니언";
            Health = 25;
            Damage = 10;
            Defense = 10;
            job = MonsterType.SiegeMinion.ToString();
            level = 5;
            Gold = 0;
            Mp = 0;
        }
        else
        {
            Name = "공허충";
            Health = 10;
            Damage = 20;
            Defense = 1;
            job = MonsterType.Voidling.ToString();
            level = 3;
            Gold = 0;
            Mp = 0;
        }
    }
    public enum MonsterType
    {
        Minion,
        SiegeMinion,
        Voidling
    }
}