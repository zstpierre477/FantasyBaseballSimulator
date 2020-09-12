CREATE TABLE AllStar (
  AllStarId int NOT NULL IDENTITY(1,1),
  PersonId int NOT NULL,
  Year smallint DEFAULT NULL,
  GameNumber smallint NOT NULL,
  GameId varchar(12) DEFAULT NULL,
  TeamAbbreviation char(3) DEFAULT NULL,
  TeamId int DEFAULT NULL,
  LeagueId int DEFAULT NULL,
  GamesPlayed smallint DEFAULT NULL,
  StartingPositionId smallint DEFAULT NULL,
  PRIMARY KEY (AllStarId),
  FOREIGN KEY (LeagueId) REFERENCES League(LeagueId),
  FOREIGN KEY (TeamId) REFERENCES Team(TeamId),
  FOREIGN KEY (PersonId) REFERENCES Person(PersonId)
);

GO

CREATE TABLE Appearances (
  AppearancesId int NOT NULL IDENTITY(1,1),
  Year smallint NOT NULL,
  TeamAbbreviation char(3) NOT NULL,
  TeamId int DEFAULT NULL,
  LeagueId int DEFAULT NULL,
  PersonId int NOT NULL,
  Games smallint DEFAULT NULL,
  GamesStarted smallint DEFAULT NULL,
  GamesBatted smallint DEFAULT NULL,
  GamesFielded smallint DEFAULT NULL,
  GamesPitcher smallint DEFAULT NULL,
  GamesCatcher smallint DEFAULT NULL,
  GamesFirstBase smallint DEFAULT NULL,
  GamesSecondBase smallint DEFAULT NULL,
  GamesThirdBase smallint DEFAULT NULL,
  GamesShortStop smallint DEFAULT NULL,
  GamesLeftfield smallint DEFAULT NULL,
  GamesCenterfield smallint DEFAULT NULL,
  GamesRightfield smallint DEFAULT NULL,
  GamesOutfield smallint DEFAULT NULL,
  GamesDesignatedHitter smallint DEFAULT NULL,
  GamesPinchHitter smallint DEFAULT NULL,
  GamesPinchRunner smallint DEFAULT NULL,
  PRIMARY KEY (AppearancesId),
  CONSTRAINT UC_Appearances UNIQUE (Year,TeamId,PersonId),
  FOREIGN KEY (LeagueId) REFERENCES League(LeagueId),
  FOREIGN KEY (TeamId) REFERENCES Team(TeamId),
  FOREIGN KEY (PersonId) REFERENCES Person(PersonId)
);

GO

CREATE TABLE Award (
  AwardId int NOT NULL IDENTITY(1,1),
  PersonId int NOT NULL,
  AwardName varchar(75) NOT NULL,
  Year smallint NOT NULL,
  LeagueId int NOT NULL,
  Tie bit DEFAULT NULL,
  Notes varchar(100) DEFAULT NULL,
  PRIMARY KEY (AwardId),
  CONSTRAINT UC_Award UNIQUE (PersonId,AwardName, Year, LeagueId),
  FOREIGN KEY (LeagueId) REFERENCES League(LeagueId),
  FOREIGN KEY (PersonId) REFERENCES Person(PersonId)
);

GO

CREATE TABLE AwardVoting (
  AwardVotingId int NOT NULL IDENTITY(1,1),
  AwardName varchar(25) NOT NULL,
  Year smallint NOT NULL,
  LeagueId int NOT NULL,
  PersonId int NOT NULL,
  PointsWon smallint DEFAULT NULL,
  PointsMax smallint DEFAULT NULL,
  VotesFirst smallint DEFAULT NULL,
  PRIMARY KEY (AwardVotingId),
  CONSTRAINT UC_AwardVoting UNIQUE (PersonId,AwardName,Year,LeagueId),
  FOREIGN KEY (LeagueId) REFERENCES League (LeagueId),
  FOREIGN KEY (PersonId) REFERENCES Person (PersonId)
);

