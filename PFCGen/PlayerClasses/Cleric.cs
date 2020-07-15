using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFCharGen.PlayerClasses
{
    class Cleric: Class
    {
        String[] keyStats = {"Wisdom", "Charisma"};
        
        override public void applyStats(Character me){
            me.MyStats.classOrder(keyStats);
            return;
        }
    }
}
