using System;
using System.IO;
using System.Text;
// using System.Linq;

namespace DebugTools
{
    public static class DebugHelper
    {
        private static String path = @"debug_log.txt";
        public static void addMessage(String msg){
            try
            {
                if (!File.Exists(path)){
                    // Create the file, or overwrite if the file exists.
                    using (FileStream fs = File.Create(path))
                    {
                        using (StreamWriter writer = new StreamWriter(fs)){
                            writer.WriteLine("New debug file created at: "+System.DateTime.Now.ToString());
                        }
                    }
                }
                using (StreamWriter sw = File.AppendText(path)){
                    sw.WriteLine(msg);
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
