public class Warrior : Job
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

    public Warrior()
    {
        Name = "전사";
        AdditionalHp = 50;
        AdditionalATK = 10;
        AdditionalDEF = 5;
        AdditionalMp = 0;
        AdditionalCriticalPer = 0;
        AdditionalAvoidanceRate = 0;
        HpPerLevel = 10;
        ATKPerLevel = 2;
        DEFPerLevel = 1;
        MpPerLevel = 1;
        CriticalPerLevel = 0;
        AvoidanceRatePerLevel = 0;
}
}

public class Wizard : Job
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
    public Wizard()
    {
        Name = "법사";
        AdditionalHp = 0;
        AdditionalATK = 15;
        AdditionalDEF = 0;
        AdditionalMp = 50;
        AdditionalCriticalPer = 5;
        AdditionalAvoidanceRate = 0;
        HpPerLevel = 0;
        ATKPerLevel = 5;
        DEFPerLevel = 0;
        MpPerLevel = 10;
        CriticalPerLevel = 1;
        AvoidanceRatePerLevel = 0;
    }
}
public class Thief : Job
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
    public Thief()
    {
        Name = "도적";
        AdditionalHp = 10;
        AdditionalATK = 5;
        AdditionalDEF = 0;
        AdditionalMp = 15;
        AdditionalCriticalPer = 5;
        AdditionalAvoidanceRate = 10;
        HpPerLevel = 0;
        ATKPerLevel = 1;
        DEFPerLevel = 0;
        MpPerLevel = 2;
        CriticalPerLevel = 1;
        AvoidanceRatePerLevel = 1;
    }
}

public class Archer : Job
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
    public Archer()
    {
        Name = "궁수";
        AdditionalHp = 0;
        AdditionalATK = 10;
        AdditionalDEF = 0;
        AdditionalMp = 10;
        AdditionalCriticalPer = 15;
        AdditionalAvoidanceRate = 0;
        HpPerLevel = 0;
        ATKPerLevel = 1;
        DEFPerLevel = 0;
        MpPerLevel = 2;
        CriticalPerLevel = 2;
        AvoidanceRatePerLevel = 0;
    }
}
public class Deprived : Job
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
    public Deprived()
    {
        Name = "Deprived";
        AdditionalHp = 0;
        AdditionalATK = 0;
        AdditionalDEF = 0;
        AdditionalMp = 0;
        AdditionalCriticalPer = 0;
        AdditionalAvoidanceRate = 0;
        HpPerLevel = 0;
        ATKPerLevel = 0;
        DEFPerLevel = 0;
        MpPerLevel = 0;
        CriticalPerLevel = 0;
        AvoidanceRatePerLevel = 0;
    }
}