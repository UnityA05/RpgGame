public class Minion : Job
{
    public string Name { get; set; }
    public int AdditionalHp { get; set; }
    public int AdditionalATK { get; set; }
    public int AdditionalDEF { get; set; }
    public int AdditionalMp { get; set; }
    public float AdditionalCriticalPer { get; set; }
    public float AdditionalAvoidanceRate { get; set; }
    public int HpPerLevel { get; set; }
    public int ATKPerLevel { get; set; }
    public int DEFPerLevel { get; set; }
    public int MpPerLevel { get; set; }
    public float CriticalPerLevel { get; set; }
    public float AvoidanceRatePerLevel { get; set; }
    public Minion()
    {
        Name = "Minion";
        AdditionalHp = 0;
        AdditionalATK = 0;
        AdditionalDEF = 0;
        AdditionalMp = 0;
        AdditionalCriticalPer = 0;
        AdditionalAvoidanceRate = 0;
    }
}

public class SiegeMinion : Job
{
    public string Name { get; set; }
    public int AdditionalHp { get; set; }
    public int AdditionalATK { get; set; }
    public int AdditionalDEF { get; set; }
    public int AdditionalMp { get; set; }
    public float AdditionalCriticalPer { get; set; }
    public float AdditionalAvoidanceRate { get; set; }
    public int HpPerLevel { get; set; }
    public int ATKPerLevel { get; set; }
    public int DEFPerLevel { get; set; }
    public int MpPerLevel { get; set; }
    public float CriticalPerLevel { get; set; }
    public float AvoidanceRatePerLevel { get; set; }
    public SiegeMinion()
    {
        Name = "SiegeMinion";
        AdditionalHp = 50;
        AdditionalATK = 5;
        AdditionalDEF = 10;
        AdditionalMp = 30;
        AdditionalCriticalPer = 0;
        AdditionalAvoidanceRate = 0;
    }
}
public class Voidling : Job
{
    public string Name { get; set; }
    public int AdditionalHp { get; set; }
    public int AdditionalATK { get; set; }
    public int AdditionalDEF { get; set; }
    public int AdditionalMp { get; set; }
    public float AdditionalCriticalPer { get; set; }
    public float AdditionalAvoidanceRate { get; set; }
    public int HpPerLevel { get; set; }
    public int ATKPerLevel { get; set; }
    public int DEFPerLevel { get; set; }
    public int MpPerLevel { get; set; }
    public float CriticalPerLevel { get; set; }
    public float AvoidanceRatePerLevel { get; set; }
    public Voidling()
    {
        Name = "Voidling";
        AdditionalHp = 10;
        AdditionalATK = 10;
        AdditionalDEF = 0;
        AdditionalMp = 10;
        AdditionalCriticalPer = 5;
        AdditionalAvoidanceRate = 5;
    }
}