GO

CREATE TABLE BattingStint (
  BattingStintId int NOT NULL IDENTITY(1,1),
  PersonId int NOT NULL,
  Year smallint NOT NULL,
  Stint smallint NOT NULL,
  TeamAbbreviation char(3) DEFAULT NULL,
  TeamId int DEFAULT NULL,
  LeagueId int DEFAULT NULL,
  Games smallint NOT NULL,
  GamesBatted smallint NOT NULL,
  AtBats smallint NOT NULL,
  Runs smallint NOT NULL,
  Hits smallint NOT NULL,
  Doubles smallint NOT NULL,
  Triples smallint NOT NULL,
  HomeRuns smallint NOT NULL,
  RunsBattedIn smallint NOT NULL,
  StolenBases smallint NOT NULL,
  CaughtStealing smallint NOT NULL,
  Walks smallint NOT NULL,
  Strikeouts smallint NOT NULL,
  IntentionalWalks smallint NOT NULL,
  HitByPitch smallint NOT NULL,
  SacrificeHits smallint NOT NULL,
  SacrificeFlies smallint NOT NULL,
  GroundedIntoDoublePlay smallint NOT NULL,
  OnBasePercentage as case when (AtBats+Walks+HitByPitch+SacrificeFlies) = 0 then 0 else (Hits+Walks+HitByPitch)/(AtBats+Walks+HitByPitch+SacrificeFlies) end,
  SluggingPercentage as case when AtBats = 0 then 0	else (Hits+Doubles+(2*Triples)+(3*HomeRuns))/(AtBats) end,
  OnBasePlusSlugging as case when AtBats = 0 or (AtBats+Walks+HitByPitch+SacrificeFlies) = 0 then 0 else ((Hits+Walks+HitByPitch)/(AtBats+Walks+HitByPitch+SacrificeFlies)) + ((Hits+Doubles+(2*Triples)+(3*HomeRuns))/(AtBats)) end,
  PRIMARY KEY (BattingStintId),
  CONSTRAINT UC_BattingStint UNIQUE (PersonId,Year,Stint),
  FOREIGN KEY (LeagueId) REFERENCES League (LeagueId),
  FOREIGN KEY (TeamId) REFERENCES Team (TeamId),
  FOREIGN KEY (PersonId) REFERENCES Person (PersonId)
);

GO

CREATE TABLE BattingPostseasonRound (
  BattingPostseasonRoundId int NOT NULL IDENTITY(1,1),
  Year smallint NOT NULL,
  Round varchar(10) NOT NULL,
  PersonId int NOT NULL,
  TeamAbbreviation char(3) DEFAULT NULL,
  TeamId int DEFAULT NULL,
  LeagueId int DEFAULT NULL,
  Games smallint DEFAULT NULL,
  AtBats smallint DEFAULT NULL,
  Runs smallint DEFAULT NULL,
  Hits smallint DEFAULT NULL,
  Doubles smallint DEFAULT NULL,
  Triples smallint DEFAULT NULL,
  HomeRuns smallint DEFAULT NULL,
  RunsBattedIn smallint DEFAULT NULL,
  StolenBases smallint DEFAULT NULL,
  CaughtStealing smallint DEFAULT NULL,
  Walks smallint DEFAULT NULL,
  Strikeouts smallint DEFAULT NULL,
  IntentionalWalks smallint DEFAULT NULL,
  HitByPitch smallint DEFAULT NULL,
  SacrificeHits smallint DEFAULT NULL,
  SacrificeFlies smallint DEFAULT NULL,
  GroundedIntoDoublePlays smallint DEFAULT NULL,
  PRIMARY KEY (BattingPostseasonRoundId),
  CONSTRAINT UC_BattingPostseasonRound UNIQUE (Year,Round,PersonId),
  FOREIGN KEY (LeagueId) REFERENCES League (LeagueId),
  FOREIGN KEY (TeamId) REFERENCES Team (TeamId),
  FOREIGN KEY (PersonId) REFERENCES Person (PersonId)
);

