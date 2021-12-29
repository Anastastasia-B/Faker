using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class DecimalGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            return new decimal(context.Random.Next(int.MinValue, int.MaxValue) + context.Random.NextDouble());
        }
        public bool CanGenerate(Type type)
        {
            return type == typeof(decimal);
        }
    }
}
