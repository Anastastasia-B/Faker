using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class CharGenerator : IGenerator
    {
        private readonly Random random;

        public CharGenerator(Random random)
        {
            this.random = random;
        }

        public object Generate()
        {
            return (char)random.Next('A', 'z');
        }
    }
}
