using FantasyBaseball.Entities.Enums;
using FantasyBaseball.Entities.Helpers;
using FantasyBaseball.Entities.Models;
using System;

namespace FantasyBaseball.Business.Services
{
    public class SingleGameService : ISingleGameService
    {
        public bool GetStealResult(BattingStint runner, FieldingStint catcher)
        {
            // only handles lead runner steals
            // todo add complex steals/errors/balks/rundowns2
            var random = new Random().Next(0, 1001);

            if (catcher == null)
            {
                catcher = FieldingStintHelperFunctions.CreateFieldingStintForPlayerOutOfPosition(PositionType.Catcher);
            }

            if (runner == null)
            {
                runner = BattingStintHelperFunctions.CreateBattingStintForNonBatter();
            }

            var successThreshold = ((double)runner.StolenBases + catcher.StolenBases) / (runner.StolenBases + runner.CaughtStealing + catcher.StolenBases + catcher.CaughtStealing)*1000;
            return random <= successThreshold;
        }

        public BattingResult GetBattingResult(BattingStint batter, PitchingStint pitcher)
        {
            var random = new Random().Next(0, 2);

            if (random == 0)
            {
                return GetBatterBattingResult(batter);
            }

            return GetPitcherBattingResult(pitcher);
        }

        public FieldingResult GetFieldingResult(FieldingStint fielder, PositionType positionType)
        {
            // add metrics for range and hits
            var random = new Random().Next(0, 1001);

            if (fielder == null)
            {
                fielder = FieldingStintHelperFunctions.CreateFieldingStintForPlayerOutOfPosition(PositionType.Catcher);
            }

            var successThreshold = ((double)fielder.Errors/(fielder.Putouts+fielder.Errors+fielder.Assists))*1000;
            if (random <= successThreshold)
            {
                random = new Random().Next(0, 101);
                if (random <= 90)
                {
                    return FieldingResult.OneBaseError;
                }
                else if (random <= 99)
                {
                    return FieldingResult.TwoBaseError;
                }
                return FieldingResult.ThreeBaseError;
            }
            random = new Random().Next(0, 101);
            if (random <= 50)
            {
                if (positionType == PositionType.CenterFielder || positionType == PositionType.LeftFielder ||
                    positionType == PositionType.RightFielder || positionType == PositionType.OutFielder)
                {
                    return FieldingResult.Flyout;
                }
                return FieldingResult.Groundout;
            }
            if (random <= 88)
            {
                if (positionType == PositionType.CenterFielder || positionType == PositionType.LeftFielder ||
                    positionType == PositionType.RightFielder || positionType == PositionType.OutFielder)
                {
                    return FieldingResult.Flyout;
                }
                return FieldingResult.Popout;
            }
            if (random <= 98)
            {
                return FieldingResult.Lineout;
            }
            return FieldingResult.Foulout;
        }

        private BattingResult GetPitcherBattingResult(PitchingStint pitcher)
        {
            var random = new Random().Next(0, 1001);

            if (pitcher == null)
            {
                pitcher = PitchingStintHelperFunctions.CreatePitchingStintForNonPitcher();
            }

            var totalOutcomes = pitcher.BattersFaced + pitcher.WildPitches + pitcher.Balks;
            var successThreshold = ((double)pitcher.Balks/ totalOutcomes) * 1000;
            if (random <= successThreshold)
            {
                return BattingResult.Balk;
            }
            successThreshold += (((double)pitcher.WildPitches) / totalOutcomes) * 1000;
            if (random <= successThreshold)
            {
                return BattingResult.WildPitch;
            }
            successThreshold += (((double)pitcher.Hits - pitcher.HomeRuns) / totalOutcomes) * 1000;
            if (random <= successThreshold)
            {
                random = new Random().Next(0, 101);
                if (random <= 1)
                {
                    return BattingResult.Triple;
                }
                if (random <= 25)
                {
                    return BattingResult.Double;
                }
                return BattingResult.Single;
            }
            successThreshold += (((double)pitcher.HitBatters) / totalOutcomes) * 1000;
            if (random <= successThreshold)
            {
                return BattingResult.HitByPitch;
            }
            successThreshold += (((double)pitcher.HomeRuns) / totalOutcomes) * 1000;
            if (random <= successThreshold)
            {
                return BattingResult.HomeRun;
            }
            successThreshold += (((double)pitcher.Strikeouts) / totalOutcomes) * 1000;
            if (random <= successThreshold)
            {
                return BattingResult.Strikeout;
            }
            successThreshold += (((double)pitcher.Walks) / totalOutcomes) * 1000;
            if (random <= successThreshold)
            {
                return BattingResult.Walk;
            }
            successThreshold += (((double)pitcher.Walks) / totalOutcomes) * 1000;
            if (random <= successThreshold)
            {
                return BattingResult.Walk;
            }
            return GetFieldedByRandomPositionResult();
        }

