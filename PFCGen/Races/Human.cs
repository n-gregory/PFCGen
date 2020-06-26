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
            me.MyStats.Dexterity += 2;
            me.MyStats.Intelligence += 2;
            me.MyStats.Constitution -= 2;
        }
        // private void addFloatingBonus() {
        //     int i = rnd.Next(2);
        //     int[] stats = { Str, Dex, Con, Int, Wis, Cha };
        //     Array.Sort(stats);
        //     Array.Reverse(stats);
        //     stats[i] += 2;
        //     //applyThreshhold.IsChecked = !applyThreshhold.IsChecked;
        // }
    }
}
