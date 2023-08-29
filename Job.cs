public interface Job
{
    string Name { get; set; }
    int AdditionalHp { get; set; }
    int AdditionalATK { get; set; }
    int AdditionalDEF { get; set; }
    int AdditionalMp { get; set; }
    float AdditionalCriticalPer { get; set; }
    float AdditionalAvoidanceRate { get; set; }
}