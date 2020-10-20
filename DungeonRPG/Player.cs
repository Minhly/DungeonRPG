using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    public class Player : Character
    {

        public Player(string name,int fullhitpoints, int maxhit, int coins, int weapondamage)
        {
            Name = name;
            Coins = coins;
            FullHitpoints = fullhitpoints;
            WeaponDmg = weapondamage;
            MaxHit = maxhit;
        }

        public int Attack() {
            return rnd.Next(WeaponDmg, (int)MaxHit);
        }

    }
}
