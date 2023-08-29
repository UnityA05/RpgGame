using SprtaGame;
using System.Runtime.InteropServices.JavaScript;

public class Inventory
{
    static List<Item> playerInven { get; set; } = new List<Item>(10);
    //�Ʒ��� �κ��丮 ����Ʈ�� ������ ����� ������ �ε��� ��ȣ. ��� ��������
    public static int exArmorNum = -1;
    public static int exWeaponNum = -1;
    static Player player = Program.defaultPlayer;
    //�������ͽ�
    public Inventory()
    {
        Item steelArmor = new Item("���谩��", 0, 5, 500, "����� ������� ưư�� �����Դϴ�.");
        Item leatherArmor = new Item("���װ���", 0, 2, 200, "�Ұ������� ������� ���� ���װ���.");

        Item oldSword = new Item("���� ��", 2, 0, 800, "���� �� �� �ִ� ���� ���Դϴ�.");
        Item gladius = new Item("�۶��콺", 6, 0, 1000, "��⿡ Ưȭ�� ª�� �Ѽհ�.");

        playerInven.Add(steelArmor);
        playerInven.Add(leatherArmor);
        playerInven.Add(oldSword);
        playerInven.Add(gladius);
    }
    public static void DisplayInven()
    {
        Console.Clear();
        Console.WriteLine("�κ��丮");

        Console.WriteLine("���� ���� �������� ������ �� �ֽ��ϴ�.");
        Console.WriteLine();
        Console.WriteLine("[������ ���]");

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
                                                .Insert(0, " ���� +" + Convert.ToString(playerInven[currentIndex].item_Defense));
            }
            else
            {
                //weapon
                int effectLength = HowManyDigit(playerInven[currentIndex].item_Damage) + 6;
                Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                .Insert(0, " ���ݷ� +" + Convert.ToString(playerInven[currentIndex].item_Damage));
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
        Console.WriteLine(". ������");
        ConsoleUI.Write(ConsoleColor.DarkRed, "1");
        Console.WriteLine(". ��������");
        Console.WriteLine();

        Console.WriteLine("���Ͻô� �ൿ�� �Է����ּ���.");
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
            ConsoleUI.Write(ConsoleColor.Red, "�߸��� �Է��Դϴ�.");
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
        }
    }
    public static void DisplayEquip()
    {
        Console.Clear();
        Console.WriteLine("��������");

        Console.WriteLine("������ ��ȣ�� �Է��ϸ� ����, ������ ������ ��ȣ �Է� �� �����˴ϴ�.");
        Console.WriteLine();
        Console.WriteLine("[������ ���]");

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
                int effectLength = HowManyDigit(playerInven[currentIndex].item_Defense) + 6;
                Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                .Insert(0, " ���� +" + Convert.ToString(playerInven[currentIndex].item_Defense));
            }
            else
            {
                //weapon
                int effectLength = HowManyDigit(playerInven[currentIndex].item_Damage) + 6;
                Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                .Insert(0, " ���ݷ� +" + Convert.ToString(playerInven[currentIndex].item_Damage));
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
        Console.WriteLine(". ������");
        ConsoleUI.Write(ConsoleColor.DarkRed, "1~");
        Console.WriteLine(". ����/����");
        Console.WriteLine();

        Console.WriteLine("���Ͻô� �ൿ�� �Է����ּ���.");
        ConsoleUI.Write(ConsoleColor.Yellow, ">> ");

        var currentCursor = Console.GetCursorPosition();
        int inputNumber = 0;
        bool isWrongInput = true;

        while (isWrongInput)
        {
            if (int.TryParse(Console.ReadLine(), out inputNumber) == true)
            {
                if ((inputNumber >= 0)&&(inputNumber <= playerInven.Count()))
                    break;
            }
            Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
            ConsoleUI.Write(ConsoleColor.Red, "�߸��� �Է��Դϴ�.");
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
    public void InvenAdd(Item item)
    {
        if (playerInven.Count() == 10)
        {
            Console.WriteLine("�κ��丮 â�� ���� á���ϴ�.");
            Console.WriteLine("������ ���Ͻø� �κ��丮�� ����ֽʽÿ�.");
        }
        else
        {
            playerInven.Add(item);
        }
    }
    public void InvenUse(Item item)
    {
        //���Ƿ�
        //ȿ�� ����?

        playerInven.Remove(item);
    }
    public static void Equip(int i)
    {
        bool isEquiped = playerInven[i].item_Name.Contains("[E]");

        if (isEquiped == true)  //[E] �������� ����
        {
            //[E]�ؽ�Ʈ ����
            playerInven[i].item_Name = playerInven[i].item_Name.Replace("[E]", "");

            //�����Ѵٸ�
            if (playerInven[i].item_Damage == 0)
            {
                //���� ����
                player.Defense = player.Defense - playerInven[i].item_Defense;
                exArmorNum = -1;
            }
            else if (playerInven[i].item_Defense == 0)
            {
            //���� ����
                player.Damage = player.Damage - playerInven[i].item_Damage;
                exWeaponNum = -1;
            }
        }
        else
        {
            playerInven[i].item_Name = "[E]" + playerInven[i].item_Name;
            //��������
            if (playerInven[i].item_Damage == 0)
            {
                //���� �����Ѱ� ������
                if(exArmorNum == -1)
                {
                    player.Defense += playerInven[i].item_Defense;
                    exArmorNum = i;
                }
                //�����Ѱ� ������
                else
                {
                    playerInven[exArmorNum].item_Name = playerInven[exArmorNum].item_Name.Replace("[E]", "");
                    player.Defense = player.Defense - playerInven[exArmorNum].item_Defense + playerInven[i].item_Defense;
                    exArmorNum = i;
                }
            }
            else if(playerInven[i].item_Defense == 0)
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
