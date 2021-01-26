using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    public class Battle
    {
        
        public static void StartFight(Player warrior1, Monsters warrior2)
        {
            Random rnd = new Random();
            while (true)
            {

                if (GetAttackResult(warrior1, warrior2) == "Game Over")
                {
                    int hpGain = rnd.Next(10, 80);
                    int coinsGain = rnd.Next(50, 200);
                    warrior1.FullHitpoints = warrior1.FullHitpoints + hpGain;
                    warrior1.Coins = warrior1.Coins + coinsGain;
                    warrior1.Mana = warrior1.Mana + 50;
                    Console.WriteLine("\nYou gain {0} Hitpoints, {1} coins and 50 mana!",hpGain, coinsGain);
                    break;
                }
                if (GetAttackResult2(warrior2, warrior1) == "Game Over")
                {
                    break;
                }
            }
        }

        public static void PrintHpMana(Player warrior, Monsters monstardo)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("{2} - Health: {0} Mana: {1}          {3} - Health: {4}", warrior.FullHitpoints, warrior.Mana, warrior.Name, monstardo.Name, monstardo.FullHitpoints);
            Console.ResetColor();
        }

        public static void UltimateAttack(Player warriorA, Monsters warriorB)
        {
            int warAAttkAmt = warriorA.Attack();
            int dmg2WarB = warAAttkAmt;
            Random rnd = new Random();
            bool manaLoop = true;
            int hitOrMiss = rnd.Next(1, 4);
            while (manaLoop == true)
            {
                if (warriorA.Mana < 50)
                {
                    Console.WriteLine("\nYou dont got enough mana to use this ability!\n");
                    Console.WriteLine("\n                     *");
                    Console.WriteLine("                ***  *                           ***");
                    Console.WriteLine("                ***  *                           ***");
                    Console.WriteLine("                 *   *                     *****  *");
                    Console.WriteLine("                 *  ***                       **  *");
                    Console.WriteLine("                 *****                     ********");
                    Console.WriteLine("                 *   *                        **  *");
                    Console.WriteLine("                 *                         *****  *");
                    Console.WriteLine("                 *                                *");
                    Console.WriteLine("                | |                              | |");
                    Console.WriteLine("\n");
                    PrintHpMana(warriorA, warriorB);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n(1) Attack (2) Ultimate Risk Attack 50% Hitchance(-50 mana)  (3) Regen 100 HP(-35 mana)");
                    Console.ResetColor();
                    int attackChoice = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    if (attackChoice == 1)
                    {
                        manaLoop = false;
                        NormalAttack(warriorA,warriorB);
                    }
                    if (attackChoice == 2)
                    {
                        manaLoop = true;
                    }
                    else if (attackChoice == 3)
                    {
                        manaLoop = false;
                        Heal100HP(warriorA, warriorB);
                    }
                    else
                    {
                        manaLoop = false;
                    }
                }
                else
                {
                    if (hitOrMiss == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Jackpot!! Your ultimate ability hit!\n");
                        Console.ResetColor();
                        Console.WriteLine("\n                     *");
                        Console.WriteLine("                ***  *                           ***");
                        Console.WriteLine("                ***  *                           ***");
                        Console.WriteLine("                 *   *                     *****  *");
                        Console.WriteLine("                 *  ***                       **  *");
                        Console.WriteLine("                 *****                     ********");
                        Console.WriteLine("                 *   *                        **  *");
                        Console.WriteLine("                 *                         *****  *");
                        Console.WriteLine("                 *                                *");
                        Console.WriteLine("                | |                              | |");
                        Console.WriteLine("\n");
                        dmg2WarB = dmg2WarB + 10 * 3;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Your Ultimate ability missed too bad!!\n");
                        Console.ResetColor();
                        dmg2WarB = 0;
                    }
                    warriorA.Mana -= 50;
                    if (dmg2WarB > 0)
                    {
                        warriorB.FullHitpoints = warriorB.FullHitpoints - dmg2WarB;
                    }
                    else
                    {
                        dmg2WarB = 0;
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0} Attacks {1} and Deals {2} Damage",
                        warriorA.Name, warriorB.Name, dmg2WarB);
                    Console.ResetColor();
                    Console.WriteLine("{0} Has {1} Health \n", warriorB.Name, warriorB.FullHitpoints);
                    manaLoop = false;
                }
            }
        }

        public static void Heal100HP(Player warriorA, Monsters warriorB)
        {
            int warAAttkAmt = warriorA.Attack();
            int dmg2WarB = warAAttkAmt;
            bool manaLoop2 = true;
            while (manaLoop2 == true)
            {
                if (warriorA.Mana < 35)
                {
                    Console.WriteLine("\nYou dont got enough mana to use this ability!\n");
                    PrintHpMana(warriorA, warriorB);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n(1) Attack (2) Ultimate Risk Attack(-50 mana)  (3) Regen 100 HP(-35 mana)");
                    Console.ResetColor();
                    int attackChoice = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    if (attackChoice == 3)
                    {
                        manaLoop2 = true;
                    }
                    else if(attackChoice == 2)
                    {
                        manaLoop2 = false;
                        UltimateAttack(warriorA, warriorB);
                    }
                    else if (attackChoice == 1)
                    {
                        manaLoop2 = false;
                        NormalAttack(warriorA, warriorB);
                    }
                    else
                    {
                        manaLoop2 = false;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("You healed 100 HP yay!\n");
                    Console.ResetColor();
                    dmg2WarB = 0;
                    warriorA.FullHitpoints += 100;
                    warriorA.Mana -= 35;
                    manaLoop2 = false;
                }
            }
        }

        public static void NormalAttack(Player warriorA, Monsters warriorB)
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} Attacks {1} and Deals {2} Damage",
                warriorA.Name, warriorB.Name, dmg2WarB);
            Console.ResetColor();
            Console.WriteLine("{0} Has {1} Health \n", warriorB.Name, warriorB.FullHitpoints);
        }

        public static string GetAttackResult(Player warriorA, Monsters warriorB)
        {            
            int warAAttkAmt = warriorA.Attack();
            int dmg2WarB = warAAttkAmt;
            Random rnd = new Random();
            Console.WriteLine("\n                     *");
            Console.WriteLine("                ***  *                           ***");
            Console.WriteLine("                ***  *                           ***");
            Console.WriteLine("                 *   *                     *****  *");
            Console.WriteLine("                 *  ***                       **  *");
            Console.WriteLine("                 *****                     ********");
            Console.WriteLine("                 *   *                        **  *");
            Console.WriteLine("                 *                         *****  *");
            Console.WriteLine("                 *                                *");
            Console.WriteLine("                | |                              | |");
            Console.WriteLine("\n");
            PrintHpMana(warriorA, warriorB);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n(1) Attack (2) Ultimate Risk Attack(-50 mana)  (3) Regen 100 HP(-35 mana)");
            Console.ResetColor();
            int attackChoice = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("\n");
            if (attackChoice == 1)
            {
                NormalAttack(warriorA,warriorB);
            }
            else if (attackChoice == 2)
            {
                UltimateAttack(warriorA,warriorB);
            }
            else if (attackChoice == 3)
            {
                Heal100HP(warriorA,warriorB);
            }
            else
            {
                NormalAttack(warriorA, warriorB);
            }


            if (warriorB.FullHitpoints <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0} has Died and {1} is Victorious!!!\n",
                    warriorB.Name, warriorA.Name);
                Console.ResetColor();
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0} Attacks {1} and Deals {2} Damage",
                warriorA.Name, warriorB.Name, dmg2WarB);
            Console.ResetColor();
            Console.WriteLine("{0} Has {1} Health \n", warriorB.Name, warriorB.FullHitpoints);
            if (warriorB.FullHitpoints <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} has Died and {1} is Victorious!!!\n",
                    warriorB.Name, warriorA.Name);
                Console.WriteLine("YOU DIED TO {0}?? HOW SHAMEFUL BEGONE NOOB!" ,warriorA.Name);
                Console.WriteLine("\n\nPress a key to Revive");
                Console.ReadLine();
                Console.ResetColor();
                return "Game Over";
            }
            else return "Fight Again";
        }
    }
}
