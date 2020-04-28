using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyBaseball.Entities
{
    public class FieldingOutfieldStint
    {
        public int FieldingOutfieldStintId { get; set; }

        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int Year { get; set; }
        
        public int Stint { get; set; }
        
        public int GamesLeftfield { get; set; }
        
        public int GamesCenterfield { get; set; }
        
        public int GamesRightField { get; set; }
    }
}
