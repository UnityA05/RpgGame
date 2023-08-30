using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using SprtaGame;

public class MainPage
{
    public void GameStart()
	{
		bool isGameExit = false;
		Intro(out isGameExit);
		while (isGameExit == false)
		{
			InMainPage(out isGameExit);
		}
	}

	private void Intro(out bool isGameExit)
	{
		Console.Clear();
		string introLogo = "스파르타 던전 배틀";
		int loopCount = 10;
		int index = 0;
		Console.SetCursorPosition(4, 2);
		while (loopCount-- > 0)
		{
			Thread.Sleep(200);
			Console.Write(introLogo[index++]);
			Console.Write("  ");
		}
		Thread.Sleep(800);

		Console.SetCursorPosition(0, 4);
		ConsoleUI.Write(ConsoleColor.DarkRed, "1");
		Console.WriteLine(". 캐릭터 생성");
		ConsoleUI.Write(ConsoleColor.DarkRed, "0");
		Console.WriteLine(". 게임 종료\n");

		Console.WriteLine("원하시는 행동을 입력해주세요.");
		ConsoleUI.Write(ConsoleColor.Yellow, ">> ");
		var currentCursor = Console.GetCursorPosition();
		
		int inputNumber = -1;
		while (true)
		{
			if (int.TryParse(Console.ReadLine(), out inputNumber) == true)
			{
				if ((0 <= inputNumber) && (inputNumber <= 1))
					break ;
			}
			Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
			ConsoleUI.Write(ConsoleColor.Red, "잘못된 입력입니다.");
			Thread.Sleep(1000);
			Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
			Console.Write("                    ");
			Console.SetCursorPosition(currentCursor.Left, currentCursor.Top);
		}

		isGameExit = false;
		if (inputNumber == 1)
			MakeNewCharacter();
		else
			isGameExit = true;
	}

	private void MakeNewCharacter()
	{
		string name = SetName();
		string job = SetJob();
		Program.defaultPlayer = new Player(name, job);
	}

	private string SetName()
	{
		while (true)
		{
			Console.Clear();
			ConsoleUI.Write(ConsoleColor.DarkYellow, "캐릭터 생성\n\n");
			Console.WriteLine("이름을 입력해주세요.");
			ConsoleUI.Write(ConsoleColor.Yellow, ">> ");
			string? name = Console.ReadLine();
			if (name != null)
			{
				if (name.Length != 0)
					return name;
			}
			ConsoleUI.Write(ConsoleColor.Red, "\n잘못된 입력입니다");
			Thread.Sleep(800);
		}
	}

	private string SetJob()
	{
		Console.Clear();
		ConsoleUI.Write(ConsoleColor.DarkYellow, "캐릭터 생성\n\n");
		Console.WriteLine("직업을 정해주세요.\n");

		ConsoleUI.Write(ConsoleColor.DarkRed, "1");
		Console.WriteLine(". 전사");
		ConsoleUI.Write(ConsoleColor.DarkRed, "2");
		Console.WriteLine(". 법사");
		ConsoleUI.Write(ConsoleColor.DarkRed, "3");
		Console.WriteLine(". 궁수");
		ConsoleUI.Write(ConsoleColor.DarkRed, "4");
		Console.WriteLine(". 도적\n");

		ConsoleUI.Write(ConsoleColor.Yellow, ">> ");
		var currentCursor = Console.GetCursorPosition();
		
		int inputNumber = -1;
		while (true)
		{
			if (int.TryParse(Console.ReadLine(), out inputNumber) == true)
			{
				if ((1 <= inputNumber) && (inputNumber <= 4))
					break ;
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
			case 1:
				return "Warrior";
			case 2:
				return "Wizard";
			case 3:
				return "Archer";
			default: // case 4
				return "Thief";
		}
	}

	private void InMainPage(out bool isGameExit)
	{
		Console.Clear();
		Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
		Console.WriteLine("이제 전투를 시작하실 수 있습니다.\n");

		ConsoleUI.Write(ConsoleColor.DarkRed, "1");
		Console.WriteLine(". 상태 보기");
		ConsoleUI.Write(ConsoleColor.DarkRed, "2");
		Console.WriteLine(". 인벤토리");
		ConsoleUI.Write(ConsoleColor.DarkRed, "3");
		Console.WriteLine(". 상점 입장");
		ConsoleUI.Write(ConsoleColor.DarkRed, "4");
		Console.WriteLine(". 전투 시작");
		ConsoleUI.Write(ConsoleColor.DarkRed, "0");
		Console.WriteLine(". 게임 종료\n");

		Console.WriteLine("원하시는 행동을 입력해주세요.");
		ConsoleUI.Write(ConsoleColor.Yellow, ">> ");
		var currentCursor = Console.GetCursorPosition();
		
		int inputNumber = -1;
		while (true)
		{
			if (int.TryParse(Console.ReadLine(), out inputNumber) == true)
			{
				if ((0 <= inputNumber) && (inputNumber <= 4))
					break ;
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
			case 1:
				Status();
				break;
			case 2:
				Program.inventory.DisplayInven();
				break;
			case 3:
				Program.shop.DisplayShop();
				break;
			case 4:
				Dungeon dungeon = new Dungeon(Program.defaultPlayer);
				dungeon.inDungeon();
				break;
			case 0:
				isGameExit = true;
				return;
		}
		isGameExit = false;
	}

	private void Status()
	{
		Console.Clear();
		ConsoleUI.Write(ConsoleColor.DarkYellow, "상태 보기\n");
		Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
		
		Player player = Program.defaultPlayer;

		Console.Write("Lv. ");
		if (player.level / 10 == 0)
			ConsoleUI.Write(ConsoleColor.DarkRed, "0");
		ConsoleUI.Write(ConsoleColor.DarkRed, player.level.ToString());
		Console.WriteLine();

		Console.Write(player.Name);
		Console.WriteLine($" ( {player.job} )");
		
		Console.Write("공격력 : ");
		ConsoleUI.Write(ConsoleColor.DarkRed, player.Damage.ToString());
		Console.WriteLine();

		Console.Write("방어력 : ");
		ConsoleUI.Write(ConsoleColor.DarkRed, player.Defense.ToString());
		Console.WriteLine();

		Console.Write("체  력 : ");
		ConsoleUI.Write(ConsoleColor.DarkRed, player.Health.ToString());
		Console.WriteLine();

		Console.Write("MP     : ");
		ConsoleUI.Write(ConsoleColor.DarkRed, player.Mp.ToString());
		Console.WriteLine();

		Console.Write("Gold   : ");
		ConsoleUI.Write(ConsoleColor.DarkRed, player.Gold.ToString());
		Console.WriteLine(" G\n");

		ConsoleUI.Write(ConsoleColor.DarkRed, "0");
		Console.WriteLine(". 나가기\n");

		Console.WriteLine("원하시는 행동을 입력해주세요.");
		ConsoleUI.Write(ConsoleColor.Yellow, ">> ");
		var currentCursor = Console.GetCursorPosition();
		
		int inputNumber = -1;
		while (true)
		{
			if (int.TryParse(Console.ReadLine(), out inputNumber) == true)
			{
				if (inputNumber == 0)
					break ;
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
				return ;
		}
	}
}