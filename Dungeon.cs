public class Dungeon
{
    Player player; // 플레이어
    Monster[] monster; // 몬스터들
    
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
            Console.WriteLine("Lv .{0} {1} HP {2}",monster[i].level, monster[i].Name, monster[i].Health);
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

        int inputNumber = 0;
		bool isWrongInput = true;
		while (isWrongInput)
		{
			if (int.TryParse(Console.ReadLine(), out inputNumber) == true)
			{
				if (inputNumber >= 1 && inputNumber <= 4)
					break ;
			}
			Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
			ConsoleUI.Write(ConsoleColor.Red, "잘못된 입력입니다.");
			Thread.Sleep(1000);
			Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
			Console.Write("                    ");
			Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
		}

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
            break;
            
            case 2:
            break;

            case 3:
            break;

            case 4:
            break;
        }
    }
}