﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    public class Player
    {
        Weapon NoobWeapon = new Weapon("Noob Sword", 10);

        public int FullHitpoints { get; set; } = 0;
        public int MaxHit { get; set; } = 0;
        public string Name { get; set; }

        Random rnd = new Random();

        public Player(string name,int fullhitpoints, int maxhit)
        {
            Name = name;
            FullHitpoints = fullhitpoints;
            MaxHit = maxhit + NoobWeapon.Damage;
        }

        public int Attack() {
            return rnd.Next(NoobWeapon.Damage, (int)MaxHit);
        }

    }
}
