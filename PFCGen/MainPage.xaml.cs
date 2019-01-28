using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

        
namespace PFCGen
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Random rnd = new Random();
        int threshhold = 10;
        String[] randClass = new String[] { "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Wizard" };
        String[] randRace = new String[] { "Dwarf", "Elf", "Gnome", "Half-Elf", "Half-Orc", "Halfling", "Human" };
        Assembly assembly = Assembly.Load(new AssemblyName("PFCGen"));
        //stats and such
        public int Str = 10;
        public int Dex = 10;
        public int Con = 10;
        public int Int = 10;
        public int Wis = 10;
        public int Cha = 10;
        Character newMe = new Character();
        //public bool FloatBonus = false;

        public MainPage()
        {
            
            this.InitializeComponent();
            classLock.OffContent = "Unlocked";
            classLock.OnContent = "Locked";
            raceLock.OffContent = "Unlocked";
            raceLock.OnContent = "Locked";

            /*
            foreach (var item in randClass)
            {
                classBox.Items.Add(item);
            }
            */

            Assembly Test;
            //Console.WriteLine("Assembly name: {0}", assem.FullName);

            foreach(var item in newMe.MyRace.RaceList)
            {
                if (item.Namespace == "PFCGen.Races") { 
                    raceBox.Items.Add(item.Name);
                }
            }
            //
            /*
            foreach (var item in newMe.MyRace.Races)
            {
                
                raceBox.Items.Add(item);
            }
            */
            foreach (var item in newMe.MyClass.ClassList)
            {
                  
                 classBox.Items.Add(item.Name);
                
            }
            /*
            foreach (var item in randRace)
            {
                raceBox.Items.Add(item);
            }
            */
        }

        public int RollStat(Random rnd)
        {
            
            int stat = 0;
            //String result = "results were: ";
            int[] dice = new int[4];
            int low = 7;

            
            foreach (int item in dice) {
                //rnd = new Random();
                dice[item] = rnd.Next(1, 7);
                stat += dice[item];
                //result += dice[item].ToString() +", ";
                if (dice[item] < low) {
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
        private void wait()
        {
            int x = 20000000;
            while (x > 0)
            {
                x--;
            }
        }// these aren't needed anymore, but I might find a use for them.
        private void wait(int x)
        {
            while (x > 0)
                {
                    x--;
                }
        }
        private String getRandClass(int Str, int Dex, int Con, int Int, int Wis, int Cha)
        {
            String className = "wazard"; //placeholder text

            //get my modifiers, could do in other area, but for now do here.
            //if performance is hit too hard, do this elsewhere so it's done once and once only.
            double strMod = Math.Floor((Str-10)/2.0);
            double dexMod = Math.Floor((Dex - 10) / 2.0);
            double conMod = Math.Floor((Con - 10) / 2.0);
            double intMod = Math.Floor((Int - 10) / 2.0);
            double wisMod = Math.Floor((Wis - 10) / 2.0);
            double chaMod = Math.Floor((Cha - 10) / 2.0);

            //get average modifiers for these classes, based on key ability score.
            
            double barbarian = Math.Max(0.0,Math.Floor((strMod + conMod) / 2));
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
            int classSum = Convert.ToInt16(barbarian + bard + cleric + druid + fighter + monk + paladin + ranger + rogue + sorcerer + wizard);
            String[] myClass = new String[classSum];
            
            for (int i = 0; i < myClass.Length; i++)
            {
                while (barbarian > 0)
                {
                    myClass[i] = "Barbarian";
                    i++;
                    barbarian--;
                }
                while (bard > 0)
                {
                    myClass[i] = "Bard";
                    i++;
                    bard--;
                }
                while (cleric > 0)
                {
                    myClass[i] = "Cleric";
                    i++;
                    cleric--;
                }
                while (druid > 0)
                {
                    myClass[i] = "Druid";
                    i++;
                    druid--;
                }
                while (fighter > 0)
                {
                    myClass[i] = "Fighter";
                    i++;
                    fighter--;
                }
                while (monk > 0)
                {
                    myClass[i] = "Monk";
                    i++;
                    monk--;
                }
                while (paladin > 0)
                {
                    myClass[i] = "Paladin";
                    i++;
                    paladin--;
                }
                while (ranger > 0)
                {
                    myClass[i] = "Ranger";
                    i++;
                    ranger--;
                }
                while (rogue > 0)
                {
                    myClass[i] = "Rogue";
                    i++;
                    rogue--;
                }
                while (sorcerer > 0)
                {
                    myClass[i] = "Sorcerer";
                    i++;
                    sorcerer--;
                }
                while (wizard > 0)
                {
                    myClass[i] = "Wizard";
                    i++;
                    wizard--;
                }
                //myClass[i] = "no class";
            } //create the randomiser array.
            if (classSum > 0)
            {
                className = myClass[rnd.Next(Math.Max(classSum, 0))].ToString();
            } else //there is a small chance that the modifiers are all 0 or below.
            {
                className = randClass[rnd.Next(0, 11)].ToString();
            }
            return className;
        }
        private void randGen(Random rnd) {

            //threshhold = 16;
            bool goodStats = false;
            while (!goodStats)
            {
                Str = RollStat(rnd);
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
            //addRaceMods(raceBox.SelectedItem.ToString());
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
        }

        private void addFloatingBonus()
        {
            int i = rnd.Next(2);
            int[] stats = { Str, Dex, Con, Int, Wis, Cha };
            Array.Sort(stats);
            Array.Reverse(stats);
            stats[i] += 2;
            //applyThreshhold.IsChecked = !applyThreshhold.IsChecked;
        }
        private void addRaceMods(string race)
        {
            
            if (race.ToUpper() == "Dwarf".ToUpper())
            {
                Con += 2;
                Wis += 2;
                Cha -= 2;
            }
            else if (race.ToUpper() == "Elf".ToUpper())
            {
                Dex += 2;
                Int += 2;
                Con -= 2;
            }
            else if (race.ToUpper() == "Gnome".ToUpper())
            {
                Con += 2;
                Cha += 2;
                Str += 2;
            }
            else if (race.ToUpper() == "Half-Elf".ToUpper())
            {
                addFloatingBonus();
            }
            else if (race.ToUpper() == "Halfling".ToUpper())
            {
                Dex += 2;
                Cha += 2;
                Str -= 2;
            }
            else if (race.ToUpper() == "Half-Orc".ToUpper())
            {
                addFloatingBonus();
            }
            else if (race.ToUpper() == "Human".ToUpper())
            {
                addFloatingBonus();
            }
            //throw new NotImplementedException();
        }
        /*
        private void whichClass(int i, Random rnd)
        {
            //debugText.Text = "you rolled: ";
            int[] stats = new int[6];
            stats[0] = -1;
            if (applyThreshhold.IsChecked == true) {
                while (stats[0] < threshhold) {
                    for (int x = 0; x < stats.Length; x++)
                    {
                        stats[x] = RollStat(rnd);
                    }
                    Array.Sort(stats); //sorts low to high
                    Array.Reverse(stats); //reverse array so it is high to low
                }
            } else
            {
                for (int x = 0; x < stats.Length; x++)
                {
                    stats[x] = RollStat(rnd);
                }
                Array.Sort(stats); //sorts low to high
                Array.Reverse(stats); //reverse array so it is high to low
            }


            if (i == 0) //Barbarian
            {
                genBarb(stats);
            }
            else if (i == 1) //Bard
            {
                genBard(stats);
            }
            else if (i == 2) //Cleric
            {
                genCleric(stats);
            }
            else if (i == 3) //Druid
            {
                genDruid(stats);

            }
            else if (i == 4) //Fighter
            {
                genFight(stats);

            }
            else if (i == 5) //Monk
            {
                genMonk(stats);

            }
            else if (i == 6) //Paladin
            {
               genPal(stats);

            }
            else if (i == 7) //Ranger
            {
                genRang(stats);

            }
            else if (i == 8) //Rogue
            {
                genRog(stats);

            }
            else if (i == 9) //Sorcerer
            {
                genSorc(stats);

            }
            else if (i == 10) //Wizard
            {
                genWiz(stats);

            }
            addRaceMods(raceBox.SelectedItem.ToString());

        }
        */
        /*
        private void genBarb(int[] stats)
        {
            //determine if strength is 1 or 2
            int strSpot = rnd.Next(2);
            //determine if constitution is 1, 2, or 3
            int conSpot = rnd.Next(3);
            while (strSpot == conSpot)
            {
                conSpot = rnd.Next(3);
            }
            int dexSpot = rnd.Next(6);
            int intSpot = rnd.Next(6);
            int wisSpot = rnd.Next(6);
            int chaSpot = rnd.Next(6);
            while (dexSpot == strSpot || dexSpot == conSpot || dexSpot == intSpot || dexSpot == wisSpot || dexSpot == chaSpot
                || intSpot == strSpot || intSpot == conSpot || intSpot == dexSpot || intSpot == wisSpot || intSpot == chaSpot
                || wisSpot == strSpot || wisSpot == conSpot || wisSpot == intSpot || wisSpot == dexSpot || wisSpot == chaSpot
                || chaSpot == strSpot || chaSpot == conSpot || chaSpot == intSpot || chaSpot == wisSpot || chaSpot == dexSpot)
            {
                dexSpot = rnd.Next(6);
                intSpot = rnd.Next(6);
                wisSpot = rnd.Next(6);
                chaSpot = rnd.Next(6);
            }
            
            strBox.Text = stats[strSpot].ToString();
            conBox.Text = stats[conSpot].ToString();
            dexBox.Text = stats[dexSpot].ToString();
            wisBox.Text = stats[wisSpot].ToString();
            intBox.Text = stats[intSpot].ToString();
            chaBox.Text = stats[chaSpot].ToString();

        }
        private void genBard(int[] stats)
        {
            //determine if primary is 1 or 2
            int dexSpot = rnd.Next(2);
            //determine if secondary is 1, 2, or 3
            int chaSpot = rnd.Next(3);

            //ensure primary != secondary
            while (chaSpot == dexSpot)
            {
                chaSpot = rnd.Next(3);
            }
            //determine the remaining spots
            int conSpot = rnd.Next(6);
            int intSpot = rnd.Next(6);
            int wisSpot = rnd.Next(6);
            int strSpot = rnd.Next(6);

            //ensure no clashes
            while (conSpot == strSpot || conSpot == dexSpot || conSpot == intSpot || conSpot == wisSpot || conSpot == chaSpot
                || intSpot == strSpot || intSpot == conSpot || intSpot == dexSpot || intSpot == wisSpot || intSpot == chaSpot
                || wisSpot == strSpot || wisSpot == conSpot || wisSpot == intSpot || wisSpot == dexSpot || wisSpot == chaSpot
                || strSpot == chaSpot || strSpot == conSpot || strSpot == intSpot || strSpot == wisSpot || strSpot == dexSpot)
            {
                conSpot = rnd.Next(6);
                intSpot = rnd.Next(6);
                wisSpot = rnd.Next(6);
                strSpot = rnd.Next(6);
            }

            //display attributes
            strBox.Text = stats[strSpot].ToString();
            conBox.Text = stats[conSpot].ToString();
            dexBox.Text = stats[dexSpot].ToString();
            wisBox.Text = stats[wisSpot].ToString();
            intBox.Text = stats[intSpot].ToString();
            chaBox.Text = stats[chaSpot].ToString();

        }
        private void genCleric(int[] stats)
        {
            //determine if primary is 1 or 2
            int wisSpot = rnd.Next(2);
            //determine if secondary is 1, 2, or 3
            int chaSpot = rnd.Next(3);

            //ensure primary != secondary
            while (chaSpot == wisSpot)
            {
                chaSpot = rnd.Next(3);
            }
            //determine the remaining spots
            int conSpot = rnd.Next(6);
            int intSpot = rnd.Next(6);
            int dexSpot = rnd.Next(6);
            int strSpot = rnd.Next(6);

            //ensure no clashes
            while (conSpot == strSpot || conSpot == dexSpot || conSpot == intSpot || conSpot == wisSpot || conSpot == chaSpot
                || intSpot == strSpot || intSpot == conSpot || intSpot == dexSpot || intSpot == wisSpot || intSpot == chaSpot
                || dexSpot == strSpot || dexSpot == conSpot || dexSpot == intSpot || wisSpot == dexSpot || dexSpot == chaSpot
                || strSpot == chaSpot || strSpot == conSpot || strSpot == intSpot || strSpot == wisSpot || strSpot == dexSpot)
            {
                conSpot = rnd.Next(6);
                intSpot = rnd.Next(6);
                dexSpot = rnd.Next(6);
                strSpot = rnd.Next(6);
            }

            //display attributes
            strBox.Text = stats[strSpot].ToString();
            conBox.Text = stats[conSpot].ToString();
            dexBox.Text = stats[dexSpot].ToString();
            wisBox.Text = stats[wisSpot].ToString();
            intBox.Text = stats[intSpot].ToString();
            chaBox.Text = stats[chaSpot].ToString();

        }
        private void genDruid(int[] stats)
        {
            //determine if primary is 1 or 2
            int wisSpot = rnd.Next(2);

            //determine the remaining spots
            int conSpot = rnd.Next(6);
            int intSpot = rnd.Next(6);
            int dexSpot = rnd.Next(6);
            int strSpot = rnd.Next(6);
            int chaSpot = rnd.Next(6);

            //ensure no clashes //made generic so I don't have to keep changing it.
            while (conSpot == strSpot || conSpot == dexSpot || conSpot == intSpot || conSpot == wisSpot || conSpot == chaSpot
                || intSpot == strSpot || intSpot == conSpot || intSpot == dexSpot || intSpot == wisSpot || intSpot == chaSpot
                || dexSpot == strSpot || dexSpot == conSpot || dexSpot == intSpot || dexSpot == wisSpot || dexSpot == chaSpot
                || strSpot == chaSpot || strSpot == conSpot || strSpot == intSpot || strSpot == wisSpot || strSpot == dexSpot
                || chaSpot == wisSpot || chaSpot == conSpot || chaSpot == intSpot || strSpot == chaSpot || chaSpot == dexSpot)
            {
                conSpot = rnd.Next(6);
                intSpot = rnd.Next(6);
                dexSpot = rnd.Next(6);
                strSpot = rnd.Next(6);
                chaSpot = rnd.Next(6);
            }

            //display attributes
            strBox.Text = stats[strSpot].ToString();
            conBox.Text = stats[conSpot].ToString();
            dexBox.Text = stats[dexSpot].ToString();
            wisBox.Text = stats[wisSpot].ToString();
            intBox.Text = stats[intSpot].ToString();
            chaBox.Text = stats[chaSpot].ToString();

        }
        private void genFight(int[] stats)
        {
            //determine if primary is 1 or 2
            int strSpot = rnd.Next(2);

            //determine the remaining spots
            int conSpot = rnd.Next(6);
            int intSpot = rnd.Next(6);
            int dexSpot = rnd.Next(6);
            int wisSpot = rnd.Next(6);
            int chaSpot = rnd.Next(6);

            //ensure no clashes //made generic so I don't have to keep changing it.
            while (conSpot == strSpot || conSpot == dexSpot || conSpot == intSpot || conSpot == wisSpot || conSpot == chaSpot
                || intSpot == strSpot || intSpot == conSpot || intSpot == dexSpot || intSpot == wisSpot || intSpot == chaSpot
                || dexSpot == strSpot || dexSpot == conSpot || dexSpot == intSpot || dexSpot == wisSpot || dexSpot == chaSpot
                || strSpot == chaSpot || strSpot == conSpot || strSpot == intSpot || strSpot == wisSpot || strSpot == dexSpot
                || chaSpot == wisSpot || chaSpot == conSpot || chaSpot == intSpot || strSpot == chaSpot || chaSpot == dexSpot)
            {
                conSpot = rnd.Next(6);
                intSpot = rnd.Next(6);
                dexSpot = rnd.Next(6);
                wisSpot = rnd.Next(6);
                chaSpot = rnd.Next(6);
            }

            //display attributes
            strBox.Text = stats[strSpot].ToString();
            conBox.Text = stats[conSpot].ToString();
            dexBox.Text = stats[dexSpot].ToString();
            wisBox.Text = stats[wisSpot].ToString();
            intBox.Text = stats[intSpot].ToString();
            chaBox.Text = stats[chaSpot].ToString();

        }
        private void genMonk(int[] stats)
        {
            //determine if primary is 1 or 2
            int strSpot = rnd.Next(2);
            //determine if secondary is 1, 2, or 3
            int dexSpot = rnd.Next(3);

            //ensure primary != secondary
            while (dexSpot == strSpot)
            {
                dexSpot = rnd.Next(3);
            }
            //determine if tertiary is 1, 2, 3, or 4
            int wisSpot = rnd.Next(4);

            //ensure primary != secondary
            while (wisSpot == strSpot || wisSpot == dexSpot)
            {
                wisSpot = rnd.Next(4);
            }
            //determine the remaining spots
            int conSpot = rnd.Next(6);
            int intSpot = rnd.Next(6);
            int chaSpot = rnd.Next(6);

            //ensure no clashes
            //ensure no clashes //made generic so I don't have to keep changing it.
            while (conSpot == strSpot || conSpot == dexSpot || conSpot == intSpot || conSpot == wisSpot || conSpot == chaSpot
                || intSpot == strSpot || intSpot == conSpot || intSpot == dexSpot || intSpot == wisSpot || intSpot == chaSpot
                || dexSpot == strSpot || dexSpot == conSpot || dexSpot == intSpot || dexSpot == wisSpot || dexSpot == chaSpot
                || strSpot == chaSpot || strSpot == conSpot || strSpot == intSpot || strSpot == wisSpot || strSpot == dexSpot
                || chaSpot == wisSpot || chaSpot == conSpot || chaSpot == intSpot || strSpot == chaSpot || chaSpot == dexSpot)
            {
                conSpot = rnd.Next(6);
                intSpot = rnd.Next(6);
                chaSpot = rnd.Next(6);
            }

            //display attributes
            strBox.Text = stats[strSpot].ToString();
            conBox.Text = stats[conSpot].ToString();
            dexBox.Text = stats[dexSpot].ToString();
            wisBox.Text = stats[wisSpot].ToString();
            intBox.Text = stats[intSpot].ToString();
            chaBox.Text = stats[chaSpot].ToString();

        }
        private void genPal(int[] stats)
        {
            //determine if primary is 1 or 2
            int strSpot = rnd.Next(2);
            //determine if secondary is 1, 2, or 3
            int chaSpot = rnd.Next(3);

            //ensure primary != secondary
            while (chaSpot == strSpot)
            {
                chaSpot = rnd.Next(3);
            }
            //determine the remaining spots
            int conSpot = rnd.Next(6);
            int intSpot = rnd.Next(6);
            int dexSpot = rnd.Next(6);
            int wisSpot = rnd.Next(6);

            //ensure no clashes
            while (conSpot == strSpot || conSpot == dexSpot || conSpot == intSpot || conSpot == wisSpot || conSpot == chaSpot
                || intSpot == strSpot || intSpot == conSpot || intSpot == dexSpot || intSpot == wisSpot || intSpot == chaSpot
                || dexSpot == strSpot || dexSpot == conSpot || dexSpot == intSpot || dexSpot == wisSpot || dexSpot == chaSpot
                || strSpot == chaSpot || strSpot == conSpot || strSpot == intSpot || strSpot == wisSpot || strSpot == dexSpot
                || chaSpot == wisSpot || chaSpot == conSpot || chaSpot == intSpot || strSpot == chaSpot || chaSpot == dexSpot)
            {
                conSpot = rnd.Next(6);
                intSpot = rnd.Next(6);
                dexSpot = rnd.Next(6);
                wisSpot = rnd.Next(6);
            }

            //display attributes
            strBox.Text = stats[strSpot].ToString();
            conBox.Text = stats[conSpot].ToString();
            dexBox.Text = stats[dexSpot].ToString();
            wisBox.Text = stats[wisSpot].ToString();
            intBox.Text = stats[intSpot].ToString();
            chaBox.Text = stats[chaSpot].ToString();

        }
        private void genRang(int[] stats)
        {
            //determine if primary is 1 or 2
            int dexSpot = rnd.Next(2);
            //determine if secondary is 1, 2, or 3
            int wisSpot = rnd.Next(3);

            //ensure primary != secondary
            while (wisSpot == dexSpot)
            {
                wisSpot = rnd.Next(3);
            }
            //determine the remaining spots
            int conSpot = rnd.Next(6);
            int intSpot = rnd.Next(6);
            int chaSpot = rnd.Next(6);
            int strSpot = rnd.Next(6);

            //ensure no clashes
            while (conSpot == strSpot || conSpot == dexSpot || conSpot == intSpot || conSpot == wisSpot || conSpot == chaSpot
                || intSpot == strSpot || intSpot == conSpot || intSpot == dexSpot || intSpot == wisSpot || intSpot == chaSpot
                || dexSpot == strSpot || dexSpot == conSpot || dexSpot == intSpot || dexSpot == wisSpot || dexSpot == chaSpot
                || strSpot == chaSpot || strSpot == conSpot || strSpot == intSpot || strSpot == wisSpot || strSpot == dexSpot
                || chaSpot == wisSpot || chaSpot == conSpot || chaSpot == intSpot || strSpot == chaSpot || chaSpot == dexSpot)
            {
                conSpot = rnd.Next(6);
                intSpot = rnd.Next(6);
                chaSpot = rnd.Next(6);
                strSpot = rnd.Next(6);
            }

            //display attributes
            strBox.Text = stats[strSpot].ToString();
            conBox.Text = stats[conSpot].ToString();
            dexBox.Text = stats[dexSpot].ToString();
            wisBox.Text = stats[wisSpot].ToString();
            intBox.Text = stats[intSpot].ToString();
            chaBox.Text = stats[chaSpot].ToString();

        }
        private void genRog(int[] stats)
        {
            //determine if primary is 1 or 2
            int dexSpot = rnd.Next(2);

            //determine the remaining spots
            int conSpot = rnd.Next(6);
            int intSpot = rnd.Next(6);
            int strSpot = rnd.Next(6);
            int wisSpot = rnd.Next(6);
            int chaSpot = rnd.Next(6);

            //ensure no clashes //made generic so I don't have to keep changing it.
            while (conSpot == strSpot || conSpot == dexSpot || conSpot == intSpot || conSpot == wisSpot || conSpot == chaSpot
                || intSpot == strSpot || intSpot == conSpot || intSpot == dexSpot || intSpot == wisSpot || intSpot == chaSpot
                || dexSpot == strSpot || dexSpot == conSpot || dexSpot == intSpot || dexSpot == wisSpot || dexSpot == chaSpot
                || strSpot == chaSpot || strSpot == conSpot || strSpot == intSpot || strSpot == wisSpot || strSpot == dexSpot
                || chaSpot == wisSpot || chaSpot == conSpot || chaSpot == intSpot || strSpot == chaSpot || chaSpot == dexSpot)
            {
                conSpot = rnd.Next(6);
                intSpot = rnd.Next(6);
                dexSpot = rnd.Next(6);
                wisSpot = rnd.Next(6);
                chaSpot = rnd.Next(6);
            }

            //display attributes
            strBox.Text = stats[strSpot].ToString();
            conBox.Text = stats[conSpot].ToString();
            dexBox.Text = stats[dexSpot].ToString();
            wisBox.Text = stats[wisSpot].ToString();
            intBox.Text = stats[intSpot].ToString();
            chaBox.Text = stats[chaSpot].ToString();

        }
        private void genSorc(int[] stats)
        {
            //determine if primary is 1 or 2
            int chaSpot = rnd.Next(2);

            //determine the remaining spots
            int conSpot = rnd.Next(6);
            int intSpot = rnd.Next(6);
            int strSpot = rnd.Next(6);
            int wisSpot = rnd.Next(6);
            int dexSpot = rnd.Next(6);

            //ensure no clashes //made generic so I don't have to keep changing it.
            while (conSpot == strSpot || conSpot == dexSpot || conSpot == intSpot || conSpot == wisSpot || conSpot == chaSpot
                || intSpot == strSpot || intSpot == conSpot || intSpot == dexSpot || intSpot == wisSpot || intSpot == chaSpot
                || dexSpot == strSpot || dexSpot == conSpot || dexSpot == intSpot || dexSpot == wisSpot || dexSpot == chaSpot
                || strSpot == chaSpot || strSpot == conSpot || strSpot == intSpot || strSpot == wisSpot || strSpot == dexSpot
                || chaSpot == wisSpot || chaSpot == conSpot || chaSpot == intSpot || strSpot == chaSpot || chaSpot == dexSpot)
            {
                conSpot = rnd.Next(6);
                intSpot = rnd.Next(6);
                dexSpot = rnd.Next(6);
                wisSpot = rnd.Next(6);
                strSpot = rnd.Next(6);
            }

            //display attributes
            strBox.Text = stats[strSpot].ToString();
            conBox.Text = stats[conSpot].ToString();
            dexBox.Text = stats[dexSpot].ToString();
            wisBox.Text = stats[wisSpot].ToString();
            intBox.Text = stats[intSpot].ToString();
            chaBox.Text = stats[chaSpot].ToString();

        }
        private void genWiz(int[] stats)
        {
            //determine if primary is 1 or 2
            int intSpot = rnd.Next(2);

            //determine the remaining spots
            int conSpot = rnd.Next(6);
            int chaSpot = rnd.Next(6);
            int strSpot = rnd.Next(6);
            int wisSpot = rnd.Next(6);
            int dexSpot = rnd.Next(6);

            //ensure no clashes //made generic so I don't have to keep changing it.
            while (conSpot == strSpot || conSpot == dexSpot || conSpot == intSpot || conSpot == wisSpot || conSpot == chaSpot
                || intSpot == strSpot || intSpot == conSpot || intSpot == dexSpot || intSpot == wisSpot || intSpot == chaSpot
                || dexSpot == strSpot || dexSpot == conSpot || dexSpot == intSpot || dexSpot == wisSpot || dexSpot == chaSpot
                || strSpot == chaSpot || strSpot == conSpot || strSpot == intSpot || strSpot == wisSpot || strSpot == dexSpot
                || chaSpot == wisSpot || chaSpot == conSpot || chaSpot == intSpot || strSpot == chaSpot || chaSpot == dexSpot)
            {
                conSpot = rnd.Next(6);
                chaSpot = rnd.Next(6);
                dexSpot = rnd.Next(6);
                wisSpot = rnd.Next(6);
                strSpot = rnd.Next(6);
            }

            //display attributes
            strBox.Text = stats[strSpot].ToString();
            conBox.Text = stats[conSpot].ToString();
            dexBox.Text = stats[dexSpot].ToString();
            wisBox.Text = stats[wisSpot].ToString();
            intBox.Text = stats[intSpot].ToString();
            chaBox.Text = stats[chaSpot].ToString();

        }
        */
        private void GenerateButtin_Click(object sender, RoutedEventArgs e)
        {
            rnd = new Random();

            newMe.genStats(); //generate new stat array, and then display it
            strBox.Text = newMe.MyStats.Strength.ToString();
            dexBox.Text = newMe.MyStats.Dexterity.ToString();
            conBox.Text = newMe.MyStats.Constitution.ToString();
            intBox.Text = newMe.MyStats.Intelligence.ToString();
            wisBox.Text = newMe.MyStats.Wisdom.ToString();
            chaBox.Text = newMe.MyStats.Charisma.ToString();

            if (!raceLock.IsOn || raceBox.SelectedIndex < 0)
            {
                //newMe.MyRace = new Races.Dwarf();
                newMe.genRace(); //generate my race
                raceBox.SelectedValue = newMe.MyRace.GetType().Name; //display my race
                //raceBox.SelectedIndex = rnd.Next(randRace.Length - 1);
            } else
            {
                newMe.MyRace = (Race)Activator.CreateInstance(newMe.MyRace.GetType()); //to redo any racial mods
            }

            //choose class
            if (!classLock.IsOn || classBox.SelectedIndex < 0)
            {
                newMe.genClass(); //generate my class
                classBox.SelectedValue = newMe.MyClass.GetType().Name; //display my class
                //randGen(rnd);
            } else
            {
                Output.Text = "I was expecting a crash, but passed " + newMe.MyClass.GetType();
                newMe.MyClass = (Class)Activator.CreateInstance(newMe.MyClass.GetType()); // to re-do any internal choices (feats, spells, etc)
                //I think each class is going to need a stats reorder
                // but, if I do it after race mods, that gets messy.
                // I think this is going to need a switch, or a bitwise enum or similar
                // to cater for each case. there are only 4 total options so far, so not too bad
                // no lock, lock race, lock class, and lock race and class... ah, but then there's the "locked but none selected" as well...
                //ah, I know, I'll have the race mods not part of the constructor for race, and call them out here
                //that makes it simpler, and allows the "reorder()" thing to work, and if more options are added later, it is easier to do so.
            }
            //Output.Text = "I made a "+newMe.MyRace.MyRace+"\r\n which is from the class "+newMe.MyRace.GetType().Name;
        }

        private void threshBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (threshBox.Text == "")
                {
                    threshBox.Text = "0";
                }
                int threshVal = Convert.ToInt32(threshBox.Text);
                threshhold = Math.Min(threshVal,18);
                if(threshhold > 17)
                {
                    threshBox.Text = threshhold.ToString();
                }
            }
            catch (Exception er)
            {
                threshBox.Text = threshhold.ToString();
                //throw er;
            }
        }
        
    }
}
