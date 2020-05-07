using FantasyBaseball.Entities.Enums;
using FantasyBaseball.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyBaseball.Business.Services
{
    public class SingleGameService : ISingleGameService
    {
        public SingleGameTeam HomeTeam { get; set; }

        public SingleGameTeam AwayTeam { get; set; }

        public SingleGameService(homeTeam, awayTeam)
        {
            HomeTeam = homeTeam;
            AwayTeam = awayTeam;
        }

        public bool GetStealingResult(BatterViewModel runner, BatterViewModel catcher)
        {
            // only handles lead runner steals
            // todo add complex steals/errors/balks/rundowns2
            var random = new Random().Next(0, 1000);
        }

        public BattingResult GetBattingResult(BatterViewModel batter, PitcherViewModel pitcher)
        {
            var random = new Random().Next(0, 2000);
            if (random < 1000)
            {
                return GetBatterBattingResult(batter, random);
            }

            return GetPitcherBattingResult(pitcher, random%1000);
        }

        public OutfieldFieldingResult GetOutfieldFieldingResult(BatterViewModel fielder)
        {

        }

        public InfieldFieldingResult GetInfieldFieldingResult(BatterViewModel fielder)
        {

        }

        private BattingResult GetPitcherBattingResult(PitcherViewModel pitcher, int random)
        {

        }

        private BattingResult GetBatterBattingResult(BatterViewModel batter, int random)
        {
        }
    }
}
