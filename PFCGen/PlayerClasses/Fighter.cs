using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFCharGen.PlayerClasses
{
    class Fighter: Class
    {
        String[] keyStats = {"Strength", "Dexterity"};
        
        override public void applyStats(Character me){
            me.MyStats.classOrder(keyStats);
            return;
        }
    }
}
