using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class DecimalGenerator : IGenerator
    {
        private readonly Random random;

        public DecimalGenerator(Random random)
        {
            this.random = random;
        }

        public object Generate()
        {
            return new decimal(random.Next(int.MinValue, int.MaxValue) + random.NextDouble());
        }
    }
}
