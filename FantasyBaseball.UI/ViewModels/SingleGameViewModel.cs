using GalaSoft.MvvmLight;
using System.Collections.Generic;

namespace FantasyBaseball.UI.ViewModels
{
    public class SingleGameViewModel : ViewModelBase
    {
        public TeamViewModel HomeTeam { get; set; }

        public TeamViewModel AwayTeam { get; set; }

        public BatterViewModel OnFieldCatcher { get; set; }

        public BatterViewModel OnFieldFirstBaseman { get; set; }

        public BatterViewModel OnFieldSecondBaseman { get; set; }

        public BatterViewModel OnFieldThirdBaseman { get; set; }

        public BatterViewModel OnFieldShortstop { get; set; }

        public BatterViewModel OnFieldLeftFielder { get; set; }

        public BatterViewModel OnFieldCenterFielder { get; set; }

        public BatterViewModel OnFieldRightFielder { get; set; }

        public PitcherViewModel OnFieldPitcher { get; set; }

        public BatterViewModel AtPlateBatter { get; set; }

        public BatterViewModel OnDeckBatter { get; set; }

        public BatterViewModel RunnerOnFirst { get; set; }

        public BatterViewModel RunnerOnSecond { get; set; }

        public BatterViewModel RunnerOnThird { get; set; }

        public int Outs { get; set; }

        public int Inning { get; set; }

        public IEnumerable<int> AwayTeamScoreboard { get; set; }

        public IEnumerable<int> HomeTeamScoreboard { get; set; }
    }
}
