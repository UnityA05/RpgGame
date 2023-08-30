using SprtaGame;
using System.Numerics;

public class Shop
{
    private static List<Item> shopList { get; set; } = new List<Item>();

    public Shop()
    {
        shopList.Add(Program.itemMake.chainVest);
        shopList.Add(Program.itemMake.brambleVest);

        shopList.Add(Program.itemMake.dagger);
        shopList.Add(Program.itemMake.bfSword);

        shopList.Add(Program.itemMake.HealthPotion);
        shopList.Add(Program.itemMake.corruptingPotion);

        shopList.Add(Program.itemMake.sapphireCrystal);
        shopList.Add(Program.itemMake.rubyCrystall);
        shopList.Add(Program.itemMake.hexteckAlternator);
    }

    public void DisplayShop()
    {
        Console.Clear();
        Console.WriteLine("상점");
        Console.WriteLine();
        Console.WriteLine("[보유 골드]");
        ConsoleUI.Write(ConsoleColor.DarkRed, Convert.ToString(Program.defaultPlayer.Gold));
        Console.WriteLine("G");

        Console.WriteLine();
        ConsoleUI.Write(ConsoleColor.DarkRed, "0");
        Console.WriteLine(". 나가기");
        ConsoleUI.Write(ConsoleColor.DarkRed, "1");
        Console.WriteLine(". 아이템 구매");
        ConsoleUI.Write(ConsoleColor.DarkRed, "2");
        Console.WriteLine(". 아이템 판매");
        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        ConsoleUI.Write(ConsoleColor.Yellow, ">> ");

        var currentCursor = Console.GetCursorPosition();
        int inputNumber = 0;
        bool isWrongInput = true;

        while (isWrongInput)
        {
            if (int.TryParse(Console.ReadLine(), out inputNumber) == true)
            {
                if (inputNumber == 0 || inputNumber == 1 || inputNumber == 2)
                    break;
            }
            Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
            ConsoleUI.Write(ConsoleColor.Red, "잘못된 입력입니다.");
            Thread.Sleep(1000);
            Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
            Console.Write("                    ");
            Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
        }

        switch (inputNumber)
        {
            case 0:
                break;
            case 1:
                DisplayShopBuy();
                break;
            case 2:
                DisplayShopSell();
                break;
        }
    }

