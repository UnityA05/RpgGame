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
    public Monster(string name, int health, int damage, int defense, string _job, int _level, int gold, int mp, float criticalPer, float avoidanceRate)
    {
        
        if(_job == "SiegeMinion")
            job = new SiegeMinion();
        else if(_job == "Voidling")
            job = new Voidling();
        else
            job = new Minion();
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
    public Monster()
    {
        job = new Minion();
        Name = "미니언";
        Health = 15;
        Damage = 1;
        Defense = 1;
        level = 2;
        Gold = 0;
        Mp = 0;
        IsDead = false;
        CriticalPer = 15f;
        AvoidanceRate = 10f;
    }
    public Monster(string _job, int _level)
    {
        if (_job == "SiegeMinion")
        {
            job = new SiegeMinion();
            Name = "대포미니언";
            Health = 15 + job.AdditionalHp;
            Damage = 1 + job.AdditionalATK;
            Defense = 1 + job.AdditionalDEF;
            level = _level;
            Gold = 0;
            Mp = 0 + job.AdditionalMp;
            IsDead = false;
            CriticalPer = 15f + job.AdditionalCriticalPer;
            AvoidanceRate = 10f + job.AdditionalAvoidanceRate;
        }
        else if (_job == "Voidling")
        {
            job = new Voidling();
            Name = "공허충";
            Health = 15 + job.AdditionalHp;
            Damage = 1 + job.AdditionalATK;
            Defense = 1 + job.AdditionalDEF;
            level = _level;
            Gold = 0;
            Mp = 0 + job.AdditionalMp;
            IsDead = false;
            CriticalPer = 15f + job.AdditionalCriticalPer;
            AvoidanceRate = 10f + job.AdditionalAvoidanceRate;
        }
        else
        {
            job = new Minion();
            Name = "미니언";
            Health = 15 + job.AdditionalHp;
            Damage = 1 + job.AdditionalATK;
            Defense = 1 + job.AdditionalDEF;
            level = _level;
            Gold = 0;
            Mp = 0 + job.AdditionalMp;
            IsDead = false;
            CriticalPer = 15f + job.AdditionalCriticalPer;
            AvoidanceRate = 10f + job.AdditionalAvoidanceRate;
        }
    }
    public Monster(string _job)
    {
        if (_job == "SiegeMinion")
        {
            job = new SiegeMinion();
            Name = "대포미니언";
            Health = 15 + job.AdditionalHp;
            Damage = 1 + job.AdditionalATK;
            Defense = 1 + job.AdditionalDEF;
            level = 5;
            Gold = 0;
            Mp = 0 + job.AdditionalMp;
            IsDead = false;
            CriticalPer = 15f + job.AdditionalCriticalPer;
            AvoidanceRate = 10f + job.AdditionalAvoidanceRate;
        }
        else if (_job == "Voidling")
        {
            job = new Voidling();
            Name = "공허충";
            Health = 15 + job.AdditionalHp;
            Damage = 1 + job.AdditionalATK;
            Defense = 1 + job.AdditionalDEF;
            level = 3;
            Gold = 0;
            Mp = 0 + job.AdditionalMp;
            IsDead = false;
            CriticalPer = 15f + job.AdditionalCriticalPer;
            AvoidanceRate = 10f + job.AdditionalAvoidanceRate;
        }
        else
        {
            job = new Minion();
            Name = "미니언";
            Health = 15 + job.AdditionalHp;
            Damage = 1 + job.AdditionalATK;
            Defense = 1 + job.AdditionalDEF;
            level = 1;
            Gold = 0;
            Mp = 0 + job.AdditionalMp;
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
}