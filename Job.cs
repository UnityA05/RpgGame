public interface Job
{
    string Name { get; set; }
    int AdditionalHp { get; set; }
    int AdditionalATK { get; set; }
    int AdditionalDEF { get; set; }
    int AdditionalMp { get; set; }
    float AdditionalCriticalPer { get; set; }
    float AdditionalAvoidanceRate { get; set; }
    int HpPerLevel { get; set; }
    int ATKPerLevel { get; set; }
    int DEFPerLevel { get; set; }
    int MpPerLevel { get; set; }
    float CriticalPerLevel { get; set; }
    float AvoidanceRatePerLevel { get; set; }
}