using Microsoft.EntityFrameworkCore;

namespace FantasyBaseball.Entities
{
    public class FantasyBaseballDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appearances>()
                .HasIndex(m => new { m.Year, m.TeamId, m.PersonId })
                .IsUnique(true);

            modelBuilder.Entity<Award>()
                .HasIndex(m => new { m.PersonId, m.AwardName, m.Year, m.LeagueId })
                .IsUnique(true);

            modelBuilder.Entity<AwardVoting>()
                .HasIndex(m => new { m.PersonId, m.AwardName, m.Year, m.LeagueId })
                .IsUnique(true);

            modelBuilder.Entity<BattingPostseasonRound>()
                .HasIndex(m => new { m.Year, m.Round, m.PersonId })
                .IsUnique(true);

            modelBuilder.Entity<BattingStint>()
                .HasIndex(m => new { m.Year, m.Stint, m.PersonId })
                .IsUnique(true);

            modelBuilder.Entity<Division>()
                .HasIndex(m => new { m.DivisionAbbreviation, m.LeagueId })
                .IsUnique(true);

            modelBuilder.Entity<FieldingOutfieldStint>()
                .HasIndex(m => new { m.Year, m.Stint, m.PersonId })
                .IsUnique(true);

            modelBuilder.Entity<FieldingPostseasonRound>()
                .HasIndex(m => new { m.Year, m.Round, m.PersonId, m.Position })
                .IsUnique(true);

            modelBuilder.Entity<FieldingStint>()
                .HasIndex(m => new { m.Year, m.Stint, m.PersonId, m.Position })
                .IsUnique(true);

            modelBuilder.Entity<HallOfFameMember>()
                .HasIndex(m => new { m.PersonId, m.Year, m.VotedBy })
                .IsUnique(true);

            modelBuilder.Entity<ManagerStint>()
                .HasIndex(m => new { m.TeamId, m.Year, m.InSeason })
                .IsUnique(true);

            modelBuilder.Entity<PitchingPostseasonRound>()
                .HasIndex(m => new { m.Year, m.Round, m.PersonId })
                .IsUnique(true);

            modelBuilder.Entity<PitchingStint>()
                .HasIndex(m => new { m.Year, m.Stint, m.PersonId })
                .IsUnique(true);

            modelBuilder.Entity<PostseasonSeries>()
                .HasIndex(m => new { m.Year, m.Round })
                .IsUnique(true);

            modelBuilder.Entity<Salary>()
                .HasIndex(m => new { m.TeamId, m.Year, m.LeagueId, m.PersonId })
                .IsUnique(true);

            modelBuilder.Entity<Team>()
                .HasIndex(m => new { m.Year, m.LeagueId, m.TeamName })
                .IsUnique(true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("");
        }

        public DbSet<AllStar> AllStars { get; set; }
        
        public DbSet<Appearances> Appearances { get; set; }

        public DbSet<Award> Awards { get; set; }

        public DbSet<AwardVoting> AwardShares { get; set; }

        public DbSet<BattingPostseasonRound> BattingPostseasonRounds { get; set; }

        public DbSet<BattingStint> BattingStints { get; set; }
        
        public DbSet<CollegeStint> CollegeStints { get; set; }
        
        public DbSet<Division> Divisions { get; set; }

        public DbSet<FieldingOutfieldStint> FieldingOutfieldStints { get; set; }

        public DbSet<FieldingPostseasonRound> FieldingPostseasonRounds { get; set; }

        public DbSet<FieldingStint> FieldingStints { get; set; }
        
        public DbSet<Franchise> Franchises { get; set; }
        
        public DbSet<HallOfFameMember> HallOfFameMembers { get; set; }

        public DbSet<League> Leagues { get; set; }

        public DbSet<ManagerStint> ManagerStints { get; set; }

        public DbSet<Park> Parks { get; set; }

        public DbSet<ParkStint> ParkStints { get; set; }

        public DbSet<Person> People { get; set; }
        
        public DbSet<PitchingPostseasonRound> PitchingPostseasonRounds { get; set; }

        public DbSet<PitchingStint> PitchingStints { get; set; }

        public DbSet<PostseasonSeries> PostseasonSeries { get; set; }

        public DbSet<Salary> Salaries { get; set; }
        
        public DbSet<School> Schools { get; set; }
        
        public DbSet<Team> Teams { get; set; }
    }
}
