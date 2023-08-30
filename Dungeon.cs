using System.Reflection.Metadata;
using SprtaGame;

public class Dungeon
{
    /* 던전 불러오기 
    Dungeon dungeon;
    dungeon = new Dungeon(plyer); // 플레이어 객체 전달
    dungeon.inDungeon();
    */
    MainPage mainPage = new MainPage();
    Player player; // 플레이어
    Monster[] monster; // 몬스터들
    int inputNumber = 0; // 입력 번호
    Random randomObj = new Random(); // 랜덤변수
    static int stageLevel=1; // 스테이지 레벨
    int beforeHp = 0;
    int alldead=0; // 전부 죽었는지 판단
    public Dungeon(Player player) // 생성자
    {
        string[] mon = new string[3]{"","SiegeMinion","Voidling"};
        this.player=player;
        spawnMoster(mon); // 몬스터 스폰
        beforeHp=player.Health; // 이전 체력
    }

    public void inDungeon() // 던전 입장
    {
        Console.Clear();
		Console.WriteLine("Battle!");
        
        for(int i=0; i<monster.Length; i++) // 몬스터 정보
        {
            if(monster[i].IsDead)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("{0}  Lv.{1} {2} Dead",i+1,monster[i].level, monster[i].Name);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("{0}  Lv.{1} {2} HP {3}",i+1,monster[i].level, monster[i].Name, monster[i].Health);
            }

        }
        Console.WriteLine();
		Console.WriteLine("[내정보]");
        Console.WriteLine("Lv.{0} {1} ({2}) HP {3}",player.level, player.job, player.Name, player.Health);
        Console.WriteLine();

        if(alldead==(stageLevel+2)) // 승리 판단
        {
            Console.Clear();
            Console.WriteLine("You Win!");
            Console.WriteLine("던전에서 {0}마리 잡았습니다.",stageLevel+2);
            Console.WriteLine("Lv.{0} {1} ({2}) HP {3} -> HP{4}",player.level, player.job, player.Name, beforeHp,player.Health);
            dungeonCompensation();
            stageLevel++;
            Console.WriteLine();
            ConsoleUI.Write(ConsoleColor.DarkRed, "0");
		    Console.WriteLine(". 되돌아기기");
            ConsoleUI.Write(ConsoleColor.Yellow, ">> ");
		    var Cursor = Console.GetCursorPosition();
            worngInput(Cursor,0,0);
 		    switch (inputNumber)
		    {
			    case 0:
                //돌아가기
                return;
		    }
        }
//행동 선택
        ConsoleUI.Write(ConsoleColor.DarkRed, "1");
		Console.WriteLine(". 공격");
        ConsoleUI.Write(ConsoleColor.DarkRed, "2");
		Console.WriteLine(". 방어");
		ConsoleUI.Write(ConsoleColor.DarkRed, "3");
		Console.WriteLine(". 스킬");
        ConsoleUI.Write(ConsoleColor.DarkRed, "4");
		Console.WriteLine(". 창고");
		Console.WriteLine();

        Console.WriteLine("원하시는 행동을 입력해주세요.");
		ConsoleUI.Write(ConsoleColor.Yellow, ">> ");
		var currentCursor = Console.GetCursorPosition();
        worngInput(currentCursor,1,4);

