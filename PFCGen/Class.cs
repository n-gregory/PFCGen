using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DebugTools;
using MyUtilities;

namespace PFCharGen
{
    abstract class Class
    {
        int hitDiceBase;
        int skills;
        int bab;
        int levelHP;
        int fortitude;
        int reflex;
        int will;
        String[] classSkills; //y'know, should probably make this a bitwise enum, but that's a huge number.
        /*
        String[] classList = new String[] 
        {
            "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Wizard"
        };
        */
        List<Type> classList = Assembly.Load(new AssemblyName("PFCharGen")).GetTypes().Where(a => a.Namespace != null && a.Namespace.Contains(@"PlayerClasses")).ToList();
        public Class()
        {
            DebugHelper.addMessage("I created a character with class: "+this.GetType().ToString());
        }
        abstract public void applyStats(Character me);

        public int HitDiceBase { get => hitDiceBase; set => hitDiceBase = value; }
        public int Skills { get => skills; set => skills = value; }
        public int Bab { get => bab; set => bab = value; }
        public int LevelHP { get => levelHP; set => levelHP = value; }
        public int Fortitude { get => fortitude; set => fortitude = value; }
        public int Reflex { get => reflex; set => reflex = value; }
        public int Will { get => will; set => will = value; }
        public string[] ClassSkills { get => classSkills; set => classSkills = value; }
        public List<Type> ClassList { get => classList; set => classList = value; }

        public String getRandClass(StatHandler inStats) {
            String className = "no hits";

            //get my modifiers, could do in other area, but for now do here.
            //if performance is hit too hard, do this elsewhere so it's done once and once only.
            double strMod = Math.Floor((inStats.getStatValue("Strength") - 10) / 2.0);
            double dexMod = Math.Floor((inStats.getStatValue("Dexterity") - 10) / 2.0);
            double conMod = Math.Floor((inStats.getStatValue("Constitution") - 10) / 2.0);
            double intMod = Math.Floor((inStats.getStatValue("Intelligence") - 10) / 2.0);
            double wisMod = Math.Floor((inStats.getStatValue("Wisdom") - 10) / 2.0);
            double chaMod = Math.Floor((inStats.getStatValue("Charisma") - 10) / 2.0);

            //get average modifiers for these classes, based on key ability score.

            double barbarian = Math.Max(0.0, Math.Floor((strMod + conMod) / 2));
            double bard = Math.Max(0.0, Math.Floor((dexMod + chaMod) / 2));
            double cleric = Math.Max(0.0, Math.Floor((wisMod + chaMod) / 2));
            double druid = Math.Max(0.0, wisMod);
            double fighter = Math.Max(0.0, strMod);
            double monk = Math.Max(0.0, Math.Floor((strMod + wisMod + dexMod) / 3));
            double paladin = Math.Max(0.0, Math.Floor((strMod + chaMod) / 2));
            double ranger = Math.Max(0.0, Math.Floor((dexMod + wisMod) / 2));
            double rogue = Math.Max(0.0, dexMod);
            double sorcerer = Math.Max(0.0, chaMod);
            double wizard = Math.Max(0.0, intMod);

            //set up array with names so I can randomly choose a class with hopefully relevant stats
            // int classSum = Convert.ToInt16(fighter + wizard);
            int classSum = Convert.ToInt16(barbarian + bard + cleric + druid + fighter + monk + paladin + ranger + rogue + sorcerer + wizard);
            String[] myClass = new String[classSum];

            for (int i = 0; i < myClass.Length; i++) {
                while (barbarian > 0) {
                    myClass[i] = "Barbarian";
                    i++;
                    barbarian--;
                }
                while (bard > 0) {
                    myClass[i] = "Bard";
                    i++;
                    bard--;
                }
                while (cleric > 0) {
                    myClass[i] = "Cleric";
                    i++;
                    cleric--;
                }
                while (druid > 0) {
                    myClass[i] = "Druid";
                    i++;
                    druid--;
                }
                while (fighter > 0) {
                    myClass[i] = "Fighter";
                    i++;
                    fighter--;
                }
                while (monk > 0) {
                    myClass[i] = "Monk";
                    i++;
                    monk--;
                }
                while (paladin > 0) {
                    myClass[i] = "Paladin";
                    i++;
                    paladin--;
                }
                while (ranger > 0) {
                    myClass[i] = "Ranger";
                    i++;
                    ranger--;
                }
                while (rogue > 0) {
                    myClass[i] = "Rogue";
                    i++;
                    rogue--;
                }
                while (sorcerer > 0) {
                    myClass[i] = "Sorcerer";
                    i++;
                    sorcerer--;
                }
                while (wizard > 0) {
                    myClass[i] = "Wizard";
                    i++;
                    wizard--;
                }
                //myClass[i] = "no class";
            } //create the randomiser array.
            if (classSum > 0) {
                className = myClass[Util.GetRandom(Math.Max(classSum, 0))].ToString();
            }
            else //there is a small chance that the modifiers are all 0 or below.
          {
                className = ClassList[Util.GetRandom(0, ClassList.Count)].ToString();
            }
            DebugHelper.addMessage("I randomly generated a character with class: "+className);
            return className;
        }
    }
}
