namespace Rabbits
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;

    public class Cage
    {

        private List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Rabbit>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => data.Count;

        public void Add(Rabbit rabbit)
        {
            if (Capacity > Count)
            {
                data.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            Rabbit rabbitToRemove = data.FirstOrDefault(x => x.Name == name);
            return data.Remove(rabbitToRemove);
        
        }

        public void RemoveSpecies(string species)
        {
            data.RemoveAll(r => r.Species == species);
             
        }

        public Rabbit SellRabbit(string name)
        {
            Rabbit rabbit = data.FirstOrDefault(r => r.Name == name);

            if (rabbit != null)
            {
                rabbit.Available = false;
            }

            return rabbit;
        
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            Rabbit[] rabbits = data.Where(r => r.Species == species).ToArray();

            foreach (var rabbit in rabbits)
            {
                rabbit.Available = false;
            }
            return rabbits;
        }


        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {Name}:");
            foreach (var rabbit in data.Where(r => r.Available))
            {
                sb.AppendLine(rabbit.ToString());
            }
            return sb.ToString().TrimEnd();
        }

    }
}