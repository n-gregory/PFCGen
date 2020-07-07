using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PFCharGen
{
    public interface IRace
    {

    }
    abstract class Race
    {
        Random rnd = new Random();

        public Race()
        {
        }

        static String[] races = new String[] //make this an enum or something, probably makes it easier in future rather than typing it all out.
        {
             "Dwarf", "Elf", "Gnome", "Half-Elf", "Half-Orc", "Halfling", "Human"
        };
        String myRace;

        //Assembly test = typeof(Races.Elf).GetTypeInfo().Assembly;
        //List<Type> preRaceList = typeof(Races.Elf).GetTypeInfo().Assembly.GetTypes().ToList(); // new List<Type>();
        //List<Type> x = Assembly.Load(new AssemblyName("PFCharGen")).GetTypes().ToList();
        List<Type> raceList = Assembly.Load(new AssemblyName("PFCharGen")).GetTypes().Where(a => a.Namespace != null && a.Namespace.Contains(@"Races")).ToList();


        //foreach (var item in preRaceList)

        public string MyRace { get => myRace; set => myRace = value; }
        public string[] Races { get => races; set => races = value; }
        public List<Type> RaceList { get => raceList; set => raceList = value; }

        /*public Race(Character me)
        {
            myRace = races[rnd.Next(races.Length - 1)];
            addRaceMods(myRace, me);
        }*/

        abstract public void addRaceMods(Character me);

        /*
        private void addRaceMods(string race, Character me)
        {

            if (race.ToUpper() == "Dwarf".ToUpper())
            {
                
                me.MyStats.Constitution += 2;
                me.MyStats.Wisdom += 2;
                me.MyStats.Charisma -= 2;
            }
            else if (race.ToUpper() == "Elf".ToUpper())
            {
                me.MyStats.Dexterity += 2;
                me.MyStats.Intelligence += 2;
                me.MyStats.Constitution -= 2;
            }
            else if (race.ToUpper() == "Gnome".ToUpper())
            {
                me.MyStats.Constitution += 2;
                me.MyStats.Charisma += 2;
                me.MyStats.Strength += 2;
            }
            else if (race.ToUpper() == "Half-Elf".ToUpper())
            {
                addFloatingBonus(me);
            }
            else if (race.ToUpper() == "Halfling".ToUpper())
            {
                me.MyStats.Dexterity += 2;
                me.MyStats.Charisma += 2;
                me.MyStats.Strength -= 2;
            }
            else if (race.ToUpper() == "Half-Orc".ToUpper())
            {
                addFloatingBonus(me);
            }
            else if (race.ToUpper() == "Human".ToUpper())
            {
                addFloatingBonus(me);
            }
            //throw new NotImplementedException();
        }
        */
        private void addFloatingBonus(Character me)
        {
            //find highest 3 stats, and what they are
            // int[] top3 = getTop3(me.MyStats.getStats()); //I now have the index of the top 3 stats

            // me.MyStats.getStats()[top3[rnd.Next(top3.Length-1)]] +=2; //add 2 to one of the top 3 stats

        }
        private int[] getTop3(int[] array)
        {
            int[] top3;
            //bool firstPass = true;
            int spot1 = 0;
            int spot2 = 0;
            int spot3 = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > array[spot1])
                {
                    //Console.WriteLine("checking spot 1!");
                    spot3 = spot2;
                    spot2 = spot1;
                    spot1 = i;
                    //Console.WriteLine("new spot 1!");
                }
                else if (array[i] > array[spot2])
                {
                    //Console.WriteLine("checking spot 2!");
                    spot3 = spot2;
                    spot2 = i;
                    //Console.WriteLine("new spot 2!");
                }
                else if (array[i] > array[spot3])
                {
                    //Console.WriteLine("checking spot 3!");
                    spot3 = i;
                    //Console.WriteLine("new spot 2!");
                }
                //firstPass = false;


            }
            top3 = new int[] { spot1, spot2, spot3 };
            return top3;
        
 
        }

    }
}
