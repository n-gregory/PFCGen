using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyUtilities;
using DebugTools;

namespace PFCharGen
{
    class AbilityHandler 
    {
        private List<AbilityNode> abilityList;
        public AbilityHandler(){
            abilityList = new List<AbilityNode>();
        }
        public AbilityHandler(List<AbilityNode> oldList){
            abilityList = oldList;
        }
        public bool abilityExists(String name){
            //because a lot of these methods needed this line, made a method call.
            bool exists = abilityList.Exists(x => x.getName() == name);
            return exists;
        }
    }
}