using System.ComponentModel;

public class Make
{
    // ���� �ƹ��͵� ���� �����ָ� ����Ʈ�� �����˴ϴ�.
    private Player player;
    private List<Monster> monsters;

    public Make()
    {
        player = new Player();
        monsters = new List<Monster>();
    }
    public Make(string name, int health, int damage, int defense, string _job, int _level, int gold, int mp)
    {
        player = new Player(name, health, damage, defense, _job, _level, gold, mp);
        monsters = new List<Monster>();
    }
    /// <summary>
    /// �̸�, ü��, �����, ����, ����, ����, ���, ������ �Է����ּ���
    /// </summary>
    /// <param name="name"></param>
    /// <param name="health"></param>
    /// <param name="damage"></param>
    /// <param name="defense"></param>
    /// <param name="_job"></param>
    /// <param name="_level"></param>
    /// <param name="gold"></param>
    /// <param name="mp"></param>
    public void AddMonster(string name, int health, int damage, int defense, string _job, int _level, int gold, int mp)
    {
        Monster mosnter = new Monster(name, health, damage, defense, _job, _level, gold, mp);
        monsters.Add(mosnter);
    }
    public Player GetPlayer()
    {
        return player;
    }
    public void RemoveAtMonster(int index)
    {
        monsters.RemoveAt(index);
    }
    public void MonstersClear()
    {
        monsters.Clear();
    }
    public Monster GetMonster(int index)
    {
        return monsters[index];
    }
    public List<Monster> GetMonsters()
    {
        return monsters;
    }
    public int MonsterCount()
    {
        return monsters.Count();
    }
}