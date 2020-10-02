using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Lab_05._Filter_By_Age
{
    class Program
    {
        public class Person
        {
            public string Name { get; set; }

            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string name = data[0];
                int age = int.Parse(data[1]);

                Person newPerson = new Person()
                {
                    Name = name,
                    Age = age
                };

                people.Add(newPerson);
            }

            string condition = Console.ReadLine();

            int ageLine = int.Parse(Console.ReadLine());

            Func<Person, bool> tester = CreateTester(condition, ageLine);

            string format = Console.ReadLine();

            Action<Person> printer = CreatePrinter(format);

            Print(people, tester, printer);





        }
        private static void Print(List<Person> people, Func<Person, bool> tester, Action<Person> printer)
        {
            people.Where(tester).ToList().ForEach(printer);
        }

        private static Action<Person> CreatePrinter(string format)
        {
            if (format == "name")
            {
                return x => Console.WriteLine($"{x.Name}");
            }
            else if (format == "name age")
            {
                return x => Console.WriteLine($"{x.Name} - {x.Age}");
            }
            else if (format == "age name")
            {
                return x => Console.WriteLine($"{x.Age} - {x.Name}");
            }
            else if (format == "age")
            {
                return x => Console.WriteLine($"{x.Age}");
            }
            else
            {
                return null;
            }
        }

        private static Func<Person, bool> CreateTester(string condition, int ageLine)
        {
            if (condition == "older")
            {
                return x => x.Age >= ageLine;
            }
            else
            {
                return x => x.Age < ageLine;
            }
        }

    }
}
