using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FantasyBaseball.Entities.Enums;
using FantasyBaseball.Entities.Helpers;

namespace FantasyBaseball.Entities.Models
{
    public partial class FieldingStint
    {
        public int FieldingStintId { get; set; }
        public int PersonId { get; set; }
        public short Year { get; set; }
        public short Stint { get; set; }
        public string TeamAbbreviation { get; set; }
        public int? TeamId { get; set; }
        public int? LeagueId { get; set; }
        private string _position { get; set; }
        public string Position
        {
            get { return _position; }
            set
            {
                _position = value;
                PositionType = PositionTypeHelperFunctions.PositionAbbreviationStringToPositionType(_position);
            }
        }
        public short Games { get; set; }
        public short GamesStarted { get; set; }
        public short InningsPlayedOuts { get; set; }
        public short Putouts { get; set; }
        public short Assists { get; set; }
        public short Errors { get; set; }
        public short DoublePlays { get; set; }
        public short? PassedBalls { get; set; }
        public short? WildPitches { get; set; }
        public short? StolenBases { get; set; }
        public short? CaughtStealing { get; set; }
        public short? ZoneRating { get; set; }

        public virtual League League { get; set; }
        public virtual Person Person { get; set; }
        public virtual Team Team { get; set; }

        [NotMapped]
        public double FieldingPercentage => (Putouts + Assists + Errors) != 0 ? Math.Round(((double)Putouts + Assists) / (Putouts + Assists + Errors), 3) : .000;

        [NotMapped]
        public PositionType PositionType { get; set; }
    }
}
