using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyUtilities;
using DebugTools;

namespace PFCharGen
{
    class ClassHandler 
    {
        private List<PlayerClass> classList;
        public ClassHandler(){
            classList = new List<PlayerClass>();
        }
        public ClassHandler(List<PlayerClass> oldList){
            classList = oldList;
        }
        public bool classExists(String name){
            //because a lot of these methods needed this line, made a method call.
            bool exists = classList.Exists(x => x.getName() == name);
            return exists;
        }
    }
}