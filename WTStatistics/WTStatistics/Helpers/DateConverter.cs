using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace WTStatistics.Helpers
{
    class DateConverter
    {
        public double GetSpendTime(string timeHTML)
        {
            Regex regexOnlyNumbersWithDots = new Regex(@"[А-Яа-я\s]");
            string regexMounth = @"^[0-9]{1,2}.{1,}м$";
            string regexDayAndHour = @"^[0-9]{1,2}д\s[0-9]{1,2}ч$";
            string regexHourAndMin = @"^[0-9]{1,2}ч\s[0-9]{1,2}мин$";

            Match matchMounth = Regex.Match(timeHTML, regexMounth, RegexOptions.IgnoreCase);
            Match matchDayAndHours = Regex.Match(timeHTML, regexDayAndHour, RegexOptions.IgnoreCase);
            Match matchHoursAndMinutes = Regex.Match(timeHTML, regexHourAndMin, RegexOptions.IgnoreCase);


            if (matchMounth.Success)
            {
                string totalTime_d = regexOnlyNumbersWithDots.Replace(timeHTML, "");
                CultureInfo temp_culture = Thread.CurrentThread.CurrentCulture;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
                var totalTime = Convert.ToDouble(totalTime_d);
                Thread.CurrentThread.CurrentCulture = temp_culture;
                return totalTime * 30;
            }
            else
              if (matchDayAndHours.Success)
            {
                var time = TimeSpan.ParseExact(timeHTML, "d'д 'h'ч'", null);
                return time.TotalDays;
            }
            else
              if (matchHoursAndMinutes.Success)
            {
                var time = TimeSpan.ParseExact(timeHTML, "h'ч 'm'мин'", null);
                return time.TotalDays;
            }
            return 0;
        }
    }
}
