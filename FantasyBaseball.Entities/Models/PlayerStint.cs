using System.Collections.Generic;

namespace FantasyBaseball.Entities.Models
{
    public class PlayerStint
    {
        public Person Person { get; set; }

        public Team Team { get; set; }
        
        public BattingStint BattingStint { get; set; }

        public PitchingStint PitchingStint { get; set; }

        public IEnumerable<FieldingStint> FieldingStints { get; set; }
    }
}
