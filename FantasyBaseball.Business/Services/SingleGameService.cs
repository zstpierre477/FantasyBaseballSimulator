using FantasyBaseball.Entities.Enums;
using FantasyBaseball.Entities.Models;
using System;

namespace FantasyBaseball.Business.Services
{
    public class SingleGameService : ISingleGameService
    {
        public SingleGameService()
        {
        }

        public bool GetStealResult(BattingStint runner, FieldingStint catcher)
        {
            // only handles lead runner steals
            // todo add complex steals/errors/balks/rundowns2
            var random = new Random().Next(0, 1000);
        }

        public BattingResult GetBattingResult(BattingStint batter, PitchingStint pitcher)
        {
            var random = new Random().Next(0, 2000);
            if (random < 1000)
            {
                return GetBatterBattingResult(batter, random);
            }

            return GetPitcherBattingResult(pitcher, random%1000);
        }

        public FieldingResult GetFieldingResult(FieldingStint fielder)
        {

        }

        private BattingResult GetPitcherBattingResult(PitchingStint pitcher, int random)
        {

        }

        private BattingResult GetBatterBattingResult(BattingStint batter, int random)
        {
        }

        public bool GetIsPassedBallResult(FieldingStint fielder)
        {
            // return if passed ball
        }
    }
}
