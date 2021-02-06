using System;
using System.Globalization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = new DateTime(1999,1,1);
            Console.WriteLine(dt.ToPersianDate());
            Console.ReadKey(); ;
        }
    }

    public static class DateTimeExtension
    {

        public static DateTime ToPersianDate(this DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            int day = pc.GetDayOfMonth(dt);
            int month = pc.GetMonth(dt);
            int year = pc.GetYear(dt);
            return new DateTime(year, month, day);
        }
    }
}
