public interface Skill
{
    string Name { get; set; }
    /// <summary>
    /// 스킬의 대미지 배율을 표시합니다.
    /// 1.2f 또는 2f등등
    /// </summary>
    float DamageScale { get; set; }
    int MpConsumption { get; set; }
    int TargetCount { get; set; }
    string Explanation { get; set; }
    int AttackCount { get; set; }
    float RecoveryScale { get; set; }
}