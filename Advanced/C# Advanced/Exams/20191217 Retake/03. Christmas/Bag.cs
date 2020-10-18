using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        private List<Present> presents;

        public Bag(string color, int capacity)
        {
            Color = color;
            Capacity = capacity;
            presents = new List<Present>();
        }

        public string Color { get; set; }
        public int Capacity { get; set; }
        public void Add(Present present)
        {
            if (presents.Count < Capacity)
            {
                presents.Add(present);
            }
        }

        public bool Remove(string name)
        {
            if (presents.Any(x => x.Name == name))
            {
                Present currentPresent = presents.FirstOrDefault(x => x.Name == name);
                presents.Remove(currentPresent);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Present GetHeaviestPresent()
        {
            Present currentPresent = presents.OrderByDescending(x => x.Weight).FirstOrDefault();
            return currentPresent;
        }

        public Present GetPresent(string name)
        {
            Present currentPresent = presents.FirstOrDefault(x => x.Name == name);
            return currentPresent;
        }
        public int Count
        {
            get
            {
                return this.presents.Count;
            }
        }

        public string Report()
        {
           StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Color} bag contains:");
            foreach (var item in presents)
            {
                sb.AppendLine($"{item.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}