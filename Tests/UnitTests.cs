using FakerLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        private readonly Faker faker = new Faker();

        [TestMethod]
        public void TestGeneratePrimitive()
        {
            var primitive = faker.Create<int>();
            Assert.AreEqual(typeof(int), primitive.GetType());
            Assert.AreNotEqual(default, primitive);
        }

        [TestMethod]
        public void TestGenerateListWithPrimitive()
        {
            var list = faker.Create<List<long>>();
            Assert.AreEqual(typeof(List<long>), list.GetType());
            Assert.AreEqual(typeof(long), list.GetType().GetGenericArguments().Single());
            Assert.IsTrue(list.Count > 0);
        }

        [TestMethod]
        public void TestGenerateClass()
        {
            var generatedClass = faker.Create<ExampleClass>();
            Assert.AreNotEqual(default(char), generatedClass.CharProp);
            Assert.AreNotEqual(default(string), generatedClass.StringProp);
            Assert.AreNotEqual(default(decimal), generatedClass.DecimalProp);
            Assert.AreNotEqual(default(int), generatedClass.IntProp);
            Assert.AreNotEqual(default(long), generatedClass.LongProp);
        }

        [TestMethod]
        public void TestCycleDependenciesDetection()
        {
            C c = faker.Create<C>();
            Assert.IsNull(c.a.b.c);
        }

        [TestMethod]
        public void TestGenerateStruct()
        {
            ExampleStruct generatedStruct = faker.Create<ExampleStruct>();
            Assert.AreNotEqual(default(char), generatedStruct.CharField);
            Assert.AreNotEqual(default(string), generatedStruct.StringField);
        }
    }
}
