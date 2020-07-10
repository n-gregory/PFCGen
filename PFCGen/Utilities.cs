using System;
namespace MyUtilities
{
    public static class Util
    {
        private static Random rnd = new Random();
        public static int GetRandom()
        {
            return rnd.Next();
        }
        public static int GetRandom(int max)
        {
            return rnd.Next(max);
        }
        public static int GetRandom(int min,int max)
        {
            return rnd.Next(min,max);
        }
    }
}