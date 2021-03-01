using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public Team()
        {
            this.Players = new HashSet<Player>();
            this.HomeGames = new HashSet<Game>();
            this.AwayGames = new HashSet<Game>();
        }

        public int TeamId { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string Initials { get; set; }

        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; } // Foreign Key
        public Color PrimaryKitColor { get; set; } // Navigational property

        public int SecondaryKitColorId { get; set; } // Foreign Key
        public Color SecondaryKitColor { get; set; } // Navigational property

        public int TownId { get; set; } // Foreign Key
        public Town Town { get; set; } // Navigational property

        public ICollection<Player> Players { get; set; }

        public int MyProperty { get; set; }

        public ICollection<Game> HomeGames { get; set; }

        public ICollection<Game> AwayGames { get; set; }

        //collection of players
        //collection of games

    }
}
