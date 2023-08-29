public class Dungeon
{
    Player player; // 플레이어
    Monster[] monster; // 몬스터들
    int inputNumber = 0;
    Random randomObj = new Random(); // 랜덤변수
    static int stageLevel=0; // 스테이지 레벨
    
    public Dungeon(Player player) // 생성자
    {
        this.player=player;
        spawnMoster(); // 몬스터 스폰
    }

    public void inDungeon() // 던전 입장
    {
        Console.Clear();
		Console.WriteLine("Battle!");

        for(int i=0; i<monster.Length; i++) // 몬스터 정보
        {
            if(monster[i].Health!=0)
            {
                Console.WriteLine("Lv .{0} {1} HP {2}",monster[i].level, monster[i].Name, monster[i].Health);
            }
            else
            {
                Console.WriteLine("Lv .{0} {1} Dead",monster[i].level, monster[i].Name);
            }

        }

		Console.WriteLine("[내정보]");
        Console.WriteLine("Lv .{0} {1} ({2})",player.level, player.job, player.Name);
        Console.WriteLine();

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

    public void spawnMoster() // 몬스터 소환
    {
        for(int i=0; i<(stageLevel+3); i++)
        {
            monster[i] = new Monster();
        }
    }

    public void battleStage(int s) // 배틀 상태
    {
        switch(s)
        {
            case 1:
            Console.WriteLine("대상을 선택해주세요.");
		    ConsoleUI.Write(ConsoleColor.Yellow, ">> ");
            var currentCursor = Console.GetCursorPosition();
            worngInput(currentCursor,0,monster.Length);
            if(monster[inputNumber].Health<=0)
            {
                Console.WriteLine("대상이 죽었습니다.");
                battleStage(1);
            }
            Console.WriteLine("{0}의 공격!", player.Name);
            monster[inputNumber].Health=battleCalculate(player.Damage, monster[inputNumber]); // 공격 계산

            for(int i=0;i<monster.Length;i++)
            {
                if(monster[i].Health>0)
                {
                    player.Health=battleCalculate(monster[i].Damage, player);
                }
            }
            break;

            case 2:
            break;

            case 3:
            break;

            case 4:
            break;
        }
        if(player.Health<=0)
        {
            Console.WriteLine("You Lose");
        }
        else
        {
            inDungeon(); // 되돌아기기
        }
    }

    public int battleCalculate(int damage, Character character )// 회피, 치명타 공격 계산(몬스터 플레이어 공용)
    {
        int lastDamage;
        int random1 =randomObj.Next(10) ;
        float random2 =randomObj.Next(10) ;
        if(random1>=9) // 회피
        {
            lastDamage = 0;
            Console.WriteLine("Lv.{0} {1}을(를) 공격했지만 아무일도 일어나지 않았습니다.",character.level, character.Name);
        }
        else
        {
            if(random2>=8.5) // 치명타
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