using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class ShortGenerator : IGenerator
    {
        private readonly Random random;

        public ShortGenerator(Random random)
        {
            this.random = random;
        }

        public object Generate()
        {
            return (short)random.Next(short.MinValue, short.MaxValue);
        }
    }
}
