public class Shop
{
    public List<Item> shopList = new List<Item>();
    public void DisplayShop()
    {
        Console.Clear();
        Console.WriteLine("상점");
        Console.WriteLine();
        Console.WriteLine("[보유 골드]");
        // ConsoleUI.Write(ConsoleColor.DarkRed, player.Gold);
        Console.WriteLine("G");

        
    }
    public void ShopBuy()
    {
        Console.WriteLine("아이템 구매");
        Console.WriteLine("[보유 골드]");
        // ConsoleUI.Write(ConsoleColor.DarkRed, player.Gold);
        Console.WriteLine("G");


    }
    public void ShopSell()
    {
        Console.Clear();
        Console.WriteLine("아이템 판매");
        Console.WriteLine();
        // ConsoleUI.Write(ConsoleColor.DarkRed, player.Gold);
        Console.WriteLine("G");
        

    }
}