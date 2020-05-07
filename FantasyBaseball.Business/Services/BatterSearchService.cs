using FantasyBaseball.Entities.Models;
using FantasyBaseball.Repository;
using System.Collections.Generic;

namespace FantasyBaseball.Business.Services
{
    public class BatterSearchService : IPlayerSearchService
    {
        public IBattingStintRepository BattingStintRepository { get; set; }

        public BatterSearchService(IBattingStintRepository battingStintRepository)
        {
            BattingStintRepository = battingStintRepository;
        }

        public IEnumerable<PlayerStint> SearchByLastNameAndYear(string lastName, int year)
        {
            return BattingStintRepository.GetBattingStintByLastNameAndYear(lastName, year);
        }
    }
}
