using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    public class Weapon
    {
        public string Name { get; set; } = "Noob Sword";
        public int Damage { get; set; } = 1;
        public int Price { get; set; } = 0;
        public Weapon(string name, int damage, int price)
        {
            Name = name;
            Damage = damage;
            Price = price;
        }
    }
}
