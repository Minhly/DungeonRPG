using System;

namespace DungeonRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Gamecontroller GameStart = new Gamecontroller();
            GameStart.StartGame();
            Console.ReadLine();
        }
    }
}
