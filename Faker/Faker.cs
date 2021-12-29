using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FakerLib
{
    public class Faker
    {
        private readonly List<IGenerator> generators = new List<IGenerator>();
        private readonly Random Random = new Random();

        public Faker()
        {
            BuildGeneratorsCollection();
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        public object Create(Type type)
        {
            foreach (IGenerator generator in generators)
            {
                if (generator.CanGenerate(type))
                {
                    return generator.Generate(new GeneratorContext(Random, type, this));
                }
            }

            if (type.IsClass)
            {
                var constructor = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public).ToList().First();
                if (constructor == null)
                {
                    throw new ArgumentException("Class: " + type + " has no public constructors");
                }

                var result = CreateUsingConstructor(type, constructor);

                return result;
            }

            return default;
        }

        private void BuildGeneratorsCollection()
        {
            generators.Add(new BoolGenerator());
            generators.Add(new IntGenerator());
            generators.Add(new ShortGenerator());
            generators.Add(new LongGenerator());
            generators.Add(new ByteGenerator());
            generators.Add(new DoubleGenerator());
            generators.Add(new FloatGenerator());
            generators.Add(new DecimalGenerator());
            generators.Add(new CharGenerator());
            generators.Add(new StringGenerator());
            generators.Add(new DateTimeGenerator());
            generators.Add(new ListGenerator());
        }

        private object CreateUsingConstructor(Type type, ConstructorInfo constructor)
        {
            try
            {
                return constructor.Invoke((from parameterInfo in constructor.GetParameters() select Create(parameterInfo.ParameterType)).ToArray());
            }
            catch (TargetInvocationException e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }
    }
}
