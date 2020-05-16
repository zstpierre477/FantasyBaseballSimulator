using FantasyBaseball.Entities.Enums;
using FantasyBaseball.Entities.Helpers;
using FantasyBaseball.Entities.Models;
using System;

namespace FantasyBaseball.Business.Services
{
    public class SingleGameService : ISingleGameService
    {
        public bool GetStealResult(BattingStint runner, FieldingStint catcher, BaseballBase baseballBase)
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

            double baseFactor = 1;

            if (baseballBase == BaseballBase.Third)
            {
                baseFactor = .75;
            }
            else if (baseballBase == BaseballBase.Home)
            {
                baseFactor = .5;
            }

            double catcherArmFactor = 1;

            if (catcher.StolenBases < 20 || runner.StolenBases < 20)
            {
                catcherArmFactor = .9;
            }
            else
            {
                var csRatio = (double)catcher.CaughtStealing / (catcher.CaughtStealing + catcher.StolenBases);
                if (csRatio >= .6)
                {
                    catcherArmFactor = .6;
                }
                else if (csRatio >= .5)
                {
                    catcherArmFactor = .7;
                }

                else if (catcher.StolenBases >= .4)
                {
                    catcherArmFactor = .8;
                }
                else if (catcher.StolenBases >= .3)
                {
                    catcherArmFactor = .9;
                }
                else if (catcher.StolenBases >= .2)
                {
                    catcherArmFactor = .95;
                }

            }

            double stealingFrequencyFactor = 1;
            if (runner.StolenBases >= 100)
            {
                stealingFrequencyFactor = .97;
            }
            else if (runner.StolenBases >= 70)
            {
                stealingFrequencyFactor = .92;
            }
            else if (runner.StolenBases >= 50)
            {
                stealingFrequencyFactor = .87;
            }
            else if (runner.StolenBases >= 40)
            {
                stealingFrequencyFactor = .82;
            }
            else if (runner.StolenBases >= 30)
            {
                stealingFrequencyFactor = .75;
            }
            else if (runner.StolenBases >= 20)
            {
                stealingFrequencyFactor = .7;
            }
            else if (runner.StolenBases >= 10)
            {
                stealingFrequencyFactor = .6;
            }
            else
            {
                stealingFrequencyFactor = .5;
            }

            var successThreshold = stealingFrequencyFactor*catcherArmFactor*baseFactor*1000;
            return randomResult <= successThreshold;
        }

        public BattingResult GetBattingResult(BattingStint batter, PitchingStint pitcher, bool isPitcherTired)
        {
            var random = new Random();
            var randomResult = random.Next(0, 2);

            if (randomResult == 0)
            {
                return GetBatterBattingResult(batter, random);
            }

            return GetPitcherBattingResult(pitcher, random, isPitcherTired);
        }