    public void DisplayShopBuy()
    {
        Console.Clear();
        Console.WriteLine("아이템 구매");
        Console.WriteLine("[보유 골드]");
        ConsoleUI.Write(ConsoleColor.DarkRed, Convert.ToString(Program.defaultPlayer.Gold));
        Console.WriteLine("G");
        Console.WriteLine();
        Console.WriteLine("아이템 목록");
        
        PrintList(shopList);
        Console.WriteLine();

        ConsoleUI.Write(ConsoleColor.DarkRed, "0");
        Console.WriteLine(". 나가기");
        ConsoleUI.Write(ConsoleColor.DarkRed,"1~");
        Console.WriteLine(". 아이템 구매");

        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        ConsoleUI.Write(ConsoleColor.Yellow, ">> ");

        var currentCursor = Console.GetCursorPosition();
        int inputNumber = 0;
        bool isWrongInput = true;


        while (isWrongInput)
        {
            if (int.TryParse(Console.ReadLine(), out inputNumber) == true)
            {
                if (inputNumber >=0 && inputNumber <= shopList.Count())
                    break;
            }
            Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
            ConsoleUI.Write(ConsoleColor.Red, "잘못된 입력입니다.");
            Thread.Sleep(1000);
            Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
            Console.Write("                    ");
            Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
        }

        if(inputNumber == 0)
        {
            DisplayShop();
        }
        else
        {
            if(Program.defaultPlayer.Gold < shopList[inputNumber-1].item_Gold)
            {
                Console.WriteLine("소지하신 골드가 적습니다.");
                Thread.Sleep(1000);
                DisplayShopBuy();
            }
            else
            {
                if(Inventory.playerInven.Count() == 10)
                {
                    Console.WriteLine("인벤토리 창이 가득 찼습니다.");
                    Console.WriteLine("인벤토리를 비우고 다시 구매해주세요.");
                    Thread.Sleep(1000);
                    DisplayShopBuy();
                }
                else
                {
                    Console.WriteLine("구매를 완료했습니다.");
                    Program.defaultPlayer.Gold -= shopList[inputNumber - 1].item_Gold;
                    Inventory.InvenAdd(shopList[inputNumber - 1]);
                    shopList.Remove(shopList[inputNumber - 1]);
                    Thread.Sleep(1000);
                    DisplayShopBuy();
                }
            }
        }
    }
    public void DisplayShopSell()
    {
        Console.Clear();
        Console.WriteLine("아이템 판매");
        Console.WriteLine();
        ConsoleUI.Write(ConsoleColor.DarkRed, Convert.ToString(Program.defaultPlayer.Gold));
        Console.WriteLine("G");

        PrintList(Inventory.playerInven);

        Console.WriteLine();
        ConsoleUI.Write(ConsoleColor.DarkRed, "0");
        Console.WriteLine(". 나가기");
        ConsoleUI.Write(ConsoleColor.DarkRed, "1~");
        Console.WriteLine(". 판매");

        Console.WriteLine();
        Console.WriteLine("원하시는 행동을 입력해주세요.");
        ConsoleUI.Write(ConsoleColor.Yellow, ">> ");

        var currentCursor = Console.GetCursorPosition();
        int inputNumber = 0;
        bool isWrongInput = true;

        while (isWrongInput)
        {
            if (int.TryParse(Console.ReadLine(), out inputNumber) == true)
            {
                if (inputNumber >= 0 && inputNumber <= Inventory.playerInven.Count())
                    break;
            }
            Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
            ConsoleUI.Write(ConsoleColor.Red, "잘못된 입력입니다.");
            Thread.Sleep(1000);
            Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
            Console.Write("                    ");
            Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
        }

        if(inputNumber == 0)
        {
            DisplayShop();
        }
        else
        {
            if (Inventory.playerInven[inputNumber - 1].item_Name.Contains("[E]"))
            {
                Console.WriteLine("장착 중인 아이템입니다.");
                Thread.Sleep(1000);
                DisplayShopSell();
            }
            else
            {
                Console.WriteLine("판매가 완료되었습니다.");
                Program.defaultPlayer.Gold += Inventory.playerInven[inputNumber - 1].item_Gold;
                shopList.Add(Inventory.playerInven[inputNumber - 1]);
                Inventory.playerInven.Remove(Inventory.playerInven[inputNumber - 1]);
                Thread.Sleep(1000);
                DisplayShopSell();
            }
        }
    }
    public void PrintList(List<Item> itemList)
    {
        int currentIndex = 0;

        while (currentIndex < itemList.Count())
        {
            //출력 칸 정렬
            string InvenStr_Gold = "          |";
            string InvenStr_Name = "            |";
            string InvenStr_Effect = "                    |";
            string InvenStr_Explain = "                                                  |";

            string Replace_Name = string.Empty;
            string Replace_Effect = string.Empty;
            string Replace_Gold = string.Empty;
            string Replace_Explain = string.Empty;

            //삽입될 만큼 정렬 문자열에서 빈칸 지우기
            int nameLength = itemList[currentIndex].item_Name.Count();
            Replace_Name = InvenStr_Name.Remove(0, nameLength)
                                        .Insert(0, itemList[currentIndex].item_Name);

            if (itemList[currentIndex].GetType() == typeof(Item.Potion)) //물약이라면
            {
                if (itemList[currentIndex].item_Mp > 0)
                {
                    //부패 물약
                    int effectLength = HowManyDigit(itemList[currentIndex].item_Health) + HowManyDigit(itemList[currentIndex].item_Mp) + 8;
                    Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, "체력 +" + Convert.ToString(itemList[currentIndex].item_Health) + "마력 +" + Convert.ToString(itemList[currentIndex].item_Mp));
                }
                else
                {
                    //회복 물약
                    int effectLength = HowManyDigit(itemList[currentIndex].item_Health) + 6;    // + 6은 문자열 "체력회복 +"
                    Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, "체력회복 +" + Convert.ToString(itemList[currentIndex].item_Health));
                }
            }
            else if(itemList[currentIndex].GetType() == typeof(Item.Accessories))   //악세서리라면
            {
                if (itemList[currentIndex].item_Health > 0)
                {
                    int effectLength = HowManyDigit(itemList[currentIndex].item_Health) + 4;    // + 6은 문자열 "체력회복 +"
                    Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, "체력 +" + Convert.ToString(itemList[currentIndex].item_Health));
                }
                else if (itemList[currentIndex].item_Mp > 0)
                {
                    int effectLength = HowManyDigit(itemList[currentIndex].item_Mp) + 4;    // + 6은 문자열 "체력회복 +"
                    Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, "마력 +" + Convert.ToString(itemList[currentIndex].item_Mp));
                }
                else
                {
                    int effectLength = HowManyDigit(itemList[currentIndex].item_Health) + HowManyDigit(itemList[currentIndex].item_CriticalPer) + 4 + 6;    // + 6은 문자열 "체력회복 +"
                    Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, "체력 +" + Convert.ToString(itemList[currentIndex].item_Health) + "크리티컬 +" + Convert.ToString(itemList[currentIndex].item_CriticalPer));
                }
            }
            else    //장비라면
            {
                if (itemList[currentIndex].GetType() == typeof(Item.Armor))
                {
                    //armor
                    if (itemList[currentIndex].item_CriticalPer > 0)
                    {
                        int effectLength = HowManyDigit(itemList[currentIndex].item_Defense) + HowManyDigit(itemList[currentIndex].item_CriticalPer) + 6 + 7;
                        Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, " 방어력 +" + Convert.ToString(itemList[currentIndex].item_Defense + " 치명타율 +" + Convert.ToString(itemList[currentIndex].item_CriticalPer)));
                    }
                    else
                    {
                        int effectLength = HowManyDigit(itemList[currentIndex].item_Defense) + 6;
                        Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                        .Insert(0, " 방어력 +" + Convert.ToString(itemList[currentIndex].item_Defense));
                    }
                }
                else
                {
                    //weapon
                    if (itemList[currentIndex].item_AvoidanceRate > 0)
                    {
                        int effectLength = HowManyDigit(itemList[currentIndex].item_Damage) + HowManyDigit(itemList[currentIndex].item_AvoidanceRate) + 6 + 5;
                        Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                        .Insert(0, " 공격력 +" + Convert.ToString(itemList[currentIndex].item_Damage) + " 회피 +" + Convert.ToString(itemList[currentIndex].item_AvoidanceRate));
                    }
                    else
                    {
                        int effectLength = HowManyDigit(itemList[currentIndex].item_Damage) + 6;
                        Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                        .Insert(0, " 공격력 +" + Convert.ToString(itemList[currentIndex].item_Damage));
                    }
                }
            }

            int goldLength = HowManyDigit(itemList[currentIndex].item_Gold) + 6;
            Replace_Gold = InvenStr_Gold.Remove(0, goldLength)
                                        .Insert(0, "가격 : " + Convert.ToString(itemList[currentIndex].item_Gold) + "G");

            int explainLength = itemList[currentIndex].item_Discription.Length;
            Replace_Explain = InvenStr_Explain.Remove(0, explainLength)
                                              .Insert(0, itemList[currentIndex].item_Discription);

            ConsoleUI.Write(ConsoleColor.DarkRed, Convert.ToString(currentIndex + 1));
            Console.Write("- ");
            Console.Write(Replace_Name);
            Console.Write(Replace_Effect);
            Console.Write(Replace_Gold);
            Console.Write(Replace_Explain);
            Console.WriteLine();
            currentIndex++;
        }
        static int HowManyDigit(int j)
        {
            int i = 0;
            while (true)
            {
                j /= 10;
                if (j <= 0)
                {
                    return (i + 1);
                }
                i++;
            }
        }
    }
}