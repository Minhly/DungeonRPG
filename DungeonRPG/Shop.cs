using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    public class Shop
    {
        public Weapon[] WepList;
        Weapon BronzeSword = new Weapon("Bronze Sword", 10, 30);
        Weapon IronSword = new Weapon("Iron Sword", 20, 30);
        Weapon SteelSword = new Weapon("Steel Sword", 40, 500);
        Weapon MithrilSword = new Weapon("Mithril Sword", 60, 900);
        Weapon RuneSword = new Weapon("Rune Sword", 100, 2000);

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

        public Weapon[] GetWeapons()
        {
            return WepList;
        }

        public void WeaponShop()
        {
            Console.Clear();
            Console.WriteLine("(1) {0} DPS: {1} Price: {2}", IronSword.Name, IronSword.Damage, IronSword.Price);
            Console.WriteLine("(2) {0} DPS: {1} Price: {2}", SteelSword.Name, SteelSword.Damage, SteelSword.Price);
            Console.WriteLine("(3) {0} DPS: {1} Price: {2}", MithrilSword.Name, MithrilSword.Damage, MithrilSword.Price);
            Console.WriteLine("(4) {0} DPS: {1} Price: {2}", RuneSword.Name, RuneSword.Damage, RuneSword.Price);
            Console.WriteLine("(11) Exit");
        }
    }
}
