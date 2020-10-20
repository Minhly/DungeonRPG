using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    interface Characterz
    {
        public int FullHitpoints { get; set; }
        public int MaxHit { get; set; }
        public string Name { get; set; }

        public int Attack();
    }
}
