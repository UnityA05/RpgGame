public class MainPage
{
	public void GameStart()
	{
		Console.Clear();
		Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
		Console.WriteLine("이제 전투를 시작하실 수 있습니다.");
		Console.WriteLine();

		ConsoleUI.Write(ConsoleColor.DarkRed, "1");
		Console.WriteLine(". 상태 보기");
		ConsoleUI.Write(ConsoleColor.DarkRed, "2");
		Console.WriteLine(". 전투 시작");
		Console.WriteLine();

		Console.WriteLine("원하시는 행동을 입력해주세요.");
		ConsoleUI.Write(ConsoleColor.Yellow, ">> ");
		var currentCursor = Console.GetCursorPosition();
		
		int inputNumber = 0;
		while (true)
		{
			if (int.TryParse(Console.ReadLine(), out inputNumber) == true)
			{
				if (inputNumber == 1 || inputNumber == 2)
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
				break;
			case 2:
				break;
		}
	}
}