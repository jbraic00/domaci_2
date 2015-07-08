using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateProject
{
    public class Date
    {
        private int year;
        private int month;
        private int day;

        public string[] months = new string[12] {"January", "February", "March", "April",
                                                 "May", "June", "July", "August",
                                                 "September", "October", "November", "December"};
        public int[] numberOfDays = new int[12] {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

        public Date(int year, int month, int day)
        {
            if (month < 1 || month > 12)
            {
                throw new InvalidProgramException("Month is not between 1 and 12.");
            }

            if (day < 1 || day > numberOfDays[month - 1])
            {
                throw new InvalidProgramException("Day number is not correct for this month.");
            }
            
            this.year = year;
            this.month = month;
            this.day = day;
            
            if (month == 2 && IsLeapYear())
            {
                numberOfDays[month-1] = 29;
            }
        }

        public string GetMonthName()
        { 
            return "The name of the month is " + months[month-1] + ".";
        }

        public int GetNumberOfRemainingDaysInMonth()
        {
            return numberOfDays[month-1] - day;
        }

        public bool IsLeapYear()
        {
            if (((year % 4 == 0) && (year % 100 != 0)) || year % 400 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
