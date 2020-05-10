using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace FantasyBaseball.UI.ViewModels
{
    public class TeamViewModel : ViewModelBase
    {
        public string TeamName { get; set; }

        private BatterViewModel _catcher { get; set; }
        public BatterViewModel Catcher
        {
            get { return _catcher; }
            set { _catcher = value; RaisePropertyChanged("Catcher"); }
        }

        private BatterViewModel _firstBaseman { get; set; }
        public BatterViewModel FirstBaseman
        {
            get { return _firstBaseman; }
            set { _firstBaseman = value; RaisePropertyChanged("FirstBaseman"); }
        }

        private BatterViewModel _secondBaseman { get; set; }
        public BatterViewModel SecondBaseman
        {
            get { return _secondBaseman; }
            set { _secondBaseman = value; RaisePropertyChanged("SecondBaseman"); }
        }

        private BatterViewModel _thirdBaseman { get; set; }
        public BatterViewModel ThirdBaseman
        {
            get { return _thirdBaseman; }
            set { _thirdBaseman = value; RaisePropertyChanged("ThirdBaseman"); }
        }

        private BatterViewModel _shortstop { get; set; }
        public BatterViewModel Shortstop
        {
            get { return _shortstop; }
            set { _shortstop = value; RaisePropertyChanged("Shortstop"); }
        }

        private BatterViewModel _leftFielder { get; set; }
        public BatterViewModel LeftFielder
        {
            get { return _leftFielder; }
            set { _leftFielder = value; RaisePropertyChanged("LeftFielder"); }
        }

        private BatterViewModel _centerFielder { get; set; }
        public BatterViewModel CenterFielder
        {
            get { return _centerFielder; }
            set { _centerFielder = value; RaisePropertyChanged("CenterFielder"); }
        }

        private BatterViewModel _rightFielder { get; set; }
        public BatterViewModel RightFielder
        {
            get { return _rightFielder; }
            set { _rightFielder = value; RaisePropertyChanged("RightFielder"); }
        }

        private BatterViewModel _designatedHitter { get; set; }
        public BatterViewModel DesignatedHitter
        {
            get { return _designatedHitter; }
            set { _designatedHitter = value; RaisePropertyChanged("DesignatedHitter"); }
        }

        private BatterViewModel _benchPlayer1 { get; set; }
        public BatterViewModel BenchPlayer1
        {
            get { return _benchPlayer1; }
            set { _benchPlayer1 = value; RaisePropertyChanged("BenchPlayer1"); }
        }

        private BatterViewModel _benchPlayer2 { get; set; }
        public BatterViewModel BenchPlayer2
        {
            get { return _benchPlayer2; }
            set { _benchPlayer2 = value; RaisePropertyChanged("BenchPlayer2"); }
        }

        private BatterViewModel _benchPlayer3 { get; set; }
        public BatterViewModel BenchPlayer3
        {
            get { return _benchPlayer3; }
            set { _benchPlayer3 = value; RaisePropertyChanged("BenchPlayer3"); }
        }

        private BatterViewModel _benchPlayer4 { get; set; }
        public BatterViewModel BenchPlayer4
        {
            get { return _benchPlayer4; }
            set { _benchPlayer4 = value; RaisePropertyChanged("BenchPlayer4"); }
        }

        private PitcherViewModel _currentPitcher { get; set; }
        public PitcherViewModel CurrentPitcher
        {
            get { return _currentPitcher; }
            set { _currentPitcher = value; RaisePropertyChanged("CurrentPitcher"); }
        }


        private PitcherViewModel _startingPitcher1 { get; set; }
        public PitcherViewModel StartingPitcher1
        {
            get { return _startingPitcher1; }
            set { _startingPitcher1 = value; RaisePropertyChanged("StartingPitcher1"); }
        }

        private PitcherViewModel _startingPitcher2 { get; set; }
        public PitcherViewModel StartingPitcher2
        {
            get { return _startingPitcher2; }
            set { _startingPitcher2 = value; RaisePropertyChanged("StartingPitcher2"); }
        }

        private PitcherViewModel _startingPitcher3 { get; set; }
        public PitcherViewModel StartingPitcher3
        {
            get { return _startingPitcher3; }
            set { _startingPitcher3 = value; RaisePropertyChanged("StartingPitcher3"); }
        }

        private PitcherViewModel _startingPitcher4 { get; set; }
        public PitcherViewModel StartingPitcher4
        {
            get { return _startingPitcher4; }
            set { _startingPitcher4 = value; RaisePropertyChanged("StartingPitcher4"); }
        }

        private PitcherViewModel _startingPitcher5 { get; set; }
        public PitcherViewModel StartingPitcher5
        {
            get { return _startingPitcher5; }
            set { _startingPitcher5 = value; RaisePropertyChanged("StartingPitcher5"); }
        }

        private PitcherViewModel _reliefPitcher1 { get; set; }
        public PitcherViewModel ReliefPitcher1
        {
            get { return _reliefPitcher1; }
            set { _reliefPitcher1 = value; RaisePropertyChanged("ReliefPitcher1"); }
        }

        private PitcherViewModel _reliefPitcher2 { get; set; }
        public PitcherViewModel ReliefPitcher2
        {
            get { return _reliefPitcher2; }
            set { _reliefPitcher2 = value; RaisePropertyChanged("ReliefPitcher2"); }
        }

        private PitcherViewModel _reliefPitcher3 { get; set; }
        public PitcherViewModel ReliefPitcher3
        {
            get { return _reliefPitcher3; }
            set { _reliefPitcher3 = value; RaisePropertyChanged("ReliefPitcher3"); }
        }

        private PitcherViewModel _reliefPitcher4 { get; set; }
        public PitcherViewModel ReliefPitcher4
        {
            get { return _reliefPitcher4; }
            set { _reliefPitcher4 = value; RaisePropertyChanged("ReliefPitcher4"); }
        }

        private PitcherViewModel _reliefPitcher5 { get; set; }
        public PitcherViewModel ReliefPitcher5
        {
            get { return _reliefPitcher5; }
            set { _reliefPitcher5 = value; RaisePropertyChanged("ReliefPitcher5"); }
        }

        private PitcherViewModel _reliefPitcher6 { get; set; }
        public PitcherViewModel ReliefPitcher6
        {
            get { return _reliefPitcher6; }
            set { _reliefPitcher6 = value; RaisePropertyChanged("ReliefPitcher6"); }
        }

        private PitcherViewModel _reliefPitcher7 { get; set; }
        public PitcherViewModel ReliefPitcher7
        {
            get { return _reliefPitcher7; }
            set { _reliefPitcher7 = value; RaisePropertyChanged("ReliefPitcher7"); }
        }

        private ObservableCollection<PitcherViewModel> _bullpen { get; set; }
        public ObservableCollection<PitcherViewModel> Bullpen
        {
            get { return _bullpen; }
            set { _bullpen = value; RaisePropertyChanged("Bullpen"); }
        }

        private ObservableCollection<BatterViewModel> _lineup { get; set; }
        public ObservableCollection<BatterViewModel> Lineup
        {
            get { return _lineup; }
            set { _lineup = value; RaisePropertyChanged("Lineup"); }
        }

        private ObservableCollection<BatterViewModel> _bench { get; set; }
        public ObservableCollection<BatterViewModel> Bench
        {
            get { return _bench; }
            set { _bench = value; RaisePropertyChanged("Bench"); }
        }

        private ObservableCollection<IPlayerViewModel> _unavailablePlayers { get; set; }
        public ObservableCollection<IPlayerViewModel> UnavailablePlayers
        {
            get { return _unavailablePlayers; }
            set { _unavailablePlayers = value; RaisePropertyChanged("UnavailablePlayers"); }
        }

        public TeamViewModel()
        {
            UnavailablePlayers = new ObservableCollection<IPlayerViewModel>();
            Bullpen = new ObservableCollection<PitcherViewModel>();
            Bench = new ObservableCollection<BatterViewModel>();
            Lineup = new ObservableCollection<BatterViewModel>();
        }
    }
}
