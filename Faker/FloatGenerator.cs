using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class FloatGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            double range = (double)float.MaxValue - (double)float.MinValue;
            double sample = context.Random.NextDouble();
            double scaled = (sample * range) + float.MinValue;
            return (float)scaled;
        }
        public bool CanGenerate(Type type)
        {
            return type == typeof(float);
        }
    }
}
