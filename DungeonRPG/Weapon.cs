﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    public class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public Weapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }
    }
}
