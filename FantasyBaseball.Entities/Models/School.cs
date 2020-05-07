using System.Collections.Generic;

namespace FantasyBaseball.Entities.Models
{
    public partial class School
    {
        public School()
        {
            CollegeStint = new HashSet<CollegeStint>();
        }

        public int SchoolId { get; set; }
        public string SchoolStringIdentifier { get; set; }
        public string SchoolName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual ICollection<CollegeStint> CollegeStint { get; set; }
    }
}
