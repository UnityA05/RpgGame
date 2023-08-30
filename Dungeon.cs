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
    int inputNumber = 0;
    Random randomObj = new Random(); // 랜덤변수
    static int stageLevel=1; // 스테이지 레벨
    int alldead=0; // 전부 죽었는지 판단
    public Dungeon(Player player) // 생성자
    {
        string[] mon = new string[3]{"","SiegeMinion","Voidling"};
        this.player=player;
        spawnMoster(mon); // 몬스터 스폰
    }

    public void inDungeon() // 던전 입장
    {
        Console.Clear();
		Console.WriteLine("Battle!");
        alldead=0;

        for(int i=0; i<monster.Length; i++) // 몬스터 정보
        {
            if(monster[i].IsDead)
            {
                 Console.WriteLine("{0}  Lv.{1} {2} Dead",i+1,monster[i].level, monster[i].Name);
                alldead++;
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
            stageLevel++;
            Console.WriteLine("던전에서 {0}마리 잡았습니다.",stageLevel+2);
            Console.WriteLine();
            ConsoleUI.Write(ConsoleColor.DarkRed, "0");
		    Console.WriteLine(". 되돌아기기");
            ConsoleUI.Write(ConsoleColor.Yellow, ">> ");
		    var Cursor = Console.GetCursorPosition();
            worngInput(Cursor,0,0);
 		    switch (inputNumber)
		    {
			    case 0:
				mainPage.GameStart();
				break;
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
		Console.WriteLine(". 회복");
		Console.WriteLine();

        Console.WriteLine("원하시는 행동을 입력해주세요.");
		ConsoleUI.Write(ConsoleColor.Yellow, ">> ");
		var currentCursor = Console.GetCursorPosition();
        worngInput(currentCursor,1,4);

        battleStage(inputNumber); // 배틀시작 
    }

    public void spawnMoster(string[] mon) // 몬스터 소환
    {
        int j = 0;
        monster = new Monster[stageLevel+2];
        for(int i=0; i<(stageLevel+2); i++)
        {
            if(j>=3){j=1;}
            monster[i] = new Monster(mon[j], stageLevel);
            j++;
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
            if(monster[inputNumber-1].Health<=0)
            {
                monster[inputNumber-1].IsDead=true;
            }
            for(int i=0;i<monster.Length;i++)
            {
                if(!monster[i].IsDead)
                {
                    player.Health=battleCalculate(monster[i].Damage, player);
                }
            }
            break;

            case 2: // 방어하기
            Thread.Sleep(1000);
            Console.WriteLine("{0}의 방어!", player.Name);
            Thread.Sleep(1000);
            for(int i=0;i<monster.Length;i++)
            {
                if(monster[i].Health>0)
                {
                    if(monster[i].Damage<=player.Defense)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("{0}는(은) 공격을 방어했다!", player.Name);
                    }
                    else
                    {
                        player.Health=battleCalculate(monster[i].Damage-player.Defense, player);
                    }
                }
            }
            break;

            case 3:
            
            break;

            case 4:

            break;
        }
        if(player.Health<=0){player.IsDead=true;}
        Thread.Sleep(1000);
        if(player.IsDead)
        {
            Console.WriteLine("You Lose");
            mainPage.GameStart(); // 졌으니 쫓겨난다.
        }
        else
        {
            inDungeon(); // 되돌아기기
        }


    }

    public int battleCalculate(int damage, Character character )// 회피, 치명타 공격 계산(몬스터 플레이어 공용)
    {
        Console.WriteLine();
        int lastDamage;
        int random1 =randomObj.Next(100) ;
        float random2 =randomObj.Next(100) ;
        Thread.Sleep(1000);
        if(random1>=(90-character.AvoidanceRate)) // 회피
        {
            lastDamage = 0;
            Console.WriteLine("Lv.{0} {1}을(를) 공격했지만 아무일도 일어나지 않았습니다.",character.level, character.Name);
        }
        else
        {
            if(random2>=(85-character.CriticalPer)) // 치명타
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