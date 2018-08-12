using System;

namespace CorujasDev.TodoList.Util.Helper
{
    public static class DateTimeHelper
    {
        public static int GetDiffDays(DateTime initialDate, DateTime finalDate)
        {
            int days = 0;
            int daysCount = 0;
            days = initialDate.Subtract(finalDate).Days;

            //Módulo
            if (days < 0)
                days = days * -1;

            for (int i = 1; i <= days; i++)
            {
                initialDate = initialDate.AddDays(1);
                //Conta apenas dias da semana.
                if (initialDate.DayOfWeek != DayOfWeek.Sunday &&
                    initialDate.DayOfWeek != DayOfWeek.Saturday)
                    daysCount++;
            }
            return daysCount;
        }

        public static DateTime GetCurrentTimeZone(this DateTime dt)
        {
            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            DateTime localDatetime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);

            return localDatetime;
        }
    }
}
