using FantasyBaseball.Business.Services;
using FantasyBaseball.Entities.Enums;
using GalaSoft.MvvmLight;

namespace FantasyBaseball.UI.ViewModels
{
    public class SingleGameTeamSelectorViewModel : ViewModelBase
    {
        public TeamViewModel HomeTeam { get; set; }

        public TeamViewModel AwayTeam { get; set; }

        public IRandomPlayerSelectorService RandomPlayerSelectorService { get; set; }

        public SingleGameTeamSelectorViewModel(IRandomPlayerSelectorService randomPlayerSelectorService)
        {
            RandomPlayerSelectorService = randomPlayerSelectorService;
            HomeTeam = new TeamViewModel();
            AwayTeam = new TeamViewModel();
        }

        public void GenerateRandomTeams()
        {
            HomeTeam.Catcher = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.Catcher, true));
            AwayTeam.Catcher = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.Catcher, true));
            HomeTeam.FirstBaseman = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.FirstBaseman, true));
            AwayTeam.FirstBaseman = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.FirstBaseman, true));
            HomeTeam.SecondBaseman = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.SecondBaseman, true));
            AwayTeam.SecondBaseman = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.SecondBaseman, true));
            HomeTeam.ThirdBaseman = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.ThirdBaseman, true));
            AwayTeam.ThirdBaseman = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.ThirdBaseman, true));
            HomeTeam.Shortstop = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.Shortstop, true));
            AwayTeam.Shortstop = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.Shortstop, true));
            HomeTeam.LeftFielder = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.LeftFielder, true));
            AwayTeam.LeftFielder = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.LeftFielder, true));
            HomeTeam.CenterFielder = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.CenterFielder, true));
            AwayTeam.CenterFielder = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.CenterFielder, true));
            HomeTeam.RightFielder = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.RightFielder, true));
            AwayTeam.RightFielder = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.RightFielder, true));
            HomeTeam.DesignatedHitter = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.DesignatedHitter, true));
            AwayTeam.DesignatedHitter = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.DesignatedHitter, true));
            HomeTeam.BenchPlayer1 = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.Catcher));
            AwayTeam.BenchPlayer1 = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.Catcher));
            HomeTeam.BenchPlayer2 = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.CornerInfielder));
            AwayTeam.BenchPlayer2 = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.CornerInfielder));
            HomeTeam.BenchPlayer3 = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.MiddleInfielder));
            AwayTeam.BenchPlayer3 = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.MiddleInfielder));
            HomeTeam.BenchPlayer4 = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.OutFielder));
            AwayTeam.BenchPlayer4 = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.OutFielder));
            HomeTeam.StartingPitcher1 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true));
            AwayTeam.StartingPitcher1 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true));
            HomeTeam.StartingPitcher2 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true));
            AwayTeam.StartingPitcher2 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true));
            HomeTeam.StartingPitcher3 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true));
            AwayTeam.StartingPitcher3 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true));
            HomeTeam.StartingPitcher4 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true));
            AwayTeam.StartingPitcher4 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true));
            HomeTeam.StartingPitcher5 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true));
            AwayTeam.StartingPitcher5 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true));
            HomeTeam.ReliefPitcher1 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher());
            AwayTeam.ReliefPitcher1 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher());
            HomeTeam.ReliefPitcher2 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher());
            AwayTeam.ReliefPitcher2 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher());
            HomeTeam.ReliefPitcher3 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher());
            AwayTeam.ReliefPitcher3 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher());
            HomeTeam.ReliefPitcher4 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher());
            AwayTeam.ReliefPitcher4 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher());
            HomeTeam.ReliefPitcher5 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher());
            AwayTeam.ReliefPitcher5 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher());
            HomeTeam.ReliefPitcher6 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher());
            AwayTeam.ReliefPitcher6 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher());
            HomeTeam.ReliefPitcher7 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher());
            AwayTeam.ReliefPitcher7 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher());
        }

        public bool CanPlaySingleGame()
        {
            return HomeTeam.Catcher != null && HomeTeam.FirstBaseman != null && HomeTeam.SecondBaseman != null && HomeTeam.ThirdBaseman != null && HomeTeam.Shortstop != null &&
                HomeTeam.LeftFielder != null && HomeTeam.CenterFielder != null && HomeTeam.RightFielder != null && HomeTeam.DesignatedHitter != null && HomeTeam.StartingPitcher1 != null &&
                AwayTeam.Catcher != null && AwayTeam.FirstBaseman != null && AwayTeam.SecondBaseman != null && AwayTeam.ThirdBaseman != null && AwayTeam.Shortstop != null &&
                AwayTeam.LeftFielder != null && AwayTeam.CenterFielder != null && AwayTeam.RightFielder != null && AwayTeam.DesignatedHitter != null && AwayTeam.StartingPitcher1 != null
                && HomeTeam.TeamName != null && AwayTeam.TeamName != null;
        }
    }
}
