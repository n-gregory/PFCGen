using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyUtilities;
using DebugTools;

namespace PFCharGen
{
    class StatHandler 
    {
        //each stat handler contains only one set of stats.
        //the stats no longer need to be "str", "dex", etc
        // Random rnd = new Random();
        private List<StatNode> statList;
        public StatHandler(){
            statList = new List<StatNode>();
        }
        public StatHandler(List<StatNode> oldList){
            statList = oldList;
        }
        public bool statExists(String name){
            //because a lot of these methods needed this line, made a method call.
            bool exists = statList.Exists(x => x.getName() == name);
            return exists;
        }
        public int getStatValue(String name){
            //returns the value of a stat, specified by name if it exists
            if (statExists(name)){
                return getStat(name).getValue();
            } else {
                return -1;
            }
            
            
        }
        public StatNode getStat(String name){
            //if stat exists, return stat, specified by name
            if (statExists(name)){
                return statList.Find(x => x.getName() == name);
            } else {
                return null;
            }
            
        }
        public void setStatValue(String name, int i) {
            //update a stat by specifying name

            //if stat exists, replace value with new value
            if (statExists(name)) {
                getStat(name).setValue(i);
            } else {
                //if stat does not exist, 
                //add a stat to current list
                makeNewStat(name, i);
            }
            return;
        }
        public void adjustStatValue(String name,int i) {
            // if stat exists, add i to value of stat
            if (statExists(name)){
                getStat(name).setValue(getStat(name).getValue()+i);
            }
            
            
        }
        public void renameStat(String oldName, String newName)
        {
            if (statExists(oldName) && !statExists(newName))
            {
                getStat(oldName).setName(newName);
                DebugHelper.addMessage("Renamed statnode "+oldName+" to "+newName);
            }
        }
        public void addStat(StatNode newStat){
            // String tempName = newStat.getName();
            //if stat exists, replace value with new stat value
            if (statExists(newStat.getName())) {
                getStat(newStat.getName()).setValue(newStat.getValue());
            } else {
                //if stat does not exist, 
                //add a stat to current list
                statList.Add(newStat);
            }
        }
        public void makeNewStat(String name){
            int i = RollStat(); //get stat value ready

            //make a new stat by name, and add it to the stat list
            StatNode temp = new PFCharGen.StatNode(name,i);
            addStat(temp);                        
        }
        public void makeNewStat(String name,int i){

            //make a new stat by name, and add it to the stat list
            StatNode temp = new PFCharGen.StatNode(name,i);
            addStat(temp);                        
        }
        public List<StatNode> getStatList(){
            return statList;
        }
        public int RollStat()
        {
            int stat = 0;
            //String result = "results were: ";
            int[] dice = new int[4];
            int low = 7;
            foreach (int item in dice)
            {
                //rnd = new Random();
                dice[item] = Util.GetRandom(1, 7);
                stat += dice[item];
                //result += dice[item].ToString() +", ";
                if (dice[item] < low)
                {
                    low = dice[item];
                }
            }
            stat -= low;
            return stat;
        }
        public void addFloatingBonus(){
            int i = Util.GetRandom(3);
            List<StatNode> temp = getStatList();
            temp.Sort();
            temp.Reverse();
            adjustStatValue(temp[i].getName(),2);
            return;
        }
        public void addFloatingBonus(int val){
            int i = Util.GetRandom(3);
            List<StatNode> temp = getStatList();
            temp.Sort();
            temp.Reverse();
            adjustStatValue(temp[i].getName(),val);
            return;
        }
        public void classOrder(String[] list){
            //get the list of key stats (method signature)
            // DebugHelper.addMessage("starting my reordering");
            int[] used = new int[] {-1};
            int pos = 0;
            // DebugHelper.addMessage("position variable 'pos' created with value: "+pos.ToString());
            //make a list of used indices, to avoid shuffling to the same spot all the time

            //sort the list of stats
            statList.Sort(); //low to high
            statList.Reverse(); //high to low
            // Random innerRandom = new Random();

            
            // DebugHelper.addMessage("outside loop, target index: "+int_tar.ToString());

            //for each item in list
            foreach (String label in list){
                // pos = list.
                //rename current statNode that shares the name of keystat (to temp or something)
                DebugHelper.addMessage("Adjusting stat: "+label);
                renameStat(label,"temp");
                
                //get an index to use as the target, and ensure that it isn't already used
                

                // int int_tar = 3;
                // DebugHelper.addMessage("target index manually set to : "+int_tar.ToString());
                int int_tar = Util.GetRandom(0,pos+2);
                DebugHelper.addMessage("before while loop, target index: "+int_tar.ToString());
                while (used.Contains(int_tar)) {
                    DebugHelper.addMessage("encountered used index, changing to new index");
                    int_tar = Util.GetRandom(0,pos+2);
                    DebugHelper.addMessage("inside while loop, target index: "+int_tar.ToString());
                }
                DebugHelper.addMessage("after while loop, target index: "+int_tar.ToString());
                // int target = 1;
                //get the name of the stat at list target index
                //store that stat name in a temporary string
                String tempString = statList.ElementAt(int_tar).getName();
                //rename that stat with the key stat
                renameStat(tempString,label);
                //rename "temp" node with temporary string essentially just swapping the labels
                renameStat("temp",tempString);
                DebugHelper.addMessage("length of used array: "+used.Length.ToString());
                used = used.Append(int_tar).ToArray();
                DebugHelper.addMessage("length of used array after append: "+used.Length.ToString());
                pos++;
                DebugHelper.addMessage("Adjusted stat:"+label);
            }

        }

    }
}