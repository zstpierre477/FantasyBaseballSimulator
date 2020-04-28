using System;

namespace FantasyBaseball.Entities
{
    public class Person
    {
        public int PersonId { get; set; }
        
        public string PersonStringIdentifier { get; set; }
        
        public int BirthYear { get; set; }
        
        public int BirthMonth { get; set; }
        
        public int BirthDay { get; set; }
        
        public string BirthCountry { get; set; }
        
        public string BirthState { get; set; }
        
        public string BirthCity { get; set; }
        
        public int DeathYear { get; set; }
        
        public int DeathMonth { get; set; }
        
        public int DeathDay { get; set; }
        
        public string DeathCountry { get; set; }
        
        public string DeathState { get; set; }
        
        public string DeathCity { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string GivenName { get; set; }
        
        public int Weight { get; set; }
        
        public int Height { get; set; }
        
        public string Bats { get; set; }
        
        public string Throws { get; set; }
        
        public string Debut { get; set; }
        
        public string FinalGame { get; set; }
        
        public string RetroId { get; set; }
        
        public string BBRefId { get; set; }
        
        public DateTime BirthDate { get; set; }
        
        public DateTime DebutDate { get; set; }
        
        public DateTime FinalGameDate { get; set; }
        
        public DateTime DeathDate { get; set; }
    }
}
