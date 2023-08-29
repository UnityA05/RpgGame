using System.Runtime.InteropServices.JavaScript;

public class Inventory
{
    List<Item> playerInven = new List<Item>();
    //아래는 인벤토리 리스트에서 각각 무기와 갑옷의 인덱스. 어떻게 고칠지 모르겠다.
    public int exArmorNum = -1;
    public int exWeaponNum = -1;
    //스테이터스
    public Inventory()
    {
        Item steelArmor = new Item("무쇠갑옷", 0, 5, 500, "무쇠로 만들어져 튼튼한 갑옷입니다.");
        Item oldSword = new Item("낡은 검", 2, 0, 800, "쉽게 볼 수 있는 낡은 검입니다.");

        playerInven.Add(steelArmor);
        playerInven.Add(oldSword);
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

            if (playerInven[currentIndex].item_Atk == 0)
            {
                //armor
                int effectLength = HowManyDigit(playerInven[currentIndex].item_Def) + 6;
                Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                .Insert(0, " 방어력 +" + Convert.ToString(playerInven[currentIndex].item_Def));
            }
            else
            {
                //weapon
                int effectLength = HowManyDigit(playerInven[currentIndex].item_Atk) + 6;
                Replace_Effect = InvenStr_Effect.Remove(0, effectLength)
                                                .Insert(0, " 공격력 +" + Convert.ToString(playerInven[currentIndex].item_Atk));
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

            //if 해제
            if (playerInven[i].item_Atk == 0)
            {
                //갑옷 해제
                player.Def = player.Def - myInven[i].Item_Def;
            }
            else if (playerInven[i].item_Def == 0)
            {
            //무기 해제
                player.Atk = player.Atk - playerInven[i].item_Atk;
            }
        }
        else
        {
            playerInven[i].item_Name = "[E]" + playerInven[i].item_Name;
            //갑옷장착
            if (playerInven[i].item_Atk == 0)
            {
                //기존 장착한거 없으면
                if(exArmorNum == -1)
                {
                    player.Def += playerInven[i].item_Def;
                    exArmorNum = i;
                }
                //장착한게 있으면
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
