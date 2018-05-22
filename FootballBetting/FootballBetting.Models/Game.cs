using System;
using System.Collections.Generic;
using System.Text;

namespace FootballBetting.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public DateTime DateTime { get; set; }
        public GameResult Result { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public int HomeTeamGoals { get; set; }
        public int AwayTeamGoals { get; set; }

        public double HomeTeamBetRate { get; set; }
        public double AwayTeamBetRate { get; set; }
        public double DrawBetRate { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new HashSet<PlayerStatistic>();
        public ICollection<Bet> Bets { get; set; } = new HashSet<Bet>();
    }
}
