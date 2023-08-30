using SprtaGame;
using System.Numerics;

public class Shop
{
    private static List<Item> shopList { get; set; } = new List<Item>();
    static Player player = Program.defaultPlayer; 

    public Shop()
    {
        //어디로 옮기지? 이게 구동이 가능한건가?
        Item rapier = new Item("레이피어", 4, 0, 900, "찌르기에 특화된 사정거리가 길고 폭이 좁은 한손검.");
        Item ScaleArmor = new Item("미늘갑옷", 0, 8, 900, "쇠나 뼈 따위로 만든 미늘조각을 끈으로 연결해 만든 갑옷.");

        Item.Potion lowHpPotion = new Item.Potion("하급 체력 포션", 0, 0, 400,  30, "초보 모험자들이 애용하는 물약.");
        Item.Potion lowAtkPotion = new Item.Potion("하급 힘 포션", 2, 0, 300, 0, "몬스터들을 재료로 고아낸 힘 물약.");
        Item.Potion lowDefPotion = new Item.Potion("하급 방어력 포션", 0, 2, 200,  0, "몬스터들의 갑각을 재료로 고아낸 물약.");

        shopList.Add(rapier);
        shopList.Add(ScaleArmor);
        shopList.Add(lowHpPotion);
        shopList.Add(lowAtkPotion);
        shopList.Add(lowDefPotion);
    }

    public void DisplayShop()
    {
        Console.Clear();
        Console.WriteLine("상점");
        Console.WriteLine();
        Console.WriteLine("[보유 골드]");
        ConsoleUI.Write(ConsoleColor.DarkRed, Convert.ToString(player.Gold));
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
                MainPage mainPage = new MainPage();
                mainPage.GameStart();
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
        ConsoleUI.Write(ConsoleColor.DarkRed, Convert.ToString(player.Gold));
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
            if(player.Gold < shopList[inputNumber-1].item_Gold)
            {
                Console.WriteLine("소지하신 골드가 적습니다.");
                DisplayShopBuy();
            }
            else
            {
                if(Inventory.playerInven.Count() == 10)
                {
                    Console.WriteLine("인벤토리 창이 가득 찼습니다.");
                    Console.WriteLine("인벤토리를 비우고 다시 구매해주세요.");
                }
                else
                {
                    Console.WriteLine("구매를 완료했습니다.");
                    player.Gold -= shopList[inputNumber - 1].item_Gold;
                    Inventory.InvenAdd(shopList[inputNumber - 1]);
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
        ConsoleUI.Write(ConsoleColor.DarkRed, Convert.ToString(player.Gold));
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
            player.Gold += Inventory.playerInven[inputNumber - 1].item_Gold;
            Inventory.playerInven.Remove(Inventory.playerInven[inputNumber - 1]);
            DisplayShopSell();
        }
    }
    public void PrintList(List<Item> itemList)
    {
        int currentIndex = 0;

        while (currentIndex < itemList.Count())
        {
            if (itemList[currentIndex].GetType() == typeof(Item.Potion)) //물약이라면
            {
                //출력 칸 정렬
                string InvenStr_Name    = "          |";
                string InvenStr_Effect  = "          |";
                string InvenStr_Gold    = "          |";
                string InvenStr_Explain = "                                                  |";

                string Replace_Name = string.Empty;
                string Replace_Effect = string.Empty;
                string Replace_Gold = string.Empty;
                string Replace_Explain = string.Empty;

                //삽입될 만큼 정렬 문자열에서 빈칸 지우기
                int nameLength = itemList[currentIndex].item_Name.Count();
                Replace_Name = InvenStr_Name.Remove(0, nameLength)
                                            .Insert(0, itemList[currentIndex].item_Name);

                if (itemList[currentIndex].item_Health > 0)
                {
                    //회복 물약

                    int effectLength = HowManyDigit(itemList[currentIndex].item_Health) + 6;    // + 6은 문자열 "체력회복 +"
                    Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, "체력회복 +" + Convert.ToString(itemList[currentIndex].item_Health));
                }
                else if (itemList[currentIndex].item_Damage == 0)
                {
                    //방어력 물약
                    int effectLength = HowManyDigit(itemList[currentIndex].item_Defense) + 6;
                    Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, " 방어력 +" + Convert.ToString(itemList[currentIndex].item_Defense));
                }
                else
                {
                    //공격력 물약
                    int effectLength = HowManyDigit(itemList[currentIndex].item_Damage) + 6;
                    Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, " 공격력 +" + Convert.ToString(itemList[currentIndex].item_Damage));
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
            else
            {
                string InvenStr_Name    = "          |";
                string InvenStr_Effect  = "          |";
                string InvenStr_Gold    = "          |";
                string InvenStr_Explain = "                                                  |";

                string Replace_Name = string.Empty;
                string Replace_Effect = string.Empty;
                string Replace_Gold = string.Empty;
                string Replace_Explain = string.Empty;

                int nameLength = itemList[currentIndex].item_Name.Count();
                Replace_Name = InvenStr_Name.Remove(0, nameLength)
                                            .Insert(0, itemList[currentIndex].item_Name);

                if (itemList[currentIndex].item_Damage == 0)
                {
                    //armor
                    int effectLength = HowManyDigit(itemList[currentIndex].item_Defense) + 6;
                    Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, " 방어력 +" + Convert.ToString(itemList[currentIndex].item_Defense));
                }
                else
                {
                    //weapon
                    int effectLength = HowManyDigit(itemList[currentIndex].item_Damage) + 6;
                    Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, " 공격력 +" + Convert.ToString(itemList[currentIndex].item_Damage));
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