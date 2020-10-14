using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    public class Gamecontroller
    {
        
        Player player = new Player("Minh", 200, 15);
        Locationprint Location2 = new Locationprint();
        MonsterList Monsterlist = new MonsterList();
        Random rnd = new Random();

        bool gameCon = true;
        int c = 0;

        public void StartGame()
        {
            Console.WriteLine("Enter your name adventurer!");
            string playerName = Console.ReadLine();
            player.Name = playerName;
            Console.Clear();
            Console.WriteLine("Health: {0} Strenght: {1}", player.FullHitpoints, player.MaxHit);
            Console.WriteLine("Hello {0} you are now starting your journey to conquer all the dungeons!", player.Name);
            Console.WriteLine("You enter the first dungeon Darnassus");
            while (gameCon == true) { 
                MovePlayer();
            }

        }

        public void MovePlayer()
        {
            Console.WriteLine("Enter (w) to progress further");
            char move = Convert.ToChar(Console.ReadLine());
            var loc = Location2.GetLocations()[c];
            var monst = Monsterlist.GetMonsters()[c];
            Console.WriteLine("You have reached {0} a monstrous shadow stands before you", loc.DungeonName);
            Console.WriteLine("Press (q) to engage in battle or (e) to retreat!");
            move = Convert.ToChar(Console.ReadLine());
            if (move == 'q')
            {
                Console.WriteLine("You have engaged the monster {0}", monst.Name);
                Battle.StartFight(player, monst);
            }
            else if(move == 'e')
            {
                monst.MaxHit = monst.MaxHit * 2;
                monst.FullHitpoints = monst.FullHitpoints * 2;
                Console.WriteLine("YOU FOOL THERES NO ESCAPE FROM HELL {0} HAS ENRAGED AND DOUBLED ITS STATS", monst.Name);
            }
            c++;
        }
    }
}