GO

CREATE TABLE CollegeStint (
  CollegeStintId int NOT NULL IDENTITY(1,1),
  PersonId int NOT NULL,
  SchoolId int DEFAULT NULL,
  Year smallint DEFAULT NULL,
  PRIMARY KEY (CollegeStintId),
  FOREIGN KEY (SchoolId) REFERENCES School (SchoolId),
  FOREIGN KEY (PersonId) REFERENCES Person (PersonId)
);

GO

CREATE TABLE Division (
  DivisionId int NOT NULL IDENTITY(1,1),
  DivisionAbbreviation char(2) NOT NULL,
  LeagueId int NOT NULL,
  DivisionName varchar(50) NOT NULL,
  Active bit NOT NULL,
  PRIMARY KEY (DivisionId),
  CONSTRAINT UC_Division UNIQUE (DivisionAbbreviation,LeagueId),
  FOREIGN KEY (LeagueId) REFERENCES League (LeagueId)
);

GO

CREATE TABLE FieldingStint (
  FieldingStintId int NOT NULL IDENTITY(1,1),
  PersonId int NOT NULL,
  Year smallint NOT NULL,
  Stint smallint NOT NULL,
  TeamAbbreviation char(3) DEFAULT NULL,
  TeamId int DEFAULT NULL,
  LeagueId int DEFAULT NULL,
  Position varchar(2) NOT NULL,
  Games smallint not NULL,
  GamesStarted smallint not NULL,
  InningsPlayedOuts smallint not NULL,
  Putouts smallint not NULL,
  Assists smallint not NULL,
  Errors smallint not NULL,
  DoublePlays smallint not NULL,
  PassedBalls smallint DEFAULT NULL,
  WildPitches smallint DEFAULT NULL,
  StolenBases smallint DEFAULT NULL,
  CaughtStealing smallint DEFAULT NULL,
  ZoneRating smallint DEFAULT NULL,
  PRIMARY KEY (FieldingStintId),
  CONSTRAINT UC_FieldingStint UNIQUE (PersonId,Year,Stint,Position),
  FOREIGN KEY (LeagueId) REFERENCES League (LeagueId),
  FOREIGN KEY (TeamId) REFERENCES Team (TeamId),
  FOREIGN KEY (PersonId) REFERENCES Person (PersonId)
);

GO

CREATE TABLE FieldingOutfieldStint (
  FieldingOutfieldStintId int NOT NULL IDENTITY(1,1),
  PersonId int NOT NULL,
  Year smallint NOT NULL,
  Stint smallint NOT NULL,
  GamesLeftfield smallint DEFAULT NULL,
  GamesCenterField smallint DEFAULT NULL,
  GamesRightField smallint DEFAULT NULL,
  PRIMARY KEY (FieldingOutfieldStintId),
  CONSTRAINT UC_FieldingOutfieldStint UNIQUE (PersonId,Year,Stint),
  FOREIGN KEY (PersonId) REFERENCES Person (PersonId)
);

GO

CREATE TABLE FieldingPostseasonRound (
  FieldingPostseasonRoundId int NOT NULL IDENTITY(1,1),
  PersonId int NOT NULL,
  Year smallint NOT NULL,
  TeamAbbreviation char(3) DEFAULT NULL,
  TeamId int DEFAULT NULL,
  LeagueId int DEFAULT NULL,
  Round varchar(10) NOT NULL,
  Position varchar(2) NOT NULL,
  Games smallint DEFAULT NULL,
  GamesStarted smallint DEFAULT NULL,
  InningsPlayedOuts smallint DEFAULT NULL,
  Putouts smallint DEFAULT NULL,
  Assists smallint DEFAULT NULL,
  Errors smallint DEFAULT NULL,
  DoublePlays smallint DEFAULT NULL,
  PassedBalls smallint DEFAULT NULL,
  WildPitches smallint DEFAULT NULL,
  StolenBases smallint DEFAULT NULL,
  CaughtStealing smallint DEFAULT NULL,
  PRIMARY KEY (FieldingPostseasonRoundId),
  CONSTRAINT UC_FieldingPostseasonRound UNIQUE (PersonId,Year,Round,Position),
  FOREIGN KEY (LeagueId) REFERENCES League (LeagueId),
  FOREIGN KEY (TeamId) REFERENCES Team (TeamId),
  FOREIGN KEY (PersonId) REFERENCES Person (PersonId)
);

