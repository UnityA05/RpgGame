public static class ConsoleUI
{
   public static void Write(ConsoleColor color, string str)
	{
		Console.ForegroundColor = color;
		Console.Write(str);
		Console.ResetColor();
	}
}