using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFCharGen.Races
{
    class Dwarf : Race
    {
        override public void addRaceMods(Character me)
        {
            me.MyStats.adjustStatValue("Constitution" , 2);
            me.MyStats.adjustStatValue("Wisdom", 2);
            me.MyStats.adjustStatValue("Charisma ",-2);
        }
    }
}
