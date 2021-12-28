using System;
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
            Console.WriteLine($"bool: {variable}\nint: {v1}\nbyte: {v2}\nshort: {v3}\nlong: {v4}");
        }
    }
}
