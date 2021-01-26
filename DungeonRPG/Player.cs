using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    public class Player : Character
    {

        public Player(string name,int fullhitpoints, int maxhit, int coins, int weapondamage, string weaponname, int mana)
        {
            Name = name;
            Coins = coins;
            FullHitpoints = fullhitpoints;
            WeaponDmg = weapondamage;
            MaxHit = maxhit;
            WeaponName = weaponname;
            Mana = mana;
        }

        public override int Attack() {
            return rnd.Next(WeaponDmg, (int)MaxHit);
        }

    }
}
