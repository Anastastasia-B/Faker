using System;
using System.Collections.Generic;
using System.Text.Json;
using FakerLib;
using Newtonsoft.Json;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Faker faker = new Faker();
            Person person = faker.Create<Person>();
            var result = JsonConvert.SerializeObject(person);
            Console.WriteLine(result);
        }

        class Person
        {
            public DateTime dateOfBirth;
            public bool alive;
            public string password;

            public Person()
            {
                dateOfBirth = DateTime.Now;
                alive = true;
                password = "heh";
            }
        }
    }
}
