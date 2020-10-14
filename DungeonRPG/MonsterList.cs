﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    class MonsterList
    {
        private Monsters[] MonList;
        Monsters Lichking = new Monsters("Lich King", 100, 10);
        Monsters Sylvanas = new Monsters("Sylvanas", 100, 10);
        Monsters Arthas = new Monsters("Arthas", 100, 10);
        Monsters Alexstrasza = new Monsters("Alexstrasza", 100, 10);
        Monsters Malygos = new Monsters("Malygos", 100, 10);
        Monsters Ysera = new Monsters("Ysera", 100, 10);
        Monsters Azshara = new Monsters("Azshara", 100, 10);
        Monsters Illidan = new Monsters("Illidan", 100, 10);
        Monsters Cenarius = new Monsters("Cenarius", 100, 10);

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