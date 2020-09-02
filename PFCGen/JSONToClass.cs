using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

using DebugTools;

namespace PFCharGen
{
    class JSONToClass
    {
        public PlayerClass resultClass {get; set;}

        public void makePlayerClass(string filePath){
            string jsonString = File.ReadAllText(filePath);
            // using (FileStream fs = File.OpenRead(filePath))
            // {
                resultClass = JsonSerializer.Deserialize<PlayerClass>(jsonString);
            // }
        }

        public PlayerClass giveResults(){
            if (resultClass != null){
                // DebugHelper.addMessage("inside giveResults() and resultClass is not null");
                return resultClass;
            }
            else {
                // DebugHelper.addMessage("inside giveResults() and resultClass is null");
                return null;
            }
        }
    }
}
