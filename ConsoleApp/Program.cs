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

            C c = faker.Create<C>();
            result = JsonConvert.SerializeObject(c);
            Console.WriteLine(result);

            Dog dog = faker.Create<Dog>();
            result = JsonConvert.SerializeObject(dog);
            Console.WriteLine(result);
        }

        class Person
        {
            public DateTime dateOfBirth;
            public bool alive;
            public string password;
            public byte friendsNumber { get; set; }
            public byte catsNumber;
            public byte dogsNumber;

            public Person(DateTime dateOfBirth)
            {
                this.dateOfBirth = dateOfBirth;
            }
            public Person(DateTime dateOfBirth, string password)
            {
                this.dateOfBirth = dateOfBirth;
                this.password = password;
                friendsNumber = 44;
                dogsNumber = 3;
            }
        }

        class A
        {
            public B b { get; set; }
        }

        class B
        {
            public C c { get; set; }
        }

        class C
        {
            public A a { get; set; }
        }

        struct Dog
        {
            public string name;
            public byte age;
        }
    }
}
