using GalaSoft.MvvmLight;

namespace FantasyBaseball.UI.ViewModels
{
    public class SingleGameTeamSelectorViewModel : ViewModelBase
    {
        public TeamViewModel HomeTeam { get; set; }

        public TeamViewModel AwayTeam { get; set; }

        public bool CanPlaySingleGame()
        {
            return HomeTeam.Catcher != null && HomeTeam.FirstBaseman != null && HomeTeam.SecondBaseman != null && HomeTeam.ThirdBaseman != null && HomeTeam.Shortstop != null &&
                HomeTeam.LeftFielder != null && HomeTeam.CenterFielder != null && HomeTeam.RightFielder != null && HomeTeam.DesignatedHitter != null && HomeTeam.StartingPitcher1 != null &&
                AwayTeam.Catcher != null && AwayTeam.FirstBaseman != null && AwayTeam.SecondBaseman != null && AwayTeam.ThirdBaseman != null && AwayTeam.Shortstop != null &&
                AwayTeam.LeftFielder != null && AwayTeam.CenterFielder != null && AwayTeam.RightFielder != null && AwayTeam.DesignatedHitter != null && AwayTeam.StartingPitcher1 != null;
        }
    }
}
