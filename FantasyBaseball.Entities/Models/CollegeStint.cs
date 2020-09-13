using System;
using System.Collections.Generic;

namespace FantasyBaseball.Entities.Models
{
    public partial class CollegeStint
    {
        public int CollegeStintId { get; set; }
        public int PersonId { get; set; }
        public int? SchoolId { get; set; }
        public short? Year { get; set; }

        public virtual Person Person { get; set; }
        public virtual School School { get; set; }
    }
}
