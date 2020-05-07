using System.Collections.Generic;

namespace FantasyBaseball.Entities.Models
{
    public partial class Park
    {
        public Park()
        {
            ParkStint = new HashSet<ParkStint>();
        }

        public int ParkId { get; set; }
        public string ParkAlias { get; set; }
        public string ParkKey { get; set; }
        public string ParkName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual ICollection<ParkStint> ParkStint { get; set; }
    }
}
