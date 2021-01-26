using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    public class Monsters : Character
    {
        public Monsters(string name, int fullhitpoints, int maxhit)
        {
            Name = name;
            FullHitpoints = fullhitpoints;
            MaxHit = maxhit;
        }

        public override int Attack()
        {
            return rnd.Next(1, (int)MaxHit);
        }
    }
}
