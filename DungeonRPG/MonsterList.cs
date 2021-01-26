using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    class MonsterList
    {
        private Monsters[] MonList;
        
        Monsters Cenarius = new Monsters("Joe Whitton the Fearful", 50, 2);
        Monsters Sylvanas = new Monsters("Sylvanas the Sexy Waifu", 100, 10);
        Monsters Arthas = new Monsters("Trump the Wise", 200, 15);
        Monsters Alexstrasza = new Monsters("Vadim the Forever lost soul", 400, 15);
        Monsters Malygos = new Monsters("Alex inFXicious the Happy elf", 400, 15);
        Monsters Ysera = new Monsters("Kristian Dyreplager the Dreamer", 500, 20);
        Monsters Azshara = new Monsters("Kreddi-San the Crazy cat lady", 600, 20);
        Monsters Illidan = new Monsters("Michael Cookie the RNGlord", 1000, 30);
        Monsters Lichking = new Monsters("Gol D. Minheru the Sleepless wandere", 4000, 100);

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
