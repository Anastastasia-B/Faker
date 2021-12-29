using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class IntGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            return context.Random.Next(int.MinValue, int.MaxValue);
        }
        public bool CanGenerate(Type type)
        {
            return type == typeof(int);
        }
    }
}