        battleStage(inputNumber); // 배틀시작 
    }

    public void spawnMoster(string[] mon) // 몬스터 소환
    {
        monster = new Monster[stageLevel+2];
        for(int i=0; i<(stageLevel+2); i++)
        {
            int j = randomObj.Next(0,3);
            monster[i] = new Monster(mon[j], stageLevel);
        }
    }

    public void battleStage(int s) // 배틀 상태
    {
        switch(s)
        {
            case 1: // 공격하기
            Console.WriteLine("대상을 선택해주세요.");
		    ConsoleUI.Write(ConsoleColor.Yellow, ">> ");
            var currentCursor = Console.GetCursorPosition();
            worngInput(currentCursor,1,monster.Length);

            if(monster[inputNumber-1].IsDead)
            {
                Console.WriteLine("대상이 죽었습니다.");
                battleStage(1);
            }

            Thread.Sleep(1000);
            Console.WriteLine("{0}의 공격!", player.Name);
            Thread.Sleep(1000);
            monster[inputNumber-1].Health=battleCalculate(player.Damage, monster[inputNumber-1]); // 공격 계산
            for(int i =0; i<monster.Length;i++)
            {
                if(monster[i].IsDead){alldead++;}
            }
            if(alldead<stageLevel+2)
            {
                alldead=0;
                mosterAtteck(0);
            }
            break;

            case 2: // 방어하기
            Thread.Sleep(1000);
            Console.WriteLine("{0}의 방어!", player.Name);
            Thread.Sleep(1000);
            for(int i =0; i<monster.Length;i++)
            {
                if(monster[i].IsDead){alldead++;}
            }
            if(alldead<stageLevel+2)
            {
                alldead=0;
                mosterAtteck(1);
            }
            break;

            case 3:  // 스킬 사용하기
            for(int i = 1; i<=player.Skills.Count; i++) // 스킬 목록
            {
                Console.WriteLine("{0}. {1}: {2}  -MP{3}  현재MP{4}", i, player.Skills[i-1].Name, player.Skills[i-1].Explanation, player.Skills[i-1].MpConsumption, player.Mp);
            }
            ConsoleUI.Write(ConsoleColor.DarkRed, "0");
		    Console.WriteLine(". 되돌아기기");
            Console.WriteLine("스킬을 선택해주세요.");
		    ConsoleUI.Write(ConsoleColor.Yellow, ">> ");
            currentCursor = Console.GetCursorPosition();
            worngInput(currentCursor,0,player.Skills.Count);
            if(inputNumber==0){break;}// 뒤로가기
            if(player.Mp<player.Skills[inputNumber-1].MpConsumption) // 마나부족
            {
                Console.WriteLine("마나부족");
                Thread.Sleep(1000);
                battleStage(3);
            }
            Thread.Sleep(1000);
            Console.WriteLine("{0}의 {1}!", player.Name, player.Skills[inputNumber-1].Name);
/////////////////////////
            
            if(player.Skills[inputNumber-1].DamageScale<=0) // 스킬 사용하기(힐이면)
            {
                if(player.Health<player.MaxHealth)
                {
                    player.Mp -=player.Skills[inputNumber-1].MpConsumption;
                    Console.WriteLine("{0}  {1} -> {2}", player.Name, player.Health, player.Health + (int)(player.MaxHealth * player.Skills[inputNumber - 1].RecoveryScale));
                    player.Health += (int)(player.MaxHealth * player.Skills[inputNumber - 1].RecoveryScale);
                }
                else
                {
                    Console.WriteLine("체력이 최대치입니다.");
                }
            }
            else//(힐이 아니면)
            {
                player.Mp -=player.Skills[inputNumber-1].MpConsumption;
                if(player.Skills[inputNumber-1].Name.Equals("더블 스트라이크")) // 랜덤 공격
                {
                    int yesAttck = 0;
                    bool[] monbool = new bool[monster.Length];
                    for(int i =0; i<monbool.Length;i++){monbool[i]=monster[i].IsDead;}
                    foreach(bool j in monbool)
                    {
                        if(j){yesAttck++;}
                    }
                    if(yesAttck>=monster.Length){break;}
                    for(int i=0;i<player.Skills[inputNumber-1].TargetCount;i++)
                    {
                        int random = randomObj.Next(monster.Length);
                        if(monster[random].IsDead)
                        {
                            for(int j =0; j<monbool.Length;j++){monbool[i]=monster[i].IsDead;}
                            foreach(bool j in monbool)
                            {
                            if(j){yesAttck++;}
                            }
                            if(yesAttck>=monster.Length){break;}
                            i--;
                        }
                        else
                        {
                            battleCalculate((int)(player.Damage*player.Skills[inputNumber-1].DamageScale),monster[random]);
                        }
                    }
                }
                else
                {
                    int skills = inputNumber-1;
                    bool check = true;
                    int[] count = new int[player.Skills[inputNumber-1].TargetCount];
                    for(int i=0; i<count.Length;i++)
                    {
                        check=true;
                        while(check)
                        {
                            Console.WriteLine("대상을 선택해주세요.");
		                    ConsoleUI.Write(ConsoleColor.Yellow, ">> ");
                            currentCursor = Console.GetCursorPosition();
                            worngInput(currentCursor,1,monster.Length);
                            if(monster[inputNumber-1].IsDead){Console.WriteLine("죽은상대 다시 선택해주세요.");}
                            else{count[i]=inputNumber-1;check=false;}
                        }
                    }
                    for(int i=0; i<count.Length; i++)
                    {
                        for(int j=0; j<player.Skills[skills].AttackCount ; j++)
                        {
                            battleCalculate((int)(player.Damage*player.Skills[skills].DamageScale),monster[count[i]]);
                        }
                    }
                }
            }
//////////////////////////////////////////////
            Thread.Sleep(1000);
            for(int i =0; i<monster.Length;i++)
            {
                if(monster[i].IsDead){alldead++;}
            }
            if(alldead<stageLevel+2)
            {
                alldead=0;
                mosterAtteck(0);
            }
            break;

            case 4: // 아이템 보기
            Program.inventory.DisplayInven();
            break;
        }
        if(player.Health<=0){player.IsDead=true;}
        Thread.Sleep(1000);
        if(player.IsDead)
        {
            Console.WriteLine("You Lose");
            player.Health=player.MaxHealth;
            player.Mp=player.MaxMp;
            return;
        }
        else
        {
            inDungeon(); // 되돌아기기
        }


    }

    public void mosterAtteck(int typs)
    {
        Console.Clear();
        Console.WriteLine("몬스터 공격!");
            for(int i=0;i<monster.Length;i++) // 몬스터 차례
            {
                if(!monster[i].IsDead)
                {
                    if(typs==1)
                    {
                        if(monster[i].Damage<=player.Defense)
                        {
                            Console.WriteLine("{0}는(은) 공격을 방어했다!", player.Name);
                        }
                        else
                        {
                            player.Health=battleCalculate(monster[i].Damage-player.Defense, player);
                        }
                    }
                    else
                    {
                        int random = randomObj.Next((int)10); // 30퍼 확률로 스킬 사용
                        if(random>7)
                        {
                            random = randomObj.Next((int)monster[i].Skills.Count);
                            Console.WriteLine("Lv.{0} {1}의 {2}!", monster[i].level, monster[i].Name, monster[i].Skills[random].Name);
                            for(int j=0; j<monster[i].Skills[random].AttackCount;j++)
                            {
                                player.Health=battleCalculate((int)(monster[i].Damage*monster[i].Skills[random].DamageScale), player);
                            }
                        }
                        else
                        {
                            player.Health=battleCalculate(monster[i].Damage, player);
                        }
                    }
                }
                Thread.Sleep(1000);
            }
    }

    public int battleCalculate(int damage, Character character )// 회피, 치명타 공격 계산(몬스터 플레이어 공용)
    {
        Console.WriteLine();
        int lastDamage;
        int random1 =randomObj.Next(100) ;
        float random2 =randomObj.Next(100) ;
        
        if(random1>=(100-character.AvoidanceRate)) // 회피
        {
            lastDamage = 0;
            Console.WriteLine("Lv.{0} {1}을(를) 공격했지만 아무일도 일어나지 않았습니다.",character.level, character.Name);
        }
        else
        {
            if(random2>=(100-character.CriticalPer)) // 치명타
                {
                    lastDamage = damage*100/60;
                    Console.WriteLine("Lv.{0} {1}을(를) 맞췄습니다. [데미지 : {2}] - 치명타 공격!!", character.level, character.Name, lastDamage);
                }
            else
                {
                    lastDamage = randomObj.Next(damage-(damage/10),damage+(damage/10)); // 최종데미지
                    Console.WriteLine("Lv.{0} {1}을(를) 맞췄습니다. [데미지 : {2}]", character.level, character.Name, lastDamage);
                }
             Console.WriteLine("Lv.{0} {1}",character.level, character.Name);
             Console.WriteLine();
            if(character.Health-lastDamage<=0)
            {
                Console.WriteLine("HP{0}->Dead",character.Health);
                character.IsDead=true;
            }
            else
            {
                Console.WriteLine("HP {0}->HP {1}",character.Health,character.Health-lastDamage);
            }
            character.Health-=lastDamage;
        }
        Console.WriteLine();
        Thread.Sleep(1000);
        return character.Health;
    }

    public void dungeonCompensation() // 보상클래스
    {
            int getGold =0;
            int ex=0;
            int levels = player.level;

            for(int i = 0; i<monster.Length; i++)
            {
                switch(monster[i].Name)
                {
                    case"미니언":
                    getGold+=200;
                    ex+=5;
                    break;
                    case"공허충":
                    getGold+=400;
                    ex+=10;
                    break;
                    case"대포미니언":
                    getGold+=600;
                    ex+=15;
                    break;
                }
            }

            Console.WriteLine("Gold +{0}!",getGold);
            player.Gold+=getGold;
            Console.WriteLine("Ex +{0}!",ex);
            player.Experience+=ex;
            
            if(player.TryLevelUP())
            {
                Console.WriteLine("레벨업! {0} -> {1}", levels, player.level);
            }
    }

    public void worngInput((int Left, int Top) currentCursor, int min, int max) // 입력보기
    {
        bool isWrongInput = true;
		while (isWrongInput)
		{
			if (int.TryParse(Console.ReadLine(), out inputNumber) == true)
			{
				if (inputNumber >= min && inputNumber <= max)
					break ;
			}
			Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
			ConsoleUI.Write(ConsoleColor.Red, "잘못된 입력입니다.");
			Thread.Sleep(1000);
			Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
			Console.Write("                    ");
			Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
		}
    }
}