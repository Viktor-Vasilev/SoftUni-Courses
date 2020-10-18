using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Count
        {
            get
            {
                return this.roster.Count;
            }
        }

        public void AddPlayer(Player player)
        {
            if (roster.Count < this.Capacity && !roster.Any(x => x.Name == player.Name))
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string namey)
        {
            if (roster.Any(x => x.Name == namey))
            {
                Player myTempPlayer = roster.Where(x => x.Name == namey).FirstOrDefault();
                roster.Remove(myTempPlayer);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string namePromotedPlayer)
        {
            if (roster.Any(x => x.Name == namePromotedPlayer))
            {
                Player myPromotedPlayer = roster.Where(x => x.Name == namePromotedPlayer).FirstOrDefault();
                myPromotedPlayer.Rank = "Member";
            }
        }

        public void DemotePlayer(string nameDemotedPlayer)
        {
            if (roster.Any(x => x.Name == nameDemotedPlayer))
            {
                Player myDemotedPlayer = roster.Where(x => x.Name == nameDemotedPlayer).FirstOrDefault();
                myDemotedPlayer.Rank = "Trial";
            }
        }

        public string Report()
        {
            StringBuilder myString = new StringBuilder();
            myString.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.roster)
            {
                myString.AppendLine($"Player {player.Name}: {player.Classs}");
                myString.AppendLine($"Rank: {player.Rank}");
                myString.AppendLine($"Description: {player.Description}");
            }
            return myString.ToString().TrimEnd();
        }

        public Player[] KickPlayersByClass(string classy)
        {

            List<Player> myListTemp = new List<Player>();
            foreach (var player in this.roster)
            {
                if (player.Classs == classy)
                {
                    myListTemp.Add(player);
                }
            }
            Player[] myArrayToReturn = myListTemp.ToArray();

            this.roster = this.roster.Where(x => x.Classs != classy).ToList();

            return myArrayToReturn;
        }
    }
}
