using FantasyBaseball.Repository;

namespace FantasyBaseball.Business.Services
{
    public class DatabaseLoader : IDatabaseLoader
    {
        private IDatabaseLoaderRepository DatabaseLoaderRepository { get; set; }

        public DatabaseLoader(IDatabaseLoaderRepository databaseLoaderRepository)
        {
            DatabaseLoaderRepository = databaseLoaderRepository;
        }

        public void LoadDatabaseForSingleGame()
        {
            DatabaseLoaderRepository.LoadSingleGame();
        }
    }
}
