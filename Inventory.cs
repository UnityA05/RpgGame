using SprtaGame;
using System.Runtime.InteropServices.JavaScript;

public class Inventory
{
    List<Item> playerInven { get; set; } = new List<Item>(10);
    //아래는 인벤토리 리스트에서 각각 무기와 갑옷의 인덱스. 어떻게 고칠지 모르겠다.
    public int exArmorNum = -1;
    public int exWeaponNum = -1;
    Player player = Program.defaultPlayer;
    //스테이터스
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
    public void DisplayInven()
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
                int effectLength = HowManyDigit(playerInven[currentIndex].item_Defence) + 6;
                Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                .Insert(0, " 방어력 +" + Convert.ToString(playerInven[currentIndex].item_Defence));
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
            currentIndex++;                         
        }

        ConsoleUI.Write(ConsoleColor.DarkRed, "0");
        Console.WriteLine(". 나가기");
        ConsoleUI.Write(ConsoleColor.DarkRed, "1");
        Console.WriteLine(". 장착관리");
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
                if (inputNumber == 0 || inputNumber == 1)
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
                MainPage.GameStart();
                break;
            case 1:
                DisplayEquip();
                break;
        }
    }
    public void DisplayEquip()
    {
        Console.Clear();
        Console.WriteLine("장착관리");

        Console.WriteLine("아이템 번호를 입력하면 장착, 장착된 아이템 번호 입력 시 해제됩니다.");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");

        int invenLength = playerInven.Count();
        int currentIndex = 0;

        while (currentIndex < invenLength)
        {
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
                int effectLength = HowManyDigit(playerInven[currentIndex].item_Defence) + 6;
                Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                .Insert(0, " 방어력 +" + Convert.ToString(playerInven[currentIndex].item_Defence));
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

            ConsoleUI.Write(ConsoleColor.DarkRed, currentIndex + 1);
            Console.Write("- ");
            Console.Write(Replace_Name);
            Console.Write(Replace_Effect);
            Console.Write(Replace_Explain);
            currentIndex++;
        }

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
                if ((inputNumber >= 0)&&(inputNumber <= playerInven.Count())
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
            Equip(inputNumber - 1);
        }
    }
    public void InvenAdd(Item item)
    {
        if (playerInven.count == 10)
        {
            Console.WriteLine("인벤토리 창이 가득 찼습니다.");
            Console.WriteLine("구입을 원하시면 인벤토리를 비워주십시오.");
        }
        else
        {
            playerInven.Add(item);
        }
    }
    public void InvenUse(Item item)
    {
        //포션류
        player
        playerInven.Remove(item);
    }
    public void Equip(int i)
    {
        bool isEquiped = playerInven[i].item_Name.Contains("[E]");

        if (isEquiped == true)
        {
            //player
            playerInven[i].item_Name = playerInven[i].item_Name.Replace("[E]", "");

            //if 해제
            if (playerInven[i].item_Damage == 0)
            {
                //갑옷 해제
                player.Defence = player.Defence - myInven[i].Item_Defence;
            }
            else if (playerInven[i].item_Def == 0)
            {
            //무기 해제
                player.Damage = player.Damage - playerInven[i].item_Damage;
            }
        }
        else
        {
            playerInven[i].item_Name = "[E]" + playerInven[i].item_Name;
            //갑옷장착
            if (playerInven[i].item_Damage == 0)
            {
                //기존 장착한거 없으면
                if(exArmorNum == -1)
                {
                    player.Defence += playerInven[i].item_Defence;
                    exArmorNum = i;
                }
                //장착한게 있으면
                else
                {
                    player.Defence = player.Defence - playerInven[exArmorNum].item_Defence + playerInven[i].item_Defence;
                    exArmorNum = i;
                }
            }
            else if(playerInven[i].item_Defence == 0)
            {
                if(exWeaponNum == -1)
                {
                    player.Damage += playerInven[i].item_Damage;
                    exWeaponNum = i;
                }
                else
                {
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
