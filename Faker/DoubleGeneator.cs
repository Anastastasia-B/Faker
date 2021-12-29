using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class DoubleGenerator : IGenerator
    {
        private readonly Random random;

        public DoubleGenerator(Random random)
        {
            this.random = random;
        }

        public object Generate()
        {
            double range = double.MaxValue;
            double sample = random.NextDouble();
            return (sample * range) + double.MinValue / 2;
        }
    }
}
