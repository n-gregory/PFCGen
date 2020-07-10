using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace PFCharGen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
     public sealed partial class MainWindow : Window {
        Random rnd = new Random();
        int threshhold = 10;
        // String[] randClass = new String[] { "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Wizard" };
        // String[] randRace = new String[] { "Dwarf", "Elf", "Gnome", "Half-Elf", "Half-Orc", "Halfling", "Human" };
        Assembly assembly = Assembly.Load(new AssemblyName("PFCharGen"));
        Character newMe = new Character();
        //public bool FloatBonus = false;


        public MainWindow() {
            InitializeComponent();
        
            // Assembly Test;

            foreach (var item in newMe.MyRace.RaceList) {
                    raceBox.Items.Add(item.Name);
            }
            foreach (var item in newMe.MyClass.ClassList) {
                classBox.Items.Add(item.Name);
            }
        }


        private void GenerateButtin_Click(object sender, RoutedEventArgs e) {
            // rnd = new Random();

            newMe.genStats(); //generate new stat array, and then display it
            
            Output.Text = "My Strength is: "+newMe.MyStats.getStatValue("Strength").ToString();
            Output.Text += "\r\nMy Dexterity is: "+newMe.MyStats.getStatValue("Dexterity").ToString();
            Output.Text += "\r\nMy Constitution is: "+newMe.MyStats.getStatValue("Constitution").ToString();
            Output.Text += "\r\nMy Intelligence is: "+newMe.MyStats.getStatValue("Intelligence").ToString();
            Output.Text += "\r\nMy Wisdom is: "+newMe.MyStats.getStatValue("Wisdom").ToString();
            Output.Text += "\r\nMy Charisma is: "+newMe.MyStats.getStatValue("Charisma").ToString();
            
            if (!raceLock.IsChecked.Value || raceBox.SelectedIndex < 0) {
                //newMe.MyRace = new Races.Dwarf();
                newMe.genRace(); //generate my race
                raceBox.SelectedValue = newMe.MyRace.GetType().Name; //display my race
                                                                     //raceBox.SelectedIndex = rnd.Next(randRace.Length - 1);
            }
            else {
                
                String ns = newMe.MyRace.GetType().Namespace;
                
                //newMe.MyRace = (Race)Activator.CreateInstance(newMe.MyRace.GetType()); //to redo any racial mods

                // Type type = Type.GetType("" + ns + "." + raceBox.SelectedItem.GetType());
                // Output.Text = "I selected a(n) " + raceBox.SelectedItem.ToString();
                newMe.MyRace = (Race)Activator.CreateInstance(Type.GetType("" + ns + "." + raceBox.SelectedItem.ToString())); //to redo any racial mods
            }
            
                         //choose class
            if (!classLock.IsChecked.Value || classBox.SelectedIndex < 0) { //if not locked or selected
                newMe.genClass(); //generate my class
                classBox.SelectedValue = newMe.MyClass.GetType().Name; //display my class
                                                                       //randGen(rnd);
            }
            else { //if locked and selected
                //Output.Text = "I was expecting a crash, but passed " + newMe.MyClass.GetType();

                //reorder stats here
                // newMe.reOrder();
                String cns = newMe.MyClass.GetType().Namespace;
                newMe.MyClass = (Class)Activator.CreateInstance(Type.GetType("" + cns + "." + classBox.SelectedItem.ToString()));
                // newMe.MyClass = (Class)Activator.CreateInstance(newMe.MyClass.GetType()); 
                    // to re-do any internal choices (feats, spells, etc)
                    //I think each class is going to need a stats reorder
                    // but, if I do it after race mods, that gets messy.
                    // I think this is going to need a switch, or a bitwise enum or similar
                    // to cater for each case. there are only 4 total options so far, so not too bad
                    // no lock, lock race, lock class, and lock race and class... ah, but then there's the "locked but none selected" as well...
                    //ah, I know, I'll have the race mods not part of the constructor for race, and call them out here
                    //that makes it simpler, and allows the "reorder()" thing to work, and if more options are added later, it is easier to do so.
            }
            newMe.MyClass.applyStats(newMe);
            // newMe.MyRace.addRaceMods(newMe);
            updateStats();
                // Output.Text = "I made a "+newMe.MyRace.MyRace+"\r\n which is from the class "+newMe.MyRace.GetType().Name;
            }
            private void updateStats() {
                //should also look at generic-ifying thing
                //hopefully not too difficult to manage
                strBox.Text = newMe.MyStats.getStatValue("Strength").ToString();
                dexBox.Text = newMe.MyStats.getStatValue("Dexterity").ToString();
                conBox.Text = newMe.MyStats.getStatValue("Constitution").ToString();
                intBox.Text = newMe.MyStats.getStatValue("Intelligence").ToString();
                wisBox.Text = newMe.MyStats.getStatValue("Wisdom").ToString();
                chaBox.Text = newMe.MyStats.getStatValue("Charisma").ToString();
            }
            private void threshBox_TextChanged(object sender, TextChangedEventArgs e)
            {
                try {
                    if (threshBox.Text == "") {
                        threshBox.Text = "0";
                    }
                    int threshVal = Convert.ToInt32(threshBox.Text);
                    threshhold = Math.Min(threshVal, 18);
                    if (threshhold > 17) {
                        threshBox.Text = threshhold.ToString();
                    }
                }
                catch (Exception er) {
                    threshBox.Text = threshhold.ToString();
                    //throw er;
                }
            }
        }
    }

