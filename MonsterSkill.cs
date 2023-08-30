public class Tackle : Skill
{
    public string Name { get; set; }
    /// <summary>
    /// 스킬의 대미지 배율을 표시합니다.
    /// 1.2f 또는 2f등등
    /// </summary>
    public float DamageScale { get; set; }
    public int MpConsumption { get; set; }
    public int TargetCount { get; set; }
    public string Explanation { get; set; }
    public int AttackCount { get; set; }
    public float RecoveryScale { get; set; }
    public Tackle()
    {
        Name = "몸통박치기";
        DamageScale = 1.5f;
        MpConsumption = 10;
        TargetCount = 1;
        AttackCount = 1;
        RecoveryScale = 0;
        Explanation = string.Format("공격력 * {0} 로 {1}의 적을 {2}회 공격합니다.", DamageScale, TargetCount, AttackCount);
    }
}
public class Scratch : Skill
{
    public string Name { get; set; }
    /// <summary>
    /// 스킬의 대미지 배율을 표시합니다.
    /// 1.2f 또는 2f등등
    /// </summary>
    public float DamageScale { get; set; }
    public int MpConsumption { get; set; }
    public int TargetCount { get; set; }
    public string Explanation { get; set; }
    public int AttackCount { get; set; }
    public float RecoveryScale { get; set; }
    public Scratch()
    {
        Name = "할퀴기";
        DamageScale = 2f;
        MpConsumption = 15;
        TargetCount = 1;
        AttackCount = 1;
        RecoveryScale = 0;
        Explanation = string.Format("공격력 * {0} 로 {1}의 적을 {2}회 공격합니다.", DamageScale, TargetCount, AttackCount);
    }
}
public class FurySwipes : Skill
{
    public string Name { get; set; }
    /// <summary>
    /// 스킬의 대미지 배율을 표시합니다.
    /// 1.2f 또는 2f등등
    /// </summary>
    public float DamageScale { get; set; }
    public int MpConsumption { get; set; }
    public int TargetCount { get; set; }
    public string Explanation { get; set; }
    public int AttackCount { get; set; }
    public float RecoveryScale { get; set; }
    public FurySwipes()
    {
        Name = "마구할퀴기";
        DamageScale = 0.8f;
        MpConsumption = 20;
        TargetCount = 1;
        AttackCount = 3;
        RecoveryScale = 0;
        Explanation = string.Format("공격력 * {0} 로 {1}의 적을 {2}회 공격합니다.", DamageScale, TargetCount, AttackCount);
    }
}
public class CannonBlaster : Skill
{
    public string Name { get; set; }
    /// <summary>
    /// 스킬의 대미지 배율을 표시합니다.
    /// 1.2f 또는 2f등등
    /// </summary>
    public float DamageScale { get; set; }
    public int MpConsumption { get; set; }
    public int TargetCount { get; set; }
    public string Explanation { get; set; }
    public int AttackCount { get; set; }
    public float RecoveryScale { get; set; }
    public CannonBlaster()
    {
        Name = "캐논 스플래셔";
        DamageScale = 2.2f;
        MpConsumption = 20;
        TargetCount = 1;
        AttackCount = 1;
        RecoveryScale = 0;
        Explanation = string.Format("공격력 * {0} 로 {1}의 적을 {2}회 공격합니다.", DamageScale, TargetCount, AttackCount);
    }
}
public class CannonBarrage : Skill
{
    public string Name { get; set; }
    /// <summary>
    /// 스킬의 대미지 배율을 표시합니다.
    /// 1.2f 또는 2f등등
    /// </summary>
    public float DamageScale { get; set; }
    public int MpConsumption { get; set; }
    public int TargetCount { get; set; }
    public string Explanation { get; set; }
    public int AttackCount { get; set; }
    public float RecoveryScale { get; set; }
    public CannonBarrage()
    {
        Name = "캐논 버스터";
        DamageScale = 1.2f;
        MpConsumption = 30;
        TargetCount = 1;
        AttackCount = 3;
        RecoveryScale = 0;
        Explanation = string.Format("공격력 * {0} 로 {1}의 적을 {2}회 공격합니다.", DamageScale, TargetCount, AttackCount);
    }
}