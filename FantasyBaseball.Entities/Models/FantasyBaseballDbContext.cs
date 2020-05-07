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
                optionsBuilder.UseSqlServer("Server=.;Database=FantasyBaseballDb;Trusted_Connection=True;");
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
                    .HasConstraintName("FK__AllStar__LeagueI__2C88998B");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.AllStar)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AllStar__PersonI__29AC2CE0");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.AllStar)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__AllStar__TeamId__28B808A7");
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
                    .HasConstraintName("FK__Appearanc__Leagu__2D7CBDC4");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Appearances)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Appearanc__Perso__753864A1");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Appearances)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__Appearanc__TeamI__74444068");
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
                    .HasConstraintName("FK__Award__LeagueId__2E70E1FD");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Award)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Award__PersonId__7720AD13");
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
                    .HasConstraintName("FK__AwardVoti__Leagu__2F650636");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.AwardVoting)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AwardVoti__Perso__7908F585");
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
                    .HasConstraintName("FK__BattingPo__Leagu__30592A6F");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.BattingPostseasonRound)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingPo__Perso__7BE56230");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.BattingPostseasonRound)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__BattingPo__TeamI__7AF13DF7");
            });

            modelBuilder.Entity<BattingStint>(entity =>
            {
                entity.HasIndex(e => new { e.PersonId, e.Year, e.Stint })
                    .HasName("UC_BattingStint")
                    .IsUnique();

                entity.Property(e => e.TeamAbbreviation)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.League)
                    .WithMany(p => p.BattingStint)
                    .HasForeignKey(d => d.LeagueId)
                    .HasConstraintName("FK__BattingSt__Leagu__314D4EA8");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.BattingStint)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BattingSt__Perso__7EC1CEDB");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.BattingStint)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__BattingSt__TeamI__7DCDAAA2");
            });

            modelBuilder.Entity<CollegeStint>(entity =>
            {
                entity.HasOne(d => d.Person)
                    .WithMany(p => p.CollegeStint)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CollegeSt__Perso__00AA174D");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.CollegeStint)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK__CollegeSt__Schoo__7FB5F314");
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
                    .HasConstraintName("FK__Division__League__324172E1");
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
                    .HasConstraintName("FK__FieldingO__Perso__02925FBF");
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
                    .HasConstraintName("FK__FieldingP__Leagu__3335971A");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.FieldingPostseasonRound)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FieldingP__Perso__056ECC6A");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.FieldingPostseasonRound)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__FieldingP__TeamI__047AA831");
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
                    .HasConstraintName("FK__FieldingS__Leagu__3429BB53");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.FieldingStint)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FieldingS__Perso__084B3915");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.FieldingStint)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__FieldingS__TeamI__075714DC");
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
                    .HasConstraintName("FK__HallOfFam__Perso__093F5D4E");
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
                    .HasConstraintName("FK__ManagerSt__Leagu__351DDF8C");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.ManagerStint)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK__ManagerSt__Perso__0C1BC9F9");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.ManagerStint)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__ManagerSt__TeamI__0B27A5C0");
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
                    .HasConstraintName("FK__ParkStint__Leagu__361203C5");

                entity.HasOne(d => d.Park)
                    .WithMany(p => p.ParkStint)
                    .HasForeignKey(d => d.ParkId)
                    .HasConstraintName("FK__ParkStint__ParkI__0EF836A4");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.ParkStint)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__ParkStint__TeamI__0E04126B");
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
                    .HasConstraintName("FK__PitchingP__Leagu__370627FE");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PitchingPostseasonRound)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PitchingP__Perso__11D4A34F");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.PitchingPostseasonRound)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__PitchingP__TeamI__10E07F16");
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

                entity.HasOne(d => d.League)
                    .WithMany(p => p.PitchingStint)
                    .HasForeignKey(d => d.LeagueId)
                    .HasConstraintName("FK__PitchingS__Leagu__37FA4C37");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.PitchingStint)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PitchingS__Perso__14B10FFA");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.PitchingStint)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__PitchingS__TeamI__13BCEBC1");
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
                    .HasConstraintName("FK__Postseaso__Losin__1881A0DE");

                entity.HasOne(d => d.LosingTeamLeague)
                    .WithMany(p => p.PostseasonSeriesLosingTeamLeague)
                    .HasForeignKey(d => d.LosingTeamLeagueId)
                    .HasConstraintName("FK__Postseaso__Losin__39E294A9");

                entity.HasOne(d => d.WinningTeam)
                    .WithMany(p => p.PostseasonSeriesWinningTeam)
                    .HasForeignKey(d => d.WinningTeamId)
                    .HasConstraintName("FK__Postseaso__Winni__178D7CA5");

                entity.HasOne(d => d.WinningTeamLeague)
                    .WithMany(p => p.PostseasonSeriesWinningTeamLeague)
                    .HasForeignKey(d => d.WinningTeamLeagueId)
                    .HasConstraintName("FK__Postseaso__Winni__38EE7070");
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
                    .HasConstraintName("FK__Salary__LeagueId__3AD6B8E2");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Salary)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Salary__PersonId__1B5E0D89");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Salary)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK__Salary__TeamId__1A69E950");
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

                entity.Property(e => e.WonLeague).HasColumnName("WonLEague");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName("FK__Team__DivisionId__1D4655FB");

                entity.HasOne(d => d.Franchise)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.FranchiseId)
                    .HasConstraintName("FK__Team__FranchiseI__1E3A7A34");

                entity.HasOne(d => d.League)
                    .WithMany(p => p.Team)
                    .HasForeignKey(d => d.LeagueId)
                    .HasConstraintName("FK__Team__LeagueId__3BCADD1B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
