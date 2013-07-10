using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbraco.Community.ExtensionMethods.Numeric
{
    public static class Numeric
    {
        /// <summary>
        /// Safely parse any object to integer. Return zero if not an integer
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Integer Value</returns>
        public static int ToInt(this object number)
        {
            int retValue = 0;
            if (number != null)
                int.TryParse(number.ToString(), out retValue);

            return retValue;
        }

        /// <summary>
        /// Strips out the sign and returns the absolute value of given integer
        /// </summary>
        /// <param name="number">The given integer</param>
        /// <returns>The absolute value of given integer</returns>
        public static int AbsoluteValue(this int number)
        {
            return Math.Abs(number);
        }


    }
}
