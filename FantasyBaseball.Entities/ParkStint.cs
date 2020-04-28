using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyBaseball.Entities
{
    public class ParkStint
    {
        public int ParkStintId { get; set; }
        
        public int Year { get; set; }
        
        [ForeignKey("League")]
        public int LeagueId { get; set; }
        
        public string TeamAbbreviation { get; set; }
        
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        
        public string ParkKey { get; set; }
        
        [ForeignKey("Park")]
        public int ParkId { get; set; }

        public League League { get; set; }
        
        public Team Team { get; set; }
        
        public Park Park { get; set; }

        public string SpanFirst { get; set; }
        
        public string SpanLast { get; set; }
        
        public int Games { get; set; }
        
        public int Openings { get; set; }
        
        public int Attendance { get; set; }
        
        public DateTime SpanFirstDate { get; set; }
        
        public DateTime SpanLastDate { get; set; }
    }
}
