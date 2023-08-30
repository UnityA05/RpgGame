using System.Net.Security;
using static System.Net.Mime.MediaTypeNames;
/// <summary>
/// 몬스터를 생성합니다. 아무 값도 입력하지 않을 시 디폴트(Minion)가 생성됩니다.
/// 모든 값을(이름, 체력, 대미지, 방어력, 직업, 레벨, 골드, 마나, 크리티컬 확률, 회피율 순)으로 설정이 가능합니다.
/// 직업을 넘길시 그에 맞는 값을 알아서 설정해 줍니다. 예시 : Monster("Minion");
/// 직업과 레벨을 넘길시 그에 맞는 값을 알아서 설정해 줍니다. 예시 : Monster("Minion", 1);
/// 설정된 직업 : "Minion", "SiegeMinion", 'Voidling" 단 잘못된 값을 입력시 자동으로 "Miniond"으로 설정됩니다.
/// </summary> 
public class Monster : Character
{
    private int _level;
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Defense { get; set; }
    public Job job { get; set; }
    // public int level { get; set; }
    public int level
    {
        get { return _level; }
        set
        {
            _level = value;
            SetStatByLevel(_level);
        }
    }
    public int Gold { get; set; }
    public int Mp { get; set; }
    public bool IsDead { get; set; }
    public float CriticalPer { get; set; }
    public float AvoidanceRate { get; set; }
    public List<Skill> Skills { get; set; }
    public int MaxHealth { get; set; }
    public int MaxMp { get; set; }
    /// <summary>
    /// 모든 값을(이름, 체력, 대미지, 방어력, 직업, 레벨, 골드, 마나, 크리티컬 확률, 회피율 순)으로 설정이 가능합니다.
    /// 설정된 직업 : "Minion", "SiegeMinion", 'Voidling" 단 잘못된 값을 입력시 자동으로 "Miniond"으로 설정됩니다.
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
    public Monster(string name, int health, int damage, int defense, string _job, int _level, int gold, int mp, float criticalPer, float avoidanceRate)
    {
        Skills = new List<Skill>();
        if (_job == "SiegeMinion")
        {
            job = new SiegeMinion();
            Skills.Add(new Tackle());
            Skills.Add(new CannonBlaster());
            Skills.Add(new CannonBarrage());
        }
        else if (_job == "Voidling")
        {
            job = new Voidling();
            Skills.Add(new Tackle());
            Skills.Add(new Scratch());
            Skills.Add(new FurySwipes());
        }
        else
        {
            job = new Minion();
            Skills.Add(new Tackle());
        }
        Name = name;
        MaxHealth = health + job.AdditionalHp;
        Health = MaxHealth;
        MaxMp = mp + job.AdditionalMp;
        Mp = MaxMp;
        Damage = damage + job.AdditionalATK;
        Defense = defense + job.AdditionalDEF;
        level = _level;
        Gold = gold;
        IsDead = false;
        CriticalPer = criticalPer + job.AdditionalCriticalPer;
        AvoidanceRate = avoidanceRate + job.AdditionalAvoidanceRate;
    }
    public Monster()
    {
        Skills = new List<Skill>();
        job = new Minion();
        Skills.Add(new Tackle());
        Name = "미니언";
        MaxHealth = 15;
        Health = MaxHealth;
        MaxMp = 20;
        Mp = MaxMp;
        Damage = 1;
        Defense = 1;
        level = 2;
        Gold = 0;
        IsDead = false;
        CriticalPer = 15f;
        AvoidanceRate = 10f;
    }
    /// <summary>
    /// 설정된 직업 : "Minion", "SiegeMinion", 'Voidling" 단 잘못된 값을 입력시 자동으로 "Miniond"으로 설정됩니다.
    /// </summary>
    /// <param name="_job"></param>
    /// <param name="_level"></param>
    public Monster(string _job, int _level)
    {
        Skills = new List<Skill>();
        if (_job == "SiegeMinion")
        {
            job = new SiegeMinion();
            Skills.Add(new Tackle());
            Skills.Add(new CannonBlaster());
            Skills.Add(new CannonBarrage());
            Name = "대포미니언";
            MaxHealth = 15 + job.AdditionalHp;
            Health = MaxHealth;
            MaxMp = 20 + job.AdditionalMp;
            Mp = MaxMp;
            Damage = 1 + job.AdditionalATK;
            Defense = 1 + job.AdditionalDEF;
            level = _level;
            Gold = 0;
            IsDead = false;
            CriticalPer = 15f + job.AdditionalCriticalPer;
            AvoidanceRate = 10f + job.AdditionalAvoidanceRate;
        }
        else if (_job == "Voidling")
        {
            job = new Voidling();
            Skills.Add(new Tackle());
            Skills.Add(new Scratch());
            Skills.Add(new FurySwipes());
            Name = "공허충";
            MaxHealth = 15 + job.AdditionalHp;
            Health = MaxHealth;
            MaxMp = 20 + job.AdditionalMp;
            Mp = MaxMp;
            Damage = 1 + job.AdditionalATK;
            Defense = 1 + job.AdditionalDEF;
            level = _level;
            Gold = 0;
            IsDead = false;
            CriticalPer = 15f + job.AdditionalCriticalPer;
            AvoidanceRate = 10f + job.AdditionalAvoidanceRate;
        }
        else
        {
            job = new Minion();
            Skills.Add(new Tackle());
            Name = "미니언";
            MaxHealth = 15 + job.AdditionalHp;
            Health = MaxHealth;
            MaxMp = 20 + job.AdditionalMp;
            Mp = MaxMp;
            Damage = 1 + job.AdditionalATK;
            Defense = 1 + job.AdditionalDEF;
            level = _level;
            Gold = 0;
            IsDead = false;
            CriticalPer = 15f + job.AdditionalCriticalPer;
            AvoidanceRate = 10f + job.AdditionalAvoidanceRate;
        }
    }
    /// <summary>
    /// 설정된 직업 : "Minion", "SiegeMinion", 'Voidling" 단 잘못된 값을 입력시 자동으로 "Miniond"으로 설정됩니다.
    /// </summary>
    /// <param name="_job"></param>
    public Monster(string _job)
    {
        Skills = new List<Skill>();
        if (_job == "SiegeMinion")
        {
            job = new SiegeMinion();
            Skills.Add(new Tackle());
            Skills.Add(new CannonBlaster());
            Skills.Add(new CannonBarrage());
            Name = "대포미니언";
            MaxHealth = 15 + job.AdditionalHp;
            Health = MaxHealth;
            MaxMp = 20 + job.AdditionalMp;
            Mp = MaxMp;
            Damage = 1 + job.AdditionalATK;
            Defense = 1 + job.AdditionalDEF;
            level = 5;
            Gold = 0;
            IsDead = false;
            CriticalPer = 15f + job.AdditionalCriticalPer;
            AvoidanceRate = 10f + job.AdditionalAvoidanceRate;
        }
        else if (_job == "Voidling")
        {
            job = new Voidling();
            Skills.Add(new Tackle());
            Skills.Add(new Scratch());
            Skills.Add(new FurySwipes());
            Name = "공허충";
            MaxHealth = 15 + job.AdditionalHp;
            Health = MaxHealth;
            MaxMp = 20 + job.AdditionalMp;
            Mp = MaxMp;
            Damage = 1 + job.AdditionalATK;
            Defense = 1 + job.AdditionalDEF;
            level = 3;
            Gold = 0;
            IsDead = false;
            CriticalPer = 15f + job.AdditionalCriticalPer;
            AvoidanceRate = 10f + job.AdditionalAvoidanceRate;
        }
        else
        {
            job = new Minion();
            Skills.Add(new Tackle());
            Name = "미니언";
            MaxHealth = 15 + job.AdditionalHp;
            Health = MaxHealth;
            MaxMp = 20 + job.AdditionalMp;
            Mp = MaxMp;
            Damage = 1 + job.AdditionalATK;
            Defense = 1 + job.AdditionalDEF;
            level = 1;
            Gold = 0;
            IsDead = false;
            CriticalPer = 15f + job.AdditionalCriticalPer;
            AvoidanceRate = 10f + job.AdditionalAvoidanceRate;
        }
    }
    public bool TryGetExperience(out int result)
    {
        result = 0;
        if (IsDead)
        {
            result = level;
            return true;
        }
        return false;
    }

    private void SetStatByLevel(int level)
    {
        float correction = 1 + (float)level * (float)0.1;
        MaxHealth = (int)(MaxHealth * correction);
        Health = MaxHealth;
        MaxMp = (int)(MaxMp * correction);
        Mp = MaxMp;
        Damage = (int)(Damage * correction);
        Defense = (int)(Defense * correction);
    }
}