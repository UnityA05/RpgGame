using System.Diagnostics.CodeAnalysis;
/// <summary>
/// 플레이어를 생성합니다. 아무 값도 입력하지 않을 시 디폴트(Deprived직업의 Chad)가 생성됩니다.
/// 모든 값을(이름, 체력, 대미지, 방어력, 직업, 레벨, 골드, 마나, 크리티컬 확률, 회피율 순)으로 설정이 가능합니다.
/// 또한 이름과 직업을 넘길시 그에 맞는 값을 알아서 설정해 줍니다. 예시 : Player("Chad", "Wizard");
/// 설정된 직업 : Warrior, Wizard, Thief, Archer, Deprived 단 잘못된 값을 입력시 자동으로 Deprived으로 설정됩니다.
/// 회피율과 크리티컬확률은 float으로 선언되어 있으며 %값입니다. 에시 : AvoidanceRate = 10f -> 10%입니다.
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
    public List<Skill> Skills { get; set; }
    public int MaxHealth { get; set; }
    public int MaxMp { get; set; }
    /// <summary>
    /// 이름, 체력, 대미지, 방어력, 직업, 레벨, 골드, 마나, 크리티컬 확률, 회피율 순 으로 설정이 가능합니다.
    /// 설정된 직업 : Warrior, Wizard, Thief, Archer, Deprived 단 잘못된 값을 입력시 자동으로 Deprived으로 설정됩니다.
    /// 회피율과 크리티컬확률은 float으로 선언되어 있으며 %값입니다. 에시 : AvoidanceRate = 10f -> 10%입니다.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="health"></param>
    /// <param name="damage"></param>
    /// <param name="defense"></param>
    /// <param name="_job"></param>
    /// <param name="_level"></param>
    /// <param name="gold"></param>
    /// <param name="mp"></param>
    /// <param name="criticalPer"></param>
    /// <param name="avoidanceRate"></param>
    public Player(string name, int health, int damage, int defense, string _job, int _level, int gold, int mp, float criticalPer, float avoidanceRate)
    {
        Skills = new List<Skill>();
        if (_job == "Wizard")
        {
            job = new Wizard();
            Skills.Add(new Heal());
            Skills.Add(new EnergyBolthot());
        }
        else if (_job == "Thief")
        {
            job = new Thief();
            Skills.Add(new AlphaStrike());
            Skills.Add(new LuckySeven());
        }
        else if (_job == "Archer")
        {
            job = new Archer();
            Skills.Add(new AlphaStrike());
            Skills.Add(new doubleShot());
        }
        else if (_job == "Warrior")
        {
            job = new Warrior();
            Skills.Add(new AlphaStrike());
            Skills.Add(new DoubleStrike());
        }
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
        Skills = new List<Skill>();
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
    /// <summary>
    /// 설정된 직업 : Warrior, Wizard, Thief, Archer, Deprived 단 잘못된 값을 입력시 자동으로 Deprived으로 설정됩니다.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="_job"></param>
    public Player(string name, string _job)
    {
        Skills = new List<Skill>();
        if (_job == "Wizard")
        {
            job = new Wizard();
            Skills.Add(new Heal());
            Skills.Add(new EnergyBolthot());
        }
        else if (_job == "Thief")
        {
            job = new Thief();
            Skills.Add(new AlphaStrike());
            Skills.Add(new LuckySeven());
        }
        else if (_job == "Archer")
        {
            job = new Archer();
            Skills.Add(new AlphaStrike());
            Skills.Add(new doubleShot());
        }
        else if (_job == "Warrior")
        {
            job = new Warrior();
            Skills.Add(new AlphaStrike());
            Skills.Add(new DoubleStrike());
        }
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