using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class BoolGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            return Convert.ToBoolean(context.Random.Next(2));
        }
        public bool CanGenerate(Type type)
        {
            return type == typeof(bool);
        }
    }
}
