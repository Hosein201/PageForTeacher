using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Utilities
{
    public static class RandomCommon
    {
        public static long GetRendom()
        {
            var rand = new Random();
            var result= rand.Next(0, 1000000000);
            return result;
        }
    }
}
