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
            var random = new Random();
            var randomResult = random.Next(0, 1001);

            if (catcher == null)
            {
                catcher = FieldingStintHelperFunctions.CreateFieldingStintForPlayerOutOfPosition(PositionType.Catcher);
            }

            if (runner == null)
            {
                runner = BattingStintHelperFunctions.CreateBattingStintForNonBatter();
            }

            var successThreshold = ((double)runner.StolenBases + catcher.StolenBases) / (runner.StolenBases + runner.CaughtStealing + catcher.StolenBases + catcher.CaughtStealing)*1000;
            return randomResult <= successThreshold;
        }

        public BattingResult GetBattingResult(BattingStint batter, PitchingStint pitcher)
        {
            var random = new Random();
            var randomResult = random.Next(0, 2);

            if (randomResult == 0)
            {
                return GetBatterBattingResult(batter, random);
            }

            return GetPitcherBattingResult(pitcher, random);
        }

        public FieldingResult GetFieldingResult(FieldingStint fielder, PositionType positionType)
        {
            // update these for shifts
            // add metrics for range and hits
            var random = new Random();
            var randomResult = random.Next(0, 1001);

            if (fielder == null)
            {
                fielder = FieldingStintHelperFunctions.CreateFieldingStintForPlayerOutOfPosition(positionType);
            }

            var successThreshold = ((double)fielder.Errors/(fielder.Putouts+fielder.Errors+fielder.Assists))*1000;
            if (randomResult <= successThreshold)
            {
                randomResult = random.Next(0, 101);
                if (randomResult <= 90)
                {
                    return FieldingResult.OneBaseError;
                }
                else if (randomResult <= 99)
                {
                    return FieldingResult.TwoBaseError;
                }
                return FieldingResult.ThreeBaseError;
            }
            randomResult = random.Next(0, 101);
            if (randomResult <= 65)
            {
                if (positionType == PositionType.CenterFielder || positionType == PositionType.LeftFielder ||
                    positionType == PositionType.RightFielder || positionType == PositionType.OutFielder)
                {
                    return GetFlyoutResult(random);
                }
                return GetGroundoutResult(random);
            }
            if (randomResult <= 80)
            {
                if (positionType == PositionType.CenterFielder || positionType == PositionType.LeftFielder ||
                    positionType == PositionType.RightFielder || positionType == PositionType.OutFielder)
                {
                    return GetFlyoutResult(random);
                }
                return FieldingResult.Popout;
            }
            if (randomResult <= 95)
            {
                return GetLineoutResult(random);
            }
            return FieldingResult.Foulout;
        }

        private FieldingResult GetGroundoutResult(Random random)
        {
            var randomResult = random.Next(0, 101);
            if (randomResult <= 10)
            {
                return FieldingResult.GroundoutAllAdvance;
            }
            if (randomResult <= 20)
            {
                return FieldingResult.GroundoutFieldersChoice;
            }
            if (randomResult <= 55)
            {
                return FieldingResult.GroundoutFieldersChoiceForce;
            }
            if (randomResult <= 85)
            {
                return FieldingResult.GroundoutFieldersChoice;
            }
            return FieldingResult.Groundout;
        }

        private FieldingResult GetFlyoutResult(Random random)
        {
            var randomResult = random.Next(0, 101);
            if (randomResult <= 8)
            {
                return FieldingResult.FlyoutAllAdvance;
            }
            if (randomResult <= 45)
            {
                return FieldingResult.Flyout;
            }
            return FieldingResult.FlyoutSacrifice;
        }

        private FieldingResult GetLineoutResult(Random random)
        {
            var randomResult = random.Next(0, 101);
            if (randomResult <= 2)
            {
                return FieldingResult.LineoutMaxOuts;
            }
            if (randomResult <= 20)
            {
                return FieldingResult.LineoutDoublePlay;
            }
            return FieldingResult.Lineout;
        }

        private BattingResult GetPitcherBattingResult(PitchingStint pitcher, Random random)
        {
            var randomResult = random.Next(0, 1001);

            if (pitcher == null)
            {
                pitcher = PitchingStintHelperFunctions.CreatePitchingStintForNonPitcher();
            }

            var totalOutcomes = pitcher.BattersFaced + pitcher.WildPitches + pitcher.Balks;
            var successThreshold = ((double)pitcher.Balks/ totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.Balk;
            }
            successThreshold += (((double)pitcher.WildPitches) / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.WildPitch;
            }
            successThreshold += (((double)pitcher.Hits - pitcher.HomeRuns) / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                randomResult = random.Next(0, 101);
                if (randomResult <= 1)
                {
                    return BattingResult.Triple;
                }
                if (randomResult <= 25)
                {
                    return BattingResult.Double;
                }
                return BattingResult.Single;
            }
            successThreshold += (((double)pitcher.HitBatters) / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.HitByPitch;
            }
            successThreshold += (((double)pitcher.HomeRuns) / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.HomeRun;
            }
            successThreshold += (((double)pitcher.Strikeouts) / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.Strikeout;
            }
            successThreshold += (((double)pitcher.Walks) / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.Walk;
            }
            successThreshold += (((double)pitcher.Walks) / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.Walk;
            }
            return GetFieldedByRandomPositionResult(random);
        }

        private BattingResult GetFieldedByRandomPositionResult(Random random)
        {
            var randomResult = random.Next(0, 101);
            if (randomResult <= 5)
            {
                return BattingResult.FieldedByPitcher;
            }
            if (randomResult <= 7)
            {
                return BattingResult.FieldedByCatcher;
            }
            if (randomResult <= 15)
            {
                return BattingResult.FieldedByFirstBaseman;
            }
            if (randomResult <= 28)
            {
                return BattingResult.FieldedBySecondBaseman;
            }
            if (randomResult <= 38)
            {
                return BattingResult.FieldedByThirdBaseman;
            }
            if (randomResult <= 52)
            {
                return BattingResult.FieldedByShortstop;
            }
            if (randomResult <= 67)
            {
                return BattingResult.FieldedByLeftFielder;
            }
            if (randomResult <= 85)
            {
                return BattingResult.FieldedByCenterFielder;
            }
            return BattingResult.FieldedByRightFielder;
        }

        private BattingResult GetBatterBattingResult(BattingStint batter, Random random)
        {
            if (batter == null)
            {
                batter = BattingStintHelperFunctions.CreateBattingStintForNonBatter();
            }

            var randomResult = random.Next(0, 1001);

            var totalOutcomes = batter.AtBats + batter.HitByPitch + batter.Walks;
            var successThreshold = ((double)batter.Doubles / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.Double;
            }
            successThreshold += (((double)batter.HitByPitch) / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.HitByPitch;
            }
            successThreshold += (((double)batter.HomeRuns) / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.HomeRun;
            }
            successThreshold += (((double)batter.Strikeouts) / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.Strikeout;
            }
            successThreshold += (((double)batter.Triples) / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.Triple;
            }
            successThreshold += (((double)batter.Walks) / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.Walk;
            }
            successThreshold += (((double)batter.Hits - (batter.Doubles + batter.Triples + batter.HomeRuns)) / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.Single;
            }
            return GetFieldedByRandomPositionResult(random);
        }

        public bool GetIsPassedBallResult(FieldingStint catcher)
        {
            var random = new Random();
            var randomResult = random.Next(0, 1001);

            if (catcher == null)
            {
                catcher = FieldingStintHelperFunctions.CreateFieldingStintForPlayerOutOfPosition(PositionType.Catcher);
            }

            if (catcher.InningsPlayedOuts == 0)
            {
                catcher.InningsPlayedOuts = (short)(catcher.Games * 8 * 3);
            }

            var successThreshold = ((double)catcher.PassedBalls / (catcher.InningsPlayedOuts*2))* 1000;
            return randomResult <= successThreshold;
        }
    }
}
