using FantasyBaseball.Business.Services;
using FantasyBaseball.Entities.Enums;
using FantasyBaseball.Entities.Helpers;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace FantasyBaseball.UI.ViewModels
{
    public class SingleGameViewModel : ViewModelBase
    {
        private TeamViewModel _homeTeam { get; set; }
        public TeamViewModel HomeTeam
        {
            get { return _homeTeam; }
            set { _homeTeam = value; RaisePropertyChanged("HomeTeam"); }
        }

        private TeamViewModel _awayTeam { get; set; }
        public TeamViewModel AwayTeam
        {
            get { return _awayTeam; }
            set { _awayTeam = value; RaisePropertyChanged("AwayTeam"); }
        }

        private BatterViewModel _onFieldCatcher { get; set; }
        public BatterViewModel OnFieldCatcher
        {
            get { return _onFieldCatcher; }
            set { _onFieldCatcher = value; RaisePropertyChanged("OnFieldCatcher"); }
        }

        private BatterViewModel _onFieldFirstBaseman { get; set; }
        public BatterViewModel OnFieldFirstBaseman
        {
            get { return _onFieldFirstBaseman; }
            set { _onFieldFirstBaseman = value; RaisePropertyChanged("OnFieldFirstBaseman"); }
        }

        private BatterViewModel _onFieldSecondBaseman { get; set; }
        public BatterViewModel OnFieldSecondBaseman
        {
            get { return _onFieldSecondBaseman; }
            set { _onFieldSecondBaseman = value; RaisePropertyChanged("OnFieldSecondBaseman"); }
        }

        private BatterViewModel _onFieldThirdBaseman { get; set; }
        public BatterViewModel OnFieldThirdBaseman
        {
            get { return _onFieldThirdBaseman; }
            set { _onFieldThirdBaseman = value; RaisePropertyChanged("OnFieldThirdBaseman"); }
        }

        private BatterViewModel _onFieldShortstop { get; set; }
        public BatterViewModel OnFieldShortstop
        {
            get { return _onFieldShortstop; }
            set { _onFieldShortstop = value; RaisePropertyChanged("OnFieldShortstop"); }
        }

        private BatterViewModel _onFieldLeftFielder { get; set; }
        public BatterViewModel OnFieldLeftFielder
        {
            get { return _onFieldLeftFielder; }
            set { _onFieldLeftFielder = value; RaisePropertyChanged("OnFieldLeftFielder"); }
        }

        private BatterViewModel _onFieldCenterFielder { get; set; }
        public BatterViewModel OnFieldCenterFielder
        {
            get { return _onFieldCenterFielder; }
            set { _onFieldCenterFielder = value; RaisePropertyChanged("OnFieldCenterFielder"); }
        }

        private BatterViewModel _onFieldRightFielder { get; set; }
        public BatterViewModel OnFieldRightFielder
        {
            get { return _onFieldRightFielder; }
            set { _onFieldRightFielder = value; RaisePropertyChanged("OnFieldRightFielder"); }
        }

        private PitcherViewModel _onFieldPitcher { get; set; }
        public PitcherViewModel OnFieldPitcher
        {
            get { return _onFieldPitcher; }
            set { _onFieldPitcher = value; RaisePropertyChanged("OnFieldPitcher"); }
        }

        private BatterViewModel _atPlateBatter { get; set; }
        public BatterViewModel AtPlateBatter
        {
            get { return _atPlateBatter; }
            set { _atPlateBatter = value; RaisePropertyChanged("AtPlateBatter"); }
        }

        private BatterViewModel _runnerOnFirst { get; set; }
        public BatterViewModel RunnerOnFirst
        {
            get { return _runnerOnFirst; }
            set { _runnerOnFirst = value; RaisePropertyChanged("RunnerOnFirst"); RaisePropertyChanged("RunnerOnFirstVisibility"); }
        }

        private BatterViewModel _runnerOnSecond { get; set; }
        public BatterViewModel RunnerOnSecond
        {
            get { return _runnerOnSecond; }
            set { _runnerOnSecond = value; RaisePropertyChanged("RunnerOnSecond"); RaisePropertyChanged("RunnerOnSecondVisibility"); }
        }

        private BatterViewModel _runnerOnThird { get; set; }
        public BatterViewModel RunnerOnThird
        {
            get { return _runnerOnThird; }
            set { _runnerOnThird = value; RaisePropertyChanged("RunnerOnThird"); RaisePropertyChanged("RunnerOnThirdVisibility"); }
        }

        private string _runnerOnFirstVisibility => RunnerOnFirst != null ? "Visible" : "Hidden";
        public string RunnerOnFirstVisibility
        {
            get { return _runnerOnFirstVisibility; }
        }

        private string _runnerOnSecondVisibility => RunnerOnSecond != null ? "Visible" : "Hidden";
        public string RunnerOnSecondVisibility
        {
            get { return _runnerOnSecondVisibility; }
        }

        private string _runnerOnThirdVisibility => RunnerOnThird != null ? "Visible" : "Hidden";
        public string RunnerOnThirdVisibility
        {
            get { return _runnerOnThirdVisibility; }
        }

        private ObservableCollection<PitcherViewModel> _homeTeamCurrentPitcher => new ObservableCollection<PitcherViewModel> { HomeTeam.CurrentPitcher };
        public ObservableCollection<PitcherViewModel> HomeTeamCurrentPitcher
        {
            get { return _homeTeamCurrentPitcher; }
        }

        private ObservableCollection<PitcherViewModel> _awayTeamCurrentPitcher => new ObservableCollection<PitcherViewModel> { AwayTeam.CurrentPitcher };
        public ObservableCollection<PitcherViewModel> AwayTeamCurrentPitcher
        {
            get { return _awayTeamCurrentPitcher; }
        }

        private int _outs { get; set; }
        public int Outs
        {
            get { return _outs; }
            set { _outs = value; RaisePropertyChanged("Outs"); }
        }

        private int _inning { get; set; }
        public int Inning
        {
            get { return _inning; }
            set { _inning = value; RaisePropertyChanged("Inning"); RaisePropertyChanged("InningString"); }
        }

        private bool _isTopOfInning { get; set; }
        public bool IsTopOfInning
        {
            get { return _isTopOfInning; }
            set { _isTopOfInning = value; RaisePropertyChanged("IsTopOfInning"); RaisePropertyChanged("InningString"); }
        }

        private string _inningString { get; set; }
        public string InningString
        {
            get { return (IsTopOfInning ? "Top" : "Bot") + Inning.ToString(); }
        }

        private int _awayTeamLineupIndex { get; set; }
        public int AwayTeamLineupIndex
        {
            get { return _awayTeamLineupIndex; }
            set
            {
                _awayTeamLineupIndex = value % 9;
            }
        }

        private int _homeTeamLineupIndex { get; set; }
        public int HomeTeamLineupIndex {
            get { return _homeTeamLineupIndex; }
            set
            {
                _homeTeamLineupIndex = value % 9;
            }
        }

        private int _awayTeamInning1Runs { get; set; }
        public int AwayTeamInning1Runs
        {
            get { return _awayTeamInning1Runs; }
            set { _awayTeamInning1Runs = value; RaisePropertyChanged("AwayTeamInning1Runs"); RaisePropertyChanged("AwayTeamInning1RunsString"); }
        }

        public string AwayTeamInning1RunsString
        {
            get { return Inning > 0 ? _awayTeamInning1Runs.ToString() : ""; }
        }

        private int _awayTeamInning2Runs { get; set; }
        public int AwayTeamInning2Runs
        {
            get { return _awayTeamInning2Runs; }
            set { _awayTeamInning2Runs = value; RaisePropertyChanged("AwayTeamInning2Runs"); RaisePropertyChanged("AwayTeamInning2RunsString"); }
        }

        public string AwayTeamInning2RunsString
        {
            get { return Inning > 1 ? _awayTeamInning2Runs.ToString() : ""; }
        }

        private int _awayTeamInning3Runs { get; set; }
        public int AwayTeamInning3Runs
        {
            get { return _awayTeamInning3Runs; }
            set { _awayTeamInning3Runs = value; RaisePropertyChanged("AwayTeamInning3Runs"); RaisePropertyChanged("AwayTeamInning3RunsString"); }
        }

        public string AwayTeamInning3RunsString
        {
            get { return Inning > 2 ? _awayTeamInning3Runs.ToString() : ""; }
        }

        private int _awayTeamInning4Runs { get; set; }
        public int AwayTeamInning4Runs
        {
            get { return _awayTeamInning4Runs; }
            set { _awayTeamInning4Runs = value; RaisePropertyChanged("AwayTeamInning4Runs"); RaisePropertyChanged("AwayTeamInning4RunsString"); }
        }

        public string AwayTeamInning4RunsString
        {
            get { return Inning > 3 ? _awayTeamInning4Runs.ToString() : ""; }
        }

        private int _awayTeamInning5Runs { get; set; }
        public int AwayTeamInning5Runs
        {
            get { return _awayTeamInning5Runs; }
            set { _awayTeamInning5Runs = value; RaisePropertyChanged("AwayTeamInning5Runs"); RaisePropertyChanged("AwayTeamInning5RunsString"); }
        }

        public string AwayTeamInning5RunsString
        {
            get { return Inning > 4 ? _awayTeamInning5Runs.ToString() : ""; }
        }

        private int _awayTeamInning6Runs { get; set; }
        public int AwayTeamInning6Runs
        {
            get { return _awayTeamInning6Runs; }
            set { _awayTeamInning6Runs = value; RaisePropertyChanged("AwayTeamInning6Runs"); RaisePropertyChanged("AwayTeamInning6RunsString"); }
        }

        public string AwayTeamInning6RunsString
        {
            get { return Inning > 5 ? _awayTeamInning6Runs.ToString() : ""; }
        }

        private int _awayTeamInning7Runs { get; set; }
        public int AwayTeamInning7Runs
        {
            get { return _awayTeamInning7Runs; }
            set { _awayTeamInning7Runs = value; RaisePropertyChanged("AwayTeamInning7Runs"); RaisePropertyChanged("AwayTeamInning7RunsString"); }
        }

        public string AwayTeamInning7RunsString
        {
            get { return Inning > 6 ? _awayTeamInning7Runs.ToString() : ""; }
        }

        private int _awayTeamInning8Runs { get; set; }
        public int AwayTeamInning8Runs
        {
            get { return _awayTeamInning8Runs; }
            set { _awayTeamInning8Runs = value; RaisePropertyChanged("AwayTeamInning8Runs"); RaisePropertyChanged("AwayTeamInning8RunsString"); }
        }

        public string AwayTeamInning8RunsString
        {
            get { return Inning > 7 ? _awayTeamInning8Runs.ToString() : ""; }
        }

        private int _awayTeamInning9Runs { get; set; }
        public int AwayTeamInning9Runs
        {
            get { return _awayTeamInning9Runs; }
            set { _awayTeamInning9Runs = value; RaisePropertyChanged("AwayTeamInning9Runs"); RaisePropertyChanged("AwayTeamInning9RunsString"); }
        }

        public string AwayTeamInning9RunsString
        {
            get { return Inning > 8 ? _awayTeamInning9Runs.ToString() : ""; }
        }

        private int _awayTeamExtraInningsRuns { get; set; }
        public int AwayTeamExtraInningsRuns
        {
            get { return _awayTeamExtraInningsRuns; }
            set { _awayTeamExtraInningsRuns = value; RaisePropertyChanged("AwayTeamExtraInningsRuns"); RaisePropertyChanged("AwayTeamExtraInningsRunsString"); }
        }

        public string AwayTeamExtraInningsRunsString
        {
            get { return Inning > 9 ? _awayTeamExtraInningsRuns.ToString() : ""; }
        }

        private int _awayTeamTotalRuns { get; set; }
        public int AwayTeamTotalRuns
        {
            get { return _awayTeamTotalRuns; }
            set { _awayTeamTotalRuns = value; RaisePropertyChanged("AwayTeamTotalRuns"); }
        }

        private int _awayTeamTotalHits { get; set; }
        public int AwayTeamTotalHits
        {
            get { return _awayTeamTotalHits; }
            set { _awayTeamTotalHits = value; RaisePropertyChanged("AwayTeamTotalHits"); }
        }

        private int _awayTeamTotalErrors { get; set; }
        public int AwayTeamTotalErrors
        {
            get { return _awayTeamTotalErrors; }
            set { _awayTeamTotalErrors = value; RaisePropertyChanged("AwayTeamTotalErrors"); }
        }

        private int _homeTeamInning1Runs { get; set; }
        public int HomeTeamInning1Runs
        {
            get { return _homeTeamInning1Runs; }
            set { _homeTeamInning1Runs = value; RaisePropertyChanged("HomeTeamInning1Runs"); RaisePropertyChanged("HomeTeamInning1RunsString"); }
        }

        public string HomeTeamInning1RunsString
        {
            get { return (Inning > 0 && IsTopOfInning == false) || Inning > 1 ? _homeTeamInning1Runs.ToString() : ""; }
        }

        private int _homeTeamInning2Runs { get; set; }
        public int HomeTeamInning2Runs
        {
            get { return _homeTeamInning2Runs; }
            set { _homeTeamInning2Runs = value; RaisePropertyChanged("HomeTeamInning2Runs"); RaisePropertyChanged("HomeTeamInning2RunsString"); }
        }

        public string HomeTeamInning2RunsString
        {
            get { return (Inning > 1 && IsTopOfInning == false) || Inning > 2 ? _homeTeamInning2Runs.ToString() : ""; }
        }

        private int _homeTeamInning3Runs { get; set; }
        public int HomeTeamInning3Runs
        {
            get { return _homeTeamInning3Runs; }
            set { _homeTeamInning3Runs = value; RaisePropertyChanged("HomeTeamInning3Runs"); RaisePropertyChanged("HomeTeamInning3RunsString"); }
        }

        public string HomeTeamInning3RunsString
        {
            get { return (Inning > 2 && IsTopOfInning == false) || Inning > 3 ? _homeTeamInning3Runs.ToString() : ""; }
        }

        private int _homeTeamInning4Runs { get; set; }
        public int HomeTeamInning4Runs
        {
            get { return _homeTeamInning4Runs; }
            set { _homeTeamInning4Runs = value; RaisePropertyChanged("HomeTeamInning4Runs"); RaisePropertyChanged("HomeTeamInning4RunsString"); }
        }

        public string HomeTeamInning4RunsString
        {
            get { return (Inning > 3 && IsTopOfInning == false) || Inning > 4 ? _homeTeamInning4Runs.ToString() : ""; }
        }

        private int _homeTeamInning5Runs { get; set; }
        public int HomeTeamInning5Runs
        {
            get { return _homeTeamInning5Runs; }
            set { _homeTeamInning5Runs = value; RaisePropertyChanged("HomeTeamInning5Runs"); RaisePropertyChanged("HomeTeamInning5RunsString"); }
        }

        public string HomeTeamInning5RunsString
        {
            get { return (Inning > 4 && IsTopOfInning == false) || Inning > 5 ? _homeTeamInning5Runs.ToString() : ""; }
        }

        private int _homeTeamInning6Runs { get; set; }
        public int HomeTeamInning6Runs
        {
            get { return _homeTeamInning6Runs; }
            set { _homeTeamInning6Runs = value; RaisePropertyChanged("HomeTeamInning6Runs"); RaisePropertyChanged("HomeTeamInning6RunsString"); }
        }

        public string HomeTeamInning6RunsString
        {
            get { return (Inning > 5 && IsTopOfInning == false) || Inning > 6 ? _homeTeamInning6Runs.ToString() : ""; }
        }

        private int _homeTeamInning7Runs { get; set; }
        public int HomeTeamInning7Runs
        {
            get { return _homeTeamInning7Runs; }
            set { _homeTeamInning7Runs = value; RaisePropertyChanged("HomeTeamInning7Runs"); RaisePropertyChanged("HomeTeamInning7RunsString"); }
        }

        public string HomeTeamInning7RunsString
        {
            get { return (Inning > 6 && IsTopOfInning == false) || Inning > 7 ? _homeTeamInning7Runs.ToString() : ""; }
        }

        private int _homeTeamInning8Runs { get; set; }
        public int HomeTeamInning8Runs
        {
            get { return _homeTeamInning8Runs; }
            set { _homeTeamInning8Runs = value; RaisePropertyChanged("HomeTeamInning8Runs"); RaisePropertyChanged("HomeTeamInning8RunsString"); }
        }

        public string HomeTeamInning8RunsString
        {
            get { return (Inning > 7 && IsTopOfInning == false) || Inning > 8 ? _homeTeamInning8Runs.ToString() : ""; }
        }

        private int _homeTeamInning9Runs { get; set; }
        public int HomeTeamInning9Runs
        {
            get { return _homeTeamInning9Runs; }
            set { _homeTeamInning9Runs = value; RaisePropertyChanged("HomeTeamInning9Runs"); RaisePropertyChanged("HomeTeamInning9RunsString"); }
        }

        public string HomeTeamInning9RunsString
        {
            get { return (Inning > 8 && IsTopOfInning == false) || Inning > 9 ? _homeTeamInning9Runs.ToString() : ""; }
        }

        private int _homeTeamExtraInningsRuns { get; set; }
        public int HomeTeamExtraInningsRuns
        {
            get { return _homeTeamExtraInningsRuns; }
            set { _homeTeamExtraInningsRuns = value; RaisePropertyChanged("HomeTeamExtraInningsRuns"); RaisePropertyChanged("HomeTeamExtraInningsRunsString"); }
        }

        public string HomeTeamExtraInningsRunsString
        {
            get { return (Inning > 9 && IsTopOfInning == false) || Inning > 10 ? _homeTeamExtraInningsRuns.ToString() : ""; }
        }

        private int _homeTeamTotalRuns { get; set; }
        public int HomeTeamTotalRuns
        {
            get { return _homeTeamTotalRuns; }
            set { _homeTeamTotalRuns = value; RaisePropertyChanged("HomeTeamTotalRuns"); }
        }

        private int _homeTeamTotalHits { get; set; }
        public int HomeTeamTotalHits
        {
            get { return _homeTeamTotalHits; }
            set { _homeTeamTotalHits = value; RaisePropertyChanged("HomeTeamTotalHits"); }
        }

        private int _homeTeamTotalErrors { get; set; }
        public int HomeTeamTotalErrors
        {
            get { return _homeTeamTotalErrors; }
            set { _homeTeamTotalErrors = value; RaisePropertyChanged("HomeTeamTotalErrors"); }
        }

        public bool GameOver { get; set; }

        private string _fielderColor { get; set; }
        public string FielderColor
        {
            get { return _fielderColor; }
            set { _fielderColor = value; RaisePropertyChanged("FielderColor"); }
        }

        private string _batterColor { get; set; }
        public string BatterColor
        {
            get { return _batterColor; }
            set { _batterColor = value; RaisePropertyChanged("BatterColor"); }
        }

        private string _winnerColor { get; set; }
        public string WinnerColor
        {
            get { return _winnerColor; }
            set { _winnerColor = value; RaisePropertyChanged("WinnerColor"); }
        }

        private string _winnerMessage { get; set; }
        public string WinnerMessage
        {
            get { return _winnerMessage; }
            set { _winnerMessage = value; RaisePropertyChanged("WinnerMessage"); }
        }

        private string _winnerMessageVisibility { get; set; }
        public string WinnerMessageVisibility
        {
            get { return _winnerMessageVisibility; }
            set { _winnerMessageVisibility = value; RaisePropertyChanged("WinnerMessageVisibility"); }
        }

        private ObservableCollection<InfieldShiftType> _infieldShiftTypes { get; set; }
        public ObservableCollection<InfieldShiftType> InfieldShiftTypes 
        { 
            get { return _infieldShiftTypes; }
            set { _infieldShiftTypes = value; RaisePropertyChanged("InfieldShiftTypes");}
        }

        private ObservableCollection<OutfieldShiftType> _outfieldShiftTypes { get; set; }
        public ObservableCollection<OutfieldShiftType> OutfieldShiftTypes
        {
            get { return _outfieldShiftTypes; }
            set { _outfieldShiftTypes = value; RaisePropertyChanged("OutfieldShiftTypes"); }
        }

        private InfieldShiftType _selectedInfieldShiftType { get; set; }
        public InfieldShiftType SelectedInfieldShiftType
        {
            get { return _selectedInfieldShiftType; }
            set { _selectedInfieldShiftType = value; RaisePropertyChanged("SelectedInfieldShiftType"); }
        }

        private OutfieldShiftType _selectedOutfieldShiftType { get; set; }
        public OutfieldShiftType SelectedOutfieldShiftType
        {
            get { return _selectedOutfieldShiftType; }
            set { _selectedOutfieldShiftType = value; RaisePropertyChanged("SelectedOutfieldShiftType"); }
        }

        private int _batterGridColumn => HandednessHelperFunctions.DetermineBattingHandednessFromPitchingHandedness(AtPlateBatter.BattingHandedness, OnFieldPitcher.ThrowingHandedness)
            == Handedness.Left ? 2 : 1; 
        public int BatterGridColumn
        {
            get { return _batterGridColumn; }
        }

        private DelegateCommand _swingCommand { get; set; }
        public DelegateCommand SwingCommand
        {
            get { return _swingCommand; }
            set { _swingCommand = value; }
        }

        private DelegateCommand _stealSecondCommand { get; set; }
        public DelegateCommand StealSecondCommand
        {
            get { return _stealSecondCommand; }
            set { _stealSecondCommand = value; }
        }

        private DelegateCommand _stealThirdCommand { get; set; }
        public DelegateCommand StealThirdCommand
        {
            get { return _stealThirdCommand; }
            set { _stealThirdCommand = value; }
        }

        private DelegateCommand _stealHomeCommand { get; set; }
        public DelegateCommand StealHomeCommand
        {
            get { return _stealHomeCommand; }
            set { _stealHomeCommand = value; }
        }

        private DelegateCommand _hitAndRunCommand { get; set; }
        public DelegateCommand HitAndRunCommand
        {
            get { return _hitAndRunCommand; }
            set { _hitAndRunCommand = value; }
        }

        private DelegateCommand _sacrificeBuntCommand { get; set; }
        public DelegateCommand SacrificeBuntCommand
        {
            get { return _sacrificeBuntCommand; }
            set { _sacrificeBuntCommand = value; }
        }

        private DelegateCommand _buntForAHitCommand { get; set; }
        public DelegateCommand BuntForAHitCommand
        {
            get { return _buntForAHitCommand; }
            set { _buntForAHitCommand = value; }
        }

        private DelegateCommand _intentionalWalkCommand { get; set; }
        public DelegateCommand IntentionalWalkCommand
        {
            get { return _intentionalWalkCommand; }
            set { _intentionalWalkCommand = value; }
        }

        public ISingleGameService SingleGameService { get; set; }

        private ObservableCollection<PlayByPlayViewModel> _playByPlay { get; set; }
        public ObservableCollection<PlayByPlayViewModel> PlayByPlay
        {
            get { return _playByPlay; }
            set { _playByPlay = value; RaisePropertyChanged("PlayByPlay"); }
        }

        public SingleGameViewModel(ISingleGameService singleGameService, IEnumerable<ViewModelBase> viewModels)
        {
            SingleGameService = singleGameService;
            HomeTeam = (TeamViewModel)viewModels.First();
            AwayTeam = (TeamViewModel)viewModels.ElementAt(1);
            SwingCommand = new DelegateCommand(() => ProcessSwingResult(), IsGameNotOver);
            StealSecondCommand = new DelegateCommand(StealSecond, CanStealSecond);
            StealThirdCommand = new DelegateCommand(StealThird, CanStealThird);
            StealHomeCommand = new DelegateCommand(StealHome, CanStealHome);
            HitAndRunCommand = new DelegateCommand(HitAndRun, CanMoveRunner);
            SacrificeBuntCommand = new DelegateCommand(SacrificeBunt, CanMoveRunner);
            BuntForAHitCommand = new DelegateCommand(BuntForAHit);
            IntentionalWalkCommand = new DelegateCommand(ProcessIntentionalWalk, IsGameNotOver);
            PlayByPlay = new ObservableCollection<PlayByPlayViewModel>();
            FielderColor = "LightSalmon";
            BatterColor = "MediumPurple";
            WinnerMessageVisibility = "Hidden";
            GameOver = false;
            IsTopOfInning = true;
            Inning = 1;
            SetFieldingTeam();
            SelectedInfieldShiftType = InfieldShiftType.None;
            SelectedOutfieldShiftType = OutfieldShiftType.None;
            InfieldShiftTypes = new ObservableCollection<InfieldShiftType>((IEnumerable<InfieldShiftType>)Enum.GetValues(SelectedInfieldShiftType.GetType()));
            OutfieldShiftTypes = new ObservableCollection<OutfieldShiftType>((IEnumerable<OutfieldShiftType>)Enum.GetValues(SelectedOutfieldShiftType.GetType()));
        }

        public void UpdateAwayTeamLineup(TeamViewModel team)
        {
            AwayTeam.Lineup = team.Lineup;
            AwayTeam.Bench = team.Bench;
            SetFieldingTeam();
            SetRunners();
        }

        public void UpdateAwayTeamBullpen(TeamViewModel team)
        {
            AwayTeam.CurrentPitcher = team.CurrentPitcher;
            AwayTeam.Bullpen = team.Bullpen;
            if (IsTopOfInning == false)
            {
                OnFieldPitcher = team.CurrentPitcher;
            }
            SetFieldingTeam();
            RaisePropertyChanged("AwayTeamCurrentPitcher");
        }

        public void UpdateHomeTeamLineup(TeamViewModel team)
        {
            HomeTeam.Lineup = team.Lineup;
            HomeTeam.Bench = team.Bench;
            SetFieldingTeam();
            SetRunners();
        }

        public void UpdateHomeTeamBullpen(TeamViewModel team)
        {
            HomeTeam.CurrentPitcher = team.CurrentPitcher;
            HomeTeam.Bullpen = team.Bullpen;
            if (IsTopOfInning)
            {
                OnFieldPitcher = team.CurrentPitcher;
            }
            SetFieldingTeam();
            RaisePropertyChanged("HomeTeamCurrentPitcher");
        }

        public void ProcessSwingResult(bool hitAndRun = false)
        {
            var isPassedBall = SingleGameService.GetIsPassedBallResult(OnFieldCatcher.PlayerStint.FieldingStints.SingleOrDefault(f => f.Position == "C"));

            if (isPassedBall)
            {
                if (hitAndRun)
                {
                    AdvanceRunnersTwoBases(false);
                }
                else
                {
                    AdvanceRunnersOneBase(false);
                }
                InsertToPlayByPlay($"{OnFieldCatcher.LastName} allowed a passed ball");
            }
            else
            {
                var result = SingleGameService.GetBattingResult(AtPlateBatter.PlayerStint.BattingStint, OnFieldPitcher.PlayerStint.PitchingStint, OnFieldPitcher.CurrentGameIsTired);

                switch (result)
                {
                    case BattingResult.WildPitch:
                        if (hitAndRun)
                        {
                            AdvanceRunnersTwoBases(false);
                        }
                        else
                        {
                            AdvanceRunnersOneBase(false);
                        }
                        InsertToPlayByPlay($"{OnFieldPitcher.LastName} threw a wild pitch");
                        break;
                    case BattingResult.Balk:
                        AdvanceRunnersOneBase();
                        InsertToPlayByPlay($"{OnFieldPitcher.LastName} balked");
                        break;
                    case BattingResult.FieldedByPitcher:
                        ProcessFieldingResult(OnFieldPitcher, PositionType.Pitcher, hitAndRun);
                        break;
                    case BattingResult.FieldedByCatcher:
                        ProcessFieldingResult(OnFieldCatcher, PositionType.Catcher, hitAndRun);
                        break;
                    case BattingResult.FieldedByFirstBaseman:
                        ProcessFieldingResult(OnFieldFirstBaseman, PositionType.FirstBaseman, hitAndRun);
                        break;
                    case BattingResult.FieldedBySecondBaseman:
                        ProcessFieldingResult(OnFieldSecondBaseman, PositionType.SecondBaseman, hitAndRun);
                        break;
                    case BattingResult.FieldedByThirdBaseman:
                        ProcessFieldingResult(OnFieldThirdBaseman, PositionType.ThirdBaseman, hitAndRun);
                        break;
                    case BattingResult.FieldedByShortstop:
                        ProcessFieldingResult(OnFieldShortstop, PositionType.Shortstop, hitAndRun);
                        break;
                    case BattingResult.FieldedByLeftFielder:
                        ProcessFieldingResult(OnFieldLeftFielder, PositionType.LeftFielder, hitAndRun);
                        break;
                    case BattingResult.FieldedByCenterFielder:
                        ProcessFieldingResult(OnFieldCenterFielder, PositionType.CenterFielder, hitAndRun);
                        break;
                    case BattingResult.FieldedByRightFielder:
                        ProcessFieldingResult(OnFieldRightFielder, PositionType.RightFielder, hitAndRun);
                        break;
                    case BattingResult.Strikeout:
                        OnFieldPitcher.CurrentGameStrikeouts++;
                        ProcessBattedOut($"{AtPlateBatter.LastName} struckout");
                        if (hitAndRun && Outs > 0)
                        {
                            LeadRunnerSteal();
                        }
                        break;
                    case BattingResult.HitByPitch:
                        AdvanceForcedRunnersOneBase();
                        RunnerOnFirst = AtPlateBatter;
                        InsertToPlayByPlay($"{AtPlateBatter.LastName} was hit by a pitch");
                        SwitchBatter();
                        break;
                    case BattingResult.Walk:
                        AtPlateBatter.CurrentGameWalks++;
                        OnFieldPitcher.CurrentGameWalks++;
                        AdvanceForcedRunnersOneBase();
                        RunnerOnFirst = AtPlateBatter;
                        InsertToPlayByPlay($"{AtPlateBatter.LastName} walked");
                        SwitchBatter();
                        break;
                    case BattingResult.Single:
                        ProcessSingle(hitAndRun, false);
                        break;
                    case BattingResult.Single2Bases:
                        ProcessSingle(true);
                        break;
                    case BattingResult.Double:
                        ProcessDouble(hitAndRun);
                        break;
                    case BattingResult.Double3Bases:
                        ProcessDouble(true);
                        break;
                    case BattingResult.Triple:
                        ProcessTriple();
                        break;
                    case BattingResult.HomeRun:
                        ProcessHomerun();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"{result} is not a valid batting result.");
                }
            }
            UpdateRunnerBasedCommands();
        }

        private void ProcessFieldingResult(IPlayerViewModel fielder, PositionType positionType, bool hitAndRun = false)
        {
            var fieldingStint = fielder.PlayerStint.FieldingStints.SingleOrDefault(f => f.Position == PositionTypeHelperFunctions.PositionTypeToPositionAbbreviationString(positionType));
            if (fieldingStint == null && (positionType == PositionType.CenterFielder || positionType == PositionType.LeftFielder || positionType == PositionType.RightFielder))
            {
                fieldingStint = fielder.PlayerStint.FieldingStints.SingleOrDefault(f => f.Position == "OF");
            }

            var result = SingleGameService.GetFieldingResult(fieldingStint, positionType, SelectedInfieldShiftType, SelectedOutfieldShiftType);

            switch (result)
            {
                case FieldingResult.Flyout:
                    ProcessBattedOut($"{AtPlateBatter.LastName} flew out to the {positionType}");
                    break;
                case FieldingResult.FlyoutAllAdvance:
                    ProcessBattedOut($"{AtPlateBatter.LastName} flew out to the {positionType}");
                    AdvanceRunnersOneBase();
                    break;
                case FieldingResult.FlyoutSacrifice:
                    ProcessBattedOut($"{AtPlateBatter.LastName} flew out to the {positionType}");
                    AdvanceRunnerOnThird();
                    break;
                case FieldingResult.Foulout:
                    ProcessBattedOut($"{AtPlateBatter.LastName} fouled out to the {positionType}");
                    break;
                case FieldingResult.Groundout:
                    ProcessGroundout(positionType);
                    break;
                case FieldingResult.GroundoutAllAdvance:
                    ProcessBattedOut($"{AtPlateBatter.LastName} grounded out to the {positionType}");
                    AdvanceRunnersOneBase();
                    break;
                case FieldingResult.GroundoutDoublePlay:
                    if (hitAndRun)
                    {
                        ProcessBattedOut($"{AtPlateBatter.LastName} grounded out to the {positionType}");
                        AdvanceRunnersOneBase();
                    }
                    else
                    {
                        ProcessGroundoutDoublePlay(positionType);
                    }
                    break;
                case FieldingResult.GroundoutFieldersChoice:
                    if (hitAndRun)
                    {
                        ProcessBattedOut($"{AtPlateBatter.LastName} grounded out to the {positionType}");
                        AdvanceRunnersOneBase();
                    }
                    else
                    {
                        ProcessGroundoutLeadRunnerOut(positionType);
                    }
                    break;
                case FieldingResult.GroundoutFieldersChoiceForce:
                    if (hitAndRun)
                    {
                        ProcessBattedOut($"{AtPlateBatter.LastName} grounded out to the {positionType}");
                        AdvanceRunnersOneBase();
                    }
                    else
                    {
                        ProcessGroundoutLeadForceRunnerOut(positionType, true);
                    }
                    break;
                case FieldingResult.Lineout:
                    if (hitAndRun)
                    {
                        ProcessLineoutDoublePlay(positionType);
                    }
                    else
                    {
                        ProcessBattedOut($"{AtPlateBatter.LastName} lined out to the {positionType}");
                    }
                    break;
                case FieldingResult.LineoutDoublePlay:
                    ProcessLineoutDoublePlay(positionType);
                    break;
                case FieldingResult.LineoutMaxOuts:
                    ProcessLineoutMaxOuts(positionType);
                    break;
                case FieldingResult.Popout:
                    ProcessBattedOut($"{AtPlateBatter.LastName} popped out to the {positionType}");
                    break;
                case FieldingResult.Single:
                    ProcessSingle();
                    break;
                case FieldingResult.Double:
                    ProcessDouble();
                    break;
                case FieldingResult.Triple:
                    ProcessTriple();
                    break;
                case FieldingResult.Homerun:
                    ProcessHomerun();
                    break;
                case FieldingResult.OneBaseError:
                    // handle incrementing unearned runs
                    ProcessError(fielder, 1, hitAndRun);
                    break;
                case FieldingResult.TwoBaseError:
                    ProcessError(fielder, 2, hitAndRun);
                    break;
                case FieldingResult.ThreeBaseError:
                    ProcessError(fielder, 3, hitAndRun);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{result} is not a valid fielding result.");
            }
        }

        private void SwitchBatter()
        {
            if (IsTopOfInning)
            {
                AwayTeamLineupIndex++;
                AtPlateBatter = AwayTeam.Lineup.ElementAt(AwayTeamLineupIndex);
            }
            else
            {
                HomeTeamLineupIndex++;
                AtPlateBatter = HomeTeam.Lineup.ElementAt(HomeTeamLineupIndex);
            }
            RaisePropertyChanged("BatterGridColumn");
        }

        private void ProcessSingle(bool advanceExtraBase = false, bool bunt = false)
        {
            var message = bunt ? "hit a bunt single" : "singled";
            IncrementHits();
            if (advanceExtraBase)
            {
                AdvanceRunnersTwoBases();
            }
            else
            {
                AdvanceRunnersOneBase();
            }
            RunnerOnFirst = AtPlateBatter;
            InsertToPlayByPlay($"{AtPlateBatter.LastName} {message}");
            SwitchBatter();
        }

        private void ProcessDouble(bool advanceExtraBase = false)
        {
            IncrementHits();
            if (advanceExtraBase)
            {
                AdvanceRunnersThreeBases();
            }
            else
            {
                AdvanceRunnersTwoBases();
            }
            RunnerOnSecond = AtPlateBatter;
            InsertToPlayByPlay($"{AtPlateBatter.LastName} doubled");
            SwitchBatter();
        }

        private void ProcessTriple()
        {
            IncrementHits();
            AdvanceRunnersThreeBases();
            RunnerOnThird = AtPlateBatter;
            InsertToPlayByPlay($"{AtPlateBatter.LastName} tripled");
            SwitchBatter();
        }

        private void ProcessHomerun()
        {
            IncrementHits();
            AtPlateBatter.CurrentGameHomeRuns++;
            AdvanceRunnersThreeBases();
            ScoreRun(AtPlateBatter);
            InsertToPlayByPlay($"{AtPlateBatter.LastName} homered");
            SwitchBatter();
        }

        private void IncrementErrors(IPlayerViewModel player)
        {
            player.CurrentGameErrors++;
            AtPlateBatter.CurrentGameAtBats++;
            if (IsTopOfInning)
            {
                HomeTeamTotalErrors++;
                return;
            }
            AwayTeamTotalErrors++;
        }

        private void IncrementHits()
        {
            OnFieldPitcher.CurrentGameHits++;
            AtPlateBatter.CurrentGameHits++;
            AtPlateBatter.CurrentGameAtBats++;

            if (IsTopOfInning)
            {
                AwayTeamTotalHits++;
                return;
            }
            HomeTeamTotalHits++;
        }

        private void ProcessError(IPlayerViewModel fielder, int bases, bool runnersAdvanceExtraBase = false)
        {
            IncrementErrors(fielder);

            switch (bases)
            {
                case 1:
                    if (runnersAdvanceExtraBase)
                    {
                        AdvanceRunnersTwoBases(false);
                    }
                    else
                    {
                        AdvanceRunnersOneBase(false);
                    }
                    RunnerOnFirst = AtPlateBatter;
                    break;
                case 2:
                    if (runnersAdvanceExtraBase)
                    {
                        AdvanceRunnersThreeBases(false);
                    }
                    else
                    {
                        AdvanceRunnersTwoBases(false);
                    }
                    RunnerOnSecond = AtPlateBatter;
                    break;
                case 3:
                    AdvanceRunnersThreeBases(false);
                    RunnerOnThird = AtPlateBatter;
                    break;
                case 4:
                    AdvanceRunnersThreeBases(false);
                    ScoreRun(AtPlateBatter, false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{bases} is an invalid base count for errors");
            }

            SwitchBatter();
            InsertToPlayByPlay($"{fielder.LastName} made a {bases} base error");
        }

        private void ProcessIntentionalWalk()
        {
            AtPlateBatter.CurrentGameWalks++;
            AdvanceRunnersOneBase();
            RunnerOnFirst = AtPlateBatter;
            InsertToPlayByPlay($"{AtPlateBatter.LastName} was intentionally walked");
            SwitchBatter();
        }

        private void SetFieldingTeam()
        {
            var fieldingTeam = HomeTeam;
            var battingTeam = AwayTeam;
            var index = AwayTeamLineupIndex;
            if (IsTopOfInning)
            {
                FielderColor = "LightSalmon";
                BatterColor = "MediumPurple";
            }
            else
            {
                fieldingTeam = AwayTeam;
                battingTeam = HomeTeam;
                index = HomeTeamLineupIndex;
                FielderColor = "MediumPurple";
                BatterColor = "LightSalmon";
            }
            OnFieldPitcher = fieldingTeam.CurrentPitcher;
            OnFieldCatcher = fieldingTeam.Lineup.Single(l => l.CurrentGamePositionType == PositionType.Catcher);
            OnFieldFirstBaseman = fieldingTeam.Lineup.Single(l => l.CurrentGamePositionType == PositionType.FirstBaseman);
            OnFieldSecondBaseman = fieldingTeam.Lineup.Single(l => l.CurrentGamePositionType == PositionType.SecondBaseman);
            OnFieldThirdBaseman = fieldingTeam.Lineup.Single(l => l.CurrentGamePositionType == PositionType.ThirdBaseman);
            OnFieldShortstop = fieldingTeam.Lineup.Single(l => l.CurrentGamePositionType == PositionType.Shortstop);
            OnFieldLeftFielder = fieldingTeam.Lineup.Single(l => l.CurrentGamePositionType == PositionType.LeftFielder);
            OnFieldCenterFielder = fieldingTeam.Lineup.Single(l => l.CurrentGamePositionType == PositionType.CenterFielder);
            OnFieldRightFielder = fieldingTeam.Lineup.Single(l => l.CurrentGamePositionType == PositionType.RightFielder);
            AtPlateBatter = battingTeam.Lineup.ElementAt(index);
            RaisePropertyChanged("BatterGridColumn");
        }

        private void UpdateScoreboard()
        {
            RaisePropertyChanged("HomeTeamInning1RunsString");
            RaisePropertyChanged("HomeTeamInning2RunsString");
            RaisePropertyChanged("HomeTeamInning3RunsString");
            RaisePropertyChanged("HomeTeamInning4RunsString");
            RaisePropertyChanged("HomeTeamInning5RunsString");
            RaisePropertyChanged("HomeTeamInning6RunsString");
            RaisePropertyChanged("HomeTeamInning7RunsString");
            RaisePropertyChanged("HomeTeamInning8RunsString");
            RaisePropertyChanged("HomeTeamInning9RunsString");
            RaisePropertyChanged("HomeTeamInningExtraInningsRunsString");
            RaisePropertyChanged("AwayTeamInning1RunsString");
            RaisePropertyChanged("AwayTeamInning2RunsString");
            RaisePropertyChanged("AwayTeamInning3RunsString");
            RaisePropertyChanged("AwayTeamInning4RunsString");
            RaisePropertyChanged("AwayTeamInning5RunsString");
            RaisePropertyChanged("AwayTeamInning6RunsString");
            RaisePropertyChanged("AwayTeamInning7RunsString");
            RaisePropertyChanged("AwayTeamInning8RunsString");
            RaisePropertyChanged("AwayTeamInning9RunsString");
            RaisePropertyChanged("AwayTeamInningExtraInningsRunsString");
        }

        private void ProcessOut(string play, bool switchBatter = false)
        {
            OnFieldPitcher.CurrentGameInningsPitchedOuts++;
            if (switchBatter)
            {
                SwitchBatter();
            }
            Outs++;
            InsertToPlayByPlay(play);
            if (Outs == 3)
            {
                if (Inning >= 9)
                {
                    if (IsTopOfInning && HomeTeamTotalRuns > AwayTeamTotalRuns || (IsTopOfInning == false && AwayTeamTotalRuns > HomeTeamTotalRuns))
                    {
                        EndGame();
                        UpdateScoreboard();
                        return;
                    }
                }
                Outs = 0;
                if (IsTopOfInning == false)
                {
                    Inning++;
                }
                IsTopOfInning = !IsTopOfInning;
                UpdateScoreboard();
                SetFieldingTeam();
                RunnerOnFirst = null;
                RunnerOnSecond = null;
                RunnerOnThird = null;
                return;
            }
            UpdateRunnerBasedCommands();
        }

        private void ProcessBattedOut(string play, bool switchBatter = true)
        {
            AtPlateBatter.CurrentGameAtBats++;
            ProcessOut(play, switchBatter);
        }

        private void ProcessGroundout(PositionType positionType, bool bunt = false)
        {
            if (AreBasesLoaded())
            {
                ProcessGroundoutLeadForceRunnerOut(positionType, true, bunt);
            }
            if (bunt)
            {
                ProcessOut($"{AtPlateBatter.LastName} laid down a bunt", true);
            }
            else
            {
                ProcessBattedOut($"{AtPlateBatter.LastName} grounded to the {positionType}");
            }
            AdvanceForcedRunnersOneBase();
        }

        private void ProcessGroundoutLeadRunnerOut(PositionType positionType, bool bunt = false)
        {
            var message = bunt ? "laid down a bunt" : $"grounded to the {positionType}";
            if (Outs != 2)
            {
                if (RunnerOnThird != null)
                {
                    ProcessBattedOut($"{AtPlateBatter.LastName} {message}, {RunnerOnThird.LastName} was thrown out at home", false);
                    RunnerOnThird = null;
                    AdvanceRunnersOneBase();
                    RunnerOnFirst = AtPlateBatter;
                    SwitchBatter();
                    return;
                }
                if (RunnerOnSecond != null)
                {
                    ProcessBattedOut($"{AtPlateBatter.LastName} {message}, {RunnerOnSecond.LastName} was thrown out at third", false);
                    RunnerOnSecond = null;
                    AdvanceRunnersOneBase();
                    RunnerOnFirst = AtPlateBatter;
                    SwitchBatter();
                    return;
                }
                if (RunnerOnFirst != null)
                {
                    ProcessBattedOut($"{AtPlateBatter.LastName} {message}, {RunnerOnFirst.LastName} was thrown out at second", false);
                    RunnerOnFirst = AtPlateBatter;
                    SwitchBatter();
                    return;
                }
            }
            ProcessBattedOut($"{AtPlateBatter.LastName} {message}");
        }

        private void ProcessGroundoutLeadForceRunnerOut(PositionType positionType, bool advanceRunners = false, bool bunt = false)
        {
            var message = bunt ? "laid down a bunt" : $"grounded to the {positionType}";
            if (Outs == 2 || RunnerOnFirst == null)
            {
                ProcessBattedOut($"{AtPlateBatter.LastName} {message}");
                if (advanceRunners)
                {
                    AdvanceRunnersOneBase();
                }
                return;
            }
            else if (RunnerOnSecond == null)
            {
                ProcessBattedOut($"{AtPlateBatter.LastName} {message} forcing out {RunnerOnFirst.LastName} at second", false);
                RunnerOnFirst = null;
            }
            else if (RunnerOnThird == null)
            {
                ProcessBattedOut($"{AtPlateBatter.LastName} {message} forcing out {RunnerOnSecond.LastName} at third", false);
                RunnerOnSecond = null;
            }
            else
            {
                ProcessBattedOut($"{AtPlateBatter.LastName} {message} forcing out {RunnerOnThird.LastName} at home", false);
                RunnerOnThird = null;
            }

            if (advanceRunners)
            {
                AdvanceRunnersOneBase();
            }

            RunnerOnFirst = AtPlateBatter;
        }

        private void ProcessGroundoutDoublePlay(PositionType positionType, bool bunt = false)
        {
            if (Outs == 2)
            {
                ProcessBattedOut($"{AtPlateBatter.LastName} grounded out to the {positionType}");
            }
            else
            {
                if (SelectedInfieldShiftType == InfieldShiftType.InfieldIn || bunt)
                {
                    if (AreBasesLoaded())
                    {
                        var message = bunt ? $"laid down a bunt" : $"grounded out to the {positionType}";
                        ProcessBattedOut($"{AtPlateBatter.LastName} {message}");
                        ProcessOut($"{RunnerOnThird.LastName} was thrown out at home for a double play");
                        RunnerOnThird = null;
                        return;
                    }
                    ProcessBattedOut($"{AtPlateBatter.LastName} grounded out to the {positionType}");
                }
                else
                {
                    if (RunnerOnFirst != null)
                    {
                        ProcessBattedOut($"{AtPlateBatter.LastName} grounded out to the {positionType}");
                        ProcessOut($"{RunnerOnFirst.LastName} was thrown out at second for a double play");
                        RunnerOnFirst = null;
                    }
                    else
                    {
                        ProcessBattedOut($"{AtPlateBatter.LastName} grounded out to the {positionType}");
                    }
                    AdvanceRunnersOneBase();
                }
            }
        }

        private void ProcessLineoutDoublePlay(PositionType positionType)
        {
            ProcessBattedOut($"{AtPlateBatter.LastName} lined out to the {positionType}");

            if (RunnerOnThird != null)
            {
                ProcessOut($"{RunnerOnThird.LastName} was doubled off third");
            }
            else if (RunnerOnSecond != null)
            {
                ProcessOut($"{RunnerOnSecond.LastName} was doubled off second");
            }
            else if (RunnerOnFirst != null)
            {
                ProcessOut($"{RunnerOnFirst.LastName} was doubled off first");
            }
        }

        private void ProcessLineoutMaxOuts(PositionType positionType)
        {
            ProcessBattedOut($"{AtPlateBatter.LastName} lined out to the {positionType}");

            if (RunnerOnThird != null)
            {
                ProcessOut($"{RunnerOnThird.LastName} was doubled off third");
                if (RunnerOnSecond != null)
                {
                    ProcessOut($"{RunnerOnSecond.LastName} was also tagged out for a triple play!");
                }
                if (RunnerOnFirst != null)
                {
                    ProcessOut($"{RunnerOnFirst.LastName} was also tagged out for a triple play!");
                }
            }
            if (RunnerOnSecond != null)
            {
                ProcessOut($"{RunnerOnSecond.LastName} was doubled off second");
                if (RunnerOnFirst != null)
                {
                    ProcessOut($"{RunnerOnFirst.LastName} was also tagged out for a triple play!");
                }
            }
            if (RunnerOnFirst != null)
            {
                ProcessOut($"{RunnerOnFirst.LastName} was doubled off first");
            }
        }

        private void AdvanceForcedRunnersOneBase(bool rbi = true)
        {
            if (RunnerOnSecond != null && RunnerOnFirst != null)
            {
                AdvanceRunnersOneBase(true);
            }
            else if (RunnerOnFirst != null)
            {
                RunnerOnSecond = RunnerOnFirst;
                RunnerOnFirst = null;
            }
            UpdateRunnerBasedCommands();
        }

        private void AdvanceRunnerOnThird(bool rbi = true)
        {
            if (RunnerOnThird != null)
            {
                ScoreRun(RunnerOnThird, rbi);
            }
            RunnerOnThird = null;
            UpdateRunnerBasedCommands();
        }

        private void AdvanceRunnersOneBase(bool rbi = true)
        {
            if (RunnerOnThird != null)
            {
                ScoreRun(RunnerOnThird, rbi);
            }
            RunnerOnThird = RunnerOnSecond;
            RunnerOnSecond = RunnerOnFirst;
            RunnerOnFirst = null;
            UpdateRunnerBasedCommands();
        }

        private void AdvanceRunnersTwoBases(bool rbi = true)
        {
            if (RunnerOnThird != null)
            {
                ScoreRun(RunnerOnThird, rbi);
            }
            if (RunnerOnSecond != null)
            {
                ScoreRun(RunnerOnSecond, rbi);
                RunnerOnSecond = null;
            }
            RunnerOnThird = RunnerOnFirst;
            RunnerOnFirst = null;
            UpdateRunnerBasedCommands();
        }

        private void AdvanceRunnersThreeBases(bool rbi = true)
        {
            if (RunnerOnThird != null)
            {
                ScoreRun(RunnerOnThird, rbi);
                RunnerOnThird = null;
            }
            if (RunnerOnSecond != null)
            {
                ScoreRun(RunnerOnSecond, rbi);
                RunnerOnSecond = null;
            }
            if (RunnerOnFirst != null)
            {
                ScoreRun(RunnerOnFirst, rbi);
                RunnerOnFirst = null;
            }
            UpdateRunnerBasedCommands();
        }

        private void ScoreRun(BatterViewModel runner, bool rbi = true)
        {
            if (rbi)
            {
                AtPlateBatter.CurrentGameRunsBattedIn++;
            }
            OnFieldPitcher.CurrentGameRuns++;
            runner.CurrentGameRuns++;
            if (IsTopOfInning)
            {
                IncrementAwayTeamRuns();
            }
            else
            {
                IncrementHomeTeamRuns();
                if (Inning >= 9 && HomeTeamTotalRuns > AwayTeamTotalRuns)
                {
                    EndGame();
                }
            }
            InsertToPlayByPlay($"{runner.LastName} scored");
        }

        private void IncrementAwayTeamRuns()
        {
            AwayTeamTotalRuns++;

            switch (Inning)
            {
                case 1:
                    AwayTeamInning1Runs++;
                    return;
                case 2:
                    AwayTeamInning2Runs++;
                    return;
                case 3:
                    AwayTeamInning3Runs++;
                    return;
                case 4:
                    AwayTeamInning4Runs++;
                    return;
                case 5:
                    AwayTeamInning5Runs++;
                    return;
                case 6:
                    AwayTeamInning6Runs++;
                    return;
                case 7:
                    AwayTeamInning7Runs++;
                    return;
                case 8:
                    AwayTeamInning8Runs++;
                    return;
                case 9:
                    AwayTeamInning9Runs++;
                    return;
                default:
                    AwayTeamExtraInningsRuns++;
                    return;
            }
        }

        private void IncrementHomeTeamRuns()
        {
            HomeTeamTotalRuns++;

            switch (Inning)
            {
                case 1:
                    HomeTeamInning1Runs++;
                    return;
                case 2:
                    HomeTeamInning2Runs++;
                    return;
                case 3:
                    HomeTeamInning3Runs++;
                    return;
                case 4:
                    HomeTeamInning4Runs++;
                    return;
                case 5:
                    HomeTeamInning5Runs++;
                    return;
                case 6:
                    HomeTeamInning6Runs++;
                    return;
                case 7:
                    HomeTeamInning7Runs++;
                    return;
                case 8:
                    HomeTeamInning8Runs++;
                    return;
                case 9:
                    HomeTeamInning9Runs++;
                    return;
                default:
                    HomeTeamExtraInningsRuns++;
                    return;
            }
        }

        private void EndGame()
        {
            GameOver = true;
            if (HomeTeamTotalRuns > AwayTeamTotalRuns)
            {
                var message = $"{HomeTeam.TeamName} Win!";
                InsertToPlayByPlay(message);
                WinnerColor = "LightSalmon";
                WinnerMessage = message;
                WinnerMessageVisibility = "Visible";
            }
            else
            {
                var message = $"{AwayTeam.TeamName} Win!";
                InsertToPlayByPlay(message);
                WinnerColor = "MediumPurple";
                WinnerMessage = message;
                WinnerMessageVisibility = "Visible";
            }

            UpdateRunnerBasedCommands();
            IntentionalWalkCommand.RaiseCanExecuteChanged();
            SwingCommand.RaiseCanExecuteChanged();
        }

        private void UpdateRunnerBasedCommands()
        {
            _stealSecondCommand.RaiseCanExecuteChanged();
            _stealThirdCommand.RaiseCanExecuteChanged();
            _stealHomeCommand.RaiseCanExecuteChanged();
            _sacrificeBuntCommand.RaiseCanExecuteChanged();
            _hitAndRunCommand.RaiseCanExecuteChanged();
        }

        private void ProcessStealResult(BatterViewModel runner, BaseballBase baseballBase)
        {
            var isBaseStolen = SingleGameService.GetStealResult(runner.PlayerStint.BattingStint,
                OnFieldCatcher.PlayerStint.FieldingStints.SingleOrDefault(f => f.PositionType == PositionType.Catcher), baseballBase);

            if (isBaseStolen)
            {
                switch(baseballBase)
                {
                    case BaseballBase.Second:
                        RunnerOnFirst.StolenBases++;
                        InsertToPlayByPlay($"{RunnerOnFirst.LastName} stole second base");
                        break;
                    case BaseballBase.Third:
                        RunnerOnSecond.StolenBases++;
                        InsertToPlayByPlay($"{RunnerOnSecond.LastName} stole third base");
                        break;
                    case BaseballBase.Home:
                        RunnerOnThird.StolenBases++;
                        InsertToPlayByPlay($"{RunnerOnThird.LastName} stole home");
                        break;
                }
                AdvanceRunnersOneBase(false);
                return;
            }
            else
            {
                switch (baseballBase)
                {
                    case BaseballBase.Second:
                        ProcessOut($"{RunnerOnFirst.LastName} was caught stealing second base");
                        RunnerOnFirst = null;
                        break;
                    case BaseballBase.Third:
                        ProcessOut($"{RunnerOnSecond.LastName} was caught stealing third base");
                        RunnerOnSecond = null;
                        break;
                    case BaseballBase.Home:
                        ProcessOut($"{RunnerOnThird.LastName} was caught stealing home");
                        RunnerOnThird = null;
                        break;
                }
                AdvanceRunnersOneBase(false);
            }
            UpdateRunnerBasedCommands();
        }

        private void StealSecond()
        {
            ProcessStealResult(RunnerOnFirst, BaseballBase.Second);
        }

        private void StealThird()
        {
            ProcessStealResult(RunnerOnSecond, BaseballBase.Third);
        }

        private void StealHome()
        {
            ProcessStealResult(RunnerOnThird, BaseballBase.Home);
        }

        private void LeadRunnerSteal()
        {
            if (RunnerOnThird != null)
            {
                StealHome();
                return;
            }
            if (RunnerOnSecond != null)
            {
                StealThird();
                return;
            }
            if (RunnerOnFirst != null)
            {
                StealSecond();
                return;
            }
        }

        public void HitAndRun()
        {
            var hitAndRunResult = SingleGameService.GetHitAndRunResult(AtPlateBatter.PlayerStint.BattingStint);
            if (hitAndRunResult)
            {
                ProcessSwingResult(true);
                return;
            }
            LeadRunnerSteal();
        }

        public void SacrificeBunt()
        {
            var buntResult = SingleGameService.GetSacrificeBuntResult(AtPlateBatter.PlayerStint.BattingStint);
            ProcessBuntResult(buntResult);
        }

        public void BuntForAHit()
        {
            var buntResult = SingleGameService.GetBuntForAHitResult(AtPlateBatter.PlayerStint.BattingStint);
            ProcessBuntResult(buntResult);
        }

        private void ProcessBuntResult(FieldingResult buntResult)
        {
            switch (buntResult)
            {
                case FieldingResult.Single:
                    ProcessSingle(false, true);
                    break;
                case FieldingResult.GroundoutAllAdvance:
                    if (Outs != 2)
                    {
                        ProcessOut($"{AtPlateBatter.LastName} laid down a bunt", true);
                        AdvanceRunnersOneBase();
                        return;
                    }
                    ProcessBattedOut($"{AtPlateBatter.LastName} laid down a bunt");
                    break;
                case FieldingResult.Popout:
                    ProcessBattedOut($"{AtPlateBatter.LastName} popped out trying to bunt");
                    break;
                case FieldingResult.GroundoutFieldersChoice:
                    ProcessGroundoutLeadRunnerOut(PositionType.None, true);
                    break;
                case FieldingResult.Groundout:
                    ProcessGroundout(PositionType.None, true);
                    break;
                case FieldingResult.GroundoutDoublePlay:
                    ProcessGroundoutDoublePlay(PositionType.None, true);
                    break;
                case FieldingResult.Strikeout:
                    ProcessBattedOut($"{AtPlateBatter.LastName} struck out trying to bunt");
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{buntResult} is not a valid bunt result");
            }
        }

        private bool CanStealSecond()
        {
            return IsGameNotOver() && RunnerOnFirst != null;
        }

        private bool CanStealThird()
        {
            return IsGameNotOver() && RunnerOnSecond != null;
        }

        private bool CanStealHome()
        {
            return IsGameNotOver() && RunnerOnThird != null;
        }

        private bool IsGameNotOver()
        {
            return GameOver == false;
        }

        private bool CanMoveRunner()
        {
            return IsGameNotOver() && AreBasesEmpty() == false;
        }

        private bool AreBasesEmpty()
        {
            return RunnerOnFirst == null && RunnerOnSecond == null && RunnerOnThird == null;
        }

        private bool AreBasesLoaded()
        {
            return RunnerOnFirst != null && RunnerOnSecond != null && RunnerOnThird != null;
        }

        private void SetRunners()
        {
            var team = IsTopOfInning ? AwayTeam : HomeTeam;

            if (RunnerOnFirst != null)
            {
                RunnerOnFirst = team.Lineup.ElementAt(RunnerOnFirst.CurrentGameLineupIndex.Value);
            }
            if (RunnerOnSecond != null)
            {
                RunnerOnSecond = team.Lineup.ElementAt(RunnerOnSecond.CurrentGameLineupIndex.Value);
            }
            if (RunnerOnThird != null)
            {
                RunnerOnThird = team.Lineup.ElementAt(RunnerOnThird.CurrentGameLineupIndex.Value);
            }
        }

        private void InsertToPlayByPlay(string play)
        {
            PlayByPlay.Insert(0, new PlayByPlayViewModel(play, Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));

        }
    }
}
