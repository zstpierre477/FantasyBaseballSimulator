using FantasyBaseball.Business.Services;
using FantasyBaseball.Entities.Enums;
using FantasyBaseball.Entities.Models;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FantasyBaseball.UI.ViewModels
{
    public class SingleGameSetupViewModel : ViewModelBase
    {
        private string _loadingVisibility { get; set; }
        public string LoadingVisibility
        {
            get { return _loadingVisibility; }
            set { _loadingVisibility = value; RaisePropertyChanged("LoadingVisibility"); }
        }

        private string _historicalTeamSelectorVisibility { get; set; }
        public string HistoricalTeamSelectorVisibility
        {
            get { return _historicalTeamSelectorVisibility; }
            set { _historicalTeamSelectorVisibility = value; RaisePropertyChanged("HistoricalTeamSelectorVisibility"); }
        }

        private string _historicalFranchiseSelectorVisibility { get; set; }
        public string HistoricalFranchiseSelectorVisibility
        {
            get { return _historicalFranchiseSelectorVisibility; }
            set { _historicalFranchiseSelectorVisibility = value; RaisePropertyChanged("HistoricalFranchiseSelectorVisibility"); }
        }

        private ObservableCollection<string> _homeTeamHistoricalTeamNames { get; set; }
        public ObservableCollection<string> HomeTeamHistoricalTeamNames
        {
            get { return _homeTeamHistoricalTeamNames; }
            set { _homeTeamHistoricalTeamNames = value; RaisePropertyChanged("HomeTeamHistoricalTeamNames"); }
        }

        private string _selectedHomeTeamHistoricalTeamName { get; set; }
        public string SelectedHomeTeamHistoricalTeamName
        {
            get { return _selectedHomeTeamHistoricalTeamName; }
            set { _selectedHomeTeamHistoricalTeamName = value; RaisePropertyChanged("SelectedHomeTeamHistoricalTeamName"); }
        }

        private int _selectedHomeTeamYear { get; set; }
        public int SelectedHomeTeamYear
        {
            get { return _selectedHomeTeamYear; }
            set
            {
                _selectedHomeTeamYear = value; UpdateHomeTeamTeamAndYearCombinations(); RaisePropertyChanged("SelectedHomeTeamYear");
                RaisePropertyChanged("HomeTeamHistoricalTeamNames"); RaisePropertyChanged("SelectedHomeTeamHistoricalTeamName");
            }
        }

        private ObservableCollection<string> _awayTeamHistoricalTeamNames { get; set; }
        public ObservableCollection<string> AwayTeamHistoricalTeamNames
        {
            get { return _awayTeamHistoricalTeamNames; }
            set { _awayTeamHistoricalTeamNames = value; RaisePropertyChanged("AwayTeamHistoricalTeamNames"); }
        }

        private string _selectedAwayTeamHistoricalTeamName { get; set; }
        public string SelectedAwayTeamHistoricalTeamName
        {
            get { return _selectedAwayTeamHistoricalTeamName; }
            set { _selectedAwayTeamHistoricalTeamName = value; RaisePropertyChanged("SelectedAwayTeamHistoricalTeamName"); }
        }

        private int _selectedAwayTeamYear { get; set; }
        public int SelectedAwayTeamYear
        {
            get { return _selectedAwayTeamYear; }
            set
            {
                _selectedAwayTeamYear = value; UpdateAwayTeamTeamAndYearCombinations(); RaisePropertyChanged("SelectedAwayTeamYear");
                RaisePropertyChanged("AwayTeamHistoricalTeamNames"); RaisePropertyChanged("SelectedAwayTeamHistoricalTeamName");
            }
        }

        private ObservableCollection<int> _years { get; set; }
        public ObservableCollection<int> Years
        {
            get { return _years; }
            set { _years = value; RaisePropertyChanged("Years"); }
        }

        private ObservableCollection<string> _homeTeamHistoricalFranchiseNames { get; set; }
        public ObservableCollection<string> HomeTeamHistoricalFranchiseNames
        {
            get { return _homeTeamHistoricalFranchiseNames; }
            set { _homeTeamHistoricalFranchiseNames = value; RaisePropertyChanged("HomeTeamHistoricalFranchiseNames"); }
        }

        private string _selectedHomeTeamHistoricalFranchiseName { get; set; }
        public string SelectedHomeTeamHistoricalFranchiseName
        {
            get { return _selectedHomeTeamHistoricalFranchiseName; }
            set { _selectedHomeTeamHistoricalFranchiseName = value; RaisePropertyChanged("SelectedHomeTeamHistoricalFranchiseName"); }
        }

        private ObservableCollection<string> _awayTeamHistoricalFranchiseNames { get; set; }
        public ObservableCollection<string> AwayTeamHistoricalFranchiseNames
        {
            get { return _awayTeamHistoricalFranchiseNames; }
            set { _awayTeamHistoricalFranchiseNames = value; RaisePropertyChanged("AwayTeamHistoricalFranchiseNames"); }
        }

        private string _selectedAwayTeamHistoricalFranchiseName { get; set; }
        public string SelectedAwayTeamHistoricalFranchiseName
        {
            get { return _selectedAwayTeamHistoricalFranchiseName; }
            set { _selectedAwayTeamHistoricalFranchiseName = value; RaisePropertyChanged("SelectedAwayTeamHistoricalFranchiseName"); }
        }

        public IEnumerable<Team> HistoricalTeams { get; set; }

        public IEnumerable<Franchise> HistoricalFranchises { get; set; }

        public IRandomPlayerSelectorService RandomPlayerSelectorService { get; set; }

        public IHistoricalTeamService HistoricalTeamService { get; set; }

        public SingleGameSetupViewModel(IRandomPlayerSelectorService randomPlayerSelectorService, IHistoricalTeamService historicalTeamService)
        {
            HistoricalTeamService = historicalTeamService;
            RandomPlayerSelectorService = randomPlayerSelectorService;
            LoadingVisibility = "Hidden";
            HistoricalTeamSelectorVisibility = "Hidden";
            HistoricalFranchiseSelectorVisibility = "Hidden";
            Years = new ObservableCollection<int>(Enumerable.Range(1871, 149));
            SelectedAwayTeamYear = 2019;
            SelectedHomeTeamYear = 2019;
        }

        public void ToggleLoading()
        {
            LoadingVisibility = LoadingVisibility == "Visible" ? "Hidden" : "Visible";
        }

        public void ToggleHistoricalTeamSelector()
        {
            HistoricalTeamSelectorVisibility = HistoricalTeamSelectorVisibility == "Visible" ? "Hidden" : "Visible";
        }

        public void ToggleHistoricalFranchiseSelector()
        {
            HistoricalFranchiseSelectorVisibility = HistoricalFranchiseSelectorVisibility == "Visible" ? "Hidden" : "Visible";
        }

        public void LoadHistoricalTeams()
        {
            HistoricalTeams = HistoricalTeamService.GetHistoricalTeams();
            UpdateAwayTeamTeamAndYearCombinations();
            UpdateHomeTeamTeamAndYearCombinations();
        }

        public void LoadHistoricalFranchises()
        {
            HistoricalFranchises = HistoricalTeamService.GetActiveHistoricalFranchises();
            HomeTeamHistoricalFranchiseNames = new ObservableCollection<string>(HistoricalFranchises.Select(t => t.FranchiseName));
            SelectedHomeTeamHistoricalFranchiseName = HomeTeamHistoricalFranchiseNames.First();
            AwayTeamHistoricalFranchiseNames = new ObservableCollection<string>(HistoricalFranchises.Select(t => t.FranchiseName));
            SelectedAwayTeamHistoricalFranchiseName = AwayTeamHistoricalFranchiseNames.First();
        }

        public IEnumerable<TeamViewModel> AssembleHistoricalTeams()
        {
            var homeTeam = HistoricalTeamService.GetHistoricalTeamWithPlayers(HistoricalTeams.Single(h => h.Year == SelectedHomeTeamYear && h.Name == SelectedHomeTeamHistoricalTeamName).TeamId);
            var awayTeam = HistoricalTeamService.GetHistoricalTeamWithPlayers(HistoricalTeams.Single(h => h.Year == SelectedAwayTeamYear && h.Name == SelectedAwayTeamHistoricalTeamName).TeamId);
            var homeTeamViewModel = SetupHistoricalTeamViewModel(homeTeam);
            var awayTeamViewModel = SetupHistoricalTeamViewModel(awayTeam);
            homeTeamViewModel.TeamName = "Home Team";
            awayTeamViewModel.TeamName = "Away Team";
            return new List<TeamViewModel> { homeTeamViewModel, awayTeamViewModel };
        }

        public IEnumerable<TeamViewModel> AssembleHistoricalFranchiseAllTimeTeams()
        {
            var homeTeam = HistoricalTeamService.GetHistoricalFranchiseAllTimePlayers(HistoricalFranchises.Single(h => h.FranchiseName == SelectedHomeTeamHistoricalFranchiseName).FranchiseId);
            var awayTeam = HistoricalTeamService.GetHistoricalFranchiseAllTimePlayers(HistoricalFranchises.Single(h => h.FranchiseName == SelectedAwayTeamHistoricalFranchiseName).FranchiseId);
            var homeTeamViewModel = SetupHistoricalTeamViewModel(homeTeam);
            var awayTeamViewModel = SetupHistoricalTeamViewModel(awayTeam);
            homeTeamViewModel.TeamName = "Home Team";
            awayTeamViewModel.TeamName = "Away Team";
            return new List<TeamViewModel> { homeTeamViewModel, awayTeamViewModel };
        }

        public IEnumerable<TeamViewModel> GenerateRandomTeams(bool hallOfFamer = false, bool allStar = false)
        {
            var homeTeam = new TeamViewModel();
            var awayTeam = new TeamViewModel();
            homeTeam.TeamName = "Home Team";
            awayTeam.TeamName = "Away Team";
            homeTeam.Catcher = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.Catcher, true, hallOfFamer, allStar));
            awayTeam.Catcher = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.Catcher, true, hallOfFamer, allStar));
            homeTeam.FirstBaseman = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.FirstBaseman, true, hallOfFamer, allStar));
            awayTeam.FirstBaseman = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.FirstBaseman, true, hallOfFamer, allStar));
            homeTeam.SecondBaseman = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.SecondBaseman, true, hallOfFamer, allStar));
            awayTeam.SecondBaseman = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.SecondBaseman, true, hallOfFamer, allStar));
            homeTeam.ThirdBaseman = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.ThirdBaseman, true, hallOfFamer, allStar));
            awayTeam.ThirdBaseman = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.ThirdBaseman, true, hallOfFamer, allStar));
            homeTeam.Shortstop = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.Shortstop, true, hallOfFamer, allStar));
            awayTeam.Shortstop = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.Shortstop, true, hallOfFamer, allStar));
            homeTeam.LeftFielder = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.LeftFielder, true, hallOfFamer, allStar));
            awayTeam.LeftFielder = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.LeftFielder, true, hallOfFamer, allStar));
            homeTeam.CenterFielder = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.CenterFielder, true, hallOfFamer, allStar));
            awayTeam.CenterFielder = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.CenterFielder, true, hallOfFamer, allStar));
            homeTeam.RightFielder = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.RightFielder, true, hallOfFamer, allStar));
            awayTeam.RightFielder = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.RightFielder, true, hallOfFamer, allStar));
            homeTeam.DesignatedHitter = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.DesignatedHitter, true, hallOfFamer, allStar));
            awayTeam.DesignatedHitter = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.DesignatedHitter, true, hallOfFamer, allStar));
            homeTeam.BenchPlayer1 = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.Catcher, false, hallOfFamer, allStar));
            awayTeam.BenchPlayer1 = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.Catcher, false, hallOfFamer, allStar));
            homeTeam.BenchPlayer2 = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.CornerInfielder, false, hallOfFamer, allStar));
            awayTeam.BenchPlayer2 = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.CornerInfielder, false, hallOfFamer, allStar));
            homeTeam.BenchPlayer3 = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.MiddleInfielder, false, hallOfFamer, allStar));
            awayTeam.BenchPlayer3 = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.MiddleInfielder, false, hallOfFamer, allStar));
            homeTeam.BenchPlayer4 = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.OutFielder, false, hallOfFamer, allStar));
            awayTeam.BenchPlayer4 = new BatterViewModel(RandomPlayerSelectorService.SelectRandomBatter(PositionType.OutFielder, false, hallOfFamer, allStar));
            homeTeam.StartingPitcher1 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true, hallOfFamer, allStar));
            awayTeam.StartingPitcher1 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true, hallOfFamer, allStar));
            homeTeam.StartingPitcher2 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true, hallOfFamer, allStar));
            awayTeam.StartingPitcher2 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true, hallOfFamer, allStar));
            homeTeam.StartingPitcher3 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true, hallOfFamer, allStar));
            awayTeam.StartingPitcher3 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true, hallOfFamer, allStar));
            homeTeam.StartingPitcher4 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true, hallOfFamer, allStar));
            awayTeam.StartingPitcher4 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true, hallOfFamer, allStar));
            homeTeam.StartingPitcher5 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true, hallOfFamer, allStar));
            awayTeam.StartingPitcher5 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(true, hallOfFamer, allStar));
            homeTeam.ReliefPitcher1 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(false, hallOfFamer, allStar));
            awayTeam.ReliefPitcher1 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(false, hallOfFamer, allStar));
            homeTeam.ReliefPitcher2 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(false, hallOfFamer, allStar));
            awayTeam.ReliefPitcher2 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(false, hallOfFamer, allStar));
            homeTeam.ReliefPitcher3 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(false, hallOfFamer, allStar));
            awayTeam.ReliefPitcher3 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(false, hallOfFamer, allStar));
            homeTeam.ReliefPitcher4 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(false, hallOfFamer, allStar));
            awayTeam.ReliefPitcher4 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(false, hallOfFamer, allStar));
            homeTeam.ReliefPitcher5 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(false, hallOfFamer, allStar));
            awayTeam.ReliefPitcher5 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(false, hallOfFamer, allStar));
            homeTeam.ReliefPitcher6 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(false, hallOfFamer, allStar));
            awayTeam.ReliefPitcher6 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(false, hallOfFamer, allStar));
            homeTeam.ReliefPitcher7 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(false, hallOfFamer, allStar));
            awayTeam.ReliefPitcher7 = new PitcherViewModel(RandomPlayerSelectorService.SelectRandomPitcher(false, hallOfFamer, allStar));

            return new List<TeamViewModel> { homeTeam, awayTeam };
        }

        private void UpdateHomeTeamTeamAndYearCombinations()
        {
            if (HistoricalTeams != null)
            {
                HomeTeamHistoricalTeamNames = new ObservableCollection<string>(HistoricalTeams.Where(t => t.Year == SelectedHomeTeamYear).Select(t => t.Name));
                SelectedHomeTeamHistoricalTeamName = HomeTeamHistoricalTeamNames.First();
            }
        }

        private void UpdateAwayTeamTeamAndYearCombinations()
        {
            if (HistoricalTeams != null)
            {
                AwayTeamHistoricalTeamNames = new ObservableCollection<string>(HistoricalTeams.Where(t => t.Year == SelectedAwayTeamYear).Select(t => t.Name));
                SelectedAwayTeamHistoricalTeamName = AwayTeamHistoricalTeamNames.First();
            }
        }

        private TeamViewModel SetupHistoricalTeamViewModel(Team team)
        {
            var batters = team.PlayerStints.Where(p => p.PitchingStint == null).Select(b => new BatterViewModel(b)).ToList();
            var pitchers = team.PlayerStints.Where(p => p.PitchingStint != null).Select(p => new PitcherViewModel(p)).ToList();

            var teamViewModel = new TeamViewModel();

            teamViewModel.Catcher = batters.Where(b => b.PlayerStint.FieldingStints.Any(f => f.PositionType == PositionType.Catcher))
                .OrderByDescending(b => b.PlayerStint.FieldingStints.SingleOrDefault(f => f.PositionType == PositionType.Catcher).Games).First();
            batters.Remove(teamViewModel.Catcher);

            teamViewModel.Shortstop = batters.Where(b => b.PlayerStint.FieldingStints.Any(f => f.PositionType == PositionType.Shortstop))
                .OrderByDescending(b => b.PlayerStint.FieldingStints.SingleOrDefault(f => f.PositionType == PositionType.Shortstop).Games).First();
            batters.Remove(teamViewModel.Shortstop);

            teamViewModel.SecondBaseman = batters.Where(b => b.PlayerStint.FieldingStints.Any(f => f.PositionType == PositionType.SecondBaseman))
                .OrderByDescending(b => b.PlayerStint.FieldingStints.SingleOrDefault(f => f.PositionType == PositionType.SecondBaseman).Games).First();
            batters.Remove(teamViewModel.SecondBaseman);

            teamViewModel.ThirdBaseman = batters.Where(b => b.PlayerStint.FieldingStints.Any(f => f.PositionType == PositionType.ThirdBaseman))
                .OrderByDescending(b => b.PlayerStint.FieldingStints.SingleOrDefault(f => f.PositionType == PositionType.ThirdBaseman).Games).First();
            batters.Remove(teamViewModel.ThirdBaseman);

            teamViewModel.FirstBaseman = batters.Where(b => b.PlayerStint.FieldingStints.Any(f => f.PositionType == PositionType.FirstBaseman))
                .OrderByDescending(b => b.PlayerStint.FieldingStints.SingleOrDefault(f => f.PositionType == PositionType.FirstBaseman).Games).First();
            batters.Remove(teamViewModel.FirstBaseman);
            
            teamViewModel.CenterFielder = batters.Where(b => b.PlayerStint.FieldingStints.Any(f => f.PositionType == PositionType.CenterFielder))
                .OrderByDescending(b => b.PlayerStint.FieldingStints.SingleOrDefault(f => f.PositionType == PositionType.CenterFielder).Games)?.FirstOrDefault();
            if (teamViewModel.CenterFielder == null)
            {
                teamViewModel.CenterFielder = batters.Where(b => b.PlayerStint.FieldingStints.Any(f => f.PositionType == PositionType.OutFielder))
                    .OrderByDescending(b => b.PlayerStint.FieldingStints.SingleOrDefault(f => f.PositionType == PositionType.OutFielder).Games)?.FirstOrDefault();
            }
            batters.Remove(teamViewModel.CenterFielder);
            
            teamViewModel.RightFielder = batters.Where(b => b.PlayerStint.FieldingStints.Any(f => f.PositionType == PositionType.RightFielder))
                .OrderByDescending(b => b.PlayerStint.FieldingStints.SingleOrDefault(f => f.PositionType == PositionType.RightFielder).Games)?.FirstOrDefault();
            if (teamViewModel.RightFielder == null)
            {
                teamViewModel.RightFielder = batters.Where(b => b.PlayerStint.FieldingStints.Any(f => f.PositionType == PositionType.OutFielder))
                    .OrderByDescending(b => b.PlayerStint.FieldingStints.SingleOrDefault(f => f.PositionType == PositionType.OutFielder).Games)?.FirstOrDefault();
            }
            batters.Remove(teamViewModel.RightFielder);


            teamViewModel.LeftFielder = batters.Where(b => b.PlayerStint.FieldingStints.Any(f => f.PositionType == PositionType.LeftFielder))
                .OrderByDescending(b => b.PlayerStint.FieldingStints.SingleOrDefault(f => f.PositionType == PositionType.LeftFielder).Games)?.FirstOrDefault();
            if (teamViewModel.LeftFielder == null)
            {
                teamViewModel.LeftFielder = batters.Where(b => b.PlayerStint.FieldingStints.Any(f => f.PositionType == PositionType.OutFielder))
                    .OrderByDescending(b => b.PlayerStint.FieldingStints.SingleOrDefault(f => f.PositionType == PositionType.OutFielder).Games)?.FirstOrDefault();
            }
            batters.Remove(teamViewModel.LeftFielder);

            teamViewModel.DesignatedHitter = batters.OrderByDescending(b => b.PlayerStint.BattingStint.Games).First();
            batters.Remove(teamViewModel.DesignatedHitter);

            teamViewModel.BenchPlayer1 = batters.OrderByDescending(b => b.PlayerStint.BattingStint.Games)?.FirstOrDefault();
            if (teamViewModel.BenchPlayer1 != null)
            {
                batters.Remove(teamViewModel.BenchPlayer1);
                teamViewModel.BenchPlayer2 = batters.OrderByDescending(b => b.PlayerStint.BattingStint.Games)?.FirstOrDefault();
                if (teamViewModel.BenchPlayer2 != null)
                {
                    batters.Remove(teamViewModel.BenchPlayer2);
                    teamViewModel.BenchPlayer3 = batters.OrderByDescending(b => b.PlayerStint.BattingStint.Games)?.FirstOrDefault();
                    if (teamViewModel.BenchPlayer3 != null)
                    {
                        batters.Remove(teamViewModel.BenchPlayer3);
                        teamViewModel.BenchPlayer4 = batters.OrderByDescending(b => b.PlayerStint.BattingStint.Games)?.FirstOrDefault();
                        if (teamViewModel.BenchPlayer4 != null)
                        {
                            batters.Remove(teamViewModel.BenchPlayer4);
                        }
                    }
                }
            }

            teamViewModel.StartingPitcher1 = pitchers.OrderByDescending(p => p.GamesStarted).First();
            pitchers.Remove(teamViewModel.StartingPitcher1);
            teamViewModel.StartingPitcher2 = pitchers.OrderByDescending(p => p.GamesStarted)?.FirstOrDefault();
            if (teamViewModel.StartingPitcher2 != null)
            {
                pitchers.Remove(teamViewModel.StartingPitcher2);
                teamViewModel.StartingPitcher3 = pitchers.OrderByDescending(p => p.GamesStarted)?.FirstOrDefault();
                if (teamViewModel.StartingPitcher3 != null)
                {
                    pitchers.Remove(teamViewModel.StartingPitcher3);
                    teamViewModel.StartingPitcher4 = pitchers.OrderByDescending(p => p.GamesStarted)?.FirstOrDefault();
                    if (teamViewModel.StartingPitcher4 != null)
                    {
                        pitchers.Remove(teamViewModel.StartingPitcher4);
                        teamViewModel.StartingPitcher5 = pitchers.OrderByDescending(p => p.GamesStarted)?.FirstOrDefault();
                        if (teamViewModel.StartingPitcher5 != null)
                        {
                            pitchers.Remove(teamViewModel.StartingPitcher5);
                        }
                    }
                }
            }

            teamViewModel.ReliefPitcher1 = pitchers.OrderByDescending(p => p.Games)?.FirstOrDefault();
            if (teamViewModel.ReliefPitcher1 != null)
            {
                pitchers.Remove(teamViewModel.ReliefPitcher1);
                teamViewModel.ReliefPitcher2 = pitchers.OrderByDescending(p => p.Games)?.FirstOrDefault();
                if (teamViewModel.ReliefPitcher2 != null)
                {
                    pitchers.Remove(teamViewModel.ReliefPitcher2);
                    teamViewModel.ReliefPitcher3 = pitchers.OrderByDescending(p => p.Games)?.FirstOrDefault();
                    if (teamViewModel.ReliefPitcher3 != null)
                    {
                        pitchers.Remove(teamViewModel.ReliefPitcher3);
                        teamViewModel.ReliefPitcher4 = pitchers.OrderByDescending(p => p.Games)?.FirstOrDefault();
                        if (teamViewModel.ReliefPitcher4 != null)
                        {
                            pitchers.Remove(teamViewModel.ReliefPitcher4);
                            teamViewModel.ReliefPitcher5 = pitchers.OrderByDescending(p => p.Games)?.FirstOrDefault();
                            if (teamViewModel.ReliefPitcher5 != null)
                            {
                                pitchers.Remove(teamViewModel.ReliefPitcher5);
                                teamViewModel.ReliefPitcher6 = pitchers.OrderByDescending(p => p.Games)?.FirstOrDefault();
                                if (teamViewModel.ReliefPitcher6 != null)
                                {
                                    pitchers.Remove(teamViewModel.ReliefPitcher6);
                                    teamViewModel.ReliefPitcher7 = pitchers.OrderByDescending(p => p.Games)?.FirstOrDefault();
                                    if (teamViewModel.ReliefPitcher7 != null)
                                    {
                                        pitchers.Remove(teamViewModel.ReliefPitcher7);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return teamViewModel;
        }
    }
}
