using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateProject;

namespace DateProjectTest
{
    [TestClass]
    public class DateTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestInvalidLargerMonthNumber()
        {
            var date = new Date(2015, 13, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestInvalidLessMonthNumber()
        {
            var date = new Date(2015, 0, 3);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestInvalidLargerDayNumber()
        {
            var date = new Date(2015, 7, 40);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidProgramException))]
        public void TestInvalidLessDayNumber()
        {
            var date = new Date(2015, 6, 0);
        }

        [TestMethod]
        public void TestGetCorrectMonthName()
        {
            var date = new Date(2015, 9, 15);

            Assert.AreEqual("The name of the month is September.", date.GetMonthName(), "");
        }

        [TestMethod]
        public void TestGetCorrectNumberOfRemainingDaysInMonth()
        {
            var date = new Date(2000, 2, 19);

            Assert.AreEqual(10, date.GetNumberOfRemainingDaysInMonth(), "");
        }

        [TestMethod]
        public void TestIfNotLeapYearReturnsFalse()
        {
            var date = new Date(2100, 4, 15);

            Assert.AreEqual(false, date.IsLeapYear(), "");
        }

        [TestMethod]
        public void TestIfLeapYearReturnsTrue()
        {
            var date = new Date(2000, 3, 30);
            var date2 = new Date(2004, 3, 30);

            Assert.AreEqual(true, date.IsLeapYear(), "");
            Assert.AreEqual(true, date2.IsLeapYear(), "");
        }
    }
}
