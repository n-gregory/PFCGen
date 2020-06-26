using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFCharGen.Races
{
    class Gnome : Race
    {
        override public void addRaceMods(Character me)
        {
            me.MyStats.Constitution += 2;
            me.MyStats.Charisma += 2;
            me.MyStats.Strength -= 2;
        }
    }
}
