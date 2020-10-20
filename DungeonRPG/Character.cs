using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    public class Character
    {
        public int FullHitpoints { get; set; } = 0;
        public int MaxHit { get; set; } = 0;
        public int Coins { get; set; } = 0;
        public string Name { get; set; }
        public int WeaponDmg { get; set; } = 0;

        public Random rnd = new Random();
    }
}