        private BattingResult GetFieldedByRandomPositionResult()
        {
            var random = new Random().Next(0, 101);
            if (random <= 5)
            {
                return BattingResult.FieldedByPitcher;
            }
            if (random <= 7)
            {
                return BattingResult.FieldedByCatcher;
            }
            if (random <= 15)
            {
                return BattingResult.FieldedByFirstBaseman;
            }
            if (random <= 28)
            {
                return BattingResult.FieldedBySecondBaseman;
            }
            if (random <= 38)
            {
                return BattingResult.FieldedByThirdBaseman;
            }
            if (random <= 52)
            {
                return BattingResult.FieldedByShortstop;
            }
            if (random <= 67)
            {
                return BattingResult.FieldedByLeftFielder;
            }
            if (random <= 85)
            {
                return BattingResult.FieldedByCenterFielder;
            }
            return BattingResult.FieldedByRightFielder;
        }

        private BattingResult GetBatterBattingResult(BattingStint batter)
        {
            if (batter == null)
            {
                batter = BattingStintHelperFunctions.CreateBattingStintForNonBatter();
            }

            var random = new Random().Next(0, 1001);

            var totalOutcomes = batter.AtBats + batter.HitByPitch + batter.Walks;
            var successThreshold = ((double)batter.Doubles / totalOutcomes) * 1000;
            if (random <= successThreshold)
            {
                return BattingResult.Double;
            }
            successThreshold += (((double)batter.HitByPitch) / totalOutcomes) * 1000;
            if (random <= successThreshold)
            {
                return BattingResult.HitByPitch;
            }
            successThreshold += (((double)batter.HomeRuns) / totalOutcomes) * 1000;
            if (random <= successThreshold)
            {
                return BattingResult.HomeRun;
            }
            successThreshold += (((double)batter.Strikeouts) / totalOutcomes) * 1000;
            if (random <= successThreshold)
            {
                return BattingResult.Strikeout;
            }
            successThreshold += (((double)batter.Triples) / totalOutcomes) * 1000;
            if (random <= successThreshold)
            {
                return BattingResult.Triple;
            }
            successThreshold += (((double)batter.Walks) / totalOutcomes) * 1000;
            if (random <= successThreshold)
            {
                return BattingResult.Walk;
            }
            successThreshold += (((double)batter.Hits - (batter.Doubles + batter.Triples + batter.HomeRuns)) / totalOutcomes) * 1000;
            if (random <= successThreshold)
            {
                return BattingResult.Single;
            }
            return GetFieldedByRandomPositionResult();
        }

        public bool GetIsPassedBallResult(FieldingStint catcher)
        {
            var random = new Random().Next(0, 1001);

            if (catcher == null)
            {
                catcher = FieldingStintHelperFunctions.CreateFieldingStintForPlayerOutOfPosition(PositionType.Catcher);
            }

            var successThreshold = ((double)catcher.PassedBalls / (catcher.InningsPlayedOuts*2))* 1000;
            return random <= successThreshold;
        }
    }
}
