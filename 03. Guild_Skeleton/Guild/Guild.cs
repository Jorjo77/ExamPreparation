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
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return roster.Count;
            }
        }

        public void AddPlayer(Player player)
        {
            if (Capacity>roster.Count)
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            var playerForRemovement = roster.FirstOrDefault(p => p.Name == name);
            if (playerForRemovement!= null)
            {
                roster.Remove(playerForRemovement);
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            var playerForPromotion = roster.FirstOrDefault(p => p.Name == name && p.Rank != "Member");
            if (playerForPromotion!=null)
            {
                playerForPromotion.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            var playerForPromotion = roster.FirstOrDefault(p => p.Name == name && p.Rank != "Trial");
            if (playerForPromotion != null)
            {
                playerForPromotion.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string @class) 
        {
            List<Player> classPlayers = new List<Player>();
            foreach (var item in roster)
            {
                if (item.Class==@class)
                {
                    classPlayers.Add(item);
                }
            }
            roster.RemoveAll(p => p.Class == @class);
            return classPlayers.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in roster)
            {
                sb.AppendLine(player.Name);
            }
            return sb.ToString();
        }
    }
}
