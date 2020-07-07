using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFCharGen.Races
{
    class HalfOrc : Race
    {
        override public void addRaceMods(Character me)
        {
            me.MyStats.adjustStatValue("Dexterity",2);
            me.MyStats.adjustStatValue("Intelligence",2);
            me.MyStats.adjustStatValue("Constitution",-2);
        }
    }
}
