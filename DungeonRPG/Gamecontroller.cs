using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    public class Gamecontroller
    {
        
        Player player = new Player("Minh", 200, 15);

        Monsters Lichking = new Monsters("Lich King", 100, 10);
        Monsters Sylvanas = new Monsters("Sylvanas", 100, 10);
        Monsters Arthas = new Monsters("Arthas", 100, 10);
        Monsters Alexstrasza = new Monsters("Alexstrasza", 100, 10);
        Monsters Malygos = new Monsters("Malygos", 100, 10);
        Locationprint Location2 = new Locationprint();
        Random rnd = new Random();


        public void StartGame()
        {
            Console.WriteLine("Enter your name adventurer!");
            string playerName = Console.ReadLine();
            player.Name = playerName;
            Console.Clear();
            Console.WriteLine("Health: {0} Strenght: {1}", player.FullHitpoints, player.MaxHit);
            Console.WriteLine("Hello {0} you are now starting your journey go Left(l) or Right(r)?", player.Name);
            Console.Clear();
            char move = Convert.ToChar(Console.ReadLine());
            var yolo = Location2.GetLocations()[0];
            Console.WriteLine("You are now in {0} ",yolo.DungeonName);
            Console.ReadLine();
        }
    }
}

