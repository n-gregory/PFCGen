using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFCharGen.Races
{
    class Human : Race
    {
        override public void addRaceMods(Character me)
        {
            me.MyStats.addFloatingBonus(2);
            // addFloatingBonus(me.MyStats);
        }

        // private void addFloatingBonus(ref) {
        //     int i = rnd.Next(2);
        //     int[] stats = { Str, Dex, Con, Int, Wis, Cha };
        //     Array.Sort(stats);
        //     Array.Reverse(stats);
        //     stats[i] += 2;
        //     //applyThreshhold.IsChecked = !applyThreshhold.IsChecked;
        // }
    }
}
