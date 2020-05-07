using GalaSoft.MvvmLight;

namespace FantasyBaseball.UI.ViewModels
{
    public class SingleGameTeamSelectorViewModel : ViewModelBase
    {
        public TeamViewModel HomeTeam { get; set; }

        public TeamViewModel AwayTeam { get; set; }
    }
}
