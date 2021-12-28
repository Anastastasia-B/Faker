using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;

namespace BoolGenerator
{
    public class BoolGenerator : IGenerator
    {
        public Type Type => typeof(bool);

        private readonly Random _random;

        public BoolGenerator(Random random)
        {
            _random = random;
        }

        public object Generate()
        {
            return Convert.ToBoolean(_random.Next(2));
        }
    }
}
