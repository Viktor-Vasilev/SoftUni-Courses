using System.Text;

namespace Heroes
{
    public class Hero
    {
        private string name;
        private int level;
        private Item item;

        public string Name { get => this.name; set => this.name = value; }
        public int Level { get => this.level; set => this.level = value; }
        public Item Item { get => this.item; set => this.item = value; }

        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public override string ToString()
        {
            StringBuilder sb2 = new StringBuilder();
            sb2.AppendLine($"Hero: {Name} - {Level} lvl");
            sb2.Append($"{Item}");

            return sb2.ToString();
        }
    }
}