﻿using System;
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

            if (cicleDetector.IsCycleDependencyDetected(type))
            {
                return null;
            }

            cicleDetector.PushType(type);

            var constructor = GetConstructorWithMaxParametersCount(type);
            if (constructor == null)
            {
                throw new ArgumentException("Class: " + type + " has no public constructors");
            }

            var result = CreateUsingConstructor(type, constructor);
            FillPublicFields(result);
            FillPublicProperties(result);

            cicleDetector.PopType();

            return result;
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

        private void FillPublicFields(object instance)
        {
            FieldInfo[] fields = instance.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo field in fields)
            {
                field.SetValue(instance, Create(field.FieldType));
            }
        }

        private void FillPublicProperties(object instance)
        {
            PropertyInfo[] properties = instance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                if (property.CanWrite)
                {
                    property.SetValue(instance, Create(property.PropertyType));
                }
            }
        }

        private ConstructorInfo GetConstructorWithMaxParametersCount(Type type)
        {
            var constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public).ToList();

            constructors.Sort((x, y) =>
            {
                var xx = x.GetParameters().Length;
                var yy = y.GetParameters().Length;
                return yy.CompareTo(xx);
            });
            return constructors.FirstOrDefault();
        }
    }
}
