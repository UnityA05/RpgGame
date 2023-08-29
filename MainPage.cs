using System.Drawing;
using SprtaGame;

public class MainPage
{
	public void GameStart()
	{
		Console.Clear();
		Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
		Console.WriteLine("이제 전투를 시작하실 수 있습니다.\n");

		ConsoleUI.Write(ConsoleColor.DarkRed, "1");
		Console.WriteLine(". 상태 보기");
		ConsoleUI.Write(ConsoleColor.DarkRed, "2");
		Console.WriteLine(". 전투 시작\n");

		Console.WriteLine("원하시는 행동을 입력해주세요.");
		ConsoleUI.Write(ConsoleColor.Yellow, ">> ");
		var currentCursor = Console.GetCursorPosition();
		
		int inputNumber = -1;
		while (true)
		{
			if (int.TryParse(Console.ReadLine(), out inputNumber) == true)
			{
				if ( inputNumber == 0 || inputNumber == 1 || inputNumber == 2 || inputNumber == 3)
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
				Inventory.DisplayInven();
				break;
			case 1:
				Status();
				break;
			case 2:
				break;
			case 3:
				Shop.DisplayShop();
				break;
		}
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

		Console.Write("Gold : ");
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
				GameStart();
				break;
		}
	}
}