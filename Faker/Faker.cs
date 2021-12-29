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
            generators.Add(typeof(int), new IntGenerator(Random));
            generators.Add(typeof(short), new ShortGenerator(Random));
            generators.Add(typeof(long), new LongGenerator(Random));
            generators.Add(typeof(byte), new ByteGenerator(Random));
            generators.Add(typeof(double), new DoubleGenerator(Random));
            generators.Add(typeof(float), new FloatGenerator(Random));
            generators.Add(typeof(decimal), new DecimalGenerator(Random));
            generators.Add(typeof(char), new CharGenerator(Random));
            generators.Add(typeof(string), new StringGenerator(Random));
            generators.Add(typeof(DateTime), new DateTimeGenerator(Random));
        }

        public IGenerator GetGenerator(Type type)
        {
            generators.TryGetValue(type, out var result);
            return result;
        }
    }
}
