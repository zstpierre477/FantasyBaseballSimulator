using System;
using System.Collections.Generic;

namespace FantasyBaseball.Entities.Models
{
    public partial class BattingStint
    {
        public int BattingStintId { get; set; }
        public int PersonId { get; set; }
        public short Year { get; set; }
        public short Stint { get; set; }
        public string TeamAbbreviation { get; set; }
        public int? TeamId { get; set; }
        public int? LeagueId { get; set; }
        public short Games { get; set; }
        public short GamesBatted { get; set; }
        public short AtBats { get; set; }
        public short Runs { get; set; }
        public short Hits { get; set; }
        public short Doubles { get; set; }
        public short Triples { get; set; }
        public short HomeRuns { get; set; }
        public short RunsBattedIn { get; set; }
        public short StolenBases { get; set; }
        public short CaughtStealing { get; set; }
        public short Walks { get; set; }
        public short Strikeouts { get; set; }
        public short IntentionalWalks { get; set; }
        public short HitByPitch { get; set; }
        public short SacrificeHits { get; set; }
        public short SacrificeFlies { get; set; }
        public short GroundedIntoDoublePlay { get; set; }
        public double OnBasePercentage { get; set; }
        public double SluggingPercentage { get; set; }
        public double OnBasePlusSlugging { get; set; }

        public double? OnBasePercentageDisplay => Math.Round(OnBasePercentage, 3);
        public double? SluggingPercentageDisplay => Math.Round(SluggingPercentage, 3);
        public double? OnBasePlusSluggingDisplay => Math.Round(OnBasePlusSlugging, 3);

        public virtual League League { get; set; }
        public virtual Person Person { get; set; }
        public virtual Team Team { get; set; }
    }
}
