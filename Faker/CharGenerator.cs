using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class CharGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            return (char)context.Random.Next('A', 'z');
        }
        public bool CanGenerate(Type type)
        {
            return type == typeof(char);
        }
    }
}
