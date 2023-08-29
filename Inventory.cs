using System.Runtime.InteropServices.JavaScript;

public class Inventory
{
    List<Item> playerInven = new List<Item>();
    //�Ʒ��� �κ��丮 ����Ʈ���� ���� ����� ������ �ε���. ��� ��ĥ�� �𸣰ڴ�.
    public int exArmorNum = -1;
    public int exWeaponNum = -1;
    //�������ͽ�
    public Inventory()
    {
        Item steelArmor = new Item("���谩��", 0, 5, 500, "����� ������� ưư�� �����Դϴ�.");
        Item oldSword = new Item("���� ��", 2, 0, 800, "���� �� �� �ִ� ���� ���Դϴ�.");

        playerInven.Add(steelArmor);
        playerInven.Add(oldSword);
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

            if (playerInven[currentIndex].item_Atk == 0)
            {
                //armor
                int effectLength = HowManyDigit(playerInven[currentIndex].item_Def) + 6;
                Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                .Insert(0, " ���� +" + Convert.ToString(playerInven[currentIndex].item_Def));
            }
            else
            {
                //weapon
                int effectLength = HowManyDigit(playerInven[currentIndex].item_Atk) + 6;
                Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                .Insert(0, " ���ݷ� +" + Convert.ToString(playerInven[currentIndex].item_Atk));
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
    }
    public void InvenAdd(Item item)
    {
        playerInven.Add(item);
    }
    public void InvenUse()
    {

    }
    public void Equip(int i)
    {
        bool isEquiped = playerInven[i].item_Name.Contains("[E]");

        if (isEquiped == true)
        {
            playerInven[i].item_Name = playerInven[i].item_Name.Replace("[E]", "");

            //if ����
            if (playerInven[i].item_Atk == 0)
            {
                //���� ����
                player.Def = player.Def - myInven[i].Item_Def;
            }
            else if (playerInven[i].item_Def == 0)
            {
            //���� ����
                player.Atk = player.Atk - playerInven[i].item_Atk;
            }
        }
        else
        {
            playerInven[i].item_Name = "[E]" + playerInven[i].item_Name;
            //��������
            if (playerInven[i].item_Atk == 0)
            {
                //���� �����Ѱ� ������
                if(exArmorNum == -1)
                {
                    player.Def += playerInven[i].item_Def;
                    exArmorNum = i;
                }
                //�����Ѱ� ������
                else
                {
                    player.Def = player.Def - playerInven[exArmorNum].item_Def + playerInven[i].item_Def;
                    exArmorNum = i;
                }
            }
            else if(playerInven[i].item_Def == 0)
            {
                if(exWeaponNum == -1)
                {
                    player.Atk += playerInven[i].item_Atk;
                    exWeaponNum = i;
                }
                else
                {
                    player.Atk = player.Atk - playerInven[exWeaponNum].item_Atk + playerInven[i].item_Atk;
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
