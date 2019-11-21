using System;
using System.Globalization;

namespace Umbraco.Community.ExtensionMethods.Dates {
    
    public class DateHelpers {
        
        /// <summary>
        /// Gets the current age, from the specified date of birth.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <returns>Returns the age based on the specified date of birth.</returns>
        public static int GetAge(DateTime dateOfBirth) {
            return GetAge(DateTime.Today, DateTime.Now);
        }

        /// <summary>
        /// Gets the current age, from the specified date of birth. The age is calculated based on <var>dt</var>.
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="dt"></param>
        /// <returns>Returns the age based on the specified date of birth at the moment of <var>dt</var>.</returns>
        public static int GetAge(DateTime dateOfBirth, DateTime dt) {
            int age = dt.Year - dateOfBirth.Year;
            if (dt.Month < dateOfBirth.Month || (dt.Month == dateOfBirth.Month && dt.Day < dateOfBirth.Day)) age--;
            return age;
        }

        ///<summary>
        /// Gets the Day number and ordinal suffix for a given date.
        ///</summary>
        ///<param name="date">The date.</param>
        ///<returns>The day number and ordinal suffix.</returns>
        public static string GetDayNumber(DateTime date) {
            switch (date.Day) {
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
        /// Determines whether the specified date is weekday.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// Returns <var>TRUE</var> if the specified day is weekday; otherwise <var>FALSE</var>.
        /// </returns>
        public static bool IsWeekday(DateTime date) {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }

        /// <summary>
        /// Determines whether the specified date is weekend.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// Returns <var>TRUE</var> if the specified day is weekend; otherwise <var>FALSE</var>.
        /// </returns>
        public static bool IsWeekend(DateTime date) {
            return !IsWeekday(date);
        }

        /// <summary>
        /// Determines whether the year of the specified date is a leap year.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// Returns <var>TRUE</var> if the specified date is in a leap year; otherwise <var>FALSE</var>.
        /// </returns>
        public static bool IsLeapYear(DateTime date) {
            return IsLeapYear(date.Year);
        }

        /// <summary>
        /// Determines whether the specified year is a leap year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns>
        /// Returns <var>TRUE</var> if the specified year is a leap year; otherwise <var>FALSE</var>.
        /// </returns>
        public static bool IsLeapYear(int year) {
            return (DateTime.DaysInMonth(year, 2).Equals(29));
        }

        /// <summary>
        /// Get the English name of the day.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the English name of the day.</returns>
        public static string GetDayName(DateTime date) {
            return date.ToString("dddd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the name of the day as specified by the current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the local name of the day.</returns>
        public static string GetLocalDayName(DateTime date) {
            return date.ToString("dddd", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the name of the day as specified by <var>culture</var>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The culture to be used.</param>
        /// <returns>Returns the local name of the day.</returns>
        public static string GetLocalDayName(DateTime date, CultureInfo culture) {
            return date.ToString("dddd", culture);
        }

        /// <summary>
        /// Get the English name of the month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the English name of the month.</returns>
        public static string GetMonthName(DateTime date) {
            return date.ToString("MMMM", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the name of the month as specified by the current culture.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the local name of the month.</returns>
        public static string GetLocalMonthName(DateTime date) {
            return date.ToString("MMMM", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the name of the month as specified by <var>culture</var>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="culture">The culture to be used.</param>
        /// <returns>Returns the local name of the month.</returns>
        public static string GetLocalMonthName(DateTime date, CultureInfo culture) {
            return date.ToString("MMMM", culture);
        }

    }

}
