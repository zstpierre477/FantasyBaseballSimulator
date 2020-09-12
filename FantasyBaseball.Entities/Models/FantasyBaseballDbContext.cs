using Microsoft.EntityFrameworkCore;

namespace FantasyBaseball.Entities.Models
{
    public partial class FantasyBaseballDbContext : DbContext
    {
        public FantasyBaseballDbContext()
        {
        }

        public FantasyBaseballDbContext(DbContextOptions<FantasyBaseballDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllStar> AllStar { get; set; }
        public virtual DbSet<Appearances> Appearances { get; set; }
        public virtual DbSet<Award> Award { get; set; }
        public virtual DbSet<AwardVoting> AwardVoting { get; set; }
        public virtual DbSet<BattingPostseasonRound> BattingPostseasonRound { get; set; }
        public virtual DbSet<BattingStint> BattingStint { get; set; }
        public virtual DbSet<CollegeStint> CollegeStint { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<FieldingOutfieldStint> FieldingOutfieldStint { get; set; }
        public virtual DbSet<FieldingPostseasonRound> FieldingPostseasonRound { get; set; }
        public virtual DbSet<FieldingStint> FieldingStint { get; set; }
        public virtual DbSet<Franchise> Franchise { get; set; }
        public virtual DbSet<HallOfFameMember> HallOfFameMember { get; set; }
        public virtual DbSet<League> League { get; set; }
        public virtual DbSet<ManagerStint> ManagerStint { get; set; }
        public virtual DbSet<Park> Park { get; set; }
        public virtual DbSet<ParkStint> ParkStint { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PitchingPostseasonRound> PitchingPostseasonRound { get; set; }
        public virtual DbSet<PitchingStint> PitchingStint { get; set; }
        public virtual DbSet<PostseasonSeries> PostseasonSeries { get; set; }
        public virtual DbSet<Salary> Salary { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<Team> Team { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=FantasyBaseballDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllStar>(entity =>
            {
                entity.Property(e => e.GameId)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.TeamAbbreviation)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.League)
                    .WithMany(p => p.AllStar)
                    .HasForeignKey(d => d.LeagueId)
                    .HasConstraintName("FK__AllStar__LeagueI__6319B466");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.AllStar)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AllStar__PersonI__6501FCD8");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.AllStar)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__AllStar__TeamId__640DD89F");
            });

            modelBuilder.Entity<Appearances>(entity =>
            {
                entity.HasIndex(e => new { e.Year, e.TeamId, e.PersonId })
                    .HasName("UC_Appearances")
                    .IsUnique();

                entity.Property(e => e.TeamAbbreviation)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.League)
                    .WithMany(p => p.Appearances)
                    .HasForeignKey(d => d.LeagueId)
                    .HasConstraintName("FK__Appearanc__Leagu__65F62111");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Appearances)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appearanc__Perso__67DE6983");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Appearances)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__Appearanc__TeamI__66EA454A");
            });

            modelBuilder.Entity<Award>(entity =>
            {
                entity.HasIndex(e => new { e.PersonId, e.AwardName, e.Year, e.LeagueId })
                    .HasName("UC_Award")
                    .IsUnique();

                entity.Property(e => e.AwardName)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.League)
                    .WithMany(p => p.Award)
                    .HasForeignKey(d => d.LeagueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Award__LeagueId__68D28DBC");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Award)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Award__PersonId__69C6B1F5");
            });

            modelBuilder.Entity<AwardVoting>(entity =>
            {
                entity.HasIndex(e => new { e.PersonId, e.AwardName, e.Year, e.LeagueId })
                    .HasName("UC_AwardVoting")
                    .IsUnique();

                entity.Property(e => e.AwardName)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.League)
                    .WithMany(p => p.AwardVoting)
                    .HasForeignKey(d => d.LeagueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AwardVoti__Leagu__6ABAD62E");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.AwardVoting)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AwardVoti__Perso__6BAEFA67");
            });

            modelBuilder.Entity<BattingPostseasonRound>(entity =>
            {
                entity.HasIndex(e => new { e.Year, e.Round, e.PersonId })
                    .HasName("UC_BattingPostseasonRound")
                    .IsUnique();

                entity.Property(e => e.Round)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TeamAbbreviation)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.League)
                    .WithMany(p => p.BattingPostseasonRound)
                    .HasForeignKey(d => d.LeagueId)
                    .HasConstraintName("FK__BattingPo__Leagu__6CA31EA0");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.BattingPostseasonRound)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingPo__Perso__6E8B6712");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.BattingPostseasonRound)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__BattingPo__TeamI__6D9742D9");
            });

            modelBuilder.Entity<BattingStint>(entity =>
            {
                entity.HasIndex(e => new { e.PersonId, e.Year, e.Stint })
                    .HasName("UC_BattingStint")
                    .IsUnique();

                entity.Property(e => e.OnBasePercentage).HasComputedColumnSql("(case when ((([AtBats]+[Walks])+[HitByPitch])+[SacrificeFlies])=(0) then (0) else (([Hits]+[Walks])+[HitByPitch])/((([AtBats]+[Walks])+[HitByPitch])+[SacrificeFlies]) end)");

                entity.Property(e => e.OnBasePlusSlugging).HasComputedColumnSql("(case when [AtBats]=(0) OR ((([AtBats]+[Walks])+[HitByPitch])+[SacrificeFlies])=(0) then (0) else (([Hits]+[Walks])+[HitByPitch])/((([AtBats]+[Walks])+[HitByPitch])+[SacrificeFlies])+((([Hits]+[Doubles])+(2)*[Triples])+(3)*[HomeRuns])/[AtBats] end)");

                entity.Property(e => e.SluggingPercentage).HasComputedColumnSql("(case when [AtBats]=(0) then (0) else ((([Hits]+[Doubles])+(2)*[Triples])+(3)*[HomeRuns])/[AtBats] end)");

                entity.Property(e => e.TeamAbbreviation)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.League)
                    .WithMany(p => p.BattingStint)
                    .HasForeignKey(d => d.LeagueId)
                    .HasConstraintName("FK__BattingSt__Leagu__40C49C62");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.BattingStint)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingSt__Perso__42ACE4D4");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.BattingStint)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__BattingSt__TeamI__41B8C09B");
            });

            modelBuilder.Entity<CollegeStint>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.CollegeStint)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CollegeSt__Perso__44952D46");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.CollegeStint)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK__CollegeSt__Schoo__43A1090D");
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.HasIndex(e => new { e.DivisionAbbreviation, e.LeagueId })
                    .HasName("UC_Division")
                    .IsUnique();

                entity.Property(e => e.DivisionAbbreviation)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DivisionName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.League)
                    .WithMany(p => p.Division)
                    .HasForeignKey(d => d.LeagueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Division__League__4589517F");
            });

            modelBuilder.Entity<FieldingOutfieldStint>(entity =>
            {
                entity.HasIndex(e => new { e.PersonId, e.Year, e.Stint })
                    .HasName("UC_FieldingOutfieldStint")
                    .IsUnique();

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.FieldingOutfieldStint)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FieldingO__Perso__467D75B8");
            });

            modelBuilder.Entity<FieldingPostseasonRound>(entity =>
            {
                entity.HasIndex(e => new { e.PersonId, e.Year, e.Round, e.Position })
                    .HasName("UC_FieldingPostseasonRound")
                    .IsUnique();

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Round)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TeamAbbreviation)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.League)
                    .WithMany(p => p.FieldingPostseasonRound)
                    .HasForeignKey(d => d.LeagueId)
                    .HasConstraintName("FK__FieldingP__Leagu__477199F1");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.FieldingPostseasonRound)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FieldingP__Perso__4959E263");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.FieldingPostseasonRound)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__FieldingP__TeamI__4865BE2A");
            });

            modelBuilder.Entity<FieldingStint>(entity =>
            {
                entity.HasIndex(e => new { e.PersonId, e.Year, e.Stint, e.Position })
                    .HasName("UC_FieldingStint")
                    .IsUnique();

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.TeamAbbreviation)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.League)
                    .WithMany(p => p.FieldingStint)
                    .HasForeignKey(d => d.LeagueId)
                    .HasConstraintName("FK__FieldingS__Leagu__4A4E069C");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.FieldingStint)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FieldingS__Perso__4C364F0E");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.FieldingStint)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__FieldingS__TeamI__4B422AD5");
            });

            modelBuilder.Entity<Franchise>(entity =>
            {
                entity.Property(e => e.FranchiseAbbreviation)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.FranchiseName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NationalAssociation)
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HallOfFameMember>(entity =>
            {
                entity.HasIndex(e => new { e.PersonId, e.Year, e.VotedBy })
                    .HasName("UC_HallOfFameMember")
                    .IsUnique();

                entity.Property(e => e.Category)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.NeededNote)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.VotedBy)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.HallOfFameMember)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HallOfFam__Perso__4D2A7347");
            });

            modelBuilder.Entity<League>(entity =>
            {
                entity.Property(e => e.LeagueAbbreviation)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.LeagueName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ManagerStint>(entity =>
            {
                entity.HasIndex(e => new { e.Year, e.TeamAbbreviation, e.InSeason })
                    .HasName("UC_ManagerStint")
                    .IsUnique();

                entity.Property(e => e.TeamAbbreviation)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.League)
                    .WithMany(p => p.ManagerStint)
                    .HasForeignKey(d => d.LeagueId)
                    .HasConstraintName("FK__ManagerSt__Leagu__4E1E9780");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.ManagerStint)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__ManagerSt__Perso__5006DFF2");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.ManagerStint)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__ManagerSt__TeamI__4F12BBB9");
            });

            modelBuilder.Entity<Park>(entity =>
            {
                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParkAlias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParkKey)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParkName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ParkStint>(entity =>
            {
                entity.Property(e => e.ParkKey)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SpanFirst)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SpanFirstDate).HasColumnType("date");

                entity.Property(e => e.SpanLast)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SpanLastDate).HasColumnType("date");

                entity.Property(e => e.TeamAbbreviation)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.League)
                    .WithMany(p => p.ParkStint)
                    .HasForeignKey(d => d.LeagueId)
                    .HasConstraintName("FK__ParkStint__Leagu__50FB042B");

                entity.HasOne(d => d.Park)
                    .WithMany(p => p.ParkStint)
                    .HasForeignKey(d => d.ParkId)
                    .HasConstraintName("FK__ParkStint__ParkI__52E34C9D");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.ParkStint)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__ParkStint__TeamI__51EF2864");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Bats)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BbrefId)
                    .HasColumnName("BBRefId")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BirthCity)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BirthCountry)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.BirthState)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeathCity)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeathCountry)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeathDate).HasColumnType("date");

                entity.Property(e => e.DeathState)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Debut)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DebutDate).HasColumnType("date");

                entity.Property(e => e.FinalGame)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FinalGameDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GivenName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PersonIdentifier)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RetroId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Throws)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PitchingPostseasonRound>(entity =>
            {
                entity.HasIndex(e => new { e.PersonId, e.Year, e.Round })
                    .HasName("UC_PitchingPostseasonRound")
                    .IsUnique();

                entity.Property(e => e.Round)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TeamAbbreviation)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.League)
                    .WithMany(p => p.PitchingPostseasonRound)
                    .HasForeignKey(d => d.LeagueId)
                    .HasConstraintName("FK__PitchingP__Leagu__53D770D6");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PitchingPostseasonRound)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PitchingP__Perso__55BFB948");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.PitchingPostseasonRound)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__PitchingP__TeamI__54CB950F");
            });

            modelBuilder.Entity<PitchingStint>(entity =>
            {
                entity.HasIndex(e => new { e.PersonId, e.Year, e.Stint })
                    .HasName("UC_PitchingStint")
                    .IsUnique();

                entity.Property(e => e.TeamAbbreviation)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.WalksAndHitsPerInningsPitched).HasComputedColumnSql("(case when [InningsPitchedOuts]=(0) then (0) else (([Walks]+[Hits])/[InningsPitchedOuts])/(3) end)");

                entity.Property(e => e.WalksAndHitsPerInningsPitchedPlusEarnedRunAverage).HasComputedColumnSql("(case when [InningsPitchedOuts]=(0) then (0) else (([Walks]+[Hits])/[InningsPitchedOuts])/(3)+[EarnedRunAverage] end)");

                entity.HasOne(d => d.League)
                    .WithMany(p => p.PitchingStint)
                    .HasForeignKey(d => d.LeagueId)
                    .HasConstraintName("FK__PitchingS__Leagu__56B3DD81");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PitchingStint)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PitchingS__Perso__589C25F3");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.PitchingStint)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__PitchingS__TeamI__57A801BA");
            });

            modelBuilder.Entity<PostseasonSeries>(entity =>
            {
                entity.HasIndex(e => new { e.Year, e.Round })
                    .HasName("UC_PostseasonSeries")
                    .IsUnique();

                entity.Property(e => e.LosingTeamAbbreviation)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Round)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.WinningTeamAbbreviation)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.LosingTeam)
                    .WithMany(p => p.PostseasonSeriesLosingTeam)
                    .HasForeignKey(d => d.LosingTeamId)
                    .HasConstraintName("FK__Postseaso__Losin__5C6CB6D7");

                entity.HasOne(d => d.LosingTeamLeague)
                    .WithMany(p => p.PostseasonSeriesLosingTeamLeague)
                    .HasForeignKey(d => d.LosingTeamLeagueId)
                    .HasConstraintName("FK__Postseaso__Losin__5A846E65");

                entity.HasOne(d => d.WinningTeam)
                    .WithMany(p => p.PostseasonSeriesWinningTeam)
                    .HasForeignKey(d => d.WinningTeamId)
                    .HasConstraintName("FK__Postseaso__Winni__5B78929E");

                entity.HasOne(d => d.WinningTeamLeague)
                    .WithMany(p => p.PostseasonSeriesWinningTeamLeague)
                    .HasForeignKey(d => d.WinningTeamLeagueId)
                    .HasConstraintName("FK__Postseaso__Winni__59904A2C");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasIndex(e => new { e.Year, e.TeamAbbreviation, e.LeagueId, e.PersonId })
                    .HasName("UC_Salary")
                    .IsUnique();

                entity.Property(e => e.TeamAbbreviation)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.League)
                    .WithMany(p => p.Salary)
                    .HasForeignKey(d => d.LeagueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Salary__LeagueId__5D60DB10");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Salary)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Salary__PersonId__5F492382");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Salary)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__Salary__TeamId__5E54FF49");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.Property(e => e.City)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolStringIdentifier)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(55)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasIndex(e => new { e.Year, e.LeagueId, e.TeamAbbreviation })
                    .HasName("UC_Team")
                    .IsUnique();

                entity.Property(e => e.Bpf).HasColumnName("BPF");

                entity.Property(e => e.DivisionAbbreviation)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fp).HasColumnName("FP");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Park)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Ppf).HasColumnName("PPF");

                entity.Property(e => e.TeamAbbreviation)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TeamIdBr)
                    .HasColumnName("TeamIdBR")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.TeamIdLahman45)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.TeamIdRetro)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName("FK__Team__DivisionId__61316BF4");

                entity.HasOne(d => d.Franchise)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.FranchiseId)
                    .HasConstraintName("FK__Team__FranchiseI__6225902D");

                entity.HasOne(d => d.League)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.LeagueId)
                    .HasConstraintName("FK__Team__LeagueId__603D47BB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
