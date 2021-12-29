using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class DateTimeGenerator : IGenerator
    {
        private readonly Random random;

        public DateTimeGenerator(Random random)
        {
            this.random = random;
        }

        public object Generate()
        {
            int year = random.Next(1, DateTime.Now.Year);
            int month = random.Next(1, 12);
            int day = random.Next(1, DateTime.DaysInMonth(year, month));
            int hours = random.Next(24);
            int minutes = random.Next(60);
            int seconds = random.Next(60);

            return new DateTime(year, month, day, hours, minutes, seconds);
        }
    }
}
