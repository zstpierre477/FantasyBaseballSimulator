using FantasyBaseball.Entities.Models;
using System.IO;
using System.Linq;
using FantasyBaseball.Repository.Extensions;

namespace FantasyBaseball.Repository
{
    public class DatabaseLoaderRepository : IDatabaseLoaderRepository
    {
        public void LoadSingleGame()
        {
            using (var db = new FantasyBaseballDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

            AddEntities<Park>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\ParkData.txt");
            AddEntities<Franchise>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\FranchiseData.txt");
            AddEntities<League>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\LeagueData.txt");
            AddEntities<Division>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\DivisionData.txt");
            AddEntities<Team>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\TeamData.txt");
            AddEntities<Person>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\PersonData.txt");
            AddEntities<School>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\SchoolData.txt");
            AddEntities<HallOfFameMember>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\HallOfFameMemberData.txt");
            AddEntities<PostseasonSeries>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\PostseasonSeriesData.txt");
            AddEntities<Salary>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\SalaryData.txt");
            AddEntities<ParkStint>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\ParkStintData.txt");
            AddEntities<ManagerStint>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\ManagerStintData.txt");
            AddEntities<CollegeStint>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\CollegeStintData.txt");
            AddEntities<BattingStint>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\BattingStintData.txt");
            AddEntities<BattingPostseasonRound>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\BattingPostseasonRoundData.txt");
            AddEntities<PitchingStint>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\PitchingStintData.txt");
            AddEntities<PitchingPostseasonRound>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\PitchingPostseasonRoundData.txt");
            AddEntities<FieldingStint>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\FieldingStintData.txt");
            AddEntities<FieldingOutfieldStint>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\FieldingOutfieldStintData.txt");
            AddEntities<FieldingPostseasonRound>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\FieldingPostseasonRoundData.txt");
            AddEntities<Award>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\AwardData.txt");
            AddEntities<AwardVoting>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\AwardVotingData.txt");
            AddEntities<Appearances>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\AppearancesData.txt");
            AddEntities<AllStar>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\AllStarData.txt");
        }

        private void AddEntities<T>(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var entities = lines.Select(l => l.CreateEntity<T>());

            var count = 0;
            var db = new FantasyBaseballDbContext();

            foreach (var entity in entities)
            {
                db.Add(entity);

                if (count % 300 == 0)
                {
                    db.SaveChanges();
                    db.Dispose();
                    db = new FantasyBaseballDbContext();
                }
            }

            db.SaveChanges();
            db.Dispose();
        }
    }
}