GO

CREATE TABLE Franchise (
  FranchiseId int IDENTITY(1,1),
  FranchiseAbbreviation varchar(3) NOT NULL,
  FranchiseName varchar(50) DEFAULT NULL,
  Active bit DEFAULT NULL,
  NationalAssociation varchar(3) DEFAULT NULL,
  PRIMARY KEY (FranchiseId)
);

GO

CREATE TABLE HallOfFameMember (
  HallOfFameMemberId int NOT NULL IDENTITY(1,1),
  PersonId int NOT NULL,
  Year smallint NOT NULL,
  VotedBy varchar(64) NOT NULL,
  Ballots smallint DEFAULT NULL,
  Needed smallint DEFAULT NULL,
  Votes smallint DEFAULT NULL,
  Inducted bit DEFAULT NULL,
  Category varchar(20) DEFAULT NULL,
  NeededNote varchar(25) DEFAULT NULL,
  PRIMARY KEY (HallOfFameMemberId),
  CONSTRAINT UC_HallOfFameMember UNIQUE (PersonId,Year,VotedBy),
  FOREIGN KEY (PersonId) REFERENCES Person (PersonId)
);

GO

CREATE TABLE League (
  LeagueId int IDENTITY(1,1),
  LeagueAbbreviation char(2) NOT NULL,
  LeagueName varchar(50) NOT NULL,
  Active bit NOT NULL,
  PRIMARY KEY (LeagueId)
);

GO

CREATE TABLE ManagerStint (
  ManagerStintId int NOT NULL IDENTITY(1,1),
  PersonId int DEFAULT NULL,
  Year smallint NOT NULL,
  TeamAbbreviation char(3) NOT NULL,
  TeamId int DEFAULT NULL,
  LeagueId int DEFAULT NULL,
  InSeason smallint NOT NULL,
  Games smallint DEFAULT NULL,
  Wins smallint DEFAULT NULL,
  Losses smallint DEFAULT NULL,
  TeamRank smallint DEFAULT NULL,
  PlayerManager bit DEFAULT NULL,
  PRIMARY KEY (ManagerStintId),
  CONSTRAINT UC_ManagerStint UNIQUE (Year,TeamAbbreviation,InSeason),
  FOREIGN KEY (LeagueId) REFERENCES League (LeagueId),
  FOREIGN KEY (TeamId) REFERENCES Team (TeamId),
  FOREIGN KEY (PersonId) REFERENCES Person (PersonId)
);

GO

CREATE TABLE Park (
  ParkId int NOT NULL IDENTITY(1,1),
  ParkAlias varchar(255) DEFAULT NULL,
  ParkKey varchar(255) DEFAULT NULL,
  ParkName varchar(255) DEFAULT NULL,
  City varchar(255) DEFAULT NULL,
  State varchar(255) DEFAULT NULL,
  Country varchar(255) DEFAULT NULL,
  PRIMARY KEY (ParkId)
);

GO

