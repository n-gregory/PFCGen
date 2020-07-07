using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFCharGen.Races
{
    class Halfling : Race
    {
        override public void addRaceMods(Character me)
        {
            me.MyStats.adjustStatValue("Dexterity", 2);
            me.MyStats.adjustStatValue("Charisma", 2);
            me.MyStats.adjustStatValue("Strength", -2);
        }
    }
}
