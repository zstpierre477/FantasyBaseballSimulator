using GalaSoft.MvvmLight;
using System.Collections;
using System.Collections.Generic;

namespace FantasyBaseball.UI.ViewModels
{
    public class TeamViewModel : ViewModelBase
    {
        public string TeamName { get; set; }

        public BatterViewModel Catcher { get; set; }

        public BatterViewModel FirstBaseman { get; set; }

        public BatterViewModel SecondBaseman { get; set; }

        public BatterViewModel ThirdBaseman { get; set; }

        public BatterViewModel Shortstop { get; set; }

        public BatterViewModel LeftFielder { get; set; }

        public BatterViewModel CenterFielder { get; set; }
        
        public BatterViewModel RightFielder { get; set; }

        public BatterViewModel DesignatedHitter { get; set; }

        public BatterViewModel BenchPlayer1 { get; set; }

        public BatterViewModel BenchPlayer2 { get; set; }

        public BatterViewModel BenchPlayer3 { get; set; }

        public BatterViewModel BenchPlayer4 { get; set; }

        public PitcherViewModel StartingPitcher1 { get; set; }

        public PitcherViewModel StartingPitcher2 { get; set; }

        public PitcherViewModel StartingPitcher3 { get; set; }

        public PitcherViewModel StartingPitcher4 { get; set; }

        public PitcherViewModel StartingPitcher5 { get; set; }

        public PitcherViewModel ReliefPitcher1 { get; set; }

        public PitcherViewModel ReliefPitcher2 { get; set; }

        public PitcherViewModel ReliefPitcher3 { get; set; }

        public PitcherViewModel ReliefPitcher4 { get; set; }

        public PitcherViewModel ReliefPitcher5 { get; set; }

        public PitcherViewModel ReliefPitcher6 { get; set; }

        public PitcherViewModel ReliefPitcher7 { get; set; }

        public IEnumerable<PitcherViewModel> Bullpen { get; set; }

        public IEnumerable<BatterViewModel> Lineup { get; set; }

        public IEnumerable<BatterViewModel> Bench { get; set; }
    }
}
