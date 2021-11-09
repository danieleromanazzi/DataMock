using System;

namespace DataMock.Generators
{
    public static class DateTimeGenerator
    {
        private static readonly Random random = new Random();

        public static DateTime Date()
        {
            DateTime start = DateTime.Now.AddYears(-100);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }
    }
}
