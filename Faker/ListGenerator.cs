using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace FakerLib
{
    public class ListGenerator : IGenerator
    {
        public object Generate(GeneratorContext context)
        {
            // var argumentType = context.TargetType.GetGenericArguments().Single();
            IList list = (IList)Activator.CreateInstance(context.TargetType);

            return list;
        }
        public bool CanGenerate(Type type)
        {
            if (!type.IsGenericType)
                return false;

            return type.GetGenericTypeDefinition() == typeof(List<Type>) && type.GetGenericArguments().Count() == 1;
        }
    }
}
