using FantasyBaseball.Entities.Models;

namespace FantasyBaseball.UI.ViewModels
{
    public interface IPlayerViewModel
    {      
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public short Year { get; set; }
        
        public string TeamShortName { get; set; }

        public PlayerStint PlayerStint { get; set; }
    }
}
