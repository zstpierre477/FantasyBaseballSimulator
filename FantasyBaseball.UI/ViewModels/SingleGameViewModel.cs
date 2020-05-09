using FantasyBaseball.Business.Services;
using FantasyBaseball.Entities.Enums;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

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

        public BatterViewModel RunnerOnFirst { get; set; }

        public BatterViewModel RunnerOnSecond { get; set; }

        public BatterViewModel RunnerOnThird { get; set; }

        public string CurrentPitcherStatus => OnFieldPitcher.CurrentGameIsTired ? "Tired" : "Healthy";

        public int Outs { get; set; }

        public int Inning { get; set; }

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

        public int AwayTeamInning1Runs { get; set; }

        public int AwayTeamInning2Runs { get; set; }

        public int AwayTeamInning3Runs { get; set; }

        public int AwayTeamInning4Runs { get; set; }

        public int AwayTeamInning5Runs { get; set; }

        public int AwayTeamInning6Runs { get; set; }

        public int AwayTeamInning7Runs { get; set; }

        public int AwayTeamInning8Runs { get; set; }

        public int AwayTeamInning9Runs { get; set; }

        public int AwayTeamExtraInningsRuns { get; set; }

        public int AwayTeamTotalRuns { get; set; }

        public int AwayTeamTotalHits { get; set; }

        public int AwayTeamTotalErrors { get; set; }

        public int HomeTeamInning1Runs { get; set; }

        public int HomeTeamInning2Runs { get; set; }

        public int HomeTeamInning3Runs { get; set; }

        public int HomeTeamInning4Runs { get; set; }

        public int HomeTeamInning5Runs { get; set; }

        public int HomeTeamInning6Runs { get; set; }

        public int HomeTeamInning7Runs { get; set; }

        public int HomeTeamInning8Runs { get; set; }

        public int HomeTeamInning9Runs { get; set; }

        public int HomeTeamExtraInningsRuns { get; set; }

        public int HomeTeamTotalRuns { get; set; }

        public int HomeTeamTotalHits { get; set; }

        public int HomeTeamTotalErrors { get; set; }

        public bool GameOver { get; set; }

        public string FielderColor { get; set; }

        public string BatterColor { get; set; }

        public ICommand SwingCommand { get; set; }

        public ICommand StealCommand { get; set; }

        public ICommand IntentionalWalkCommand { get; set; }

        public ISingleGameService SingleGameService { get; set; }

        public ObservableCollection<string> PlayByPlay { get; set; }

        public SingleGameViewModel(ISingleGameService singleGameService, IEnumerable<ViewModelBase> viewModels)
        {
            SingleGameService = singleGameService;
            HomeTeam = (TeamViewModel)viewModels.First();
            AwayTeam = (TeamViewModel)viewModels.ElementAt(1);
            SwingCommand = new RelayCommand(ProcessSwingResult, IsGameNotOver);
            StealCommand = new RelayCommand(GetStealResult, CanSteal);
            IntentionalWalkCommand = new RelayCommand(ProcessIntentionalWalk, IsGameNotOver);
            PlayByPlay = new ObservableCollection<string>();
            FielderColor = "LightSalmon";
            BatterColor = "MediumPurple";
            GameOver = false;
            IsTopOfInning = true;
            OnFieldPitcher = HomeTeam.CurrentPitcher;
            OnFieldCatcher = HomeTeam.Catcher;
            OnFieldFirstBaseman = HomeTeam.FirstBaseman;
            OnFieldSecondBaseman = HomeTeam.SecondBaseman;
            OnFieldThirdBaseman = HomeTeam.ThirdBaseman;
            OnFieldShortstop = HomeTeam.Shortstop;
            OnFieldLeftFielder = HomeTeam.LeftFielder;
            OnFieldCenterFielder = HomeTeam.CenterFielder;
            OnFieldRightFielder = HomeTeam.RightFielder;
            AtPlateBatter = AwayTeam.Lineup.ElementAt(0);
        }

        public void ProcessSwingResult()
        {
            var isPassedBall = SingleGameService.GetIsPassedBallResult(OnFieldCatcher.PlayerStint.FieldingStints.SingleOrDefault(f => f.PositionType == PositionType.Catcher));

            if (isPassedBall)
            {
                PlayByPlay.Add($"{OnFieldCatcher.LastName} allowed a passed ball");
                AdvanceRunnersOneBase(false);
                return;
            }

            var result = SingleGameService.GetBattingResult(AtPlateBatter.PlayerStint.BattingStint, OnFieldPitcher.PlayerStint.PitchingStint);
            
            switch (result)
            {
                case BattingResult.WildPitch:
                    PlayByPlay.Add($"{OnFieldPitcher.LastName} threw a wild pitch");
                    AdvanceRunnersOneBase();
                    break;
                case BattingResult.Balk:
                    PlayByPlay.Add($"{OnFieldPitcher.LastName} balked");
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
                    PlayByPlay.Add($"{AtPlateBatter.LastName} struckout");
                    OnFieldPitcher.CurrentGameStrikeouts++;
                    AtPlateBatter.CurrentGameAtBats++;
                    ProcessOut();
                    break;
                case BattingResult.HitByPitch:
                    PlayByPlay.Add($"{AtPlateBatter.LastName} was hit by a pitch");
                    AdvanceRunnersOneBase();
                    RunnerOnFirst = AtPlateBatter;
                    break;
                case BattingResult.Walk:
                    PlayByPlay.Add($"{AtPlateBatter.LastName} walked");
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
            PlayByPlay.Add($"{AtPlateBatter.LastName} singled");
            IncrementHits();
            AdvanceRunnersOneBase();
            RunnerOnFirst = AtPlateBatter;
        }

        private void ProcessDouble()
        {
            PlayByPlay.Add($"{AtPlateBatter.LastName} doubled");
            IncrementHits();
            AdvanceRunnersTwoBases();
            RunnerOnSecond = AtPlateBatter;
        }

        private void ProcessTriple()
        {
            PlayByPlay.Add($"{AtPlateBatter.LastName} tripled");
            IncrementHits();
            AdvanceRunnersThreeBase();
            RunnerOnThird = AtPlateBatter;
        }

        private void ProcessHomerun()
        {
            PlayByPlay.Add($"{AtPlateBatter.LastName} homered");
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
                    PlayByPlay.Add($"{AtPlateBatter.LastName} flew out to the {positionType}");
                    ProcessOut();
                    break;
                case FieldingResult.Foulout:
                    PlayByPlay.Add($"{AtPlateBatter.LastName} fouled out to the {positionType}");
                    ProcessOut();
                    break;
                case FieldingResult.Groundout:
                    PlayByPlay.Add($"{AtPlateBatter.LastName} grounded out to the {positionType}");
                    ProcessOut();
                    break;
                case FieldingResult.Lineout:
                    PlayByPlay.Add($"{AtPlateBatter.LastName} lined out to the {positionType}");
                    ProcessOut();
                    break;
                case FieldingResult.Popout:
                    PlayByPlay.Add($"{AtPlateBatter.LastName} popped out to the {positionType}");
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
                    PlayByPlay.Add($"{fielder.LastName} made a one base error");
                    IncrementErrors();
                    AdvanceRunnersOneBase(false);
                    break;
                case FieldingResult.TwoBaseError:
                    PlayByPlay.Add($"{fielder.LastName} made a two base error");
                    IncrementErrors();
                    AdvanceRunnersOneBase(false);
                    break;
                case FieldingResult.ThreeBaseError:
                    PlayByPlay.Add($"{fielder.LastName} made a three base error");
                    IncrementErrors();
                    AdvanceRunnersOneBase(false);
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{result} is not a valid fielding result.");
            }
        }

        private void ProcessIntentionalWalk()
        {
            PlayByPlay.Add($"{AtPlateBatter.LastName} was intentionally walked");
            AtPlateBatter.CurrentGameWalks++;
            AdvanceRunnersOneBase();
            RunnerOnFirst = AtPlateBatter;
        }

        private void SwitchFieldingTeam()
        {
            if (IsTopOfInning)
            {
                SwitchToHomeTeamFielding();
                return;
            }
            SwitchToAwayTeamFielding();
        }

        private void SwitchToHomeTeamFielding()
        {
            FielderColor = "LightSalmon";
            BatterColor = "MediumPurple";
            OnFieldPitcher = HomeTeam.CurrentPitcher;
            OnFieldCatcher = HomeTeam.Catcher;
            OnFieldFirstBaseman = HomeTeam.FirstBaseman;
            OnFieldSecondBaseman = HomeTeam.SecondBaseman;
            OnFieldThirdBaseman = HomeTeam.ThirdBaseman;
            OnFieldShortstop = HomeTeam.Shortstop;
            OnFieldLeftFielder = HomeTeam.LeftFielder;
            OnFieldCenterFielder = HomeTeam.CenterFielder;
            OnFieldRightFielder = HomeTeam.RightFielder;
        }

        private void SwitchToAwayTeamFielding()
        {
            FielderColor = "MediumPurple";
            BatterColor = "LightSalmon";
            OnFieldPitcher = AwayTeam.CurrentPitcher;
            OnFieldCatcher = AwayTeam.Catcher;
            OnFieldFirstBaseman = AwayTeam.FirstBaseman;
            OnFieldSecondBaseman = AwayTeam.SecondBaseman;
            OnFieldThirdBaseman = AwayTeam.ThirdBaseman;
            OnFieldShortstop = AwayTeam.Shortstop;
            OnFieldLeftFielder = AwayTeam.LeftFielder;
            OnFieldCenterFielder = AwayTeam.CenterFielder;
            OnFieldRightFielder = AwayTeam.RightFielder;
        }

        private void ProcessOut()
        {
            var ip = (OnFieldPitcher.CurrentGameInningsPitched + (1.0 / 3.0))*3;
            double i = Math.Round(ip, MidpointRounding.AwayFromZero);
            OnFieldPitcher.CurrentGameInningsPitched = i/3;
            if (Outs == 2)
            {
                if (Inning >= 9)
                {
                    if (IsTopOfInning && HomeTeamTotalRuns > AwayTeamTotalRuns)
                    {
                        PlayByPlay.Add($"{HomeTeam.TeamName} Win {HomeTeamTotalRuns} to {AwayTeamTotalRuns}!");
                        GameOver = true;
                        return;
                    }
                    if (IsTopOfInning == false && AwayTeamTotalRuns > HomeTeamTotalRuns)
                    {
                        PlayByPlay.Add($"{AwayTeam.TeamName} Win {AwayTeamTotalRuns} to {HomeTeamTotalRuns}!");
                        GameOver = true;
                        return;
                    }
                }
                Outs = 0;
                Inning++;
                IsTopOfInning = !IsTopOfInning;
                SwitchFieldingTeam();
                RunnerOnFirst = null;
                RunnerOnSecond = null;
                RunnerOnThird = null;
                return;
            }
            Outs++;
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
        }

        private void ScoreRun(BatterViewModel runner, bool rbi = true)
        {
            if (rbi)
            {
                AtPlateBatter.CurrentGameRunsBattedIn++;
            }
            OnFieldPitcher.CurrentGameRuns++;
            runner.CurrentGameRuns++;
            PlayByPlay.Add($"{runner.LastName} scored");
            if (IsTopOfInning)
            {
                IncrementAwayTeamRuns();
            }
            else
            {
                IncrementHomeTeamRuns();
                if (Inning >= 9 && HomeTeamTotalRuns > AwayTeamTotalRuns)
                {
                    PlayByPlay.Add($"{HomeTeam.TeamName} Win {HomeTeamTotalRuns} to {AwayTeamTotalRuns}!");
                    GameOver = true;
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
                PlayByPlay.Add($"{leadRunner.LastName} stole a base");
                AdvanceRunnersOneBase(false);
                return;
            }
            else
            {
                PlayByPlay.Add($"{leadRunner.LastName} was caught stealing");
                RemoveLeadRunner();
                ProcessOut();
                AdvanceRunnersOneBase(false);               
            }
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
