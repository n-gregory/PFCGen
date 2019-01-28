using PFCGen.Races;
using PFCGen.PlayerClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFCGen
{
    class Character
    {
        Random rnd = new Random();


        Stats myStats;
        Class myClass;// = new Class();
        Race myRace;// = new Race();
        Background myBackground;// myBackground = new Background();
        

        public Character() 
        {
            myStats = new Stats(this);
            //int test = myRace.Races.Length;
            //myRace = new Elf();
            //myClass = new Wizard();
            //Character[] me = new Character[] { this };
            if (myRace == null) {
                myRace = new Elf(); //initialise the list source
                myRace = (Race)Activator.CreateInstance(myRace.RaceList[rnd.Next(myRace.RaceList.Count)]);
            }
            if (myClass == null)
            {
                myClass = new Wizard(); //initialise the list source
                myClass = (Class)Activator.CreateInstance(myClass.ClassList[rnd.Next(myClass.ClassList.Count)]);
            }
            
            // myBackground = new Background(myRace, myClass);


        }
        public void genRace()
        {
            if (myRace == null)
            {
                myRace = new Elf(); //initialise the list source
            }
            myRace = (Race)Activator.CreateInstance(myRace.RaceList[rnd.Next(myRace.RaceList.Count)]);
        }
        public void genClass()
        {
            if (myClass == null)
            {
                myClass = new Wizard(); //initialise the list source
            }
            myClass = (Class)Activator.CreateInstance(myClass.ClassList[rnd.Next(myClass.ClassList.Count)]);
        }
        public void genStats()
        {
            myStats = new Stats(this);
        }

        internal Stats MyStats { get => myStats; set => myStats = value; }
        internal Class MyClass { get => myClass; set => myClass = value; }
        internal Race MyRace { get => myRace; set => myRace = value; }
        internal Background MyBackground { get => myBackground; set => myBackground = value; }
        

    }
}
