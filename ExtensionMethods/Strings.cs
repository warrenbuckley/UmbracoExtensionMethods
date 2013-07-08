using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbraco.Community.ExtensionMethods.Strings
{
    public static class Strings
    {
        /// <summary>
        /// Counts number of words in a string
        /// </summary>
        /// <param name="str">The string to parse</param>
        /// <returns>An integer of the number of words found</returns>
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
