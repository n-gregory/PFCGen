using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFCGen.Races
{
    class Dwarf : Race
    {
        private void addRaceMods(Character me)
        {
            me.MyStats.Constitution += 2;
            me.MyStats.Wisdom += 2;
            me.MyStats.Charisma -= 2;
        }
    }
}
