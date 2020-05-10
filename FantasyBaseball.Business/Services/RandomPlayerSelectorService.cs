using FantasyBaseball.Entities.Enums;
using FantasyBaseball.Entities.Helpers;
using FantasyBaseball.Entities.Models;
using FantasyBaseball.Repository;
using System;
using System.Linq;

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

        public PlayerStint SelectRandomBatter(PositionType positionType, bool starter = false)
        {
            var random = new Random();
            var year = random.Next(1873, 2020);

            string position;
            if (positionType == PositionType.DesignatedHitter)
            {
                var pos = random.Next(1, 10);
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
            var batters = BattingStintRepository.GetBattingStintByPositionYearAndMinimumGamesPlayed(position, year, minimumGamesPlayed);
            return batters.ElementAt(random.Next(0, batters.Count()));
        }

        public PlayerStint SelectRandomPitcher(bool starter = false)
        {
            var random = new Random();
            var year = random.Next(1873, 2020);
            var minimumGamesStarted = starter ? 10 : 0;
            var minimumInningsPitchedOuts = 45;
            var pitchers = PitchingStintRepository.GetPitchingStintByYearMinimumGamesStartedAndMinimumInningsPitchedOuts(year, minimumGamesStarted, minimumInningsPitchedOuts);
            return pitchers.ElementAt(random.Next(0, pitchers.Count()));
        }
    }
}
