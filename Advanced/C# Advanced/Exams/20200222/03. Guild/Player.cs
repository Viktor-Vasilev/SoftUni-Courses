using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public Player(string name, string classs)
        {
            this.Name = name;
            this.Classs = classs;
            this.Rank = "Trial";
            this.Description = "n/a";
        }

        public string Name { get; private set; }

        public string Classs { get; private set; }

        public string Rank { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            StringBuilder myStringToReturn = new StringBuilder();
            myStringToReturn.AppendLine($"Player {this.Name}: {this.Classs}");
            myStringToReturn.AppendLine($"Rank: {this.Rank}");
            myStringToReturn.AppendLine($"Description: {this.Description}");
            return myStringToReturn.ToString().TrimEnd();
        }
    }
}