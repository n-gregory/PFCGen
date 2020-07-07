using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFCharGen
{
    class StatNode : IComparable<StatNode>
    {
        String statName;
        int statValue;
        internal int StatValue { get => statValue;}
        public StatNode(){
            statName = "unspecified";
            statValue = -1;
        }
        public StatNode(String name, int i){
            statName = name;
            statValue = i;
        }
        public int getValue(){
            return statValue;
        }
        public void setValue(int i) {
            statValue = i;
        }
        public void addValue(int i) {
            statValue += i;
        }
        public String getName(){
            return statName;
        }
        public void setName(String newName){
            statName = newName;
        }
        public int CompareTo(StatNode compareNode)
        {
            // A null value means that this object is greater.
            if (compareNode == null)
                return 1;

            else
                return this.getValue().CompareTo(compareNode.getValue());
        }

    }
}