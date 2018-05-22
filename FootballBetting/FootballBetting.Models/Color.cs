using System;
using System.Collections.Generic;
using System.Text;

namespace FootballBetting.Models
{
    public class Color
    {
        public int ColorId { get; set; }
        public string Name { get; set; }

        public ICollection<Team> TeamsPrimaryKitColor { get; set; } = new HashSet<Team>();
        public ICollection<Team> TeamsSecondaryKitColor { get; set; } = new HashSet<Team>();
    }
}
