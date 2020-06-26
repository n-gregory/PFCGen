using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFCharGen
{
    class Stats
    {

        Random rnd = new Random();
        int strength;
        int dexterity;
        int constitution;
        int intelligence;
        int wisdom;
        int charisma;
        int[] statArray;

        public int Strength { get => strength; set => strength = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Constitution { get => constitution; set => constitution = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
        public int Wisdom { get => wisdom; set => wisdom = value; }
        public int Charisma { get => charisma; set => charisma = value; }

        public Stats(Character me)
        {
            statArray = genStats();
        }

        public int[] getStats()
        {
            statArray = new int[] { Strength, Dexterity, Constitution, Wisdom, Intelligence, Charisma };

            return statArray;
        }

        public void setStats(int[] newArray)
        {
            if (newArray.Length == statArray.Length)
            {
                statArray = newArray;
            }
            return;
        }
        int[] genStats()
        {

            int[] myStatArray;
            Strength = RollStat(rnd);
            Dexterity = RollStat(rnd);
            Constitution = RollStat(rnd);
            Intelligence = RollStat(rnd);
            Wisdom = RollStat(rnd);
            Charisma = RollStat(rnd);

            myStatArray = new int[] { Strength, Dexterity, Constitution, Wisdom, Intelligence, Charisma };

            return myStatArray;
        }
        public int RollStat(Random rnd)
        {

            int stat = 0;
            //String result = "results were: ";
            int[] dice = new int[4];
            int low = 7;


            foreach (int item in dice)
            {
                //rnd = new Random();
                dice[item] = rnd.Next(1, 7);
                stat += dice[item];
                //result += dice[item].ToString() +", ";
                if (dice[item] < low)
                {
                    low = dice[item];
                }
            }

            /*
            for (int i = 0; i < dice.Length; i++)
            {
                dice[i] = rnd.Next(1,7);
                stat += dice[i];
                if (dice[i] < low)
                {
                    low = dice[i];
                }
            }
            */
            stat -= low; ;
            //result += " for a total stat of: " + stat.ToString() + "  the lowest result was: " + low.ToString(); 
            return stat;
        }
    }
}
