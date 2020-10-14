using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    public class Locationprint
    {
        private Location[] LocationRND;
        Location Darnassus = new Location("Level 1", 5);
        Location Exodar = new Location("Level 2", 5);
        Location Ogrimmar = new Location("Level 3", 5);
        Location Stormwind = new Location("Level 4", 5);
        Location Undercity = new Location("Level 5", 5);
        Location Dalaran = new Location("Level 6", 5);
        Location Ironforge = new Location("Level 7", 5);
        Location Shattrah = new Location("Level 8", 5);
        Location Boralus = new Location("Level 9", 5);
        
        public Locationprint()
        {
            for (int e = 0; e < 1; e++)
            {
                this.LocationRND = new Location[10];
                this.LocationRND[0] = Darnassus;
                this.LocationRND[1] = Exodar;
                this.LocationRND[2] = Ogrimmar;
                this.LocationRND[3] = Stormwind;
                this.LocationRND[4] = Undercity;
                this.LocationRND[5] = Dalaran;
                this.LocationRND[6] = Ironforge;
                this.LocationRND[7] = Shattrah;
                this.LocationRND[8] = Boralus;
            }
        }

        public Location[] GetLocations()
        {
            return LocationRND;
        }

    }
}
