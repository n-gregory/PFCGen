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
            addFloatingBonus(me.MyStats);
        }
        private void addFloatingBonus(StatHandler sh){
            int i = 1;
            List<StatNode> temp = sh.getStatList();
            temp.Sort((x, y) => x.StatValue.CompareTo(y.StatValue));
            temp.Reverse();
            sh.adjustStatValue(temp[i].getName(),2);
            return;
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
