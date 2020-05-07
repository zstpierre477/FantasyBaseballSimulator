using FantasyBaseball.Entities.Enums;
using FantasyBaseball.Repository;
using System;

namespace FantasyBaseball.Business.Services
{
    public class PlayerSearchServiceFactory : IPlayerSearchServiceFactory
    {
        private IBattingStintRepository BattingStintRepository { get; set; }

        private IPitchingStintRepository PitchingStintRepository { get; set; }

        public PlayerSearchServiceFactory(IBattingStintRepository battingStintRepository, IPitchingStintRepository pitchingStintRepository)
        {
            BattingStintRepository = battingStintRepository;
            PitchingStintRepository = pitchingStintRepository;
        }

        public IPlayerSearchService GetPlayerSearchService(PlayerType playerType)
        {
            switch(playerType)
            {
                case PlayerType.Batter:
                    return new BatterSearchService(BattingStintRepository);
                case PlayerType.Pitcher:
                    return new PitcherSearchService(PitchingStintRepository);
                default:
                    throw new ArgumentOutOfRangeException($"PlayerType {playerType} is not a valid PlayerType.");
            }
        }
    }
}
