using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    public class Monsters
    {
        public int FullHitpoints { get; set; } = 0;
        public int MaxHit { get; set; } = 0;
        public string Name { get; set; }

        Random rnd = new Random();

        public Monsters(string name, int fullhitpoints, int maxhit)
        {
            Name = name;
            FullHitpoints = fullhitpoints;
            MaxHit = maxhit;
        }

        public int Attack()
        {
            return rnd.Next(1, (int)MaxHit);
        }
    }
}
