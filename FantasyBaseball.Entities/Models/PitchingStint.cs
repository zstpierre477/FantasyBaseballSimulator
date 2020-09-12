namespace FantasyBaseball.Entities.Models
{
    public partial class PitchingStint
    {
        public int PitchingStintId { get; set; }
        public int PersonId { get; set; }
        public short Year { get; set; }
        public short Stint { get; set; }
        public string TeamAbbreviation { get; set; }
        public int? TeamId { get; set; }
        public int? LeagueId { get; set; }
        public short Wins { get; set; }
        public short Losses { get; set; }
        public short Games { get; set; }
        public short GamesStarted { get; set; }
        public short CompleteGames { get; set; }
        public short Shutouts { get; set; }
        public short Saves { get; set; }
        public int InningsPitchedOuts { get; set; }
        public short Hits { get; set; }
        public short EarnedRuns { get; set; }
        public short HomeRuns { get; set; }
        public short Walks { get; set; }
        public short Strikeouts { get; set; }
        public double OpponentBattingAverage { get; set; }
        public double EarnedRunAverage { get; set; }
        public short IntentionalWalks { get; set; }
        public short WildPitches { get; set; }
        public short HitBatters { get; set; }
        public short Balks { get; set; }
        public short BattersFaced { get; set; }
        public short GamesFinished { get; set; }
        public short Runs { get; set; }
        public short SacrificeHits { get; set; }
        public short SacrificeFlies { get; set; }
        public short InducedDoublePlays { get; set; }
        public int? WalksAndHitsPerInningsPitched { get; set; }
        public double? WalksAndHitsPerInningsPitchedPlusEarnedRunAverage { get; set; }

        public virtual League League { get; set; }
        public virtual Person Person { get; set; }
        public virtual Team Team { get; set; }
    }
}
