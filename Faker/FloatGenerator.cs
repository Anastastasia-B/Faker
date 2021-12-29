using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class FloatGenerator : IGenerator
    {
        private readonly Random random;

        public FloatGenerator(Random random)
        {
            this.random = random;
        }

        public object Generate()
        {
            double range = (double)float.MaxValue - (double)float.MinValue;
            double sample = random.NextDouble();
            double scaled = (sample * range) + float.MinValue;
            return (float)scaled;
        }
    }
}
