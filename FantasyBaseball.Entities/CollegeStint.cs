using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace FantasyBaseball.Entities
{
    public class CollegeStint
    {
        public int CollegeStintId { get; set; }
        
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        
        [ForeignKey("School")]
        public int SchoolId { get; set; }

        public School School { get; set; }
                
        public Person Person { get; set; }

        public int Year { get; set; }
    }
}
