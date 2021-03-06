﻿using System;
using System.Collections.Generic;

namespace FantasyBaseball.Entities.Models
{
    public partial class FieldingPostseasonRound
    {
        public int FieldingPostseasonRoundId { get; set; }
        public int PersonId { get; set; }
        public short Year { get; set; }
        public string TeamAbbreviation { get; set; }
        public int? TeamId { get; set; }
        public int? LeagueId { get; set; }
        public string Round { get; set; }
        public string Position { get; set; }
        public short? Games { get; set; }
        public short? GamesStarted { get; set; }
        public short? InningsPlayedOuts { get; set; }
        public short? Putouts { get; set; }
        public short? Assists { get; set; }
        public short? Errors { get; set; }
        public short? DoublePlays { get; set; }
        public short? PassedBalls { get; set; }
        public short? WildPitches { get; set; }
        public short? StolenBases { get; set; }
        public short? CaughtStealing { get; set; }

        public virtual League League { get; set; }
        public virtual Person Person { get; set; }
        public virtual Team Team { get; set; }
    }
}
