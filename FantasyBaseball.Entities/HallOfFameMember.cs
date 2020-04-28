using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyBaseball.Entities
{
    public class HallOfFameMember
    {
        public int HallOfFameMemberId { get; set; }
       
        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public Person Person { get; set; }

        public int Year { get; set; }
        
        public string VotedBy { get; set; }
        
        public int Ballots { get; set; }
        
        public int Needed { get; set; }
        
        public int Votes { get; set; }
        
        public bool Inducted { get; set; }
        
        public string Category { get; set; }
        
        public string NeededNote { get; set; }
    }
}
