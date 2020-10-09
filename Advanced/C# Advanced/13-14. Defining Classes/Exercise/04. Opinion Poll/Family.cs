

using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public Family()
        {
            People = new List<Person>();
        }

        public List<Person> People { get; set; }

        public void AddMember(Person member)
        {
            People.Add(member);
        }



        public Person GetOldestMember()
        {
            int maxAge = int.MinValue;
            Person person = null;

            foreach (var currentPerson in People)
            {
                var currentAge = currentPerson.Age;

                if (currentAge > maxAge)
                {
                    maxAge = currentAge;
                    person = currentPerson;
                }
            }

            return person;

           // return People.OrderByDescending(x => x.Age).First();


        }
         
        public Person[] GetPeople()
        {
            var people = People.Where(x => x.Age > 30).OrderBy(x => x.Name).ToArray();
            return people;
        }

    }
}