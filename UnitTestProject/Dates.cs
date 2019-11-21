using System;
using System.Globalization;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Umbraco.Community.ExtensionMethods.Dates;
using Umbraco.Community.ExtensionMethods.Dates.ExtensionMethods;

namespace UnitTestProject {

    [TestClass]
    public class Dates {

        [TestMethod]
        public void GetAge() {

            // Since the age doesn't have a fixed value, we fake the value of "now"
            DateTime fakeNow = new DateTime(2014, 02, 15);

            Assert.AreEqual(44, DateHelpers.GetAge(new DateTime(1970, 01, 01), fakeNow));
            Assert.AreEqual(25, DateHelpers.GetAge(new DateTime(1988, 08, 17), fakeNow));

        }

        [TestMethod]
        public void GetDayNumber() {

            Assert.AreEqual("1st", DateHelpers.GetDayNumber(new DateTime(2014, 1, 1)));
            Assert.AreEqual("2nd", DateHelpers.GetDayNumber(new DateTime(2014, 1, 2)));
            Assert.AreEqual("3rd", DateHelpers.GetDayNumber(new DateTime(2014, 1, 3)));
            Assert.AreEqual("4th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 4)));
            Assert.AreEqual("5th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 5)));
            Assert.AreEqual("6th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 6)));
            Assert.AreEqual("7th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 7)));
            Assert.AreEqual("8th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 8)));
            Assert.AreEqual("9th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 9)));

            Assert.AreEqual("10th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 10)));
            Assert.AreEqual("11th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 11)));
            Assert.AreEqual("12th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 12)));
            Assert.AreEqual("13th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 13)));
            Assert.AreEqual("14th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 14)));
            Assert.AreEqual("15th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 15)));
            Assert.AreEqual("16th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 16)));
            Assert.AreEqual("17th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 17)));
            Assert.AreEqual("18th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 18)));
            Assert.AreEqual("19th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 19)));

            Assert.AreEqual("20th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 20)));
            Assert.AreEqual("21st", DateHelpers.GetDayNumber(new DateTime(2014, 1, 21)));
            Assert.AreEqual("22nd", DateHelpers.GetDayNumber(new DateTime(2014, 1, 22)));
            Assert.AreEqual("23rd", DateHelpers.GetDayNumber(new DateTime(2014, 1, 23)));
            Assert.AreEqual("24th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 24)));
            Assert.AreEqual("25th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 25)));
            Assert.AreEqual("26th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 26)));
            Assert.AreEqual("27th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 27)));
            Assert.AreEqual("28th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 28)));
            Assert.AreEqual("29th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 29)));

            Assert.AreEqual("30th", DateHelpers.GetDayNumber(new DateTime(2014, 1, 30)));
            Assert.AreEqual("31st", DateHelpers.GetDayNumber(new DateTime(2014, 1, 31)));

        }

        [TestMethod]
        public void IsWeekDay() {

            Assert.AreEqual(true, DateHelpers.IsWeekday(new DateTime(2014, 2, 10)));
            Assert.AreEqual(true, DateHelpers.IsWeekday(new DateTime(2014, 2, 11)));
            Assert.AreEqual(true, DateHelpers.IsWeekday(new DateTime(2014, 2, 12)));
            Assert.AreEqual(true, DateHelpers.IsWeekday(new DateTime(2014, 2, 13)));
            Assert.AreEqual(true, DateHelpers.IsWeekday(new DateTime(2014, 2, 14)));
            Assert.AreEqual(false, DateHelpers.IsWeekday(new DateTime(2014, 2, 15)));
            Assert.AreEqual(false, DateHelpers.IsWeekday(new DateTime(2014, 2, 16)));

        }

        [TestMethod]
        public void IsWeekend() {

            Assert.AreEqual(false, DateHelpers.IsWeekend(new DateTime(2014, 2, 10)));
            Assert.AreEqual(false, DateHelpers.IsWeekend(new DateTime(2014, 2, 11)));
            Assert.AreEqual(false, DateHelpers.IsWeekend(new DateTime(2014, 2, 12)));
            Assert.AreEqual(false, DateHelpers.IsWeekend(new DateTime(2014, 2, 13)));
            Assert.AreEqual(false, DateHelpers.IsWeekend(new DateTime(2014, 2, 14)));
            Assert.AreEqual(true, DateHelpers.IsWeekend(new DateTime(2014, 2, 15)));
            Assert.AreEqual(true, DateHelpers.IsWeekend(new DateTime(2014, 2, 16)));

        }

        [TestMethod]
        public void IsLeapYear() {

            // Se more here: http://en.wikipedia.org/wiki/Leap_year#Algorithm

            Assert.AreEqual(true, DateHelpers.IsLeapYear(2000));
            Assert.AreEqual(false, DateHelpers.IsLeapYear(2001));
            Assert.AreEqual(false, DateHelpers.IsLeapYear(2002));
            Assert.AreEqual(false, DateHelpers.IsLeapYear(2003));
            Assert.AreEqual(true, DateHelpers.IsLeapYear(2004));
            Assert.AreEqual(false, DateHelpers.IsLeapYear(2005));
            Assert.AreEqual(false, DateHelpers.IsLeapYear(2006));
            Assert.AreEqual(false, DateHelpers.IsLeapYear(2007));
            Assert.AreEqual(true, DateHelpers.IsLeapYear(2008));
            Assert.AreEqual(false, DateHelpers.IsLeapYear(2009));
            Assert.AreEqual(false, DateHelpers.IsLeapYear(2010));
            Assert.AreEqual(false, DateHelpers.IsLeapYear(2011));
            Assert.AreEqual(true, DateHelpers.IsLeapYear(2012));
            Assert.AreEqual(false, DateHelpers.IsLeapYear(2013));
            Assert.AreEqual(false, DateHelpers.IsLeapYear(2014));

            Assert.AreEqual(false, DateHelpers.IsLeapYear(1500));
            Assert.AreEqual(true, DateHelpers.IsLeapYear(1600));
            Assert.AreEqual(false, DateHelpers.IsLeapYear(1700));
            Assert.AreEqual(false, DateHelpers.IsLeapYear(1800));
            Assert.AreEqual(false, DateHelpers.IsLeapYear(1900));
            Assert.AreEqual(true, DateHelpers.IsLeapYear(2000));
            Assert.AreEqual(false, DateHelpers.IsLeapYear(2100));
            Assert.AreEqual(false, DateHelpers.IsLeapYear(2200));
            Assert.AreEqual(false, DateHelpers.IsLeapYear(2300));
            Assert.AreEqual(true, DateHelpers.IsLeapYear(2400));

        }

        [TestMethod]
        public void GetDayName() {

            // Test with InvariantCulture
            Assert.AreEqual("Monday", DateHelpers.GetDayName(new DateTime(2014, 2, 10)));
            Assert.AreEqual("Tuesday", DateHelpers.GetDayName(new DateTime(2014, 2, 11)));
            Assert.AreEqual("Wednesday", DateHelpers.GetDayName(new DateTime(2014, 2, 12)));
            Assert.AreEqual("Thursday", DateHelpers.GetDayName(new DateTime(2014, 2, 13)));
            Assert.AreEqual("Friday", DateHelpers.GetDayName(new DateTime(2014, 2, 14)));
            Assert.AreEqual("Saturday", DateHelpers.GetDayName(new DateTime(2014, 2, 15)));
            Assert.AreEqual("Sunday", DateHelpers.GetDayName(new DateTime(2014, 2, 16)));

            // Set current culture as "da-DK"
            Thread.CurrentThread.CurrentCulture = new CultureInfo("da-DK");
            Assert.AreEqual("mandag", DateHelpers.GetLocalDayName(new DateTime(2014, 2, 10)));
            Assert.AreEqual("tirsdag", DateHelpers.GetLocalDayName(new DateTime(2014, 2, 11)));
            Assert.AreEqual("onsdag", DateHelpers.GetLocalDayName(new DateTime(2014, 2, 12)));
            Assert.AreEqual("torsdag", DateHelpers.GetLocalDayName(new DateTime(2014, 2, 13)));
            Assert.AreEqual("fredag", DateHelpers.GetLocalDayName(new DateTime(2014, 2, 14)));
            Assert.AreEqual("lørdag", DateHelpers.GetLocalDayName(new DateTime(2014, 2, 15)));
            Assert.AreEqual("søndag", DateHelpers.GetLocalDayName(new DateTime(2014, 2, 16)));

            // Test with specific culture (de-DE)
            CultureInfo german = new CultureInfo("de-DE");
            Assert.AreEqual("Montag", DateHelpers.GetLocalDayName(new DateTime(2014, 2, 10), german));
            Assert.AreEqual("Dienstag", DateHelpers.GetLocalDayName(new DateTime(2014, 2, 11), german));
            Assert.AreEqual("Mittwoch", DateHelpers.GetLocalDayName(new DateTime(2014, 2, 12), german));
            Assert.AreEqual("Donnerstag", DateHelpers.GetLocalDayName(new DateTime(2014, 2, 13), german));
            Assert.AreEqual("Freitag", DateHelpers.GetLocalDayName(new DateTime(2014, 2, 14), german));
            Assert.AreEqual("Samstag", DateHelpers.GetLocalDayName(new DateTime(2014, 2, 15), german));
            Assert.AreEqual("Sonntag", DateHelpers.GetLocalDayName(new DateTime(2014, 2, 16), german));

        }

        [TestMethod]
        public void GetMonthName() {

            // Test with InvariantCulture
            Assert.AreEqual("January", DateHelpers.GetMonthName(new DateTime(2014, 1, 1)));
            Assert.AreEqual("February", DateHelpers.GetMonthName(new DateTime(2014, 2, 1)));
            Assert.AreEqual("March", DateHelpers.GetMonthName(new DateTime(2014, 3, 1)));
            Assert.AreEqual("April", DateHelpers.GetMonthName(new DateTime(2014, 4, 1)));
            Assert.AreEqual("May", DateHelpers.GetMonthName(new DateTime(2014, 5, 1)));
            Assert.AreEqual("June", DateHelpers.GetMonthName(new DateTime(2014, 6, 1)));
            Assert.AreEqual("July", DateHelpers.GetMonthName(new DateTime(2014, 7, 1)));
            Assert.AreEqual("August", DateHelpers.GetMonthName(new DateTime(2014, 8, 1)));
            Assert.AreEqual("September", DateHelpers.GetMonthName(new DateTime(2014, 9, 1)));
            Assert.AreEqual("October", DateHelpers.GetMonthName(new DateTime(2014, 10, 1)));
            Assert.AreEqual("November", DateHelpers.GetMonthName(new DateTime(2014, 11, 1)));
            Assert.AreEqual("December", DateHelpers.GetMonthName(new DateTime(2014, 12, 1)));

            // Set current culture as "da-DK"
            Thread.CurrentThread.CurrentCulture = new CultureInfo("da-DK");
            Assert.AreEqual("januar", DateHelpers.GetLocalMonthName(new DateTime(2014, 1, 1)));
            Assert.AreEqual("februar", DateHelpers.GetLocalMonthName(new DateTime(2014, 2, 1)));
            Assert.AreEqual("marts", DateHelpers.GetLocalMonthName(new DateTime(2014, 3, 1)));
            Assert.AreEqual("april", DateHelpers.GetLocalMonthName(new DateTime(2014, 4, 1)));
            Assert.AreEqual("maj", DateHelpers.GetLocalMonthName(new DateTime(2014, 5, 1)));
            Assert.AreEqual("juni", DateHelpers.GetLocalMonthName(new DateTime(2014, 6, 1)));
            Assert.AreEqual("juli", DateHelpers.GetLocalMonthName(new DateTime(2014, 7, 1)));
            Assert.AreEqual("august", DateHelpers.GetLocalMonthName(new DateTime(2014, 8, 1)));
            Assert.AreEqual("september", DateHelpers.GetLocalMonthName(new DateTime(2014, 9, 1)));
            Assert.AreEqual("oktober", DateHelpers.GetLocalMonthName(new DateTime(2014, 10, 1)));
            Assert.AreEqual("november", DateHelpers.GetLocalMonthName(new DateTime(2014, 11, 1)));
            Assert.AreEqual("december", DateHelpers.GetLocalMonthName(new DateTime(2014, 12, 1)));

            // Test with specific culture (de-DE)
            CultureInfo german = new CultureInfo("de-DE");
            Assert.AreEqual("Januar", DateHelpers.GetLocalMonthName(new DateTime(2014, 1, 1), german));
            Assert.AreEqual("Februar", DateHelpers.GetLocalMonthName(new DateTime(2014, 2, 1), german));
            Assert.AreEqual("März", DateHelpers.GetLocalMonthName(new DateTime(2014, 3, 1), german));
            Assert.AreEqual("April", DateHelpers.GetLocalMonthName(new DateTime(2014, 4, 1), german));
            Assert.AreEqual("Mai", DateHelpers.GetLocalMonthName(new DateTime(2014, 5, 1), german));
            Assert.AreEqual("Juni", DateHelpers.GetLocalMonthName(new DateTime(2014, 6, 1), german));
            Assert.AreEqual("Juli", DateHelpers.GetLocalMonthName(new DateTime(2014, 7, 1), german));
            Assert.AreEqual("August", DateHelpers.GetLocalMonthName(new DateTime(2014, 8, 1), german));
            Assert.AreEqual("September", DateHelpers.GetLocalMonthName(new DateTime(2014, 9, 1), german));
            Assert.AreEqual("Oktober", DateHelpers.GetLocalMonthName(new DateTime(2014, 10, 1), german));
            Assert.AreEqual("November", DateHelpers.GetLocalMonthName(new DateTime(2014, 11, 1), german));
            Assert.AreEqual("Dezember", DateHelpers.GetLocalMonthName(new DateTime(2014, 12, 1), german));

        }
    
    }

}
