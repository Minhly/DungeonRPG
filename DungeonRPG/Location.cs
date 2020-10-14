using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    public class Location
    {           
        public string DungeonName { get; set; }
        public int Reward { get; set; }


        public Location(string dgname, int reward)
        {
            DungeonName = dgname;
            Reward = reward;
        }
    }
}