CREATE TABLE ParkStint (
  ParkStintId int NOT NULL IDENTITY(1,1),
  Year int DEFAULT NULL,
  LeagueId int DEFAULT NULL,
  TeamAbbreviation char(3) DEFAULT NULL,
  TeamId int DEFAULT NULL,
  ParkKey varchar(255) DEFAULT NULL,
  ParkId int DEFAULT NULL,
  SpanFirst varchar(255) DEFAULT NULL,
  SpanLast varchar(255) DEFAULT NULL,
  Games int DEFAULT NULL,
  Openings int DEFAULT NULL,
  Attendance int DEFAULT NULL,
  SpanFirstDate date DEFAULT NULL,
  SpanLastDate date DEFAULT NULL,
  PRIMARY KEY (ParkStintId),
  FOREIGN KEY (LeagueId) REFERENCES League (LeagueId),
  FOREIGN KEY (TeamId) REFERENCES Team (TeamId),
  FOREIGN KEY (ParkId) REFERENCES Park (ParkId)
);

GO

CREATE TABLE Person (
  PersonId int NOT NULL IDENTITY(1,1),
  PersonIdentifier varchar(10) NOT NULL,
  BirthYear int DEFAULT NULL,
  BirthMonth int DEFAULT NULL,
  BirthDay int DEFAULT NULL,
  BirthCountry varchar(255) DEFAULT NULL,
  BirthState varchar(255) DEFAULT NULL,
  BirthCity varchar(255) DEFAULT NULL,
  DeathYear int DEFAULT NULL,
  DeathMonth int DEFAULT NULL,
  DeathDay int DEFAULT NULL,
  DeathCountry varchar(255) DEFAULT NULL,
  DeathState varchar(255) DEFAULT NULL,
  DeathCity varchar(255) DEFAULT NULL,
  FirstName varchar(255) DEFAULT NULL,
  LastName varchar(255) DEFAULT NULL,
  GivenName varchar(255) DEFAULT NULL,
  Weight int DEFAULT NULL,
  Height int DEFAULT NULL,
  Bats varchar(255) DEFAULT NULL,
  Throws varchar(255) DEFAULT NULL,
  Debut varchar(255) DEFAULT NULL,
  FinalGame varchar(255) DEFAULT NULL,
  RetroId varchar(255) DEFAULT NULL,
  BBRefId varchar(255) DEFAULT NULL,
  BirthDate date DEFAULT NULL,
  DebutDate date DEFAULT NULL,
  FinalGameDate date DEFAULT NULL,
  DeathDate date DEFAULT NULL,
  PRIMARY KEY (PersonId)
);

GO

CREATE TABLE PitchingStint (
  PitchingStintId int NOT NULL IDENTITY(1,1),
  PersonId int NOT NULL,
  Year smallint NOT NULL,
  Stint smallint NOT NULL,
  TeamAbbreviation char(3) DEFAULT NULL,
  TeamId int DEFAULT NULL,
  LeagueId int DEFAULT NULL,
  Wins smallint not NULL,
  Losses smallint not NULL,
  Games smallint not NULL,
  GamesStarted smallint not NULL,
  CompleteGames smallint not NULL,
  Shutouts smallint not NULL,
  Saves smallint not NULL,
  InningsPitchedOuts int not NULL,
  Hits smallint not NULL,
  EarnedRuns smallint not NULL,
  HomeRuns smallint not NULL,
  Walks smallint not NULL,
  Strikeouts smallint not NULL,
  OpponentBattingAverage float not NULL,
  EarnedRunAverage float not NULL,
  IntentionalWalks smallint not NULL,
  WildPitches smallint not NULL,
  HitBatters smallint not NULL,
  Balks smallint not NULL,
  BattersFaced smallint not NULL,
  GamesFinished smallint not NULL,
  Runs smallint not NULL,
  SacrificeHits smallint not NULL,
  SacrificeFlies smallint not NULL,
  InducedDoublePlays smallint not NULL,
  WalksAndHitsPerInningsPitched as case when InningsPitchedOuts = 0 then 0 else (Walks+Hits)/(InningsPitchedOuts)/3 end,
  WalksAndHitsPerInningsPitchedPlusEarnedRunAverage as case when InningsPitchedOuts = 0 then 0 else (Walks+Hits)/(InningsPitchedOuts)/3 + EarnedRunAverage end,
  PRIMARY KEY (PitchingStintId),
  CONSTRAINT UC_PitchingStint UNIQUE (PersonId,Year,Stint),
  FOREIGN KEY (LeagueId) REFERENCES League (LeagueId),
  FOREIGN KEY (TeamId) REFERENCES Team (TeamId),
  FOREIGN KEY (PersonId) REFERENCES Person (PersonId)
);

