﻿namespace SprtaGame
{
    internal class Program
    {
        public static List<Player> playerList = new();
        public static Player defaultPlayer;
        public static itemCode itemMake = new();
        public static Shop shop = new();
        static void Main(string[] args)
        {//게임을 시작하는 객체를 만들고 시작
			Program.playerList.Add(new Player());
            MainPage.GameStart();
        }
    }
}