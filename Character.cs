public interface Character // 캐릭터 인터페이스
{
    string Name { get; set; }
    int Health { get; set; }
    int Damage { get; set; }
    int Defense { get; set; }
    Job job {get; set;}
    int level{get; set;}
    int Gold { get; set; }
    int Mp { get; set; } 
    bool IsDead { get; set; }
    float CriticalPer { get; set; }
    float AvoidanceRate { get; set; }

}