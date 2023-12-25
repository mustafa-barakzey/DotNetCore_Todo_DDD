using System.Globalization;

namespace brk.Framework.Tools.DateTimes
{
    public static class PersianDated
    {
        /// <summary>
        /// تبدیل تاریخ به فرمت سال/ماه/روز 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToShamsiDate(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();

            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                   pc.GetDayOfMonth(value).ToString("00");
        }
        /// <summary>
        /// تبدیل تاریخ به فرمت کامل هرماه با ساعت
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToShamsiDateTime(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return new DateTime(pc.GetYear(value), pc.GetMonth(value), pc.GetDayOfMonth(value), 0, 0, 0);
        }
        /// <summary>
        /// تبدیل تاریخ شمسی به میلادی
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime ToMiladi(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, new PersianCalendar());
        }
        /// <summary>
        /// تاریخ میلادی سال/ماه /روز
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDateNow()
        {
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        }

        /// <summary>
        /// ساعت و دقیقه
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static string GetHourAndMinutesFormat(this DateTime time)
        {
            return time.ToString("HH:mm");
        }

        /// <summary>
        /// تبدیل تاریخ به فرمت فارسی به همراه ماه های شمسی
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToStringShamsiDate(this DateTime dt)
        {
            System.Globalization.PersianCalendar PC = new PersianCalendar();
            int intYear = PC.GetYear(dt);
            int intMonth = PC.GetMonth(dt);
            int intDayOfMonth = PC.GetDayOfMonth(dt);
            DayOfWeek enDayOfWeek = PC.GetDayOfWeek(dt);
            string strMonthName = "";
            string strDayName = "";
            switch (intMonth)
            {
                case 1:
                    strMonthName = "فروردین";
                    break;
                case 2:
                    strMonthName = "اردیبهشت";
                    break;
                case 3:
                    strMonthName = "خرداد";
                    break;
                case 4:
                    strMonthName = "تیر";
                    break;
                case 5:
                    strMonthName = "مرداد";
                    break;
                case 6:
                    strMonthName = "شهریور";
                    break;
                case 7:
                    strMonthName = "مهر";
                    break;
                case 8:
                    strMonthName = "آبان";
                    break;
                case 9:
                    strMonthName = "آذر";
                    break;
                case 10:
                    strMonthName = "دی";
                    break;
                case 11:
                    strMonthName = "بهمن";
                    break;
                case 12:
                    strMonthName = "اسفند";
                    break;
                default:
                    strMonthName = "";
                    break;
            }

            switch (enDayOfWeek)
            {
                case DayOfWeek.Friday:
                    strDayName = "جمعه";
                    break;
                case DayOfWeek.Monday:
                    strDayName = "دوشنبه";
                    break;
                case DayOfWeek.Saturday:
                    strDayName = "شنبه";
                    break;
                case DayOfWeek.Sunday:
                    strDayName = "یکشنبه";
                    break;
                case DayOfWeek.Thursday:
                    strDayName = "پنجشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    strDayName = "سه شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    strDayName = "چهارشنبه";
                    break;
                default:
                    strDayName = "";
                    break;
            }

            return (string.Format("{0} {1} {2} {3}", strDayName, intDayOfMonth, strMonthName, intYear));
        }

        /// <summary>
        /// ساعت و دقیقه
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        public static string ToShortTime(this TimeSpan ts)
        {
            return ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00");
        }

        /// <summary>
        /// تبدیل اعداد انگلیسی به فارسی
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string ToFarsiNumber(this string text) =>
            text.Replace("0", "۰")
                .Replace("1", "۱")
                .Replace("2", "۲")
                .Replace("3", "۳")
                .Replace("4", "۴")
                .Replace("5", "۵")
                .Replace("6", "۶")
                .Replace("7", "۷")
                .Replace("8", "۸")
                .Replace("9", "۹");
    }
}
