using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umbraco.Community.ExtensionMethods
{
    public static class Dates
    {
        /// <summary>
        /// Get the current age, from the specified date of birth.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <returns>
        /// Returns the age based on the specified date of birth.
        /// </returns>
        /// Kudos to uComponents - http://ucomponents.codeplex.com/SourceControl/latest#uComponents.XsltExtensions/Dates.cs
        public static int Age(this DateTime dateOfBirth)
        {
            //Today's date
            var today = DateTime.Today;
           
            // if month is less, or if month is equal, and day less
            if (today.Month < dateOfBirth.Month || today.Month == dateOfBirth.Month && today.Day < dateOfBirth.Day)
            {
                // then they haven't had this year's birthday yet!
                return today.Year - dateOfBirth.Year - 1;
            }
            else
            {
                // otherwise, substract the current year from date-of-birth.
                return today.Year - dateOfBirth.Year;
            }

            // unable to parse date-of-birth.
            return -1;
        }
    }
}
