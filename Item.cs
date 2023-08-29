public class Item
{

    public string   item_Name { get; set; }
    public int      item_Health { get; set; }
    public int      item_Damage { get; set; }
    public int      item_Defense { get; set; }
    public int      item_Gold { get; set; }
    public string   item_Discription { get; set; }

    public Item(string _item_name, int _item_damage, int _item_defense, int _item_Gold, string _item_discription)
    {
        //장비템
        item_Name = _item_name;
        item_Damage = _item_damage;
        item_Defense = _item_defense;
        item_Gold = _item_Gold;
        item_Discription = _item_discription;
    }

    public Item(string _item_name, int _item_damage, int _item_defense, int _item_Gold, int _item_health, string _item_discription)
    {
        //물약류
        item_Name = _item_name;
        item_Health = _item_health;
        item_Damage = _item_damage;
        item_Defense = _item_defense;
        item_Gold = _item_Gold;
        item_Discription = _item_discription;
    }
}