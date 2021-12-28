using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class BoolGenerator : IGenerator
    {
        private readonly Random random;

        public BoolGenerator(Random random)
        {
            this.random = random;
        }

        public object Generate()
        {
            return Convert.ToBoolean(random.Next(2));
        }
    }
}
