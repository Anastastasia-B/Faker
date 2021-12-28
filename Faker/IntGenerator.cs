using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class IntGenerator : IGenerator
    {
        private readonly Random random;

        public IntGenerator(Random random)
        {
            this.random = random;
        }

        public object Generate()
        {
            return random.Next(int.MinValue, int.MaxValue);
        }
    }
}
