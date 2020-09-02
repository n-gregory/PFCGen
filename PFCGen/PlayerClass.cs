using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using System.Text.Json;
// using System.Text.Json.Serialization;

namespace PFCharGen
{
    class PlayerClass
    {
        public string ClassName {get; set;}
        public string[] PrimaryAttributes {get; set;}
        private int ClassLevel {get; set;}
        public PlayerClass()
        {

        }
        public String getName(){
            return ClassName;
        }
    }
}
