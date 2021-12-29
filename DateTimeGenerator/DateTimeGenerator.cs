using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class DateTimeGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            int year = context.Random.Next(1, DateTime.Now.Year);
            int month = context.Random.Next(1, 12);
            int day = context.Random.Next(1, DateTime.DaysInMonth(year, month));
            int hours = context.Random.Next(24);
            int minutes = context.Random.Next(60);
            int seconds = context.Random.Next(60);

            return new DateTime(year, month, day, hours, minutes, seconds);
        }
        public bool CanGenerate(Type type)
        {
            return type == typeof(DateTime);
        }
    }
}
