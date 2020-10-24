using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        List<Pet> data;
        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }
        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Pet pet)
        {
            if (Capacity > Count)
                data.Add(pet);
        }

        public bool Remove(string name) => data.Remove(data.FirstOrDefault(x => x.Name == name));

        public Pet GetPet(string name, string owner) => data.FirstOrDefault(x => x.Name == name && x.Owner == owner);

        public Pet GetOldestPet() => data.OrderByDescending(x => x.Age).FirstOrDefault();


        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The clinic has the following patients:");
            sb.AppendLine($"{string.Join(Environment.NewLine, data)}");

            return sb.ToString().TrimEnd();
        }

    }
}
