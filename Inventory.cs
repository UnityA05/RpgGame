using SprtaGame;
using System.Data;
using System.Runtime.InteropServices.JavaScript;
using static Item;

public class Inventory
{
    public static List<Item> playerInven { get; set; } = new List<Item>(10);
    //아이템 리스트에서 장착중인 인덱스 번호들
    public static int exArmorNum = -1;
    public static int exWeaponNum = -1;
    public static int exAccessNum = -1;
    public Inventory()
    {
        playerInven.Add(Program.itemMake.colthArmor);
        playerInven.Add(Program.itemMake.longSword);
    }
    public void DisplayInven()
    {
        Console.Clear();
        Console.WriteLine("인벤토리");

        Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");

        PrintInven();

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
                break;
            case 1:
                DisplayEquip();
                break;
            case 2:
                DisplayUse();
                break;
        }
    }
    public void DisplayEquip()
    {
        Console.Clear();
        Console.WriteLine("인벤토리 - 장착관리");

        Console.WriteLine("아이템에 해당하는 숫자를 입력하시면 장착, 장착된 아이템의 숫자를 입력하시면 해제됩니다.");
        Console.WriteLine();
        Console.WriteLine("[아이템 목록]");

        List<Item> wearable = new List<Item>();

        foreach (Item wear in playerInven)
        {
            if (wear.GetType() != typeof(Item.Potion))
            {
                wearable.Add(wear);
            }
        }

        PrintEquip(wearable);

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
                if ((inputNumber >= 0) && (inputNumber <= wearable.Count()))
                {
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

        if (inputNumber == 0)
        {
            DisplayInven();
        }
        else
        {
            int index = playerInven.FindIndex(x => x.item_Name.Equals(wearable[inputNumber - 1].item_Name));
            Equip(index);
            wearable.Clear();
            DisplayEquip();
        }
    }
    public void DisplayUse()
    {
        Console.Clear();
        List<Item> potions = new List<Item>();
        Console.WriteLine("인벤토리-포션사용");

        Console.WriteLine("보유 중인 포션을 사용할 수 있습니다.");
        Console.WriteLine();
        Console.WriteLine("[포션 목록]");

        foreach (Item pot in playerInven)
        {
            if (pot.GetType() == typeof(Item.Potion))
            {
                potions.Add(pot);
            }
        }

        PrintPotion(potions);

        Console.WriteLine();
        ConsoleUI.Write(ConsoleColor.DarkRed, "0");
        Console.WriteLine(". 나가기");
        ConsoleUI.Write(ConsoleColor.DarkRed, "1~");
        Console.WriteLine(". 사용");
        Console.WriteLine();

        var currentCursor = Console.GetCursorPosition();
        int inputNumber = 0;
        bool isWrongInput = true;
        while (isWrongInput)
        {
            if (int.TryParse(Console.ReadLine(), out inputNumber) == true)
            {
                if (inputNumber >= 0 && inputNumber <= potions.Count())
                    break;
            }
            Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
            ConsoleUI.Write(ConsoleColor.Red, "잘못된 입력입니다.");
            Thread.Sleep(1000);
            Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
            Console.Write("                    ");
            Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
        }

        if (inputNumber == 0)
        {
            DisplayInven();
        }
        else
        {
            int index = playerInven.FindIndex(x => x.item_Name.Equals(potions[inputNumber - 1].item_Name));
            InvenUse(playerInven[index]);
            potions.Clear();
            DisplayInven();
        }
    }
    public static void InvenAdd(Item item)
    {
        playerInven.Add(item);
    }
    public void InvenUse(Item item)
    {
        Program.defaultPlayer.Health += item.item_Health;
        Program.defaultPlayer.Mp += item.item_Mp;

        //최대 체력과 최대 마력 한정

        playerInven.Remove(item);
    }
    public void Equip(int i)
    {
        bool isEquiped = playerInven[i].item_Name.Contains("[E]");

        if (isEquiped == true)  //[E]가 붙은 아이템 선택(해제)
        {
            //[E] 제거
            playerInven[i].item_Name = playerInven[i].item_Name.Replace("[E]", "");

            if (playerInven[i].GetType() == typeof(Item.Armor))    //갑옷 해제
            {
                Program.defaultPlayer.Defense -= -playerInven[i].item_Defense;
                Program.defaultPlayer.CriticalPer -= playerInven[i].item_CriticalPer;
                exArmorNum = -1;
            }
            else if (playerInven[i].GetType() == typeof(Item.Weapon))  //무기 해제
            {
                Program.defaultPlayer.Damage -= playerInven[i].item_Damage;
                Program.defaultPlayer.AvoidanceRate -= playerInven[i].item_AvoidanceRate;
                exWeaponNum = -1;
            }
            else if (playerInven[i].GetType() == typeof(Item.Accessories))
            {
                Program.defaultPlayer.Health -= playerInven[i].item_Health;
                Program.defaultPlayer.Mp -= playerInven[i].item_Mp;
                Program.defaultPlayer.CriticalPer -= playerInven[i].item_CriticalPer;
                exAccessNum = -1;
            }
        }
        else
        {
            playerInven[i].item_Name = "[E]" + playerInven[i].item_Name;
            if (playerInven[i].GetType() == typeof(Item.Armor))    //갑옷 장착
            {
                if (exArmorNum == -1)    //기존 장착한 장비가 없음.
                {
                    Program.defaultPlayer.Defense += playerInven[i].item_Defense;
                    Program.defaultPlayer.CriticalPer += playerInven[i].item_CriticalPer;
                    exArmorNum = i;
                }
                else                    //기존 장착한 장비가 있음.
                {
                    playerInven[exArmorNum].item_Name = playerInven[exArmorNum].item_Name.Replace("[E]", "");
                    Program.defaultPlayer.Defense = Program.defaultPlayer.Defense - playerInven[exArmorNum].item_Defense + playerInven[i].item_Defense;
                    Program.defaultPlayer.CriticalPer = Program.defaultPlayer.CriticalPer - playerInven[exArmorNum].item_CriticalPer + playerInven[i].item_CriticalPer;
                    exArmorNum = i;
                }
            }
            else if (playerInven[i].GetType() == typeof(Item.Weapon))   //무기 장착
            {
                if (exWeaponNum == -1)
                {
                    Program.defaultPlayer.Damage += playerInven[i].item_Damage;
                    Program.defaultPlayer.AvoidanceRate += playerInven[i].item_AvoidanceRate;
                    exWeaponNum = i;
                }
                else
                {
                    playerInven[exWeaponNum].item_Name = playerInven[exWeaponNum].item_Name.Replace("[E]", "");
                    Program.defaultPlayer.Damage = Program.defaultPlayer.Damage - playerInven[exWeaponNum].item_Damage + playerInven[i].item_Damage;
                    Program.defaultPlayer.AvoidanceRate = Program.defaultPlayer.AvoidanceRate - playerInven[exWeaponNum].item_AvoidanceRate + playerInven[i].item_AvoidanceRate;
                    exWeaponNum = i;
                }
            }
            else if (playerInven[i].GetType() == typeof(Item.Accessories))
            {
                if (exAccessNum == -1)
                {
                    Program.defaultPlayer.Health += playerInven[i].item_Health;
                    Program.defaultPlayer.Mp += playerInven[i].item_Mp;
                    Program.defaultPlayer.CriticalPer += playerInven[i].item_CriticalPer;
                    exAccessNum = i;
                }
                else
                {
                    playerInven[exAccessNum].item_Name = playerInven[exAccessNum].item_Name.Replace("[E]", "");
                    Program.defaultPlayer.Health = Program.defaultPlayer.Health + playerInven[i].item_Health - playerInven[exAccessNum].item_Health;
                    Program.defaultPlayer.Mp = Program.defaultPlayer.Mp + playerInven[i].item_Mp - playerInven[exAccessNum].item_Mp;
                    Program.defaultPlayer.CriticalPer = Program.defaultPlayer.CriticalPer + playerInven[i].item_CriticalPer - playerInven[i].item_CriticalPer;
                    exAccessNum = i;
                }
            }
        }
    }
    public int HowManyDigit(int j)
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
    private void PrintInven()
    {
        int currentIndex = 0;
        while (currentIndex < playerInven.Count())
        {
            //출력 칸 정렬
            string InvenStr_Name = "            |";
            string InvenStr_Effect = "                    |";
            string InvenStr_Explain = "                                                  |";

            string Replace_Name = string.Empty;
            string Replace_Effect = string.Empty;
            string Replace_Explain = string.Empty;

            //삽입될 만큼 정렬 문자열에서 빈칸 지우기
            int nameLength = playerInven[currentIndex].item_Name.Count();
            Replace_Name = InvenStr_Name.Remove(0, nameLength)
                                        .Insert(0, playerInven[currentIndex].item_Name);

            if (playerInven[currentIndex].GetType() == typeof(Item.Potion)) //물약이라면
            {
                if (playerInven[currentIndex].item_Health > 0 && playerInven[currentIndex].item_Mp == 0)
                {
                    //회복 물약

                    int effectLength = HowManyDigit(playerInven[currentIndex].item_Health) + 6;    // + 6은 문자열 "체력회복 +"
                    Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, "체력회복 +" + Convert.ToString(playerInven[currentIndex].item_Health));
                }
                else
                {
                    //부패 물약
                    int effectLength = HowManyDigit(playerInven[currentIndex].item_Health) + HowManyDigit(playerInven[currentIndex].item_Mp) + 8;
                    Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, "체력 +" + Convert.ToString(playerInven[currentIndex].item_Health) + "마력 +" + Convert.ToString(playerInven[currentIndex].item_Mp));
                }

            }
            else if (playerInven[currentIndex].GetType() == typeof(Item.Accessories))
            {
                if (playerInven[currentIndex].item_Health > 0)
                {
                    int effectLength = HowManyDigit(playerInven[currentIndex].item_Health) + 4;    // + 6은 문자열 "체력회복 +"
                    Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, "체력 +" + Convert.ToString(playerInven[currentIndex].item_Health));
                }
                else if (playerInven[currentIndex].item_Mp > 0)
                {
                    int effectLength = HowManyDigit(playerInven[currentIndex].item_Mp) + 4;    // + 6은 문자열 "체력회복 +"
                    Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, "마력 +" + Convert.ToString(playerInven[currentIndex].item_Mp));
                }
                else
                {
                    int effectLength = HowManyDigit(playerInven[currentIndex].item_Health) + HowManyDigit(playerInven[currentIndex].item_CriticalPer) + 4 + 6;    // + 6은 문자열 "체력회복 +"
                    Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, "체력 +" + Convert.ToString(playerInven[currentIndex].item_Health) + "크리티컬 +" + Convert.ToString(playerInven[currentIndex].item_CriticalPer));
                }
            }
            else
            {
                if (playerInven[currentIndex].GetType() == typeof(Item.Armor))
                {
                    //armor
                    if (playerInven[currentIndex].item_CriticalPer > 0)
                    {
                        int effectLength = HowManyDigit(playerInven[currentIndex].item_Defense) + HowManyDigit(playerInven[currentIndex].item_CriticalPer) + 6 + 7;
                        Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, " 방어력 +" + Convert.ToString(playerInven[currentIndex].item_Defense + " 치명타율 +" + Convert.ToString(playerInven[currentIndex].item_CriticalPer)));
                    }
                    else
                    {
                        int effectLength = HowManyDigit(playerInven[currentIndex].item_Defense) + 6;
                        Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                        .Insert(0, " 방어력 +" + Convert.ToString(playerInven[currentIndex].item_Defense));
                    }
                }
                else
                {
                    //weapon
                    if (playerInven[currentIndex].item_AvoidanceRate > 0)
                    {
                        int effectLength = HowManyDigit(playerInven[currentIndex].item_Damage) + HowManyDigit(playerInven[currentIndex].item_AvoidanceRate) + 6 + 5;
                        Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                        .Insert(0, " 공격력 +" + Convert.ToString(playerInven[currentIndex].item_Damage) + " 회피 +" + Convert.ToString(playerInven[currentIndex].item_AvoidanceRate));
                    }
                    else
                    {
                        int effectLength = HowManyDigit(playerInven[currentIndex].item_Damage) + 6;
                        Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                        .Insert(0, " 공격력 +" + Convert.ToString(playerInven[currentIndex].item_Damage));
                    }
                }
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
    }
    private void PrintPotion(List<Item> potions)
    {
        int currentIndex = 0;
        while (currentIndex < potions.Count())
        {
            string InvenStr_Name = "            |";
            string InvenStr_Effect = "                    |";
            string InvenStr_Explain = "                                                  |";

            string Replace_Name = string.Empty;
            string Replace_Effect = string.Empty;
            string Replace_Explain = string.Empty;

            //삽입될 만큼 정렬 문자열에서 빈칸 지우기
            int nameLength = potions[currentIndex].item_Name.Count();
            Replace_Name = InvenStr_Name.Remove(0, nameLength)
                                        .Insert(0, potions[currentIndex].item_Name);

            if (playerInven[currentIndex].item_Mp > 0)
            {
                //부패 물약
                int effectLength = HowManyDigit(playerInven[currentIndex].item_Health) + HowManyDigit(playerInven[currentIndex].item_Mp) + 8;
                Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                .Insert(0, "체력 +" + Convert.ToString(playerInven[currentIndex].item_Health) + "마력 +" + Convert.ToString(playerInven[currentIndex].item_Mp));
            }
            else
            {
                //체력 물약
                int effectLength = HowManyDigit(playerInven[currentIndex].item_Health) + 6;
                Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                .Insert(0, "체력 +" + Convert.ToString(playerInven[currentIndex].item_Health));
                
            }

            int explainLength = potions[currentIndex].item_Discription.Length;
            Replace_Explain = InvenStr_Explain.Remove(0, explainLength)
                                              .Insert(0, potions[currentIndex].item_Discription);

            ConsoleUI.Write(ConsoleColor.DarkRed, Convert.ToString(currentIndex + 1));
            Console.Write("- ");
            Console.Write(Replace_Name);
            Console.Write(Replace_Effect);
            Console.Write(Replace_Explain);
            Console.WriteLine();
            currentIndex++;
        }
    }
    private void PrintEquip(List<Item> items)
    {
        int currentIndex = 0;

        while (currentIndex < items.Count())
        {
            string InvenStr_Name = "            |";
            string InvenStr_Effect = "                    |";
            string InvenStr_Explain = "                                                  |";

            string Replace_Name = string.Empty;
            string Replace_Effect = string.Empty;
            string Replace_Explain = string.Empty;

            int nameLength = items[currentIndex].item_Name.Count();
            Replace_Name = InvenStr_Name.Remove(0, nameLength)
                                        .Insert(0, items[currentIndex].item_Name);

            if (items[currentIndex].GetType() == typeof(Item.Accessories))
            {
                if (items[currentIndex].item_Health > 0)
                {
                    int effectLength = HowManyDigit(items[currentIndex].item_Health) + 4;    // + 6은 문자열 "체력회복 +"
                    Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, "체력 +" + Convert.ToString(items[currentIndex].item_Health));
                }
                else if (items[currentIndex].item_Mp > 0)
                {
                    int effectLength = HowManyDigit(items[currentIndex].item_Mp) + 4;    // + 6은 문자열 "체력회복 +"
                    Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, "마력 +" + Convert.ToString(items[currentIndex].item_Mp));
                }
                else
                {
                    int effectLength = HowManyDigit(items[currentIndex].item_Health) + HowManyDigit(items[currentIndex].item_CriticalPer) + 4 + 6;    // + 6은 문자열 "체력회복 +"
                    Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, "체력 +" + Convert.ToString(items[currentIndex].item_Health) + "크리티컬 +" + Convert.ToString(items[currentIndex].item_CriticalPer));
                }
            }
            else
            {
                if (items[currentIndex].GetType() == typeof(Item.Armor))
                {
                    //armor
                    if (items[currentIndex].item_CriticalPer > 0)
                    {
                        int effectLength = HowManyDigit(items[currentIndex].item_Defense) + HowManyDigit(items[currentIndex].item_CriticalPer) + 6 + 7;
                        Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                    .Insert(0, " 방어력 +" + Convert.ToString(items[currentIndex].item_Defense + " 치명타율 +" + Convert.ToString(items[currentIndex].item_CriticalPer)));
                    }
                    else
                    {
                        int effectLength = HowManyDigit(items[currentIndex].item_Defense) + 6;
                        Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                        .Insert(0, " 방어력 +" + Convert.ToString(items[currentIndex].item_Defense));
                    }
                }
                else
                {
                    //weapon
                    if (items[currentIndex].item_AvoidanceRate > 0)
                    {
                        int effectLength = HowManyDigit(items[currentIndex].item_Damage) + HowManyDigit(items[currentIndex].item_AvoidanceRate) + 6 + 5;
                        Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                        .Insert(0, " 공격력 +" + Convert.ToString(items[currentIndex].item_Damage) + " 회피 +" + Convert.ToString(items[currentIndex].item_AvoidanceRate));
                    }
                    else
                    {
                        int effectLength = HowManyDigit(items[currentIndex].item_Damage) + 6;
                        Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                        .Insert(0, " 공격력 +" + Convert.ToString(items[currentIndex].item_Damage));
                    }
                }
                int explainLength = items[currentIndex].item_Discription.Length;
                Replace_Explain = InvenStr_Explain.Remove(0, explainLength)
                                                  .Insert(0, items[currentIndex].item_Discription);
            }
            ConsoleUI.Write(ConsoleColor.DarkRed, Convert.ToString(currentIndex + 1));
            Console.Write(" - ");
            Console.Write(Replace_Name);
            Console.Write(Replace_Effect);
            Console.Write(Replace_Explain);
            Console.WriteLine();
            currentIndex++;
        }
    }
}
