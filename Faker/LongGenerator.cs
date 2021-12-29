using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class LongGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            byte[] buffer = new byte[8];
            context.Random.NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }

        public bool CanGenerate(Type type)
        {
            return type == typeof(long);
        }
    }
}
