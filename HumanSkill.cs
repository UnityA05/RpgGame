/// <summary>
/// 알파 스트라이크 아무값을 설정안하면 기본값으로 설정됩니다
/// 설명을 입력하면 이름, 배율, 마나, 타겟수는 기본값으로 설정되고 설명이 입력값 (string) 으로 설정됩니다.
/// </summary>
public class AlphaStrike : Skill
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
    public AlphaStrike()
    {
        Name = "알파 스트라이크";
        DamageScale = 2f;
        MpConsumption = 10;
        TargetCount = 1;
        AttackCount = 1;
        RecoveryScale = 0;
        Explanation = string.Format("공격력 * {0} 로 {1}의 적을 {2}회 공격합니다.", DamageScale, TargetCount, AttackCount);
    }
    public AlphaStrike(string explanation)
    {
        Name = "알파 스트라이크";
        DamageScale = 2f;
        MpConsumption = 10;
        TargetCount = 1;
        AttackCount = 1;
        RecoveryScale = 0;
        Explanation = explanation;
    }
}
public class DoubleStrike : Skill
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
    public DoubleStrike()
    {
        Name = "더블 스트라이크";
        DamageScale = 1.5f;
        MpConsumption = 15;
        TargetCount = 2;
        AttackCount = 1;
        RecoveryScale = 0;
        Explanation = string.Format("공격력 * {0} 로 {1}의 적을 랜덤으로 {2}회 공격합니다.", DamageScale, TargetCount, AttackCount);
    }
    public DoubleStrike(string explanation)
    {
        Name = "더블 스트라이크";
        DamageScale = 1.5f;
        MpConsumption = 15;
        TargetCount = 2;
        AttackCount = 1;
        RecoveryScale = 0;
        Explanation = explanation;
    }
}
public class Heal : Skill
{
    public string Name { get; set; }
    public float DamageScale { get; set; }
    public int MpConsumption { get; set; }
    public int TargetCount { get; set; }
    public string Explanation { get; set; }
    public int AttackCount { get; set; }
    /// <summary>
    /// 체력비율로 회복
    /// </summary>
    public float RecoveryScale { get; set; }
    /// <summary>
    /// 힐은 최대체력 비율로 회복합니다. 기본 비율 0.3배 => RecoveryScale =0.3f;
    /// </summary>
    public Heal()
    {
        Name = "힐";
        DamageScale = 0f;
        MpConsumption = 15;
        TargetCount = 1;
        AttackCount = 1;
        RecoveryScale = 0.3f;
        Explanation = string.Format("최대체력 * {0} 만큼 {1}회 회복합니다.", RecoveryScale, AttackCount);
    }
    public Heal(string explanation)
    {
        Name = "힐";
        DamageScale = 0f;
        MpConsumption = 15;
        TargetCount = 1;
        AttackCount = 1;
        RecoveryScale = 0.3f;
        Explanation = explanation;
    }

}
public class LuckySeven : Skill
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
    public LuckySeven()
    {
        Name = "럭키세븐";
        DamageScale = 1.2f;
        MpConsumption = 15;
        TargetCount = 1;
        AttackCount = 2;
        RecoveryScale = 0;
        Explanation = string.Format("공격력 * {0} 로 {1}의 적을 {2}회 공격합니다.", DamageScale, TargetCount, AttackCount);
    }
    public LuckySeven(string explanation)
    {
        Name = "럭키세븐";
        DamageScale = 1.2f;
        MpConsumption = 15;
        TargetCount = 1;
        AttackCount = 2;
        RecoveryScale = 0;
        Explanation = explanation;
    }
}
public class doubleShot : Skill
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
    public doubleShot()
    {
        Name = "더블샷";
        DamageScale = 1.2f;
        MpConsumption = 15;
        TargetCount = 1;
        AttackCount = 2;
        RecoveryScale = 0;
        Explanation = string.Format("공격력 * {0} 로 {1}의 적을 {2}회 공격합니다.", DamageScale, TargetCount, AttackCount);
    }
    public doubleShot(string explanation)
    {
        Name = "더블샷";
        DamageScale = 1.2f;
        MpConsumption = 15;
        TargetCount = 1;
        AttackCount = 2;
        RecoveryScale = 0;
        Explanation = explanation;
    }
}
public class EnergyBolthot : Skill
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
    public EnergyBolthot()
    {
        Name = "에너지 볼트";
        DamageScale = 1.5f;
        MpConsumption = 20;
        TargetCount = 3;
        AttackCount = 1;
        RecoveryScale = 0;
        Explanation = string.Format("공격력 * {0} 로 {1}의 적을 {2}회 공격합니다.", DamageScale, TargetCount, AttackCount);
    }
    public EnergyBolthot(string explanation)
    {
        Name = "에너지 볼트";
        DamageScale = 1.5f;
        MpConsumption = 20;
        TargetCount = 3;
        AttackCount = 1;
        RecoveryScale = 0;
        Explanation = explanation;
    }
}