using FantasyBaseball.Entities.Models;
using System.IO;
using FantasyBaseball.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace FantasyBaseball.Repository
{
    public class DatabaseLoaderRepository : IDatabaseLoaderRepository
    {
        public void LoadSingleGame()
        {
            using (var db = new FantasyBaseballDbContext())
            {
                // uncomment to recreate and fill db every time
                //db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                if (db.BattingStint.Any())
                {
                    return;
                }
            }

            //AddEntities<Park>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\ParkData.txt");
            AddEntities<Franchise>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\FranchiseData.txt");
            AddEntities<League>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\LeagueData.txt");
            AddEntities<Division>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\DivisionData.txt");
            AddEntities<Team>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\TeamData.txt");
            AddEntities<Person>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\PersonData.txt");
            //AddEntities<School>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\SchoolData.txt");
            AddEntities<HallOfFameMember>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\HallOfFameMemberData.txt");
            //AddEntities<PostseasonSeries>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\PostseasonSeriesData.txt");
            //AddEntities<Salary>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\SalaryData.txt");
            //AddEntities<ParkStint>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\ParkStintData.txt");
            //AddEntities<ManagerStint>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\ManagerStintData.txt");
            //AddEntities<CollegeStint>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\CollegeStintData.txt");
            AddEntities<BattingStint>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\BattingStintData.txt");
            //AddEntities<BattingPostseasonRound>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\BattingPostseasonRoundData.txt");
            AddEntities<PitchingStint>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\PitchingStintData.txt");
            //AddEntities<PitchingPostseasonRound>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\PitchingPostseasonRoundData.txt");
            AddEntities<FieldingStint>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\FieldingStintData.txt");
            //AddEntities<FieldingOutfieldStint>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\FieldingOutfieldStintData.txt");
            //AddEntities<FieldingPostseasonRound>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\FieldingPostseasonRoundData.txt");
            //AddEntities<Award>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\AwardData.txt");
            //AddEntities<AwardVoting>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\AwardVotingData.txt");
            //AddEntities<Appearances>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\AppearancesData.txt");
            AddEntities<AllStar>("C:\\Users\\320079761\\source\\repos\\FantasyBaseballSimulator\\FantasyBaseball.Repository\\DatabaseLoaderFiles\\AllStarData.txt");
        }

        private void AddEntities<T>(string filePath)
        {
            var count = 1;
            string line;
            var file = new StreamReader(filePath);
            var db = new FantasyBaseballDbContext();

            while ((line = file.ReadLine()) != null)
            {
                var entity = line.CreateEntity<T>();

                db.Add(entity);

                if (count % 600 == 0)
                {
                    db.Database.OpenConnection();
                    db.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {typeof(T).FullName.Replace("FantasyBaseball.Entities.Models.", "")} ON");
                    db.SaveChanges();
                    db.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {typeof(T).FullName.Replace("FantasyBaseball.Entities.Models.", "")} OFF");
                    db.Database.CloseConnection();
                    db.Dispose();
                    db = new FantasyBaseballDbContext();
                }

                count++;
            }

            db.Database.OpenConnection();
            db.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {typeof(T).FullName.Replace("FantasyBaseball.Entities.Models.", "")} ON");
            db.SaveChanges();
            db.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {typeof(T).FullName.Replace("FantasyBaseball.Entities.Models.", "")} OFF");
            db.Database.CloseConnection();
            db.Dispose();

            file.Close();
        }
    }
}