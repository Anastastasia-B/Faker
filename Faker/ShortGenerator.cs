using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class ShortGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            return (short)context.Random.Next(short.MinValue, short.MaxValue);
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(short);
        }
    }
}
