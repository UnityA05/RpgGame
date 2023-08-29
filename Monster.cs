/// <summary>
/// ���͸� �����մϴ�. �ƹ� ���� �Է����� ���� �� ����Ʈ(�̴Ͼ�)�� �����Ǹ�
/// ��� ����(�̸�, ü��, �����, ����, ����, ����, ���, ���� ��)���� ������ �����մϴ�.
/// ���� ������ �ѱ�� ������ �´� ���� �˾Ƽ� �������ݴϴ�. ���� : new Monster("Minion");
/// ������ ���� Minion, SiegeMinion, Voidling
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
        Name = "�̴Ͼ�";
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
            Name = "�̴Ͼ�";
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
            Name = "�����̴Ͼ�";
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
            Name = "������";
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