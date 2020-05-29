using FantasyBaseball.Entities.Enums;
using FantasyBaseball.Entities.Helpers;
using FantasyBaseball.Entities.Models;
using FantasyBaseball.Repository;
using System;

namespace FantasyBaseball.Business.Services
{
    public class RandomPlayerSelectorService : IRandomPlayerSelectorService
    {
        public IBattingStintRepository BattingStintRepository { get; set; }

        public IPitchingStintRepository PitchingStintRepository { get; set; }

        public RandomPlayerSelectorService(IBattingStintRepository battingStintRepository, IPitchingStintRepository pitchingStintRepository)
        {
            BattingStintRepository = battingStintRepository;
            PitchingStintRepository = pitchingStintRepository;
        }

        public PlayerStint SelectRandomBatter(PositionType positionType, bool starter = false, bool hallOfFamer = false, bool allStar = false)
        {
            var random = new Random();
            var year = random.Next(1873, 2020);

            string position;
            if (positionType == PositionType.DesignatedHitter)
            {
                var pos = random.Next(2, 10);
                position = PositionTypeHelperFunctions.NumberToPositionAbbreviationString(pos);
            }
            else if (positionType == PositionType.CornerInfielder)
            {
                var pos = random.Next(0, 2);
                position = pos == 0 ? "1B" : "3B";
            }
            else if (positionType == PositionType.MiddleInfielder)
            {
                var pos = random.Next(0, 2);
                position = pos == 0 ? "2B" : "SS";
            }
            else if (positionType == PositionType.OutFielder)
            {
                var pos = random.Next(7, 10);
                position = PositionTypeHelperFunctions.NumberToPositionAbbreviationString(pos);
            }
            else
            {
                position = PositionTypeHelperFunctions.PositionTypeToPositionAbbreviationString(positionType);
            }

            if (year < 1954 && (position == "LF" || position == "CF" || position == "RF"))
            {
                position = "OF";
            }

            var minimumGamesPlayed = starter ? 80 : 20;
            var minimumAtBats = 20;

            if (hallOfFamer)
            {
                return BattingStintRepository.GetRandomHallOfFameBattingStintByPositionMinimumGamesPlayedAndMinimumAtBats(position, minimumGamesPlayed, minimumAtBats);
            }
            if (allStar)
            {
                return BattingStintRepository.GetRandomAllStarBattingStintByPositionMinimumGamesPlayedAndMinimumAtBats(position, minimumGamesPlayed, minimumAtBats);
            }

            var batter = BattingStintRepository.GetRandomBattingStintByPositionYearMinimumGamesPlayedAndMinimumAtBats(position, year, minimumGamesPlayed, minimumAtBats);
            while (batter == null)
            {
                year = random.Next(1873, 2020);
                batter = BattingStintRepository.GetRandomBattingStintByPositionYearMinimumGamesPlayedAndMinimumAtBats(position, year, minimumGamesPlayed, minimumAtBats);
            }
            return batter;
        }

        public PlayerStint SelectRandomPitcher(bool starter = false, bool hallOfFamer = false, bool allStar = false)
        {
            var random = new Random();
            var year = random.Next(1873, 2020);
            var minimumGamesStarted = starter ? 10 : 0;
            var minimumInningsPitchedOuts = 45;
            if (hallOfFamer)
            {
                return PitchingStintRepository.GetRandomHallOfFamePitchingStintByMinimumGamesStartedAndMinimumInningsPitchedOuts(minimumGamesStarted, minimumInningsPitchedOuts);
            }
            if (allStar)
            {
                return PitchingStintRepository.GetRandomAllStarPitchingStintByMinimumGamesStartedAndMinimumInningsPitchedOuts(minimumGamesStarted, minimumInningsPitchedOuts);
            }
            return PitchingStintRepository.GetRandomPitchingStintByYearMinimumGamesStartedAndMinimumInningsPitchedOuts(year, minimumGamesStarted, minimumInningsPitchedOuts);
        }
    }
}
