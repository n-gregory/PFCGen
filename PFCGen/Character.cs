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
            myRace = new Elf();
            myClass = new Wizard();
            //Character[] me = new Character[] { this };
            myRace = (Race)Activator.CreateInstance(myRace.RaceList[rnd.Next(myRace.RaceList.Count)]);

            myClass = (Class)Activator.CreateInstance(myClass.ClassList[rnd.Next(myClass.ClassList.Count)]);
            // myBackground = new Background(myRace, myClass);


        }

        internal Stats MyStats { get => myStats; set => myStats = value; }
        internal Class MyClass { get => myClass; set => myClass = value; }
        internal Race MyRace { get => myRace; set => myRace = value; }
        internal Background MyBackground { get => myBackground; set => myBackground = value; }
        /*
private void randGen(Random rnd)
{

//threshhold = 16;
bool goodStats = false;
while (!goodStats)
{
Str = Stats.RollStat(rnd);
Dex = RollStat(rnd);
Con = RollStat(rnd);
Int = RollStat(rnd);
Wis = RollStat(rnd);
Cha = RollStat(rnd);
if (Str > threshhold - 1 || Dex > threshhold - 1 || Con > threshhold - 1 || Int > threshhold - 1 || Wis > threshhold - 1 || Cha > threshhold - 1)
{
goodStats = true;
}
if (applyThreshhold.IsChecked == false)
{
goodStats = true;
}
//add racial modifiers


}
addRaceMods(raceBox.SelectedItem.ToString());
strBox.Text = Str.ToString();
dexBox.Text = Dex.ToString();
conBox.Text = Con.ToString();
intBox.Text = Int.ToString();
wisBox.Text = Wis.ToString();
chaBox.Text = Cha.ToString();
String className = getRandClass(Str, Dex, Con, Int, Wis, Cha);
foreach (var item in classBox.Items)
{
if (item.ToString() == className)
{
classBox.SelectedIndex = classBox.Items.IndexOf(item);
}
}
}*/

    }
}
