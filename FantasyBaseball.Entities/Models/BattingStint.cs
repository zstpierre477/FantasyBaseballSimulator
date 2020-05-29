using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.ComponentModel.DataAnnotations.Schema;

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

        public virtual League League { get; set; }
        public virtual Person Person { get; set; }
        public virtual Team Team { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double OnBasePercentage { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double SluggingPercentage { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double OnBasePlusSlugging { get; set; }
    }
}