GO

CREATE TABLE PitchingPostseasonRound (
  PitchingPostseasonRoundId int NOT NULL IDENTITY(1,1),
  PersonId int NOT NULL,
  Year smallint NOT NULL,
  Round varchar(10) NOT NULL,
  TeamAbbreviation char(3) DEFAULT NULL,
  TeamId int DEFAULT NULL,
  LeagueId int DEFAULT NULL,
  Wins smallint DEFAULT NULL,
  Losses smallint DEFAULT NULL,
  Games smallint DEFAULT NULL,
  GamesStarted smallint DEFAULT NULL,
  CompleteGames smallint DEFAULT NULL,
  Shutouts smallint DEFAULT NULL,
  Saves smallint DEFAULT NULL,
  InningsPitchedOuts int DEFAULT NULL,
  Hits smallint DEFAULT NULL,
  EarnedRuns smallint DEFAULT NULL,
  HomeRuns smallint DEFAULT NULL,
  Walks smallint DEFAULT NULL,
  Strikeouts smallint DEFAULT NULL,
  OpponentBattingAverage float DEFAULT NULL,
  EarnedRunAverage float DEFAULT NULL,
  IntentionalWalks smallint DEFAULT NULL,
  WildPitches smallint DEFAULT NULL,
  HitBatters smallint DEFAULT NULL,
  Balks smallint DEFAULT NULL,
  BattersFaced smallint DEFAULT NULL,
  GamesFinished smallint DEFAULT NULL,
  Runs smallint DEFAULT NULL,
  SacrificeHits smallint DEFAULT NULL,
  SacrificeFlies smallint DEFAULT NULL,
  InducedDoublePlays smallint DEFAULT NULL,
  PRIMARY KEY (PitchingPostseasonRoundId),
  CONSTRAINT UC_PitchingPostseasonRound UNIQUE (PersonId,Year,Round),
  FOREIGN KEY (LeagueId) REFERENCES League(LeagueId),
  FOREIGN KEY (TeamId) REFERENCES Team(TeamId),
  FOREIGN KEY (PersonId) REFERENCES Person(PersonId)
);

GO

CREATE TABLE PostseasonSeries (
  PostseasonSeriesId int NOT NULL IDENTITY(1,1),
  Year smallint NOT NULL,
  Round varchar(5) NOT NULL,
  WinningTeamAbbreviation varchar(3) DEFAULT NULL,
  WinningTeamLeagueId int DEFAULT NULL,
  WinningTeamId int DEFAULT NULL,
  LosingTeamAbbreviation varchar(3) DEFAULT NULL,
  LosingTeamId int DEFAULT NULL,
  LosingTeamLeagueId int DEFAULT NULL,
  Wins smallint DEFAULT NULL,
  Losses smallint DEFAULT NULL,
  Ties smallint DEFAULT NULL,
  PRIMARY KEY (PostseasonSeriesId),
  CONSTRAINT UC_PostseasonSeries UNIQUE (Year,Round),
  FOREIGN KEY (WinningTeamLeagueId) REFERENCES League (LeagueId),
  FOREIGN KEY (LosingTeamLeagueId) REFERENCES League (LeagueId),
  FOREIGN KEY (WinningTeamId) REFERENCES Team (TeamId),
  FOREIGN KEY (LosingTeamId) REFERENCES Team (TeamId)
);

GO

