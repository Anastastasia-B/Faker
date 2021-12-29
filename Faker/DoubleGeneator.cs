using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class DoubleGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            double range = double.MaxValue;
            double sample = context.Random.NextDouble();
            return (sample * range) + double.MinValue / 2;
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(double);
        }
    }
}
