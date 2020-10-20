﻿using System;
using System.Collections.Generic;
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

        public void StartGame()
        {
            IntroGame();
            while (gameCon == true) {
                BattleProgressEvent();
                shop.ShopEvent();
                WeaponPurchase();
            }
        }

        public void BattleProgressEvent()
        {
            Console.WriteLine("Enter (w) to progress further");
            char move = Convert.ToChar(Console.ReadLine());
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: {0} Strenght: {1} Weapon: {2}\n", player.FullHitpoints, player.MaxHit, shop.WepList[weaponBuy].Name);
            Console.ResetColor();
            var loc = Location2.GetLocations()[c];
            var monst = Monsterlist.GetMonsters()[c];
            Console.WriteLine("You have reached {0} of the dungeon, a monstrous shadow stands before you its {1}!!", loc.DungeonName, monst.Name);
            Console.WriteLine("Press (q) to engage in battle or (e) to retreat!");
            move = Convert.ToChar(Console.ReadLine());
            if (move == 'q')
            {
                Battle.StartFight(player, monst);
            }
            else if(move == 'e')
            {
                monst.MaxHit = monst.MaxHit * 2;
                monst.FullHitpoints = monst.FullHitpoints * 2;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("YOU FOOL THERES NO ESCAPE FROM HELL {0} HAS ENRAGED AND DOUBLED ITS STATS", monst.Name);
                Console.WriteLine("Press (q) to engage in battle quick you fool!!!");
                Console.ResetColor();
                char fight = Convert.ToChar(Console.ReadLine());
                Battle.StartFight(player, monst);
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
            char progress = Convert.ToChar(Console.ReadLine());
        }

        public void WeaponPurchase()
        {
            Console.WriteLine("\nEnter a number to buy the weapon");
            weaponBuy = Convert.ToInt32(Console.ReadLine());
            if (weaponBuy == 5)
            {
                shop.ShopEvent();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Congratulations you bought {0}!\n", shop.WepList[weaponBuy].Name);
            Console.ResetColor();
            var purchase = shop.GetWeapons()[weaponBuy];
            player.MaxHit = player.MaxHit + purchase.Damage;
        }

        public void IntroGame()
        {
            Console.WriteLine("Enter your name adventurer!");
            string playerName = Console.ReadLine();
            player.Name = playerName;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Health: {0} Strenght: {1} Weapon: {2}\n", player.FullHitpoints, player.MaxHit, shop.WepList[0].Name);
            Console.ResetColor();
            Console.WriteLine("Hello {0} you are now starting your journey to conquer all the dungeons!", player.Name);
            Console.WriteLine("You enter the first dungeon Darnassus\n");
        }

    }
}

