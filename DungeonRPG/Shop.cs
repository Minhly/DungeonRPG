using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    public class Shop
    {
        /*public Weapon[] WepList;*/
        List<Weapon> Weaponz = new List<Weapon>();

        Weapon BronzeSword = new Weapon("Stick of truth", 10, 30);
        Weapon IronSword = new Weapon("Durandal", 20, 100);
        Weapon SteelSword = new Weapon("Kusanagi", 40, 200);
        Weapon MithrilSword = new Weapon("Excalibur", 60, 300);
        Weapon RuneSword = new Weapon("Frostmourne", 100, 500);

        public Shop()
        {            
                Weaponz.Add(BronzeSword);
                Weaponz.Add(IronSword);
                Weaponz.Add(SteelSword);
                Weaponz.Add(MithrilSword);
                Weaponz.Add(RuneSword);
/*
            for (int e = 0; e < 1; e++)
            {
                this.WepList = new Weapon[5];
                this.WepList[0] = BronzeSword;
                this.WepList[1] = IronSword;
                this.WepList[2] = SteelSword;
                this.WepList[3] = MithrilSword;
                this.WepList[4] = RuneSword;
            }*/
        }

        public List<Weapon> GetWeapons()
        {
            return Weaponz;
        }

        /*        public Weapon[] GetWeapons()
                {
                    return WepList;
                }*/

        public void WeaponShop()
        {
            Console.Clear();
            /*  Console.WriteLine("(1) {0} DPS: {1} Price: {2}", IronSword.Name, IronSword.Damage, IronSword.Price);
                Console.WriteLine("(2) {0} DPS: {1} Price: {2}", SteelSword.Name, SteelSword.Damage, SteelSword.Price);
                Console.WriteLine("(3) {0} DPS: {1} Price: {2}", MithrilSword.Name, MithrilSword.Damage, MithrilSword.Price);
                Console.WriteLine("(4) {0} DPS: {1} Price: {2}", RuneSword.Name, RuneSword.Damage, RuneSword.Price);
                Console.WriteLine("(11) Exit");*/
            /*            int i = 0;
                        foreach (var s in Weaponz)
                        {
                            i++;
                            Console.WriteLine("({0}) DPS: {1} Price: {2}", i, s.Name, s.Price);
                        }*/

            for (int i = 1; i < Weaponz.Count; i++)
            {
                Console.WriteLine("\n({1}) {0} DMG: {3} Price: {2}", Weaponz[i].Name, i, Weaponz[i].Price, Weaponz[i].Damage);
            }
            Console.WriteLine("\n(11) Exit"); 
        }
    }
}
