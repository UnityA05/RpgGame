namespace SprtaGame
{
    internal class Program
    {
        public static Player defaultPlayer = new();
        public static Inventory inventory = new Inventory();
        public static Shop shop = new Shop();
        static void Main(string[] args)
        {//게임을 시작하는 객체를 만들고 시작
            MainPage mainPage = new();
            mainPage.GameStart();
        }
    }
}