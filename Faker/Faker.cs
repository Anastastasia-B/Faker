using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class Faker
    {
        private readonly Dictionary<Type, IGenerator> generators = new Dictionary<Type, IGenerator>();
        private readonly Random Random = new Random();

        public Faker()
        {
            BuildGeneratorsCollection();
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        private object Create(Type type)
        {
            var generator = GetGenerator(type);
            if (generator != null)
            {
                return generator.Generate();
            }

            if (type.IsClass)
            {
                return default;
            }

            return default;
        }

        private void BuildGeneratorsCollection()
        {
            generators.Add(typeof(bool), new BoolGenerator(Random));
            // generators.Add(typeof(int), new IntGenerator(Random));
        }

        public IGenerator GetGenerator(Type type)
        {
            generators.TryGetValue(type, out var result);
            return result;
        }
    }
}
