using System;
using System.Collections.Generic;
using FakerLib;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Faker faker = new Faker();
            bool variable = faker.Create<bool>();
            int v1 = faker.Create<int>();
            byte v2 = faker.Create<byte>();
            short v3 = faker.Create<short>();
            long v4 = faker.Create<long>();
            float v5 = faker.Create<float>();
            double v6 = faker.Create<double>();
            decimal v7 = faker.Create<decimal>();
            char v8 = faker.Create<char>();
            string v9 = faker.Create<string>();
            DateTime v10 = faker.Create<DateTime>();
            List<bool> list = faker.Create<List<bool>>();
            Console.WriteLine($"bool: {variable}\nint: {v1}\nbyte: {v2}\nshort: {v3}\nlong: {v4}\nfloat: {v5}\ndouble: {v6}\ndecimal: {v7}\nchar: {v8}\nstring: {v9}\nDateTime: {v10}");

            foreach(bool item in list)
            {
                Console.Write($"{item}, ");
            }
        }
    }
}
