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
            Console.WriteLine(variable);
        }
    }
}
