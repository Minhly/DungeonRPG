using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DungeonRPG
{
    public class Gamecontroller
    {
        Player player = new Player("Minh", 50, 15, 0, 1, "Stick of truth", 100);
        Locationprint Location2 = new Locationprint();
        MonsterList Monsterlist = new MonsterList();
        Shop shop = new Shop();
        int weaponBuy = 0;
        bool gameCon = true;
        int c = 0;
        int counterC = 0;
        Random gambah = new Random();
        List<Weapon> WepList;
        public void StartGame()
        {
            IntroGame();
            while (gameCon == true) {
                BattleProgressEvent();
                ShopEvent();
            }
            Console.ReadLine();
        }

        public void BattleEngage()
        {
            Console.Clear();
            PrintStatsGear();
            var loc = Location2.GetLocations()[c];
            var monst = Monsterlist.GetMonsters()[c];
            Console.WriteLine("\nYou have reached {0}, a monstrous shadow stands before you its {1}!!\n", loc.DungeonName, monst.Name);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress (w) to engage in battle or (e) to retreat for better chances!");
            Console.ResetColor();
            char move = Convert.ToChar(Console.ReadLine());
            Console.Clear();
            if (move == 'w')
            {
                Battle.StartFight(player, monst);

            }
            else
            {
                RandomRetreatEvent();
            }
            if (player.FullHitpoints <= 0)
            {
                DeathScreen();
            }
            c++;
            if (c == 9)
            {
                WinnerScreen();
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nEnter (w) to progress further");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
            StoryTelling();
        }

        public void BattleProgressEvent()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nEnter any (key) to progress further");
            Console.ResetColor();
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
                Console.WriteLine("\n(1) Weaponry shop ");
                Console.WriteLine("\n(2) Hitpoints and Strenght shop");
                Console.WriteLine("\n(3) Gamble all coins");
                Console.WriteLine("\n\n(w) Progress further");
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
            Console.WriteLine("(2) Hitpoints + 150 = 60 Coins");
            Console.WriteLine("(3) Mana + 50 = 30 Coins");
            Console.WriteLine("(4) Strenght + 5 = 20 Coins");
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
                    Console.ReadLine();
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
                    Console.ReadLine();
                    ShopEvent();
                }
            }
            else if (buyHp == '2')
            {
                if (player.Coins < 85)
                {
                    Console.WriteLine("\nYou are too poor to afford this!");
                    Console.WriteLine("Press anything to get back to shop:");
                    Console.ReadLine();
                    BuyHitpointsAndStrenghtShop();
                }
                else
                {
                    player.Coins = player.Coins - 60;
                    player.FullHitpoints = player.FullHitpoints + 150;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCongratulations you paid 60 coins and bought 150 Hitpoints!\n");
                    Console.WriteLine("New balance: {0}\n", player.Coins);
                    Console.ResetColor();
                    Console.WriteLine("Press anything to get back to shop:");
                    Console.ReadLine();
                    ShopEvent();
                }
            }
            else if (buyHp == '4')
            {
                if (player.Coins < 50)
                {
                    Console.WriteLine("\nYou are too poor to afford this!");
                    Console.WriteLine("Press anything to get back to shop:");
                    Console.ReadLine();
                    BuyHitpointsAndStrenghtShop();
                }
                else
                {
                    player.Coins = player.Coins - 20;
                    player.MaxHit = player.MaxHit + 5;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCongratulations you paid 20 coins and bought +5 Strenght!\n");
                    Console.WriteLine("New balance: {0}\n", player.Coins);
                    Console.ResetColor();
                    Console.WriteLine("Press anything to get back to shop:");
                    Console.ReadLine();
                    ShopEvent();
                }
            }
            else if (buyHp == '3')
            {
                if (player.Coins < 30)
                {
                    Console.WriteLine("\nYou are too poor to afford this!");
                    Console.WriteLine("Press anything to get back to shop:");
                    Console.ReadLine();
                    BuyHitpointsAndStrenghtShop();
                }
                else
                {
                    player.Coins = player.Coins - 30;
                    player.Mana = player.Mana + 50;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nCongratulations you paid 30 coins and bought 50 Mana!\n");
                    Console.WriteLine("New balance: {0}\n", player.Coins);
                    Console.ResetColor();
                    Console.WriteLine("Press anything to get back to shop:");
                    Console.ReadLine();
                    ShopEvent();
                }
            }
            else if (buyHp == '5')
            {
                ShopEvent();
            }
        }

        public void WeaponPurchase()
        {
            WepList = shop.GetWeapons();
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
            if(WepList[weaponBuy].Price > player.Coins)
            {
                Console.WriteLine("\nYou are too poor to afford this weapon!!");
                Console.WriteLine("Try again!\n");
                WeaponPurchase();
            }
            else {
            var purchase = shop.GetWeapons()[weaponBuy];
            player.WeaponName = purchase.Name;
            player.Coins = player.Coins - purchase.Price;
            player.MaxHit = player.MaxHit + purchase.Damage;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCongratulations you paid {1} bought {0}!\n", WepList[weaponBuy].Name, WepList[weaponBuy].Price);
            WepList.RemoveAt(weaponBuy);
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

        public void WinnerScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCongratulations! You beat the hardest dungeon in the whole galaxy!");
            Console.WriteLine("Your reward is a life lesson!\n");
            Console.WriteLine("\nDon’t hesitate when you should act\n");
            Console.WriteLine("Good things don’t come easy\n");
            Console.WriteLine("Take care of your health early\n\n");
            Console.ResetColor();
            Console.WriteLine("Now get out there and make the best you can out of your life!");
            Console.ReadLine();
            gameCon = false;
        }

        public void DeathScreen()
        {
            Console.Clear();
            var loc = Location2.GetLocations()[c];
            var monst = Monsterlist.GetMonsters()[c];
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nRevive?? DONT MAKE ME LAUGH!");
            Console.WriteLine("\nI expected this from the start WEAKLING! NOW I SHALL DEVOUR YOUR SOUL!\n\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You died at {0} wielding {1} having the powerlevel of {2}\n",loc.DungeonName, player.WeaponName, player.MaxHit);
            Console.WriteLine("Imagine dying to {0} Muhahahah", monst.Name);
            Console.ResetColor();
            Console.ReadLine();
            gameCon = false;
        }

        public void RandomPortalEvent()
        {
            int coinsRoll = gambah.Next(1, 100);
            int eventRoll = gambah.Next(1, 5);
            char questionAnswer;
            if(eventRoll == 1)
            {
                Console.Clear();
                int questionRoll = gambah.Next(1, 5);
                Console.WriteLine("Devils question time!!!\n");
                if(questionRoll == 1)
                {
                    Console.WriteLine("What month of the year has 28 days?");
                    Console.WriteLine("(1) Febuary  (2) April  (3) November  (4) All of them!  ");
                    questionAnswer = Convert.ToChar(Console.ReadLine());
                    if (questionAnswer == '4')
                    {
                        coinsRoll = gambah.Next(1, 100);
                        player.Coins += coinsRoll;
                        Console.WriteLine("\nCorrect! you have just earned urself {0} coins!\n",coinsRoll);
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        coinsRoll = gambah.Next(1, 50);
                        player.Coins -= coinsRoll;
                        Console.WriteLine("\nMuhahahha WRONG YOU FOOL!\n");
                        Console.WriteLine("You Lose {0} coins!", coinsRoll);
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadLine();
                    }
                }
                else if(questionRoll == 2)
                {
                    Console.WriteLine("Horde or Alliance?");
                    Console.WriteLine("(1) Horde  (2) Alliance");
                    questionAnswer = Convert.ToChar(Console.ReadLine());
                    if (questionAnswer == '2')
                    {
                        coinsRoll = gambah.Next(1, 100);
                        player.Coins += coinsRoll;
                        Console.WriteLine("\nFOR THE ALLIANCE!");
                        Console.WriteLine("\nCorrect! you have just earned urself {0} coins!\n", coinsRoll);
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        coinsRoll = gambah.Next(1, 50);
                        player.Coins -= coinsRoll;
                        Console.WriteLine("\nWrong you horde scum!\n");
                        Console.WriteLine("You Lose {0} coins!", coinsRoll);
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadLine();
                    }
                }
                else if (questionRoll == 3)
                {
                    Console.WriteLine("How many times has Trump tweeted in his 4 years as president?");
                    Console.WriteLine("(1) 18000  (2) 9000   (3) 34000   (4) 21000");
                    questionAnswer = Convert.ToChar(Console.ReadLine());
                    if (questionAnswer == '3')
                    {
                        coinsRoll = gambah.Next(1, 100);
                        player.Coins += coinsRoll;
                        Console.WriteLine("\nCorrect! you have just earned urself {0} coins!\n", coinsRoll);
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        coinsRoll = gambah.Next(1, 50);
                        player.Coins -= coinsRoll;
                        Console.WriteLine("\nWRONG!\n");
                        Console.WriteLine("You Lose {0} coins!", coinsRoll);
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadLine();
                    }
                }
                if (questionRoll == 4)
                {
                    Console.WriteLine("Are you still out there chasing ur dreams for happiness?");
                    Console.WriteLine("(1) Yes  (2) No");
                    questionAnswer = Convert.ToChar(Console.ReadLine());
                    if (questionAnswer == '1')
                    {
                        coinsRoll = gambah.Next(1, 200);
                        player.Coins += coinsRoll;
                        Console.WriteLine("\nThats what im talking about! Good luck friend!");
                        Console.WriteLine("\nYou have just earned urself {0} coins!\n", coinsRoll);
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        coinsRoll = gambah.Next(1, 80);
                        player.Coins -= coinsRoll;
                        Console.WriteLine("\nThen what are you waiting for? start living!\n");
                        Console.WriteLine("You Lose {0} coins!", coinsRoll);
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadLine();
                    }
                }
            }
            else if (eventRoll == 2 || eventRoll == 3)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the guessing game of death!\n");
                int guessNumberFirst = gambah.Next(2, 99);
                int guessNumberSecond = gambah.Next(1, 100);
                Console.WriteLine("Is the next number 1-100 (1)higher or (2)lower than {0}?", guessNumberFirst);
                char numberAnswer = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("\nThe number is {0}",guessNumberSecond);
                if (numberAnswer == '1')
                {
                    if (guessNumberSecond >= guessNumberFirst)
                    {
                        player.FullHitpoints += 50;
                        Console.WriteLine("\nYou guessed it right here have some health");
                        Console.WriteLine("You gain 50 health!");
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        player.FullHitpoints -= 20;
                        Console.WriteLine("\nYou failure begone!");
                        Console.WriteLine("You lose 20 health");
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadLine();
                    }

                }

                if (numberAnswer == '2')
                {
                    if (guessNumberSecond <= guessNumberFirst)
                    {
                        player.FullHitpoints += 50;
                        Console.WriteLine("\nYou guessed it right here have some health");
                        Console.WriteLine("You gain 50 health!");
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadLine();
                    }
                    else
                    {
                        player.FullHitpoints -= 20;
                        Console.WriteLine("\nYou failure begone!");
                        Console.WriteLine("You lose 20 health");
                        Console.WriteLine("\nPress any key to continue");
                        Console.ReadLine();
                    }

                }


            }
            else if (eventRoll == 4)
            {
                Console.Clear();
                player.MaxHit -= 5;
                Console.WriteLine("\nYou wake up from a deep sleep and see some demonic bug suck out ur strenght!");
                Console.WriteLine("\nYou Lose 5 strenght");
                Console.WriteLine("\nPress any key to continue");
                Console.ReadLine();
            }
            Console.Clear();
        }

        public void StoryTelling()
        {
            counterC++;
            if (counterC == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nI see you survived the first level beginners luck Muhahahaha!\n");
                Console.WriteLine("But then again your enemy was Joe there was never hope to begin with\n");
                Console.WriteLine("Now perish!\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nYou got thrown into a random portal");
                Console.WriteLine("Enter (w) to progress further");
                Console.ResetColor();
                Console.ReadLine();
                RandomPortalEvent();
            }
            else if (counterC == 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nYou sure have some balls thinking you can go further than this!\n");
                Console.WriteLine("After taking out my WAIFU!\n");
                Console.WriteLine("Valar Morghulis\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nYou got thrown into a random portal");
                Console.WriteLine("Enter (w) to progress further");
                Console.ResetColor();
                Console.ReadLine();
                RandomPortalEvent();
            }
            else if (counterC == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nOk ok Beating trump was impressive hes known for his great leadership\n");
                Console.WriteLine("You really want that treasure huh\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nYou got thrown into a random portal");
                Console.WriteLine("Enter (w) to progress further");
                Console.ResetColor();
                Console.ReadLine();
                RandomPortalEvent();
            }
            else if (counterC == 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nGoddammit why was the intern Vadim here today of all days!\n");
                Console.WriteLine("alright thats was a freebie enjoy it while i lasts!\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nYou got thrown into a random portal");
                Console.WriteLine("Enter (w) to progress further");
                Console.ResetColor();
                Console.ReadLine();
                RandomPortalEvent();
            }
            else if (counterC == 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nHow could you endure all of Alex's darkness without going insane!\n");
                Console.WriteLine("I see you are a follower of the dark side too\n");
                Console.WriteLine("Can you smell that? almost there young padawan\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nYou got thrown into a random portal");
                Console.WriteLine("Enter (w) to progress further");
                Console.ResetColor();
                Console.ReadLine();
                RandomPortalEvent();
            }
            else if (counterC == 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nImpressive you survived Kristian's full on attacks of Ostepops and Fries!\n");
                Console.WriteLine("Guess he wasnt able to find his true happiness afterall\n");
                Console.WriteLine("Gotta take care of yourself sometimes\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nYou got thrown into a random portal");
                Console.WriteLine("Enter (w) to progress further");
                Console.ResetColor();
                Console.ReadLine();
                RandomPortalEvent();
            }
            else if (counterC == 7)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo this cant be not even Kreddi-san could stop you?\n");
                Console.WriteLine("You even hurt his CAT!?!?!!\n");
                Console.WriteLine("Begone you monster!\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nYou got thrown into a random portal");
                Console.WriteLine("Enter (w) to progress further");
                Console.ResetColor();
                Console.ReadLine();
                RandomPortalEvent();
            }
            else if (counterC == 8)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nLooks like the RNGLord wasnt with Michael this time\n");
                Console.WriteLine("If only he went more TONK :'(\n");
                Console.WriteLine("What you seek is right ahead\n");
                Console.WriteLine("You think you got what it takes to take on Minheru?\n");
                Console.WriteLine("Not in this life you fool!\n");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nYou got thrown into a random portal");
                Console.WriteLine("Enter (w) to progress further");
                Console.ResetColor();
                Console.ReadLine();
                RandomPortalEvent();
            }
            
        }

        public void IntroGame()
        {
            Console.WriteLine("\nWho dares enter my domain speak thy name!");
            string playerName = Console.ReadLine();
            player.Name = playerName;
            Console.Clear();
            Console.WriteLine("\nWhat do you desire the most {0}?\n", player.Name);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("FORGET YOUR FOOLISH MORTAL DESIRES!!!!\n");
            Console.ResetColor();
            Console.WriteLine("In this dungeon you will learn what lives really about!\n");
            Console.WriteLine("What your heart truly desires lies deep within this Dungeon ahead of you\n");
            Console.WriteLine("But beware you might lose whats dearest to you on this journey\n");
            Console.WriteLine("Are you ready to start living?\n");
        }

        public void PrintStatsGear()
        {
            WepList = shop.GetWeapons();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n | Health: {0} |  Mana: {4} |  Strenght(maxhit): {1} |  Weapon: {2} dmg:{4} |  Coins: {3} | \n", player.FullHitpoints, player.MaxHit, player.WeaponName, player.Coins, player.Mana, player.WeaponDmg);
            Console.ResetColor();
        }

    }
}

