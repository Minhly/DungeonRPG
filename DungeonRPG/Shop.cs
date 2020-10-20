using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    public class Shop
    {
        public Weapon[] WepList;
        Weapon BronzeSword = new Weapon("Bronze Sword", 10);
        Weapon IronSword = new Weapon("Iron Sword", 15);
        Weapon SteelSword = new Weapon("Steel Sword", 20);
        Weapon MithrilSword = new Weapon("Mithril Sword", 25);
        Weapon RuneSword = new Weapon("Rune Sword", 50);

        public Shop()
        {
            for (int e = 0; e < 1; e++)
            {
                this.WepList = new Weapon[5];
                this.WepList[0] = BronzeSword;
                this.WepList[1] = IronSword;
                this.WepList[2] = SteelSword;
                this.WepList[3] = MithrilSword;
                this.WepList[4] = RuneSword;
            }
        }

        public void ShopEvent()
        {
            Console.Clear();
            bool shopLoop = true;
            while (shopLoop)
            {
                Console.WriteLine("Weapons shop (1)");
                Console.WriteLine("Regain Hitpoints (2)");
                Console.WriteLine("Train Strenght (3)");
                Console.WriteLine("Gamble all coins (4)");
                Console.WriteLine("Progress further (w)");

                char shopMenu = Convert.ToChar(Console.ReadLine());

                switch (shopMenu)
                {
                    case '1':
                        WeaponShop();
                        shopLoop = false;
                        break;

                    case '2':
                        break;

                    case '3':
                        break;

                    case '4':
                        break;

                    case 'w':
                        shopLoop = false;
                        break;

                    default:
                        break;
                }
            }
        }



        public Weapon[] GetWeapons()
        {
            return WepList;
        }

        public void WeaponShop()
        {
            Console.Clear();
            //int e = 0;
            //foreach (var s in GetWeapons())
            //{
            //    Console.WriteLine(s.Name + " (" + e + ")");
            //    e++;
            //}
            Console.WriteLine(BronzeSword.Name + " (0)");
            Console.WriteLine(IronSword.Name + " (1)");
            Console.WriteLine(SteelSword.Name + " (2)");
            Console.WriteLine(MithrilSword.Name + " (3)");
            Console.WriteLine(RuneSword.Name + " (4)");
            Console.WriteLine("Exit (5)");
        }
    }
}
