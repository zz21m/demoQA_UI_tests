using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Framework.Utilities
{
    public static class DateUtility
    {

        public static DateTime ParseDate(string value, string format)
        {
            return DateTime.ParseExact(
                value,
                format,
                CultureInfo.InvariantCulture);
        }

        public static DateTime GetNearestDate(int day, int month)
        {
            var currentDate = DateTime.Today;
            var year = currentDate.Year;

            while (true)
            {
                try
                {
                    var date = new DateTime(year, month, day);

                    if (date >= currentDate)
                    {
                        return date;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                }

                year++;
            }
        }
    }
}
