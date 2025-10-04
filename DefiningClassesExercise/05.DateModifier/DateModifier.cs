using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _05.DateModifier
{
    public class DateModifier
    {
        public int Days { get; private set; }

        public static int DaysBetweenDates(string date1, string date2)
        {
            DateTime firstDate = GetDate(date1);
            DateTime secondDate = GetDate(date2);
            DateTime GetDate(string date)
            {
                string[] tokens = date.Split(' ',StringSplitOptions.RemoveEmptyEntries);

                int year = int.Parse(tokens[0]);
                int month = int.Parse(tokens[1]);
                int day = int.Parse(tokens[2]);
                DateTime dateTime = new DateTime(year,month,day);
                return dateTime;
            }
            TimeSpan difference = secondDate - firstDate;
            return Math.Abs(difference.Days);
        }
    }
}
