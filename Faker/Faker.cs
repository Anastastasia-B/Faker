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
        private readonly CicleDependenciesDetector cicleDetector = new CicleDependenciesDetector();
        private List<IGenerator> generators = new List<IGenerator>();
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

            if (cicleDetector.IsCycleDependencyDetected(type))
            {
                return null;
            }

            cicleDetector.PushType(type);

            object result = null;
            var constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public).ToList();
            if (constructors.Count == 0)
            {
                result = Activator.CreateInstance(type);
            }

            constructors.Sort((x, y) =>
            {
                var xx = x.GetParameters().Length;
                var yy = y.GetParameters().Length;
                return yy.CompareTo(xx);
            });

            foreach (var constructor in constructors)
            {
                try
                {
                    result = CreateUsingConstructor(type, constructor);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }

            FillPublicFields(result);
            FillPublicProperties(result);

            cicleDetector.PopType();

            return result;
        }

        private void BuildGeneratorsCollection()
        {
            PluginLoader.LoadPlugins(generators);
            generators.Add(new BoolGenerator());
            generators.Add(new IntGenerator());
            generators.Add(new ShortGenerator());
            generators.Add(new LongGenerator());
            // generators.Add(new ByteGenerator());
            generators.Add(new DoubleGenerator());
            generators.Add(new FloatGenerator());
            generators.Add(new DecimalGenerator());
            generators.Add(new CharGenerator());
            generators.Add(new StringGenerator());
            // generators.Add(new DateTimeGenerator());
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

        private void FillPublicFields(object instance)
        {
            FieldInfo[] fields = instance.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo field in fields)
            {
                if ((field.FieldType.IsValueType && field.GetValue(instance).Equals(Activator.CreateInstance(field.FieldType))) ||
                        (!field.FieldType.IsValueType && field.GetValue(instance) == null))
                {
                    field.SetValue(instance, Create(field.FieldType));
                }
            }
        }

        private void FillPublicProperties(object instance)
        {
            PropertyInfo[] properties = instance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                if (property.CanWrite)
                {
                    if ((property.PropertyType.IsValueType && property.GetValue(instance).Equals(Activator.CreateInstance(property.PropertyType))) ||
                        (!property.PropertyType.IsValueType && property.GetValue(instance) == null))
                    {
                        property.SetValue(instance, Create(property.PropertyType));
                    }
                }
            }
        }
    }
}
