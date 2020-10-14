using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonRPG
{
    public class Locationprint
    {
        private Location[] LocationRND;
        Location Darnassus = new Location("Darnassus", 5);
        Location Exodar = new Location("Exodar", 5);
        Location Ogrimmar = new Location("Ogrimmar", 5);
        Location Stormwind = new Location("Stormwind", 5);
        Location Undercity = new Location("Undercity", 5);
        Location Dalaran = new Location("Dalaran", 5);
        Location Ironforge = new Location("Ironforge", 5);
        Location Shattrah = new Location("Shattrah", 5);
        Location Boralus = new Location("Boralus", 5);
        
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
