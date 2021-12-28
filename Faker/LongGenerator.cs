using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class LongGenerator : IGenerator
    {
        private readonly Random random;

        public LongGenerator(Random random)
        {
            this.random = random;
        }

        public object Generate()
        {
            byte[] buffer = new byte[8];
            random.NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }
    }
}
