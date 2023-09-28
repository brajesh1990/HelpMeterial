using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeligateExamp
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        //Our delegate
        public delegate bool FilterDelegate(Person p);

        static void Main(string[] args)
        {

            //Create 4 Person objects
            Person p1 = new Person() { Name = "John", Age = 41 };
            Person p2 = new Person() { Name = "Jane", Age = 69 };
            Person p3 = new Person() { Name = "Jake", Age = 12 };
            Person p4 = new Person() { Name = "Jessie", Age = 25 };

            //Create a list of Person objects and fill it
            List<Person> people = new List<Person>() { p1, p2, p3, p4 };

            //Invoke DisplayPeople using appropriate delegate
            DisplayPeople(people, IsChild);
            DisplayPeople(people, IsAdult);
            DisplayPeople(people, IsSenior);

            Console.Read();
        }

     
        static void DisplayPeople(List<Person> people, FilterDelegate filter)
        {

            foreach (Person p in people)
            {
                if (filter(p))
                {
                    Console.WriteLine("{0}, {1} years old", p.Name, p.Age);
                }
            }

            Console.Write("\n\n");
        }

        //==========FILTERS===================
        static bool IsChild(Person p)
        {
            return p.Age < 18;
        }

        static bool IsAdult(Person p)
        {
            return p.Age >= 18;
        }

        static bool IsSenior(Person p)
        {
            return p.Age >= 65;
        }
    }
}