using System.Diagnostics.CodeAnalysis;
/// <summary>
/// 플레이어를 생성합니다. 아무 값도 입력하지 않을 시 디폴트(Deprived직업의 Chad)가 생성됩니다.
/// 모든 값을(이름, 체력, 대미지, 방어력, 직업, 레벨, 골드, 마나, 크리티컬 확률, 회피율 순)으로 설정이 가능합니다.
/// 또한 이름과 직업을 넘길시 그에 맞는 값을 알아서 설정해 줍니다. 예시 : Player("Chad", "Wizard");
/// 설정된 직업 : Warrior, Wizard, Thief, Archer, Deprived 단 잘못된 값을 입력시 자동으로 Deprived으로 설정됩니다.
/// </summary>
public class Player : Character
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Defense { get; set; }
    public Job job { get; set; }
    public int level { get; set; }
    public int Gold { get; set; }
    public int Mp { get; set; }
    public bool IsDead { get; set; }
    public float CriticalPer { get; set; }
    public float AvoidanceRate { get; set; }
    public Player(string name, int health, int damage, int defense, string _job, int _level, int gold, int mp, float criticalPer, float avoidanceRate)
    {

        if (_job == "Wizard")
            job = new Wizard();
        else if (_job == "Thief")
            job = new Thief();
        else if (_job == "Archer")
            job = new Archer();
        else if (_job == "Warrior")
            job = new Warrior();
        else
            job = new Deprived();
        Name = name;
        Health = health + job.AdditionalHp;
        Damage = damage + job.AdditionalATK;
        Defense = defense + job.AdditionalDEF;
        level = _level;
        Gold = gold;
        Mp = mp + job.AdditionalMp;
        IsDead = false;
        CriticalPer = criticalPer + job.AdditionalCriticalPer;
        AvoidanceRate = avoidanceRate + job.AdditionalAvoidanceRate;
    }
    public Player()
    {
        job = new Deprived();
        Name = "Chad";
        Health = 100 + job.AdditionalHp;
        Damage = 10 + job.AdditionalATK;
        Defense = 5 + job.AdditionalDEF;
        level = 1;
        Gold = 1500;
        Mp = 50 + job.AdditionalMp;
        IsDead = false;
        CriticalPer = 15 + job.AdditionalCriticalPer;
        AvoidanceRate = 10 + job.AdditionalAvoidanceRate;
    }
    public Player(string name, string _job)
    {

        if (_job == "Wizard")
            job = new Wizard();
        else if (_job == "Thief")
            job = new Thief();
        else if (_job == "Archer")
            job = new Archer();
        else if (_job == "Warrior")
            job = new Warrior();
        else
            job = new Deprived();
        Name = name;
        Health = 100 + job.AdditionalHp;
        Damage = 10 + job.AdditionalATK;
        Defense = 5 + job.AdditionalDEF;
        level = 1;
        Gold = 1500;
        Mp = 50 + job.AdditionalMp;
        IsDead = false;
        CriticalPer = 15 + job.AdditionalCriticalPer;
        AvoidanceRate = 10 + job.AdditionalAvoidanceRate;
    }
}