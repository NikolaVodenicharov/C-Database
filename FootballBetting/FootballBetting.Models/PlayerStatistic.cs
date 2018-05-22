using System;
using System.Collections.Generic;
using System.Text;

namespace FootballBetting.Models
{
    public class PlayerStatistic
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int ScoredGoals { get; set; }
        public int Assists { get; set; }
        public int MinutesPlayed { get; set; }
    }
}
