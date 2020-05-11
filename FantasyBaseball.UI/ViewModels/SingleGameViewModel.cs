using FantasyBaseball.Business.Services;
using FantasyBaseball.Entities.Enums;
using GalaSoft.MvvmLight;
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
            set { _inning = value; RaisePropertyChanged("Inning"); }
        }

        public bool IsTopOfInning { get; set; }

        private int _awayTeamLineupIndex { get; set; }
        public int AwayTeamLineupIndex
        {
            get { return _awayTeamLineupIndex; }
            set
            {
                _awayTeamLineupIndex = value > 8 ? 0 : value;
            }
        }

        private int _homeTeamLineupIndex { get; set; }
        public int HomeTeamLineupIndex {
            get { return _homeTeamLineupIndex; } 
            set
            {
                _homeTeamLineupIndex = value > 8 ? 0 : value;
            } 
        }

        private int _awayTeamInning1Runs { get; set; }
        public int AwayTeamInning1Runs
        {
            get { return _awayTeamInning1Runs; }
            set { _awayTeamInning1Runs = value; RaisePropertyChanged("AwayTeamInning1Runs"); }
        }

        private int _awayTeamInning2Runs { get; set; }
        public int AwayTeamInning2Runs
        {
            get { return _awayTeamInning2Runs; }
            set { _awayTeamInning2Runs = value; RaisePropertyChanged("AwayTeamInning2Runs"); }
        }

        private int _awayTeamInning3Runs { get; set; }
        public int AwayTeamInning3Runs
        {
            get { return _awayTeamInning3Runs; }
            set { _awayTeamInning3Runs = value; RaisePropertyChanged("AwayTeamInning3Runs"); }
        }

        private int _awayTeamInning4Runs { get; set; }
        public int AwayTeamInning4Runs
        {
            get { return _awayTeamInning4Runs; }
            set { _awayTeamInning4Runs = value; RaisePropertyChanged("AwayTeamInning4Runs"); }
        }

        private int _awayTeamInning5Runs { get; set; }
        public int AwayTeamInning5Runs
        {
            get { return _awayTeamInning5Runs; }
            set { _awayTeamInning5Runs = value; RaisePropertyChanged("AwayTeamInning5Runs"); }
        }

        private int _awayTeamInning6Runs { get; set; }
        public int AwayTeamInning6Runs
        {
            get { return _awayTeamInning6Runs; }
            set { _awayTeamInning6Runs = value; RaisePropertyChanged("AwayTeamInning6Runs"); }
        }

        private int _awayTeamInning7Runs { get; set; }
        public int AwayTeamInning7Runs
        {
            get { return _awayTeamInning7Runs; }
            set { _awayTeamInning7Runs = value; RaisePropertyChanged("AwayTeamInning7Runs"); }
        }

        private int _awayTeamInning8Runs { get; set; }
        public int AwayTeamInning8Runs
        {
            get { return _awayTeamInning8Runs; }
            set { _awayTeamInning8Runs = value; RaisePropertyChanged("AwayTeamInning8Runs"); }
        }

        private int _awayTeamInning9Runs { get; set; }
        public int AwayTeamInning9Runs
        {
            get { return _awayTeamInning9Runs; }
            set { _awayTeamInning9Runs = value; RaisePropertyChanged("AwayTeamInning9Runs"); }
        }

        private int _awayTeamExtraInningsRuns { get; set; }
        public int AwayTeamExtraInningsRuns
        {
            get { return _awayTeamExtraInningsRuns; }
            set { _awayTeamExtraInningsRuns = value; RaisePropertyChanged("AwayTeamExtraInningsRuns"); }
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
            set { _homeTeamInning1Runs = value; RaisePropertyChanged("HomeTeamInning1Runs"); }
        }

        private int _homeTeamInning2Runs { get; set; }
        public int HomeTeamInning2Runs
        {
            get { return _homeTeamInning2Runs; }
            set { _homeTeamInning2Runs = value; RaisePropertyChanged("HomeTeamInning2Runs"); }
        }

        private int _homeTeamInning3Runs { get; set; }
        public int HomeTeamInning3Runs
        {
            get { return _homeTeamInning3Runs; }
            set { _homeTeamInning3Runs = value; RaisePropertyChanged("HomeTeamInning3Runs"); }
        }

        private int _homeTeamInning4Runs { get; set; }
        public int HomeTeamInning4Runs
        {
            get { return _homeTeamInning4Runs; }
            set { _homeTeamInning4Runs = value; RaisePropertyChanged("HomeTeamInning4Runs"); }
        }

        private int _homeTeamInning5Runs { get; set; }
        public int HomeTeamInning5Runs
        {
            get { return _homeTeamInning5Runs; }
            set { _homeTeamInning5Runs = value; RaisePropertyChanged("HomeTeamInning5Runs"); }
        }

        private int _homeTeamInning6Runs { get; set; }
        public int HomeTeamInning6Runs
        {
            get { return _homeTeamInning6Runs; }
            set { _homeTeamInning6Runs = value; RaisePropertyChanged("HomeTeamInning6Runs"); }
        }

        private int _homeTeamInning7Runs { get; set; }
        public int HomeTeamInning7Runs
        {
            get { return _homeTeamInning7Runs; }
            set { _homeTeamInning7Runs = value; RaisePropertyChanged("HomeTeamInning7Runs"); }
        }

        private int _homeTeamInning8Runs { get; set; }
        public int HomeTeamInning8Runs
        {
            get { return _homeTeamInning8Runs; }
            set { _homeTeamInning8Runs = value; RaisePropertyChanged("HomeTeamInning8Runs"); }
        }

        private int _homeTeamInning9Runs { get; set; }
        public int HomeTeamInning9Runs
        {
            get { return _homeTeamInning9Runs; }
            set { _homeTeamInning9Runs = value; RaisePropertyChanged("HomeTeamInning9Runs"); }
        }

        private int _homeTeamExtraInningsRuns { get; set; }
        public int HomeTeamExtraInningsRuns
        {
            get { return _homeTeamExtraInningsRuns; }
            set { _homeTeamExtraInningsRuns = value; RaisePropertyChanged("HomeTeamExtraInningsRuns"); }
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

        private DelegateCommand _swingCommand { get; set; }
        public DelegateCommand SwingCommand
        {
            get { return _swingCommand; }
            set { _swingCommand = value; }
        }

        private DelegateCommand _stealCommand { get; set; }
        public DelegateCommand StealCommand
        {
            get { return _stealCommand; }
            set { _stealCommand = value; }
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
            SwingCommand = new DelegateCommand(ProcessSwingResult, IsGameNotOver);
            StealCommand = new DelegateCommand(GetStealResult, CanSteal);
            IntentionalWalkCommand = new DelegateCommand(ProcessIntentionalWalk, IsGameNotOver);
            PlayByPlay = new ObservableCollection<PlayByPlayViewModel>();
            FielderColor = "LightSalmon";
            BatterColor = "MediumPurple";
            GameOver = false;
            IsTopOfInning = true;
            SetFieldingTeam();
        }

        public void ProcessSwingResult()
        {
            var isPassedBall = SingleGameService.GetIsPassedBallResult(OnFieldCatcher.PlayerStint.FieldingStints.SingleOrDefault(f => f.PositionType == PositionType.Catcher));

            if (isPassedBall)
            {
                PlayByPlay.Add(new PlayByPlayViewModel($"{OnFieldCatcher.LastName} allowed a passed ball", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
                AdvanceRunnersOneBase(false);
                return;
            }

            var result = SingleGameService.GetBattingResult(AtPlateBatter.PlayerStint.BattingStint, OnFieldPitcher.PlayerStint.PitchingStint);
            
            switch (result)
            {
                case BattingResult.WildPitch:
                    PlayByPlay.Add(new PlayByPlayViewModel($"{OnFieldPitcher.LastName} threw a wild pitch", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
                    AdvanceRunnersOneBase();
                    return;
                case BattingResult.Balk:
                    PlayByPlay.Add(new PlayByPlayViewModel($"{OnFieldPitcher.LastName} balked", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
                    AdvanceRunnersOneBase();
                    return;
                case BattingResult.FieldedByPitcher:
                    ProcessFieldingResult(OnFieldPitcher, PositionType.Pitcher);
                    break;
                case BattingResult.FieldedByCatcher:
                    ProcessFieldingResult(OnFieldCatcher, PositionType.Catcher);
                    break;
                case BattingResult.FieldedByFirstBaseman:
                    ProcessFieldingResult(OnFieldFirstBaseman, PositionType.FirstBaseman);
                    break;
                case BattingResult.FieldedBySecondBaseman:
                    ProcessFieldingResult(OnFieldSecondBaseman, PositionType.SecondBaseman);
                    break;
                case BattingResult.FieldedByThirdBaseman:
                    ProcessFieldingResult(OnFieldThirdBaseman, PositionType.ThirdBaseman);
                    break;
                case BattingResult.FieldedByShortstop:
                    ProcessFieldingResult(OnFieldShortstop, PositionType.Shortstop);
                    break;
                case BattingResult.FieldedByLeftFielder:
                    ProcessFieldingResult(OnFieldLeftFielder, PositionType.LeftFielder);
                    break;
                case BattingResult.FieldedByCenterFielder:
                    ProcessFieldingResult(OnFieldCenterFielder, PositionType.CenterFielder);
                    break;
                case BattingResult.FieldedByRightFielder:
                    ProcessFieldingResult(OnFieldRightFielder, PositionType.RightFielder);
                    break;
                case BattingResult.Strikeout:
                    PlayByPlay.Add(new PlayByPlayViewModel($"{AtPlateBatter.LastName} struckout", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
                    OnFieldPitcher.CurrentGameStrikeouts++;
                    AtPlateBatter.CurrentGameAtBats++;
                    ProcessOut();
                    break;
                case BattingResult.HitByPitch:
                    PlayByPlay.Add(new PlayByPlayViewModel($"{AtPlateBatter.LastName} was hit by a pitch", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
                    AdvanceRunnersOneBase();
                    RunnerOnFirst = AtPlateBatter;
                    break;
                case BattingResult.Walk:
                    PlayByPlay.Add(new PlayByPlayViewModel($"{AtPlateBatter.LastName} walked", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
                    AtPlateBatter.CurrentGameWalks++;
                    OnFieldPitcher.CurrentGameWalks++;
                    AdvanceRunnersOneBase();
                    RunnerOnFirst = AtPlateBatter;
                    break;
                case BattingResult.Single:
                    ProcessSingle();
                    break;
                case BattingResult.Double:
                    ProcessDouble();
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

            StealCommand.RaiseCanExecuteChanged();
            SwitchBatter();
        }

        private void SwitchBatter()
        {
            if (IsTopOfInning)
            {
                AwayTeamLineupIndex++;
                AtPlateBatter = AwayTeam.Lineup.ElementAt(AwayTeamLineupIndex);
                return;
            }
            HomeTeamLineupIndex++;
            AtPlateBatter = HomeTeam.Lineup.ElementAt(HomeTeamLineupIndex);
            return;
        }

        private void ProcessSingle()
        {
            PlayByPlay.Add(new PlayByPlayViewModel($"{AtPlateBatter.LastName} singled", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
            IncrementHits();
            AdvanceRunnersOneBase();
            RunnerOnFirst = AtPlateBatter;
        }

        private void ProcessDouble()
        {
            PlayByPlay.Add(new PlayByPlayViewModel($"{AtPlateBatter.LastName} doubled", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
            IncrementHits();
            AdvanceRunnersTwoBases();
            RunnerOnSecond = AtPlateBatter;
        }

        private void ProcessTriple()
        {
            PlayByPlay.Add(new PlayByPlayViewModel($"{AtPlateBatter.LastName} tripled", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
            IncrementHits();
            AdvanceRunnersThreeBase();
            RunnerOnThird = AtPlateBatter;
        }

        private void ProcessHomerun()
        {
            PlayByPlay.Add(new PlayByPlayViewModel($"{AtPlateBatter.LastName} homered", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
            IncrementHits();
            AtPlateBatter.CurrentGameHomeRuns++;
            AdvanceRunnersThreeBase();
            ScoreRun(AtPlateBatter);
        }

        private void IncrementErrors()
        {
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

        private void ProcessFieldingResult(IPlayerViewModel fielder, PositionType positionType)
        {
            var result = SingleGameService.GetFieldingResult(fielder.PlayerStint.FieldingStints.SingleOrDefault(f => f.PositionType == positionType), positionType);
            
            switch(result)
            {
                case FieldingResult.Flyout:
                    PlayByPlay.Add(new PlayByPlayViewModel($"{AtPlateBatter.LastName} flew out to the {positionType}", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
                    ProcessOut();
                    break;
                case FieldingResult.Foulout:
                    PlayByPlay.Add(new PlayByPlayViewModel($"{AtPlateBatter.LastName} fouled out to the {positionType}", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
                    ProcessOut();
                    break;
                case FieldingResult.Groundout:
                    PlayByPlay.Add(new PlayByPlayViewModel($"{AtPlateBatter.LastName} grounded out to the {positionType}", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
                    ProcessOut();
                    break;
                case FieldingResult.Lineout:
                    PlayByPlay.Add(new PlayByPlayViewModel($"{AtPlateBatter.LastName} lined out to the {positionType}", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
                    ProcessOut();
                    break;
                case FieldingResult.Popout:
                    PlayByPlay.Add(new PlayByPlayViewModel($"{AtPlateBatter.LastName} popped out to the {positionType}", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
                    ProcessOut();
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
                    // handle incrementing fielder errors and unearned runs
                    PlayByPlay.Add(new PlayByPlayViewModel($"{fielder.LastName} made a one base error", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
                    IncrementErrors();
                    AdvanceRunnersOneBase(false);
                    break;
                case FieldingResult.TwoBaseError:
                    PlayByPlay.Add(new PlayByPlayViewModel($"{fielder.LastName} made a two base error", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
                    IncrementErrors();
                    AdvanceRunnersOneBase(false);
                    break;
                case FieldingResult.ThreeBaseError:
                    PlayByPlay.Add(new PlayByPlayViewModel($"{fielder.LastName} made a three base error", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
                    IncrementErrors();
                    AdvanceRunnersOneBase(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{result} is not a valid fielding result.");
            }
            StealCommand.RaiseCanExecuteChanged();
        }

        private void ProcessIntentionalWalk()
        {
            PlayByPlay.Add(new PlayByPlayViewModel($"{AtPlateBatter.LastName} was intentionally walked", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
            AtPlateBatter.CurrentGameWalks++;
            AdvanceRunnersOneBase();
            RunnerOnFirst = AtPlateBatter;
        }

        private void SetFieldingTeam()
        {
            var fieldingTeam = HomeTeam;
            var battingTeam = AwayTeam;
            if (IsTopOfInning)
            {
                FielderColor = "LightSalmon";
                BatterColor = "MediumPurple";
            }
            else
            {
                fieldingTeam = AwayTeam;
                battingTeam = HomeTeam;
                FielderColor = "MediumPurple";
                BatterColor = "LightSalmon";
            }
            OnFieldPitcher = fieldingTeam.CurrentPitcher;
            OnFieldCatcher = fieldingTeam.Lineup.Single(l => l.CurrentGamePositionType == PositionType.Catcher);
            OnFieldFirstBaseman = fieldingTeam.Lineup.Single(l => l.CurrentGamePositionType == PositionType.FirstBaseman);
            OnFieldSecondBaseman = fieldingTeam.Lineup.Single(l => l.CurrentGamePositionType == PositionType.ThirdBaseman);
            OnFieldThirdBaseman = fieldingTeam.Lineup.Single(l => l.CurrentGamePositionType == PositionType.SecondBaseman);
            OnFieldShortstop = fieldingTeam.Lineup.Single(l => l.CurrentGamePositionType == PositionType.Shortstop);
            OnFieldLeftFielder = fieldingTeam.Lineup.Single(l => l.CurrentGamePositionType == PositionType.LeftFielder);
            OnFieldCenterFielder = fieldingTeam.Lineup.Single(l => l.CurrentGamePositionType == PositionType.CenterFielder);
            OnFieldRightFielder = fieldingTeam.Lineup.Single(l => l.CurrentGamePositionType == PositionType.RightFielder);
            AtPlateBatter = battingTeam.Lineup.ElementAt(0);
        }

        private void ProcessOut()
        {
            OnFieldPitcher.CurrentGameInningsPitchedOuts++;
            if (Outs == 2)
            {
                if (Inning >= 9)
                {
                    if (IsTopOfInning && HomeTeamTotalRuns > AwayTeamTotalRuns || (IsTopOfInning == false && AwayTeamTotalRuns > HomeTeamTotalRuns))
                    {
                        EndGame();
                        return;
                    }
                }
                Outs = 0;
                Inning++;
                IsTopOfInning = !IsTopOfInning;
                SetFieldingTeam();
                RunnerOnFirst = null;
                RunnerOnSecond = null;
                RunnerOnThird = null;
                return;
            }
            Outs++;
            StealCommand.RaiseCanExecuteChanged();
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
            StealCommand.RaiseCanExecuteChanged();
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
            StealCommand.RaiseCanExecuteChanged();
        }

        private void AdvanceRunnersThreeBase(bool rbi = true)
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
            StealCommand.RaiseCanExecuteChanged();
        }

        private void ScoreRun(BatterViewModel runner, bool rbi = true)
        {
            if (rbi)
            {
                AtPlateBatter.CurrentGameRunsBattedIn++;
            }
            OnFieldPitcher.CurrentGameRuns++;
            runner.CurrentGameRuns++;
            PlayByPlay.Add(new PlayByPlayViewModel($"{runner.LastName} scored", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
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

        private void RemoveLeadRunner()
        {
            if (RunnerOnThird != null)
            {
                RunnerOnThird = null;
                return;
            }
            if (RunnerOnSecond != null)
            {
                RunnerOnSecond = null;
                return;
            }
            if (RunnerOnFirst != null)
            {
                RunnerOnFirst = null;
                return;
            }
        }

        private BatterViewModel GetLeadRunner()
        {
            if (RunnerOnThird != null)
            {
                return RunnerOnThird;
            }
            if (RunnerOnSecond != null)
            {
                return RunnerOnSecond;
            }
            if (RunnerOnFirst != null)
            {
                return RunnerOnFirst;
            }
            return null;
        }

        public void GetStealResult()
        {
            var leadRunner = GetLeadRunner();
            // implement harder difficulty for different bases
            var result = SingleGameService.GetStealResult(leadRunner.PlayerStint.BattingStint, 
                OnFieldCatcher.PlayerStint.FieldingStints.SingleOrDefault(f => f.PositionType == PositionType.Catcher));
            
            if (result)
            {
                PlayByPlay.Add(new PlayByPlayViewModel($"{leadRunner.LastName} stole a base", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
                AdvanceRunnersOneBase(false);
                return;
            }
            else
            {
                PlayByPlay.Add(new PlayByPlayViewModel($"{leadRunner.LastName} was caught stealing", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
                RemoveLeadRunner();
                ProcessOut();
                AdvanceRunnersOneBase(false);               
            }
        }

        private void EndGame()
        {
            GameOver = true;
            if (HomeTeamTotalRuns > AwayTeamTotalRuns)
            {
                PlayByPlay.Add(new PlayByPlayViewModel($"{HomeTeam.TeamName} Win!", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
            }
            else
            {
                PlayByPlay.Add(new PlayByPlayViewModel($"{AwayTeam.TeamName} Win!", Inning, Outs, $"{AwayTeamTotalRuns} - {HomeTeamTotalRuns}"));
            }

            StealCommand.RaiseCanExecuteChanged();
            IntentionalWalkCommand.RaiseCanExecuteChanged();
            SwingCommand.RaiseCanExecuteChanged();
        }

        public bool CanSteal()
        {
            return IsGameNotOver() && (RunnerOnFirst != null || RunnerOnSecond != null || RunnerOnThird != null);
        }

        private bool IsGameNotOver()
        {
            return GameOver == false;
        }

        public void UpdateAwayTeamLineup(TeamViewModel team)
        {
            AwayTeam.Lineup = team.Lineup;
            AwayTeam.Bench = team.Bench;
        }

        public void UpdateAwayTeamBullpen(TeamViewModel team)
        {
            AwayTeam.CurrentPitcher = team.CurrentPitcher;
            AwayTeam.Bullpen = team.Bullpen;
        }

        public void UpdateHomeTeamLineup(TeamViewModel team)
        {
            HomeTeam.Lineup = team.Lineup;
            HomeTeam.Bench = team.Bench;
        }

        public void UpdateHomeTeamBullpen(TeamViewModel team)
        {
            HomeTeam.CurrentPitcher = team.CurrentPitcher;
            HomeTeam.Bullpen = team.Bullpen;
        }
    }
}
