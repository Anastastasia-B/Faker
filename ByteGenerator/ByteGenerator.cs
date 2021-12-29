using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class ByteGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            return (byte)context.Random.Next(byte.MinValue, byte.MaxValue);
        }
        public bool CanGenerate(Type type)
        {
            return type == typeof(byte);
        }
    }
}
