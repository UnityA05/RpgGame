using SprtaGame;

public static class CharacterSelect
{
	public static void SelectPage()
	{
		while (true)
		{
			Console.Clear();
			ConsoleUI.Write(ConsoleColor.DarkYellow, "캐릭터 선택\n\n");
			Console.WriteLine("캐릭터를 선택해주세요.\n");
			
			List<Player> players = Program.playerList;
			for (int index = 0; index < 3; index++)
			{
				ConsoleUI.Write(ConsoleColor.DarkRed, $"{index + 1}");
				if (index + 1 <= players.Count)
					Console.WriteLine($". {players[index].Name} [ {players[index].job} ]");
				else
					Console.WriteLine(". E M P T Y   S L O T");
			}
			ConsoleUI.Write(ConsoleColor.DarkRed, "\n4");
			Console.WriteLine(". 캐릭터 생성");
			ConsoleUI.Write(ConsoleColor.DarkRed, "0");
			Console.WriteLine(". 뒤로 가기\n");

			ConsoleUI.Write(ConsoleColor.Yellow, "\n>> ");
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

			switch(inputNumber)
			{
				case 0:
					return ;
				case 1:
				case 2:
				case 3:
					if (inputNumber > players.Count)
						break ;
					Program.defaultPlayer = Program.playerList[inputNumber - 1];
					MainPage.InMainPage();
					break;
				case 4:
					MakeNewCharacter();
					break;
			}
		}
	}

	private static void MakeNewCharacter()
	{
		string name = SetName();
		string job = SetJob();
		Program.playerList.Add(new Player(name, job));
	}

	private static string SetName()
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

	private static string SetJob()
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
}