using System;
using System.Collections.Generic;

namespace FantasyBaseball.Entities.Models
{
    public partial class Person
    {
        public Person()
        {
            AllStar = new HashSet<AllStar>();
            Appearances = new HashSet<Appearances>();
            Award = new HashSet<Award>();
            AwardVoting = new HashSet<AwardVoting>();
            BattingPostseasonRound = new HashSet<BattingPostseasonRound>();
            BattingStint = new HashSet<BattingStint>();
            CollegeStint = new HashSet<CollegeStint>();
            FieldingOutfieldStint = new HashSet<FieldingOutfieldStint>();
            FieldingPostseasonRound = new HashSet<FieldingPostseasonRound>();
            FieldingStint = new HashSet<FieldingStint>();
            HallOfFameMember = new HashSet<HallOfFameMember>();
            ManagerStint = new HashSet<ManagerStint>();
            PitchingPostseasonRound = new HashSet<PitchingPostseasonRound>();
            PitchingStint = new HashSet<PitchingStint>();
            Salary = new HashSet<Salary>();
        }

        public int PersonId { get; set; }
        public string PersonIdentifier { get; set; }
        public int? BirthYear { get; set; }
        public int? BirthMonth { get; set; }
        public int? BirthDay { get; set; }
        public string BirthCountry { get; set; }
        public string BirthState { get; set; }
        public string BirthCity { get; set; }
        public int? DeathYear { get; set; }
        public int? DeathMonth { get; set; }
        public int? DeathDay { get; set; }
        public string DeathCountry { get; set; }
        public string DeathState { get; set; }
        public string DeathCity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GivenName { get; set; }
        public int? Weight { get; set; }
        public int? Height { get; set; }
        public string Bats { get; set; }
        public string Throws { get; set; }
        public string Debut { get; set; }
        public string FinalGame { get; set; }
        public string RetroId { get; set; }
        public string BbrefId { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DebutDate { get; set; }
        public DateTime? FinalGameDate { get; set; }
        public DateTime? DeathDate { get; set; }

        public virtual ICollection<AllStar> AllStar { get; set; }
        public virtual ICollection<Appearances> Appearances { get; set; }
        public virtual ICollection<Award> Award { get; set; }
        public virtual ICollection<AwardVoting> AwardVoting { get; set; }
        public virtual ICollection<BattingPostseasonRound> BattingPostseasonRound { get; set; }
        public virtual ICollection<BattingStint> BattingStint { get; set; }
        public virtual ICollection<CollegeStint> CollegeStint { get; set; }
        public virtual ICollection<FieldingOutfieldStint> FieldingOutfieldStint { get; set; }
        public virtual ICollection<FieldingPostseasonRound> FieldingPostseasonRound { get; set; }
        public virtual ICollection<FieldingStint> FieldingStint { get; set; }
        public virtual ICollection<HallOfFameMember> HallOfFameMember { get; set; }
        public virtual ICollection<ManagerStint> ManagerStint { get; set; }
        public virtual ICollection<PitchingPostseasonRound> PitchingPostseasonRound { get; set; }
        public virtual ICollection<PitchingStint> PitchingStint { get; set; }
        public virtual ICollection<Salary> Salary { get; set; }
    }
}
