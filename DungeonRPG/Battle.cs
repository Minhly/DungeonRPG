using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    class Battle : Gamecontroller
    {
        public static void StartFight(Player warrior1, Monsters warrior2)
        {
            while (true)
            {
                if (GetAttackResult(warrior1, warrior2) == "Game Over")
                {
                    Console.WriteLine("Game Over");
                    warrior1.FullHitpoints = warrior1.FullHitpoints + 30;
                    warrior1.MaxHit = warrior1.MaxHit + 50;
                    break;
                }
                if (GetAttackResult2(warrior2, warrior1) == "Game Over")
                {
                    Console.WriteLine("Game Over");
                    warrior1.FullHitpoints = warrior1.FullHitpoints + 30;
                    warrior1.MaxHit = warrior1.MaxHit + 50;
                    break;
                }
            }
        }

        public static string GetAttackResult(Player warriorA, Monsters warriorB)
        {
            int warAAttkAmt = warriorA.Attack();

            int dmg2WarB = warAAttkAmt;

            if (dmg2WarB > 0)
            {
                warriorB.FullHitpoints = warriorB.FullHitpoints - dmg2WarB;
            }
            else 
            { 
                dmg2WarB = 0; 
            }

            Console.WriteLine("{0} Attacks {1} and Deals {2} Damage",
                warriorA.Name, warriorB.Name, dmg2WarB);

            Console.WriteLine("{0} Has {1} Health \n", warriorB.Name, warriorB.FullHitpoints);

            if (warriorB.FullHitpoints <= 0)
            {
                Console.WriteLine("{0} has Died and {1} is Victorious\n",
                    warriorB.Name, warriorA.Name);
                return "Game Over";
            }
            else return "Fight Again";
        }

        public static string GetAttackResult2(Monsters warriorA, Player warriorB)
        {
            int warAAttkAmt = warriorA.Attack();

            int dmg2WarB = warAAttkAmt;

            if (dmg2WarB > 0)
            {
                warriorB.FullHitpoints = warriorB.FullHitpoints - dmg2WarB;
            }
            else dmg2WarB = 0;

            Console.WriteLine("{0} Attacks {1} and Deals {2} Damage",
                warriorA.Name, warriorB.Name, dmg2WarB);

            Console.WriteLine("{0} Has {1} Health \n", warriorB.Name, warriorB.FullHitpoints);

            if (warriorB.FullHitpoints <= 0)
            {
                Console.WriteLine("{0} has Died and {1} is Victorious\n",
                    warriorB.Name, warriorA.Name);
                return "Game Over";
            }
            else return "Fight Again";
        }
    }
}
