/*=============================================================================
#     FileName: DateTimeExtension.cs
#         Desc: 
#       Author: WangHeng
#        Email: me@wangheng.org
#     HomePage: http://wangheng.org
#      Version: 0.0.1
#   LastChange: 2012-06-08 11:38:35
#      History:
=============================================================================*/
using System;
using System.Collections.Generic;
using System.Text;
namespace Cron
{
    public static class DateTimeExtension
    {
        public static bool JianQu(this DateTime now, string minutes, string hours, string days, string months, string week)
        {
            bool m, h, d, M, w;
            m = h = d = M = w = false;

            foreach (string minute in minutes.Split(','))
            {
                if (minute == "*" ? true : DateTime.Now.Minute - Convert.ToInt32(minute) == 0)
                    m = true;
            }
            foreach (string hour in hours.Split(','))
            {
                if (hour == "*" ? true : DateTime.Now.Hour - Convert.ToInt32(hour) == 0)
                    h = true;
            }
            foreach (string day in days.Split(','))
            {
                if (day == "*" ? true : DateTime.Now.Day - Convert.ToInt32(day) == 0)
                    d = true;
            }
            foreach (string month in months.Split(','))
            {
                M = (month == "*" ? true : DateTime.Now.Month - Convert.ToInt32(month) == 0) ? true : M;
            }
            foreach (string wee in week.Split(','))
            {
                w = (wee == "*" ? true : WeekToInt(DateTime.Now.DayOfWeek) - Convert.ToInt32(wee) == 0) ? true : w;
            }

            return m & h & M & (d | w);
        }

        private static int WeekToInt(DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return 0;
                case DayOfWeek.Monday:
                    return 1;
                case DayOfWeek.Tuesday:
                    return 2;
                case DayOfWeek.Wednesday:
                    return 3;
                case DayOfWeek.Thursday:
                    return 4;
                case DayOfWeek.Friday:
                    return 5;
                case DayOfWeek.Saturday:
                    return 6;
                default:
                    //there is something wrong by return -1
                    return -1;
            }
        }
    }
}
