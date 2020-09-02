using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFCharGen
{
    class AbilityNode
    {
        public string AbilityName { get; set; } //the name of the ability
        public string AbilityText { get; set; } //the text for the ability
        public int ClassLevel { get; set; } //the level the ability is obtained
        public AbilityNode()
        {
        }
        public String getName(){
            return AbilityName;
        }
        public String getAbility(){
            return AbilityText;
        }
        public int getLevel(){
            return ClassLevel;
        }
    }
}