CREATE TABLE Salary (
  SalaryId int NOT NULL IDENTITY(1,1),
  Year smallint NOT NULL,
  TeamAbbreviation char(3) NOT NULL,
  TeamId int DEFAULT NULL,
  LeagueId int NOT NULL,
  PersonId int NOT NULL,
  SalaryAmount float DEFAULT NULL,
  PRIMARY KEY (SalaryId),
  CONSTRAINT UC_Salary UNIQUE (Year,TeamAbbreviation,LeagueId,PersonId),
  FOREIGN KEY (LeagueId) REFERENCES League (LeagueId),
  FOREIGN KEY (TeamId) REFERENCES Team (TeamId),
  FOREIGN KEY (PersonId) REFERENCES Person (PersonId)
);

GO

CREATE TABLE School (
  SchoolId int NOT NULL IDENTITY(1,1),
  SchoolStringIdentifier varchar(15) NOT NULL,
  SchoolName varchar(255) DEFAULT NULL,
  City varchar(55) DEFAULT NULL,
  State varchar(55) DEFAULT NULL,
  Country varchar(55) DEFAULT NULL,
  PRIMARY KEY (SchoolId)
);

GO

CREATE TABLE Team (
  TeamId int NOT NULL IDENTITY(1,1),
  Year smallint NOT NULL,
  LeagueId int DEFAULT NULL,
  TeamAbbreviation char(3) NOT NULL,
  FranchiseId int DEFAULT NULL,
  DivisionAbbreviation char(2) DEFAULT NULL,
  DivisionId int DEFAULT NULL,
  TeamRank smallint DEFAULT NULL,
  Games smallint DEFAULT NULL,
  HomeGames smallint DEFAULT NULL,
  Wins smallint DEFAULT NULL,
  Losses smallint DEFAULT NULL,
  WonDivision bit DEFAULT NULL,
  WonWildCard bit DEFAULT NULL,
  WonLeague bit DEFAULT NULL,
  WonWorldSeries bit DEFAULT NULL,
  Runs smallint DEFAULT NULL,
  AtBats smallint DEFAULT NULL,
  Hits smallint DEFAULT NULL,
  Doubles smallint DEFAULT NULL,
  Triples smallint DEFAULT NULL,
  HomeRuns smallint DEFAULT NULL,
  Walks smallint DEFAULT NULL,
  Strikeouts smallint DEFAULT NULL,
  StolenBases smallint DEFAULT NULL,
  CaughtStealing smallint DEFAULT NULL,
  HitByPitch smallint DEFAULT NULL,
  SacrificeFlies smallint DEFAULT NULL,
  RunsAllowed smallint DEFAULT NULL,
  EarnedRuns smallint DEFAULT NULL,
  EarnedRunAverage float DEFAULT NULL,
  CompleteGames smallint DEFAULT NULL,
  Shutouts smallint DEFAULT NULL,
  Saves smallint DEFAULT NULL,
  InningsPitchedOuts int DEFAULT NULL,
  HitsAllowed smallint DEFAULT NULL,
  HomeRunsAllowed smallint DEFAULT NULL,
  WalksAllowed smallint DEFAULT NULL,
  StrikeoutsPitched smallint DEFAULT NULL,
  Errors int DEFAULT NULL,
  DoublePlays int DEFAULT NULL,
  FP float DEFAULT NULL,
  Name varchar(50) DEFAULT NULL,
  Park varchar(255) DEFAULT NULL,
  Attendance int DEFAULT NULL,
  BPF int DEFAULT NULL,
  PPF int DEFAULT NULL,
  TeamIdBR varchar(3) DEFAULT NULL,
  TeamIdLahman45 varchar(3) DEFAULT NULL,
  TeamIdRetro varchar(3) DEFAULT NULL,
  PRIMARY KEY (TeamId),
  CONSTRAINT UC_Team UNIQUE (Year,LeagueId,TeamAbbreviation),
  FOREIGN KEY (LeagueId) REFERENCES League (LeagueId),
  FOREIGN KEY (DivisionId) REFERENCES Division (DivisionId),
  FOREIGN KEY (FranchiseId) REFERENCES Franchise (FranchiseId)
);