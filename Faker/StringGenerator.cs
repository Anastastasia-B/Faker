using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class StringGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            var bytes = new byte[context.Random.Next(8, 16)];
            context.Random.NextBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
        public bool CanGenerate(Type type)
        {
            return type == typeof(string);
        }
    }
}
