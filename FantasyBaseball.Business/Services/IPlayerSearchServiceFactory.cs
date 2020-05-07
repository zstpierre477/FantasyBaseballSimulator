using FantasyBaseball.Entities.Enums;

namespace FantasyBaseball.Business.Services
{
    public interface IPlayerSearchServiceFactory
    {
        IPlayerSearchService GetPlayerSearchService(PlayerType playerType);
    }
}
