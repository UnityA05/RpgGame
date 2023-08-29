public class Item
{
    public string item_Name { get; set; }
    public int item_Atk { get; set; }
    public int item_Def { get; set; }
    public int item_Gold { get; set; }
    public string item_Discription { get; set; }

    public Item(string _item_name, int _item_atk, int _item_def, int _item_Gold, string _item_discription)
    {
        item_Name = _item_name;
        item_Atk = _item_atk;
        item_Def = _item_def;
        item_Gold = _item_Gold;
        item_Discription = _item_discription;
    }
}