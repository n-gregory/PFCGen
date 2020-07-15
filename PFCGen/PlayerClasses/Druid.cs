using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFCharGen.PlayerClasses
{
    class Druid: Class
    {
        String[] keyStats = {"Wisdom"};
        
        override public void applyStats(Character me){
            me.MyStats.classOrder(keyStats);
            return;
        }
    }
}
