using System;
using System.Collections.Generic;

namespace FantasyBaseball.Entities.Models
{
    public partial class AwardVoting
    {
        public int AwardVotingId { get; set; }
        public string AwardName { get; set; }
        public short Year { get; set; }
        public int LeagueId { get; set; }
        public int PersonId { get; set; }
        public double? PointsWon { get; set; }
        public double? PointsMax { get; set; }
        public double? VotesFirst { get; set; }

        public virtual League League { get; set; }
        public virtual Person Person { get; set; }
    }
}
