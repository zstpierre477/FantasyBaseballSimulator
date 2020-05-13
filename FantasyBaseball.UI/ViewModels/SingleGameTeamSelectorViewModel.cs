using GalaSoft.MvvmLight;

namespace FantasyBaseball.UI.ViewModels
{
    public class SingleGameTeamSelectorViewModel : ViewModelBase
    {
        public TeamViewModel HomeTeam { get; set; }

        public TeamViewModel AwayTeam { get; set; }

        public SingleGameTeamSelectorViewModel()
        {
            HomeTeam = new TeamViewModel();
            AwayTeam = new TeamViewModel();
            HomeTeam.TeamName = "Home Team";
            AwayTeam.TeamName = "Away Team";
        }

        public bool CanPlaySingleGame()
        {
            return HomeTeam.Catcher != null && HomeTeam.FirstBaseman != null && HomeTeam.SecondBaseman != null && HomeTeam.ThirdBaseman != null && HomeTeam.Shortstop != null &&
                HomeTeam.LeftFielder != null && HomeTeam.CenterFielder != null && HomeTeam.RightFielder != null && HomeTeam.DesignatedHitter != null && HomeTeam.StartingPitcher1 != null &&
                AwayTeam.Catcher != null && AwayTeam.FirstBaseman != null && AwayTeam.SecondBaseman != null && AwayTeam.ThirdBaseman != null && AwayTeam.Shortstop != null &&
                AwayTeam.LeftFielder != null && AwayTeam.CenterFielder != null && AwayTeam.RightFielder != null && AwayTeam.DesignatedHitter != null && AwayTeam.StartingPitcher1 != null
                && HomeTeam.TeamName != null && AwayTeam.TeamName != null;
        }

        public void SetPitcherLineupsBullpensAndBenches()
        {
            SetDefaultTeamCollections(HomeTeam);
            SetDefaultTeamCollections(AwayTeam);
        }

        private void SetDefaultTeamCollections(TeamViewModel team)
        {
            team.Lineup.Add(team.Catcher);
            team.Lineup.Add(team.FirstBaseman);
            team.Lineup.Add(team.SecondBaseman);
            team.Lineup.Add(team.ThirdBaseman);
            team.Lineup.Add(team.Shortstop);
            team.Lineup.Add(team.LeftFielder);
            team.Lineup.Add(team.CenterFielder);
            team.Lineup.Add(team.RightFielder);
            team.Lineup.Add(team.DesignatedHitter);

            if (team.BenchPlayer1 != null) 
            { 
                team.Bench.Add(team.BenchPlayer1); 
            }
            if (team.BenchPlayer2 != null)
            {
                team.Bench.Add(team.BenchPlayer2);
            }
            if (team.BenchPlayer3 != null)
            {
                team.Bench.Add(team.BenchPlayer3);
            }
            if (team.BenchPlayer4 != null)
            {
                team.Bench.Add(team.BenchPlayer4);
            }

            team.CurrentPitcher = team.StartingPitcher1;

            if (team.StartingPitcher2 != null)
            {
                team.Bullpen.Add(team.StartingPitcher2);
            }
            if (team.StartingPitcher3 != null)
            {
                team.Bullpen.Add(team.StartingPitcher3);
            }
            if (team.StartingPitcher4 != null)
            {
                team.Bullpen.Add(team.StartingPitcher4);
            }
            if (team.StartingPitcher5 != null)
            {
                team.Bullpen.Add(team.StartingPitcher5);
            }
            if (team.ReliefPitcher1 != null)
            {
                team.Bullpen.Add(team.ReliefPitcher1);
            }
            if (team.ReliefPitcher2 != null)
            {
                team.Bullpen.Add(team.ReliefPitcher2);
            }
            if (team.ReliefPitcher3 != null)
            {
                team.Bullpen.Add(team.ReliefPitcher3);
            }
            if (team.ReliefPitcher4 != null)
            {
                team.Bullpen.Add(team.ReliefPitcher4);
            }
            if (team.ReliefPitcher5 != null)
            {
                team.Bullpen.Add(team.ReliefPitcher5);
            }
            if (team.ReliefPitcher6 != null)
            {
                team.Bullpen.Add(team.ReliefPitcher6);
            }
            if (team.ReliefPitcher7 != null)
            {
                team.Bullpen.Add(team.ReliefPitcher7);
            }

            var count = 0;
            foreach(var batter in team.Lineup)
            {
                batter.CurrentGameLineupIndex = count;
                count++;
            }

            count = 0;
            foreach (var batter in team.Bench)
            {
                batter.CurrentGameBenchIndex = count;
                count++;
            }

            count = 0;
            foreach (var pitcher in team.Bullpen)
            {
                pitcher.BullpenIndex = count;
                count++;
            }
        }
    }
}
