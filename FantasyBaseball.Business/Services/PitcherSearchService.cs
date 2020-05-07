using FantasyBaseball.Entities.Models;
using FantasyBaseball.Repository;
using System.Collections.Generic;

namespace FantasyBaseball.Business.Services
{
    public class PitcherSearchService : IPlayerSearchService
    {
        public IPitchingStintRepository PitchingStintRepository { get; set; }

        public PitcherSearchService(IPitchingStintRepository pitchingStintRepository)
        {
            PitchingStintRepository = pitchingStintRepository;
        }

        public IEnumerable<PlayerStint> SearchByLastNameAndYear(string lastName, int year)
        {
            return PitchingStintRepository.GetPitchingStintByLastNameAndYear(lastName, year);
        }
    }
}
