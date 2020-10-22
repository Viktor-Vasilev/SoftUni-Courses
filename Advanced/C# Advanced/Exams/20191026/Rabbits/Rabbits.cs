
namespace Rabbits
{
    public class Rabbit
    {

        private Rabbit()
        {
            this.Available = true;
        }
        public Rabbit(string name, string species)
            : this()
        {
            Name = name;
            Species = species;
            
        }
        
        public string Name { get; set; }

        public string Species { get; set; }

        public bool Available { get; set; }


        public override string ToString()
        {
            return $"Rabbit ({Species}): {Name}";
        }

    }
}
