using SprtaGame;
using System.Runtime.InteropServices.JavaScript;

public class Inventory
{
    List<Item> playerInven { get; set; } = new List<Item>(10);
    //�Ʒ��� �κ��丮 ����Ʈ���� ���� ����� ������ �ε���. ��� ��ĥ�� �𸣰ڴ�.
    public int exArmorNum = -1;
    public int exWeaponNum = -1;
    Player player = Program.defaultPlayer;
    //�������ͽ�
    public Inventory()
    {
        Item steelArmor = new Item("���谩��", 0, 5, 500, "����� ������� ưư�� �����Դϴ�.");
        Item leatherArmor = new Item("���װ���", 0, 2, 200, "�Ұ������� ������� ���� ���װ���.");

        Item oldSword = new Item("���� ��", 2, 0, 800, "���� �� �� �ִ� ���� ���Դϴ�.");
        Item gladius = new Item("�۶��콺", 6, 0, 1000, "��⿡ Ưȭ�� �����Ÿ� ª�� �Ѽհ�.");

        playerInven.Add(steelArmor);
        playerInven.Add(leatherArmor);
        playerInven.Add(oldSword);
        playerInven.Add(gladius);
    }
    public void DisplayInven()
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
                int effectLength = HowManyDigit(playerInven[currentIndex].item_Defence) + 6;
                Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                .Insert(0, " ���� +" + Convert.ToString(playerInven[currentIndex].item_Defence));
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
            currentIndex++;                         
        }

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
                int effectLength = HowManyDigit(playerInven[currentIndex].item_Defence) + 6;
                Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                .Insert(0, " ���� +" + Convert.ToString(playerInven[currentIndex].item_Defence));
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

            ConsoleUI.Write(ConsoleColor.DarkRed, currentIndex + 1);
            Console.Write("- ");
            Console.Write(Replace_Name);
            Console.Write(Replace_Effect);
            Console.Write(Replace_Explain);
            currentIndex++;
        }

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
                if ((inputNumber >= 0)&&(inputNumber <= playerInven.Count())
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
        }
    }
    public void InvenAdd(Item item)
    {
        if (playerInven.count == 10)
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

            //if ����
            if (playerInven[i].item_Damage == 0)
            {
                //���� ����
                player.Defence = player.Defence - myInven[i].Item_Defence;
            }
            else if (playerInven[i].item_Def == 0)
            {
            //���� ����
                player.Damage = player.Damage - playerInven[i].item_Damage;
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
                    player.Defence += playerInven[i].item_Defence;
                    exArmorNum = i;
                }
                //�����Ѱ� ������
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
