using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyBaseball.UI.ViewModels
{
    public interface IPlayerViewModel : IViewModel
    {
        public int StintId { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public short Year { get; set; }
        
        public string TeamShortName { get; set; }
    }
}
