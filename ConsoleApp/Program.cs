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
            var result = JsonConvert.SerializeObject(person, Formatting.Indented);
            Console.WriteLine(result);
        }

        class Person
        {
            public string name;
            public DateTime dateOfBirth;
            public bool isAdmin;
            public byte rating { get; set; }
            public List<Ticket> tickets;

            public Person(DateTime dateOfBirth)
            {
                this.dateOfBirth = dateOfBirth;
            }
            public Person(DateTime dateOfBirth, string name)
            {
                this.dateOfBirth = dateOfBirth;
                this.name = name;
                rating = 55;
            }
        }
        struct Ticket
        {
            public string code;
            public DateTime expiresAt;
        }
    }
}
