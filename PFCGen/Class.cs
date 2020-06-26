using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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

        }
        abstract public void applyStats(int[] stats, Character me);

        public int HitDiceBase { get => hitDiceBase; set => hitDiceBase = value; }
        public int Skills { get => skills; set => skills = value; }
        public int Bab { get => bab; set => bab = value; }
        public int LevelHP { get => levelHP; set => levelHP = value; }
        public int Fortitude { get => fortitude; set => fortitude = value; }
        public int Reflex { get => reflex; set => reflex = value; }
        public int Will { get => will; set => will = value; }
        public string[] ClassSkills { get => classSkills; set => classSkills = value; }
        public List<Type> ClassList { get => classList; set => classList = value; }
    }
}
