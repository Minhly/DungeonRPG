using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    public class Weapon
    {
        public string Name { get; set; } = "Noob Sword";
        public int Damage { get; set; } = 1;
        public Weapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }
    }
}
