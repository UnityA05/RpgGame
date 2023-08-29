using SprtaGame;
using System.Runtime.InteropServices.JavaScript;

public class Inventory
{
    public static List<Item> playerInven { get; set; } = new List<Item>(10);
    //아이템 리스트에서 장착중인 인덱스 번호들
    public static int exArmorNum = -1;
    public static int exWeaponNum = -1;
    static Player player = Program.defaultPlayer;
    public Inventory()
    {
        Item steelArmor = new Item("무쇠갑옷", 0, 5, 500, "무쇠로 만들어져 튼튼한 갑옷입니다.");
        Item leatherArmor = new Item("가죽갑옷", 0, 2, 200, "소가죽으로 만들어진 낡은 가죽갑옷.");

        Item oldSword = new Item("낡은 검", 2, 0, 800, "쉽게 볼 수 있는 낡은 검입니다.");
        Item gladius = new Item("글라디우스", 6, 0, 1000, "찌르기에 특화된 사정거리 짧은 한손검.");

        playerInven.Add(steelArmor);
        playerInven.Add(leatherArmor);
        playerInven.Add(oldSword);
        playerInven.Add(gladius);
    }
    public static void DisplayInven()
    {
        Console.Clear();
        Console.WriteLine("인벤토리");

        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");

        int invenLength = playerInven.Count();
        int currentIndex = 0;

        while(currentIndex < invenLength)
        {
            string InvenStr_Name = "          |";
            string InvenStr_Effect = "          |";
            string InvenStr_Explain = "                                                            |";
            string Replace_Name = string.Empty;
            string Replace_Effect = string.Empty;
            string Replace_Explain = string.Empty;

            int nameLength =  playerInven[currentIndex].item_Name.Count();
            Replace_Name = InvenStr_Name.Remove(0, nameLength)
                                        .Insert(0, playerInven[currentIndex].item_Name);

            if (playerInven[currentIndex].item_Damage == 0)
            {
                //armor
                int effectLength = HowManyDigit(playerInven[currentIndex].item_Defense) + 6;
                Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                .Insert(0, " 방어력 +" + Convert.ToString(playerInven[currentIndex].item_Defense));
            }
            else
            {
                //weapon
                int effectLength = HowManyDigit(playerInven[currentIndex].item_Damage) + 6;
                Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                .Insert(0, " 공격력 +" + Convert.ToString(playerInven[currentIndex].item_Damage));
            }
            int explainLength = playerInven[currentIndex].item_Discription.Length;
            Replace_Explain = InvenStr_Explain.Remove(0, explainLength)
                                              .Insert(0, playerInven[currentIndex].item_Discription);
            Console.Write("- ");
            Console.Write(Replace_Name);
            Console.Write(Replace_Effect);
            Console.Write(Replace_Explain);
            Console.WriteLine();
            currentIndex++;                         
        }
        Console.WriteLine();
        ConsoleUI.Write(ConsoleColor.DarkRed, "0");
        Console.WriteLine(". 나가기");
        ConsoleUI.Write(ConsoleColor.DarkRed, "1");
        Console.WriteLine(". 장착관리");
        ConsoleUI.Write(ConsoleColor.DarkRed, "2");
        Console.WriteLine(". 포션 사용");
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
                DisplayEquip();
                break;
            case 2:
                DisplayUse();
                break;
        }
    }
    public static void DisplayEquip()
    {
        Console.Clear();
        Console.WriteLine("인벤토리 - 장착관리");

        Console.WriteLine("아이템에 해당하는 숫자를 입력하시면 장착, 장착된 아이템의 숫자를 입력하시면 해제됩니다.");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");

        int currentIndex = 0;

        while (currentIndex < playerInven.Count())
        {
            if(playerInven[currentIndex].GetType() == typeof(Item.Potion))
            {
                currentIndex++;
                continue;
            }
            string InvenStr_Name = "          |";
            string InvenStr_Effect = "          |";
            string InvenStr_Explain = "                                                            |";
            string Replace_Name = string.Empty;
            string Replace_Effect = string.Empty;
            string Replace_Explain = string.Empty;

            int nameLength = playerInven[currentIndex].item_Name.Count();
            Replace_Name = InvenStr_Name.Remove(0, nameLength)
                                        .Insert(0, playerInven[currentIndex].item_Name);

            if (playerInven[currentIndex].item_Damage == 0)
            {
                //armor
                int effectLength = HowManyDigit(playerInven[currentIndex].item_Defense) + 6;
                Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                .Insert(0, " 방어력 +" + Convert.ToString(playerInven[currentIndex].item_Defense));
            }
            else
            {
                //weapon
                int effectLength = HowManyDigit(playerInven[currentIndex].item_Damage) + 6;
                Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                .Insert(0, " 공격력 +" + Convert.ToString(playerInven[currentIndex].item_Damage));
            }
            int explainLength = playerInven[currentIndex].item_Discription.Length;
            Replace_Explain = InvenStr_Explain.Remove(0, explainLength)
                                              .Insert(0, playerInven[currentIndex].item_Discription);

            ConsoleUI.Write(ConsoleColor.DarkRed, Convert.ToString(currentIndex + 1));
            Console.Write(" - ");
            Console.Write(Replace_Name);
            Console.Write(Replace_Effect);
            Console.Write(Replace_Explain);
            Console.WriteLine();
            currentIndex++;
        }
        Console.WriteLine();
        ConsoleUI.Write(ConsoleColor.DarkRed, "0");
        Console.WriteLine(". 나가기");
        ConsoleUI.Write(ConsoleColor.DarkRed, "1~");
        Console.WriteLine(". 장착/해제");
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
                if ((inputNumber >= 0)&&(inputNumber <= playerInven.Count()))
                {
                    if (inputNumber != 0 && playerInven[inputNumber - 1].GetType() == typeof(Item.Potion))
                    {

                    }
                    else
                        break;
                }
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
            DisplayInven();
        }
        else
        {
            Equip(inputNumber - 1);
            DisplayEquip();
        }
    }
    public static void DisplayUse()
    {
        Console.Clear();
        Console.WriteLine("인벤토리");

        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");

        //~~~

        Console.WriteLine();
        ConsoleUI.Write(ConsoleColor.DarkRed, "0");
        Console.WriteLine(". 나가기");
        ConsoleUI.Write(ConsoleColor.DarkRed, "1~");
        Console.WriteLine(". 장착/해제");
        Console.WriteLine();

        var currentCursor = Console.GetCursorPosition();
        int inputNumber = 0;
        bool isWrongInput = true;
        while (isWrongInput)
        {
            if (int.TryParse(Console.ReadLine(), out inputNumber) == true)
            {
                if (inputNumber == 0 || playerInven[inputNumber - 1].GetType() == typeof(Item.Potion))
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
            DisplayInven();
        }
        else
        {

        }
    }
    public static void InvenAdd(Item item)
    {
        playerInven.Add(item);
        
    }
    public void InvenUse(Item item)
    {
        if(item.item_Health > 0)
        {
            player.Health += 30;
            if(player.Health > 100)
            {
                player.Health = 100;
            }
        }
        else if(item.item_Damage > 0)
        {
            player.Damage += item.item_Damage;
        }
        else if(item.item_Defense > 0)
        {
            player.Defense += item.item_Defense;
        }
        playerInven.Remove(item);
    }
    public static void Equip(int i)
    {
        bool isEquiped = playerInven[i].item_Name.Contains("[E]");

        if (isEquiped == true)  //[E]가 붙은 아이템 선택(해제)
        {
            //[E] 제거
            playerInven[i].item_Name = playerInven[i].item_Name.Replace("[E]", "");

            if (playerInven[i].item_Damage == 0)    //갑옷 해제
            {
                player.Defense = player.Defense - playerInven[i].item_Defense;
                exArmorNum = -1;
            }
            else if (playerInven[i].item_Defense == 0)  //무기 해제
            {
                player.Damage = player.Damage - playerInven[i].item_Damage;
                exWeaponNum = -1;
            }
        }
        else
        {
            playerInven[i].item_Name = "[E]" + playerInven[i].item_Name;
            if (playerInven[i].item_Damage == 0)    //갑옷 장착
            {
                if(exArmorNum == -1)    //기존 장착한 장비가 없음.
                {
                    player.Defense += playerInven[i].item_Defense;
                    exArmorNum = i;
                }
                else                    //기존 장착한 장비가 있음.
                {
                    playerInven[exArmorNum].item_Name = playerInven[exArmorNum].item_Name.Replace("[E]", "");
                    player.Defense = player.Defense - playerInven[exArmorNum].item_Defense + playerInven[i].item_Defense;
                    exArmorNum = i;
                }
            }
            else if(playerInven[i].item_Defense == 0)   //무기 장착
            {
                if(exWeaponNum == -1)
                {
                    player.Damage += playerInven[i].item_Damage;
                    exWeaponNum = i;
                }
                else
                {
                    playerInven[exWeaponNum].item_Name = playerInven[exWeaponNum].item_Name.Replace("[E]", "");
                    player.Damage = player.Damage - playerInven[exWeaponNum].item_Damage + playerInven[i].item_Damage;
                    exWeaponNum = i;
                }
            }
        }
    }
    public static int HowManyDigit(int j)
    {
        int i = 0;
        while(true)
        {
            j /= 10;
            if(j <= 0)
            {
                return (i+1);
            }
        i++;
        }
    }
}
