using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DungeonRPG
{
    public class Gamecontroller
    {
        Player player = new Player("Minh", 50, 15, 0, 0);
        Locationprint Location2 = new Locationprint();
        MonsterList Monsterlist = new MonsterList();
        Shop shop = new Shop();
        int weaponBuy = 0;
        bool gameCon = true;
        int c = 0;
        Random gambah = new Random();

        public void StartGame()
        {
            IntroGame();
            while (gameCon == true) {
                BattleProgressEvent();
                ShopEvent();
            }
        }

        public void BattleEngage()
        {
            Console.Clear();
            PrintStatsGear();
            var loc = Location2.GetLocations()[c];
            var monst = Monsterlist.GetMonsters()[c];
            Console.WriteLine("You have reached {0} of the dungeon, a monstrous shadow stands before you its {1}!!", loc.DungeonName, monst.Name);
            Console.WriteLine("Press (w) to engage in battle or (e) to retreat!");
            char move = Convert.ToChar(Console.ReadLine());
            if (move == 'w')
            {
                Battle.StartFight(player, monst);
            }
            else if (move == 'e')
            {
                RandomRetreatEvent();
            }
            c++;
            if (c == 9)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nCONGRATULATIONS YOU SURVIVED THE EPIC DUNGEON AND THE REWARD WAS ALL THE FRIENDS YOU MADE ALONG THE WAY!");
                Console.ResetColor();
                gameCon = false;
            }
            Console.WriteLine("\nEnter (w) to progress further");
            Console.ReadLine();
            Console.Clear();
        }

        public void BattleProgressEvent()
        {
            Console.WriteLine("Enter any (key) to progress further");
            Console.ReadLine();
            BattleEngage();
        }

        public void RandomRetreatEvent()
        {
            int randomEvent = gambah.Next(1, 6);
            if(randomEvent == 1 || randomEvent == 2)
            {
                var monst = Monsterlist.GetMonsters()[c];
                monst.MaxHit = monst.MaxHit * 2;
                monst.FullHitpoints = monst.FullHitpoints * 2;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("YOU FOOL THERES NO ESCAPE FROM HELL {0} HAS ENRAGED AND DOUBLED ITS STATS", monst.Name);
                Console.WriteLine("Press (w) to engage in battle quick you fool!!!");
                Console.ResetColor();
                char fight = Convert.ToChar(Console.ReadLine());
                Battle.StartFight(player, monst);
            }
            else if (randomEvent == 3)
            {
                Console.WriteLine("While fleeing the battle half your coins fell out of your pocket how unlucky!");
                player.Coins = player.Coins / 2;
            }
            else if (randomEvent == 4)
            {
                Console.WriteLine("You got away safely and found a chest on the way!");
                Console.WriteLine("You open it and find 100 coins!");
                player.Coins = player.Coins + 100;
                Console.WriteLine("You now have {0} coins", player.Coins);
            }
            else if (randomEvent == 5)
            {
                Console.WriteLine("While retreating you step on a lego and take 30 damage!");
                player.FullHitpoints = player.FullHitpoints - 30;
            }
        }

        public void ShopEvent()
        {
            Console.Clear();
            bool shopLoop = true;
            while (shopLoop)
            {
                Console.WriteLine("(1) Weaponry shop ");
                Console.WriteLine("(2) Hitpoints and Strenght shop");
                Console.WriteLine("(3) Gamble all coins");
                Console.WriteLine("(w) Progress further");
                PrintStatsGear();
                Console.WriteLine("What do you wanna do?:");
                char shopMenu = Convert.ToChar(Console.ReadLine());

                switch (shopMenu)
                {
                    case '1':
                        shop.WeaponShop();
                        WeaponPurchase();
                        break;

                    case '2':
                        BuyHitpointsAndStrenghtShop();
                        break;

                    case '3':
                        GambleCoins();
                        break;

                    case 'w':
                        BattleEngage();
                        break;

                    default:
                        break;
                }
            }
        }

        public void BuyHitpointsAndStrenghtShop()
        {
            Console.Clear();
            Console.WriteLine("(1) Hitpoints + 10 = 20 Coins");
            Console.WriteLine("(2) Hitpoints + 20 = 35 Coins");
            Console.WriteLine("(3) Hitpoints + 50 = 75 Coins");
            Console.WriteLine("(4) Strenght + 5 = 50 Coins");
            Console.WriteLine("(5) Exit");
            PrintStatsGear();
            Console.WriteLine("Enter number to buy or exit:");
            char buyHp = Convert.ToChar(Console.ReadLine());
            if (buyHp == '1')
            {
                if (player.Coins < 20)
                {
                    Console.WriteLine("\nYou are too poor to afford this!");
                    Console.WriteLine("Press anything to get back to shop:");
                    char huehue = Convert.ToChar(Console.ReadLine());
                    BuyHitpointsAndStrenghtShop();
                }
                else {
                    player.Coins = player.Coins - 20;
                    player.FullHitpoints = player.FullHitpoints + 10;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCongratulations you paid 20 coins and bought 10 Hitpoints!\n");
                    Console.WriteLine("New balance: {0}\n", player.Coins);
                    Console.ResetColor();
                    Console.WriteLine("Press anything to get back to shop:");
                    char huehue = Convert.ToChar(Console.ReadLine());
                    ShopEvent();
                }
            }
            else if (buyHp == '2')
            {
                if (player.Coins < 50)
                {
                    Console.WriteLine("\nYou are too poor to afford this!");
                    Console.WriteLine("Press anything to get back to shop:");
                    char huehue = Convert.ToChar(Console.ReadLine());
                    BuyHitpointsAndStrenghtShop();
                }
                else
                {
                    player.Coins = player.Coins - 35;
                    player.FullHitpoints = player.FullHitpoints + 20;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCongratulations you paid 35 coins and bought 20 Hitpoints!\n");
                    Console.WriteLine("New balance: {0}\n", player.Coins);
                    Console.ResetColor();
                    Console.WriteLine("Press anything to get back to shop:");
                    char huehue = Convert.ToChar(Console.ReadLine());
                    ShopEvent();
                }
            }
            else if (buyHp == '4')
            {
                if (player.Coins < 50)
                {
                    Console.WriteLine("\nYou are too poor to afford this!");
                    Console.WriteLine("Press anything to get back to shop:");
                    char huehue = Convert.ToChar(Console.ReadLine());
                    BuyHitpointsAndStrenghtShop();
                }
                else
                {
                    player.Coins = player.Coins - 50;
                    player.MaxHit = player.MaxHit + 5;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCongratulations you paid 50 coins and bought +5 Strenght!\n");
                    Console.WriteLine("New balance: {0}\n", player.Coins);
                    Console.ResetColor();
                    Console.WriteLine("Press anything to get back to shop:");
                    char huehue = Convert.ToChar(Console.ReadLine());
                    ShopEvent();
                }
            }
            else if (buyHp == '3')
            {
                if (player.Coins < 75)
                {
                    Console.WriteLine("\nYou are too poor to afford this!");
                    Console.WriteLine("Press anything to get back to shop:");
                    char huehue = Convert.ToChar(Console.ReadLine());
                    BuyHitpointsAndStrenghtShop();
                }
                else
                {
                    player.Coins = player.Coins - 75;
                    player.FullHitpoints = player.FullHitpoints + 50;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCongratulations you paid 75 coins and bought 50 Hitpoints!\n");
                    Console.WriteLine("New balance: {0}\n", player.Coins);
                    Console.ResetColor();
                    Console.WriteLine("Press anything to get back to shop:");
                    char huehue = Convert.ToChar(Console.ReadLine());
                    ShopEvent();
                }
            }
            else
            {
                ShopEvent();
            }
        }

        public void WeaponPurchase()
        {
            PrintStatsGear();
            Console.WriteLine("\nEnter a number to buy the weapon");
            weaponBuy = Convert.ToInt32(Console.ReadLine());  
            if (weaponBuy == 11) {
                weaponBuy = 0;
                ShopEvent();
                PrintStatsGear();
                Console.WriteLine("\nEnter a number to buy the weapon");
                weaponBuy = Convert.ToInt32(Console.ReadLine());
            }
            if(shop.WepList[weaponBuy].Price > player.Coins)
            {
                Console.WriteLine("\nYou are too poor to afford this weapon!!");
                Console.WriteLine("Try again!\n");
                WeaponPurchase();
            }
            else {
            var purchase = shop.GetWeapons()[weaponBuy];
            player.Coins = player.Coins - purchase.Price;
            player.MaxHit = player.MaxHit + purchase.Damage;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCongratulations you paid {1} bought {0}!\n", shop.WepList[weaponBuy].Name, shop.WepList[weaponBuy].Price);
            Console.WriteLine("New balance: {0}\n", player.Coins);
            Console.ResetColor();
            Console.ReadLine();
            ShopEvent();
            }
        }

        public void GambleCoins()
        {
            Console.Clear();
            PrintStatsGear();
            int gambleRoll = gambah.Next(1, 3);
            Console.WriteLine("Welcome to the Casino of misfortune");
            Console.WriteLine("Press (1) to gamble all your coins or (2) to exit");
            char gambleAll = Convert.ToChar(Console.ReadLine());
            if(gambleAll == '1')
            {
                
                if(gambleRoll == 1)
                {
                    gambleRoll = gambah.Next(1, 3);
                    player.Coins = player.Coins * 2;
                    Console.WriteLine("Goddamn you actually won!!! moneys doubled!!");
                    Console.WriteLine("press any key to continoue");
                    Console.ReadLine();
                    GambleCoins();

                }
                else if(gambleRoll == 2)
                {
                    player.Coins = 0;
                    Console.WriteLine("Too bad you lost it all pres any key to get outta here!");
                    Console.ReadLine();
                    ShopEvent();

                }
            }
            else
            {
                ShopEvent();
            }
        }

        public void IntroGame()
        {
            Console.WriteLine("Enter your name adventurer!");
            string playerName = Console.ReadLine();
            player.Name = playerName;
            Console.Clear();
            PrintStatsGear();
            Console.WriteLine("Hello {0} you are now starting your journey to conquer all the dungeons!", player.Name);
            Console.WriteLine("You enter the first dungeon Darnassus\n");
        }

        public void PrintStatsGear()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nHealth: {0} Strenght: {1} Weapon: {2} Coins: {3}\n", player.FullHitpoints, player.MaxHit, shop.WepList[weaponBuy].Name, player.Coins);
            Console.ResetColor();
        }

    }
}

