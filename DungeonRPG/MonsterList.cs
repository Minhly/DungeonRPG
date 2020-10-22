﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    class MonsterList
    {
        private Monsters[] MonList;
        Monsters Lichking = new Monsters("Lich King", 50, 2);
        Monsters Sylvanas = new Monsters("Sylvanas", 50, 2);
        Monsters Arthas = new Monsters("Arthas", 50, 2);
        Monsters Alexstrasza = new Monsters("Alexstrasza", 50, 2);
        Monsters Malygos = new Monsters("Malygos", 50, 2);
        Monsters Ysera = new Monsters("Ysera", 200, 10);
        Monsters Azshara = new Monsters("Azshara", 150, 7);
        Monsters Illidan = new Monsters("Illidan", 100, 25);
        Monsters Cenarius = new Monsters("Cenarius", 200, 1);

        public MonsterList()
        {
            for (int e = 0; e < 1; e++)
            {
                this.MonList = new Monsters[10];
                this.MonList[0] = Cenarius;
                this.MonList[1] = Sylvanas;
                this.MonList[2] = Arthas;
                this.MonList[3] = Alexstrasza;
                this.MonList[4] = Malygos;
                this.MonList[5] = Ysera;
                this.MonList[6] = Azshara;
                this.MonList[7] = Illidan;
                this.MonList[8] = Lichking;
            }
        }

        public Monsters[] GetMonsters()
        {
            return MonList;
        }

    }
}
