using System.ComponentModel;

public class itemCode
{
    public Item.Armor colthArmor = new Item.Armor("천 갑옷", 0, 1, 200, 0, 0, "가격이 싸서 인기가 많은 갑옷이다.");
    public Item.Armor chainVest = new Item.Armor("쇠사슬 조끼", 0, 4, 800, 0, 0, "방어력만 올라가는 갑옷이다.");
    public Item.Armor brambleVest = new Item.Armor("덤불 조끼", 0, 3, 800, 2, 0,"공격반사 대신 크리티컬 확률이 올라간다.");


    public Item.Weapon dagger = new Item.Weapon("단검", 1, 0, 300, 0, 1, "회피율을 증가시킨다.", "Thief");

    public Item.Weapon longSword = new Item.Weapon("롱소드", 1, 0, 350, 0, 0, "효율이 좋아 인기가 많은 검이다.", "Warrior");
    public Item.Weapon bfSword = new Item.Weapon("B.F. 대검", 4, 0, 1300, 0, 1, "고가의 대검이다.", "Warrior");

    public Item.Weapon needlessRod = new Item.Weapon("쓸데없이 큰 지팡이", 1, 0, 1250, 0, 2, "쓸큰지. 물뎀은 별로다.", "Wizard");

    public Item.Weapon recurveBow = new Item.Weapon("곡궁", 2, 0, 700, 0, 1, "공격 속도 계열 아이템 이였던것.", "Archer");


    public Item.Potion HealthPotion = new Item.Potion("체력 물약", 12, 0, 50, "체력을 12만큼 회복시킨다.");
    public Item.Potion corruptingPotion = new Item.Potion("부패 물약", 10, 7, 500, "체력과 마력을 회복시킨다..");

    public Item.Accessories sapphireCrystal = new Item.Accessories("사파이어 수정", 0, 0, 350, 0, 0, 0, 25, "마력 총량을 늘려주는 수정이다.");
    public Item.Accessories rubyCrystall = new Item.Accessories("루비 수정",0 , 0, 700, 0, 0, 15, 0, "체력 총량을 늘려주는 수정이다.");
    public Item.Accessories hexteckAlternator = new Item.Accessories("마법공학 교류 발전기", 0, 0, 600, 2, 0, 15, 0, "크리티컬 확률과 체력을 증가시킨다.");
}   