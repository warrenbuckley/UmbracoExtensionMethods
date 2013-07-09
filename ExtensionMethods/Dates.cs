using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Umbraco.Community.ExtensionMethods.Dates
{
    /// Kudos to uComponents - http://ucomponents.codeplex.com/SourceControl/latest#uComponents.XsltExtensions/Dates.cs
    public static class Dates
    {

        /// <summary>
        /// The default DateTime format for uComponents.
        /// </summary>
        internal const string DefaultDateFormat = "dd MMMM yyyy";


        /// <summary>
        /// Get the current age, from the specified date of birth.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <returns>
        /// Returns the age based on the specified date of birth.
        /// </returns>
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

        ///<summary>
        /// Gets the Day number and ordinal suffix for a given date
        ///</summary>
        ///<param name="date">The date</param>
        ///<returns>The day number and ordinal suffix</returns>
        public static string GetDayNumber(this DateTime date)
        {
            switch (date.Day)
            {
                case 1:
                case 21:
                case 31:
                    return date.Day + "st";
                case 2:
                case 22:
                    return date.Day + "nd";
                case 3:
                case 23:
                    return date.Day + "rd";
                default:
                    return date.Day + "th";
            }
        }


        /// <summary>
        /// Determines whether the specified day is weekday.
        /// </summary>
        /// <param name="day">The date</param>
        /// <returns>
        /// 	<c>true</c> if the specified day is weekday; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWeekday(this DateTime date)
        {
            var day = date.DayOfWeek;

            switch (day)
            {
                // is a weekend?
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return false;

                // otherwise its a weekday?
                default:
                    return true;
            }
        }

        /// <summary>
        /// Determines whether the specified date is weekend.
        /// </summary>
        /// <param name="date">The date</param>
        /// <returns>
        /// 	<c>true</c> if the specified date is weekend; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsWeekend(this DateTime date)
        {
            return !IsWeekday(date);
        }


        /// <summary>
        /// Determines whether [is leap year] [the specified date].
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// 	<c>true</c> if [is leap year] [the specified date]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsLeapYear(this DateTime date)
        {
            // test if number of days in Feburary is 29 for the current year in the date
            return (DateTime.DaysInMonth(date.Year, 2).Equals(29));
        }

        /// <summary>
        /// Gets the elapsed seconds since the input DateTime.
        /// </summary>
        /// <param name="date">The input DateTime (as a string).</param>
        /// <returns>
        /// Returns the elapsed seconds since the input DateTime.
        /// </returns>
        public static double ElapsedSeconds(this DateTime date)
        {
           
            return DateTime.Now.Subtract(date).TotalSeconds;
        }

        /// <summary>
        /// Tests if a date is within the last number of specified days.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="days">The number of days.</param>
        /// <returns>
        /// Returns true or false depending on if the date is within the last number of days.
        /// </returns>
        public static bool DateWithinLastDays(this DateTime date, int days)
        {
            var lastDays    = (double)0 - days;
            var startDate   = date.AddDays(lastDays);

            return (date >= startDate);
        }

        /// <summary>
        /// Converts a date to Unix time.
        /// </summary>
        /// <param name="date">The date string.</param>
        /// <returns>
        /// Return the total number of seconds between Unix epoch and the specified date/time.
        /// </returns>
        public static double ToUnixTime(this DateTime date)
        {
            // set the Unix epoch
            var unixEpoch = new DateTime(1970, 1, 1);

            // return the total seconds (from either specified date or current date/time).
            return (date - unixEpoch).TotalSeconds;
        }

        /// <summary>
        /// Gets the first day of month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfMonth(this DateTime date)
        {
            // get the first day of the month.
            var firstDay = new DateTime(date.Year, date.Month, 1);
            return firstDay;
        }

        /// <summary>
        /// Gets the last day of month.
        /// </summary>
        /// <param name="date">The date string.</param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(this DateTime date)
        {
            // get the last day of the month.
            var lastDay = new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
            return lastDay;
        }

        /// <summary>
        /// Gets the pretty date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns a pretty date.</returns>
        /// <remarks>
        /// http://dotnetperls.com/pretty-date
        /// http://ejohn.org/blog/javascript-pretty-date/
        /// </remarks>
        public static string PrettyDate(this DateTime date)
        {
            // 1. Get time span elapsed since the date.
            var s = DateTime.Now.Subtract(date);

            // 2. Get total number of days elapsed.
            var dayDiff = (int)s.TotalDays;

            // 3. Get total number of seconds elapsed.
            var secDiff = (int)s.TotalSeconds;

            // 4. Don't allow out of range values.
            if (dayDiff < 0 || dayDiff >= 31)
            {
                return date.ToString();
            }

            // 5. Handle same-day times.
            if (dayDiff == 0)
            {
                // A. Less than one minute ago.
                if (secDiff < 60)
                {
                    return "just now";
                }

                // B. Less than 2 minutes ago.
                if (secDiff < 120)
                {
                    return "1 minute ago";
                }

                // C.Less than one hour ago.
                if (secDiff < 3600)
                {
                    return string.Format("{0} minutes ago", Math.Floor((double)secDiff / 60));
                }

                // D. Less than 2 hours ago.
                if (secDiff < 7200)
                {
                    return "1 hour ago";
                }

                // E. Less than one day ago.
                if (secDiff < 86400)
                {
                    return string.Format("{0} hours ago", Math.Floor((double)secDiff / 3600));
                }
            }

            // 6. Handle previous days.
            if (dayDiff == 1)
            {
                return "yesterday";
            }

            if (dayDiff < 7)
            {
                return string.Format("{0} days ago", dayDiff);
            }

            if (dayDiff < 14)
            {
                return "1 week ago";
            }

            if (dayDiff < 31)
            {
                return string.Format("{0} weeks ago", Math.Ceiling((double)dayDiff / 7));
            }

            return date.ToString();
        }


        /// <summary>
        /// Formats the date time.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="format">The format.</param>
        /// <returns></returns>
        public static string FormatDateTime(this DateTime date, string format)
        {
            // if the format string is empty...
            if (string.IsNullOrEmpty(format))
            {
                // ... set it to the default date format.
                format = DefaultDateFormat;
            }
            else
            {
                // otherwise, replace the ordinal token
                format = Regex.Replace(format, @"(?<!\\)((\\\\)*)(S)", "$1" + GetDayNumberSuffix(date));
            }

            // return with formatting the remaining tokens.
            return date.ToString(format);
        }

        ///<summary>
        /// Gets the ordinal suffix for a given date
        ///</summary>
        ///<param name="date">The date</param>
        ///<returns>The ordinal suffix</returns>
        private static string GetDayNumberSuffix(DateTime date)
        {
            switch (date.Day)
            {
                case 1:
                case 21:
                case 31:
                    return @"\s\t";
                case 2:
                case 22:
                    return @"\n\d";
                case 3:
                case 23:
                    return @"\r\d";
                default:
                    return @"\t\h";
            }
        }


        /// <summary>
        /// Transform an integer between 1 and 12 into month name.
        /// </summary>
        /// <param name="month">Month</param>
        /// <returns></returns>
        public static string GetMonthName(int month)
        {
            string monthName = "";
            if (month > 0)
            {
                monthName = month <= 12 ? CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month) : month.ToString();
            }          
            return monthName;
        }
    }
}
