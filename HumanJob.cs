public class Warrior : Job
{
    public string Name { get; set; }
    public int AdditionalHp { get; set; }
    public int AdditionalATK { get; set; }
    public int AdditionalDEF { get; set; }
    public int AdditionalMp { get; set; }
    public float AdditionalCriticalPer { get; set; }
    public float AdditionalAvoidanceRate { get; set; }

    public Warrior()
    {
        Name = "Warrior";
        AdditionalHp = 50;
        AdditionalATK = 10;
        AdditionalDEF = 5;
        AdditionalMp = 0;
        AdditionalCriticalPer = 0;
        AdditionalAvoidanceRate = 0;
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
    public Wizard()
    {
        Name = "Wizard";
        AdditionalHp = 0;
        AdditionalATK = 15;
        AdditionalDEF = 0;
        AdditionalMp = 50;
        AdditionalCriticalPer = 5;
        AdditionalAvoidanceRate = 0;
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
    public Thief()
    {
        Name = "Thief";
        AdditionalHp = 10;
        AdditionalATK = 5;
        AdditionalDEF = 0;
        AdditionalMp = 15;
        AdditionalCriticalPer = 5;
        AdditionalAvoidanceRate = 10;
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
    public Archer()
    {
        Name = "Archer";
        AdditionalHp = 0;
        AdditionalATK = 10;
        AdditionalDEF = 0;
        AdditionalMp = 10;
        AdditionalCriticalPer = 15;
        AdditionalAvoidanceRate = 0;
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
    public Deprived()
    {
        Name = "Deprived";
        AdditionalHp = 0;
        AdditionalATK = 0;
        AdditionalDEF = 0;
        AdditionalMp = 0;
        AdditionalCriticalPer = 0;
        AdditionalAvoidanceRate = 0;
    }
}