        public FieldingResult GetFieldingResult(FieldingStint fielder, PositionType positionType, InfieldShiftType infieldShiftType, OutfieldShiftType outfieldShiftType)
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
                randomResult = random.Next(0, 100);
                if (randomResult < 90)
                {
                    return FieldingResult.OneBaseError;
                }
                else if (randomResult < 98)
                {
                    return FieldingResult.TwoBaseError;
                }
                return FieldingResult.ThreeBaseError;
            }
            randomResult = random.Next(0, 100);
            if (randomResult < 65)
            {
                if (positionType == PositionType.CenterFielder || positionType == PositionType.LeftFielder ||
                    positionType == PositionType.RightFielder || positionType == PositionType.OutFielder)
                {
                    return GetFlyoutResult(random, outfieldShiftType);
                }
                return GetGroundoutResult(random, infieldShiftType);
            }
            if (randomResult < 80)
            {
                if (positionType == PositionType.CenterFielder || positionType == PositionType.LeftFielder ||
                    positionType == PositionType.RightFielder || positionType == PositionType.OutFielder)
                {
                    return GetFlyoutResult(random, outfieldShiftType);
                }
                if (infieldShiftType == InfieldShiftType.InfieldIn)
                {
                    randomResult = random.Next(0,5);
                    if (randomResult < 2)
                    {
                        return FieldingResult.Single;
                    }
                }
                return FieldingResult.Popout;
            }
            if (randomResult < 95)
            {
                return GetLineoutResult(random, positionType, infieldShiftType);
            }
            return FieldingResult.Foulout;
        }

        private FieldingResult GetGroundoutResult(Random random, InfieldShiftType infieldShiftType)
        {
            var randomResult = random.Next(0, 100);
            if (randomResult < 15)
            {
                return infieldShiftType == InfieldShiftType.None ? FieldingResult.GroundoutAllAdvance : FieldingResult.Single;
            }
            if (randomResult < 22)
            {
                return FieldingResult.GroundoutFieldersChoice;
            }
            if (randomResult < 42)
            {
                return infieldShiftType == InfieldShiftType.None ? FieldingResult.GroundoutFieldersChoiceForce : FieldingResult.Groundout;
            }
            if (randomResult < 65)
            {
                return FieldingResult.GroundoutDoublePlay;
            }
            return FieldingResult.Groundout;
        }

        private FieldingResult GetFlyoutResult(Random random, OutfieldShiftType outfieldShiftType)
        {
            var randomResult = random.Next(0, 100);
            if (randomResult < 8)
            {
                return outfieldShiftType == OutfieldShiftType.None ? FieldingResult.FlyoutAllAdvance : FieldingResult.Double;
            }
            if (randomResult < 45)
            {
                if (outfieldShiftType == OutfieldShiftType.OutfieldIn)
                {
                    randomResult = random.Next(0, 2);
                    if (randomResult == 0)
                    {
                        return FieldingResult.FlyoutSacrifice;
                    }
                }
                return FieldingResult.Flyout;
            }
            return FieldingResult.FlyoutSacrifice;
        }

        private FieldingResult GetLineoutResult(Random random, PositionType positionType, InfieldShiftType infieldShiftType)
        {
            if (infieldShiftType == InfieldShiftType.InfieldIn && positionType.IsOutFieldPosition() == false)
            {
                return FieldingResult.Lineout;
            }

            var randomResult = random.Next(0, 100);
            if (randomResult < 2)
            {
                return FieldingResult.LineoutMaxOuts;
            }
            if (randomResult < 20)
            {
                return FieldingResult.LineoutDoublePlay;
            }
            return FieldingResult.Lineout;
        }

        private BattingResult GetPitcherBattingResult(PitchingStint pitcher, Random random, bool isPitcherTired)
        {
            var randomResult = random.Next(0, 1001);

            if (pitcher == null)
            {
                pitcher = PitchingStintHelperFunctions.CreatePitchingStintForNonPitcher();
            }

            var fatigueWildPitches = 0;
            var fatigueWalks = 0;
            var fatigueHitBatters = 0;
            var fatigueHits = 0;
            var fatigueHomeRuns = 0;

            if (isPitcherTired)
            {
                fatigueWildPitches = pitcher.WildPitches/3;
                fatigueWalks = pitcher.Walks / 3;
                fatigueHitBatters = pitcher.HitBatters / 3;
                fatigueHits = pitcher.WildPitches / 3;
                fatigueHomeRuns = pitcher.HomeRuns / 3;
            }

            var totalOutcomes = pitcher.BattersFaced + pitcher.WildPitches + pitcher.Balks + fatigueWalks + 
                fatigueHitBatters + fatigueHits + fatigueHomeRuns + fatigueWildPitches;

            var successThreshold = ((double)pitcher.Balks/ totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.Balk;
            }
            successThreshold += (((double)pitcher.WildPitches + fatigueWildPitches) / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.WildPitch;
            }
            successThreshold += ((((double)pitcher.Hits + fatigueHits) - (pitcher.HomeRuns + fatigueHomeRuns)) / totalOutcomes) * 1000;
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
            successThreshold += (((double)pitcher.HitBatters + fatigueHitBatters) / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.HitByPitch;
            }
            successThreshold += (((double)pitcher.HomeRuns + fatigueHomeRuns) / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.HomeRun;
            }
            successThreshold += (((double)pitcher.Strikeouts) / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.Strikeout;
            }
            successThreshold += (((double)pitcher.Walks + fatigueWalks) / totalOutcomes) * 1000;
            if (randomResult <= successThreshold)
            {
                return BattingResult.Walk;
            }
            return GetFieldedByRandomPositionResult(random);
        }

        private BattingResult GetFieldedByRandomPositionResult(Random random)
        {
            var randomResult = random.Next(0, 100);
            if (randomResult < 5)
            {
                return BattingResult.FieldedByPitcher;
            }
            if (randomResult < 7)
            {
                return BattingResult.FieldedByCatcher;
            }
            if (randomResult < 15)
            {
                return BattingResult.FieldedByFirstBaseman;
            }
            if (randomResult < 28)
            {
                return BattingResult.FieldedBySecondBaseman;
            }
            if (randomResult < 38)
            {
                return BattingResult.FieldedByThirdBaseman;
            }
            if (randomResult < 52)
            {
                return BattingResult.FieldedByShortstop;
            }
            if (randomResult < 67)
            {
                return BattingResult.FieldedByLeftFielder;
            }
            if (randomResult < 85)
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
                randomResult = random.Next(0,3);
                if (randomResult == 0)
                {
                    return BattingResult.Double3Bases;
                }
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
                randomResult = random.Next(0, 1);
                if (randomResult == 0)
                {
                    return BattingResult.Single2Bases;
                }
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

        public FieldingResult GetSacrificeBuntResult(BattingStint batter)
        {
            if (batter == null)
            {
                batter = BattingStintHelperFunctions.CreateBattingStintForNonBatter();
            }

            var random = new Random();
            var randomResult = random.Next(0, 101);

            var successThreshold = 60;

            if (batter.SacrificeHits > 0)
            {
                successThreshold += 12;
            }
            if (batter.SacrificeHits > 10)
            {
                successThreshold += 8;
            }

            if (randomResult <= successThreshold)
            {
                randomResult = random.Next(0, 100);
                if (randomResult < 8)
                {
                    return FieldingResult.Single;
                }
                return FieldingResult.GroundoutAllAdvance;
            }
            randomResult = random.Next(0, 100);
            if (randomResult < 8)
            {
                return FieldingResult.GroundoutDoublePlay;
            }
            if (randomResult < 18)
            {
                return FieldingResult.GroundoutFieldersChoice;
            }
            if (randomResult < 50)
            {
                return FieldingResult.Groundout;
            }
            if (randomResult < 70)
            {
                return FieldingResult.Popout;
            }
            return FieldingResult.Strikeout;
        }

        public FieldingResult GetBuntForAHitResult(BattingStint batter)
        {
            if (batter == null)
            {
                batter = BattingStintHelperFunctions.CreateBattingStintForNonBatter();
            }

            var random = new Random();
            var randomResult = random.Next(0, 100);

            var successThreshold = 20;

            if (batter.SacrificeHits > 0)
            {
                successThreshold += 5;
            }
            if (batter.SacrificeHits >= 10)
            {
                successThreshold += 5;
            }
            if (batter.StolenBases >= 10)
            {
                successThreshold += 5;
            }
            if (batter.StolenBases >= 25)
            {
                successThreshold += 10;
            }

            if (randomResult <= successThreshold)
            {
                return FieldingResult.Single;
            }
            randomResult = random.Next(0, 100);
            if (randomResult < 3)
            {
                return FieldingResult.GroundoutDoublePlay;
            }
            if (randomResult < 10)
            {
                return FieldingResult.GroundoutFieldersChoice;
            }
            if (randomResult < 40)
            {
                return FieldingResult.Groundout;
            }
            if (randomResult < 60)
            {
                return FieldingResult.Popout;
            }
            if (randomResult < 80)
            {
                return FieldingResult.Strikeout;
            }
            return FieldingResult.GroundoutAllAdvance;
        }

        public bool GetHitAndRunResult(BattingStint batter)
        {
            if (batter == null)
            {
                batter = BattingStintHelperFunctions.CreateBattingStintForNonBatter();
            }

            var random = new Random();
            var randomResult = random.Next(0, 100);

            var successThreshold = 35 + ((double)batter.Hits / batter.AtBats) * 100;

            return randomResult < successThreshold;
        }
    }
}
