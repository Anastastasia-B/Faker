using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class StringGenerator : IGenerator
    {
        private readonly Random random;

        public StringGenerator(Random random)
        {
            this.random = random;
        }

        public object Generate()
        {
            var bytes = new byte[random.Next(8, 16)];
            random.NextBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
