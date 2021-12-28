using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class ByteGenerator : IGenerator
    {
        private readonly Random random;

        public ByteGenerator(Random random)
        {
            this.random = random;
        }

        public object Generate()
        {
            return (byte)random.Next(byte.MinValue, byte.MaxValue);
        }
    }
}
