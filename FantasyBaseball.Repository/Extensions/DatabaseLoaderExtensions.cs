using System;
using System.Collections.Generic;
using System.Text;
using FantasyBaseball.Entities.Models;

namespace FantasyBaseball.Repository.Extensions
{
    public static class DatabaseLoaderExtensions
    {
        public static T CreateEntity<T>(this string line)
        {
            var objects = line.Split(",");
            switch (typeof(T).FullName)
            {
                case "FantasyBaseball.Entities.Models.AllStar":
                    return (T)Convert.ChangeType(new AllStar
                    {
                        PersonId = int.Parse(objects[0]),
                        Year = short.Parse(objects[1]),
                        GameNumber = short.Parse(objects[2]),
                        GameId = objects[3],
                        TeamAbbreviation = objects[4],
                        TeamId = string.IsNullOrEmpty(objects[5]) == false ? int.Parse(objects[5]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[6]) == false ? int.Parse(objects[6]) : (int?)null,
                        GamesPlayed = string.IsNullOrEmpty(objects[7]) == false ? short.Parse(objects[7]) : (short?)null,
                        StartingPositionId = string.IsNullOrEmpty(objects[8]) == false ? short.Parse(objects[8]) : (short?)null
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.Appearance":
                    return (T)Convert.ChangeType(new Appearances
                    {
                        Year = short.Parse(objects[0]),
                        TeamAbbreviation = objects[1],
                        TeamId = string.IsNullOrEmpty(objects[2]) == false ? int.Parse(objects[2]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[3]) == false ? int.Parse(objects[3]) : (int?)null,
                        PersonId = int.Parse(objects[4]),
                        Games = string.IsNullOrEmpty(objects[5]) == false ? short.Parse(objects[5]) : (short?)null,
                        GamesStarted = string.IsNullOrEmpty(objects[6]) == false ? short.Parse(objects[6]) : (short?)null,
                        GamesBatted = string.IsNullOrEmpty(objects[7]) == false ? short.Parse(objects[7]) : (short?)null,
                        GamesCatcher = string.IsNullOrEmpty(objects[8]) == false ? short.Parse(objects[8]) : (short?)null,
                        GamesFirstBase = string.IsNullOrEmpty(objects[9]) == false ? short.Parse(objects[9]) : (short?)null,
                        GamesSecondBase = string.IsNullOrEmpty(objects[10]) == false ? short.Parse(objects[10]) : (short?)null,
                        GamesThirdBase = string.IsNullOrEmpty(objects[11]) == false ? short.Parse(objects[11]) : (short?)null,
                        GamesShortStop = string.IsNullOrEmpty(objects[12]) == false ? short.Parse(objects[12]) : (short?)null,
                        GamesLeftfield = string.IsNullOrEmpty(objects[13]) == false ? short.Parse(objects[13]) : (short?)null,
                        GamesCenterfield = string.IsNullOrEmpty(objects[14]) == false ? short.Parse(objects[14]) : (short?)null,
                        GamesRightfield = string.IsNullOrEmpty(objects[15]) == false ? short.Parse(objects[15]) : (short?)null,
                        GamesOutfield = string.IsNullOrEmpty(objects[16]) == false ? short.Parse(objects[16]) : (short?)null,
                        GamesDesignatedHitter = string.IsNullOrEmpty(objects[17]) == false ? short.Parse(objects[17]) : (short?)null,
                        GamesPinchHitter = string.IsNullOrEmpty(objects[18]) == false ? short.Parse(objects[18]) : (short?)null,
                        GamesPinchRunner = string.IsNullOrEmpty(objects[19]) == false ? short.Parse(objects[19]) : (short?)null
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.Award":
                    return (T)Convert.ChangeType(new Award
                    {
                        PersonId = int.Parse(objects[0]),
                        AwardName = objects[1],
                        Year = short.Parse(objects[2]),
                        LeagueId = int.Parse(objects[3]),
                        Tie = string.IsNullOrEmpty(objects[4]) == false ? bool.Parse(objects[4]) : (bool?)null,
                        Notes = objects[5]
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.AwardVoting":
                    return (T)Convert.ChangeType(new AwardVoting
                    {
                        AwardName = objects[0],
                        Year = short.Parse(objects[1]),
                        LeagueId = int.Parse(objects[2]),
                        PersonId = int.Parse(objects[3]),
                        PointsWon = string.IsNullOrEmpty(objects[4]) == false ? short.Parse(objects[4]) : (short?)null,
                        PointsMax = string.IsNullOrEmpty(objects[5]) == false ? short.Parse(objects[5]) : (short?)null,
                        VotesFirst = string.IsNullOrEmpty(objects[6]) == false ? short.Parse(objects[6]) : (short?)null,
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.BattingPostseasonRound":
                    return (T)Convert.ChangeType(new BattingPostseasonRound
                    {
                        Year = short.Parse(objects[0]),
                        Round = objects[1],
                        PersonId = int.Parse(objects[2]),
                        TeamAbbreviation = objects[3],
                        TeamId = string.IsNullOrEmpty(objects[4]) == false ? int.Parse(objects[4]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[5]) == false ? int.Parse(objects[5]) : (int?)null,
                        Games = string.IsNullOrEmpty(objects[6]) == false ? short.Parse(objects[6]) : (short?)null,
                        AtBats = string.IsNullOrEmpty(objects[7]) == false ? short.Parse(objects[7]) : (short?)null,
                        Runs = string.IsNullOrEmpty(objects[8]) == false ? short.Parse(objects[8]) : (short?)null,
                        Hits = string.IsNullOrEmpty(objects[9]) == false ? short.Parse(objects[9]) : (short?)null,
                        Doubles = string.IsNullOrEmpty(objects[10]) == false ? short.Parse(objects[10]) : (short?)null,
                        Triples = string.IsNullOrEmpty(objects[11]) == false ? short.Parse(objects[11]) : (short?)null,
                        HomeRuns = string.IsNullOrEmpty(objects[12]) == false ? short.Parse(objects[12]) : (short?)null,
                        RunsBattedIn = string.IsNullOrEmpty(objects[13]) == false ? short.Parse(objects[13]) : (short?)null,
                        StolenBases = string.IsNullOrEmpty(objects[14]) == false ? short.Parse(objects[14]) : (short?)null,
                        CaughtStealing = string.IsNullOrEmpty(objects[15]) == false ? short.Parse(objects[15]) : (short?)null,
                        Walks = string.IsNullOrEmpty(objects[16]) == false ? short.Parse(objects[16]) : (short?)null,
                        Strikeouts = string.IsNullOrEmpty(objects[17]) == false ? short.Parse(objects[17]) : (short?)null,
                        IntentionalWalks = string.IsNullOrEmpty(objects[18]) == false ? short.Parse(objects[18]) : (short?)null,
                        HitByPitch = string.IsNullOrEmpty(objects[19]) == false ? short.Parse(objects[19]) : (short?)null,
                        SacrificeHits = string.IsNullOrEmpty(objects[20]) == false ? short.Parse(objects[20]) : (short?)null,
                        SacrificeFlies = string.IsNullOrEmpty(objects[21]) == false ? short.Parse(objects[21]) : (short?)null,
                        GroundedIntoDoublePlays = string.IsNullOrEmpty(objects[22]) == false ? short.Parse(objects[22]) : (short?)null
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.BattingStint":
                    return (T)Convert.ChangeType(new BattingStint
                    {
                        PersonId = int.Parse(objects[0]),
                        Year = short.Parse(objects[1]),
                        Stint = short.Parse(objects[2]),
                        TeamAbbreviation = objects[3],
                        TeamId = string.IsNullOrEmpty(objects[4]) == false ? int.Parse(objects[4]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[5]) == false ? int.Parse(objects[5]) : (int?)null,
                        Games = short.Parse(objects[6]),
                        GamesBatted = short.Parse(objects[7]),
                        AtBats = short.Parse(objects[8]),
                        Runs = short.Parse(objects[9]),
                        Hits = short.Parse(objects[10]),
                        Doubles = short.Parse(objects[11]),
                        Triples = short.Parse(objects[12]),
                        HomeRuns = short.Parse(objects[13]),
                        RunsBattedIn = short.Parse(objects[14]),
                        StolenBases = short.Parse(objects[15]),
                        CaughtStealing = short.Parse(objects[16]),
                        Walks = short.Parse(objects[17]),
                        Strikeouts = short.Parse(objects[18]),
                        IntentionalWalks = short.Parse(objects[19]),
                        HitByPitch = short.Parse(objects[20]),
                        SacrificeHits = short.Parse(objects[21]),
                        SacrificeFlies = short.Parse(objects[22]),
                        GroundedIntoDoublePlay = short.Parse(objects[23])
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.CollegeStint":
                    return (T)Convert.ChangeType(new CollegeStint
                    {
                        PersonId = int.Parse(objects[0]),
                        SchoolId = string.IsNullOrEmpty(objects[1]) == false ? int.Parse(objects[1]) : (int?)null,
                        Year = string.IsNullOrEmpty(objects[2]) == false ? short.Parse(objects[2]) : (short?)null
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.Division":
                    return (T)Convert.ChangeType(new Division
                    {
                        DivisionAbbreviation = objects[0],
                        LeagueId = int.Parse(objects[1]),
                        DivisionName = objects[2],
                        Active = bool.Parse(objects[3])
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.FieldingOutfieldStint":
                    return (T)Convert.ChangeType(new FieldingOutfieldStint
                    {
                        PersonId = int.Parse(objects[0]),
                        Year = short.Parse(objects[1]),
                        Stint = short.Parse(objects[2]),
                        GamesLeftfield = string.IsNullOrEmpty(objects[3]) == false ? short.Parse(objects[3]) : (short?)null,
                        GamesCenterField = string.IsNullOrEmpty(objects[4]) == false ? short.Parse(objects[4]) : (short?)null,
                        GamesRightField = string.IsNullOrEmpty(objects[5]) == false ? short.Parse(objects[5]) : (short?)null
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.FieldingPostseasonRound":
                    return (T)Convert.ChangeType(new FieldingPostseasonRound
                    {
                        PersonId = int.Parse(objects[0]),
                        Year = short.Parse(objects[1]),
                        TeamAbbreviation = objects[2],
                        TeamId = string.IsNullOrEmpty(objects[3]) == false ? int.Parse(objects[3]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[4]) == false ? int.Parse(objects[4]) : (int?)null,
                        Round = objects[5],
                        Position = objects[6],
                        Games = short.Parse(objects[7]),
                        GamesStarted = short.Parse(objects[8]),
                        InningsPlayedOuts = short.Parse(objects[9]),
                        Putouts = short.Parse(objects[10]),
                        Assists = short.Parse(objects[11]),
                        Errors = short.Parse(objects[12]),
                        DoublePlays = short.Parse(objects[13]),
                        PassedBalls = short.Parse(objects[14]),
                        WildPitches = short.Parse(objects[15]),
                        StolenBases = short.Parse(objects[16]),
                        CaughtStealing = short.Parse(objects[17]),
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.FieldingStint":
                    return (T)Convert.ChangeType(new FieldingStint
                    {
                        PersonId = int.Parse(objects[0]),
                        Year = short.Parse(objects[1]),
                        Stint = short.Parse(objects[2]),
                        TeamAbbreviation = objects[3],
                        TeamId = string.IsNullOrEmpty(objects[4]) == false ? int.Parse(objects[4]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[5]) == false ? int.Parse(objects[5]) : (int?)null,
                        Position = objects[6],
                        Games = short.Parse(objects[7]),
                        GamesStarted = short.Parse(objects[8]),
                        InningsPlayedOuts = short.Parse(objects[9]),
                        Putouts = short.Parse(objects[10]),
                        Assists = short.Parse(objects[11]),
                        Errors = short.Parse(objects[12]),
                        DoublePlays = short.Parse(objects[13]),
                        PassedBalls = short.Parse(objects[14]),
                        WildPitches = short.Parse(objects[15]),
                        StolenBases = short.Parse(objects[16]),
                        CaughtStealing = short.Parse(objects[17]),
                        ZoneRating = short.Parse(objects[18])
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.Franchise":
                    return (T)Convert.ChangeType(new Franchise
                    {
                        FranchiseAbbreviation = objects[0],
                        FranchiseName = objects[1],
                        Active = bool.Parse(objects[2]),
                        NationalAssociation = objects[3]
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.HallOfFameMember":
                    return (T)Convert.ChangeType(new HallOfFameMember
                    {
                        PersonId = int.Parse(objects[0]),
                        Year = short.Parse(objects[1]),
                        VotedBy = objects[2],
                        Ballots = string.IsNullOrEmpty(objects[3]) == false ? short.Parse(objects[3]) : (short?)null,
                        Needed = string.IsNullOrEmpty(objects[4]) == false ? short.Parse(objects[4]) : (short?)null,
                        Votes = string.IsNullOrEmpty(objects[5]) == false ? short.Parse(objects[5]) : (short?)null,
                        Inducted = string.IsNullOrEmpty(objects[6]) == false ? bool.Parse(objects[6]) : (bool?)null,
                        Category = objects[7],
                        NeededNote = objects[8]
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.League":
                    return (T)Convert.ChangeType(new League
                    {
                        LeagueAbbreviation = objects[0],
                        LeagueName = objects[1],
                        Active = bool.Parse(objects[2])
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.ManagerStint":
                    return (T)Convert.ChangeType(new ManagerStint
                    {
                        PersonId = string.IsNullOrEmpty(objects[0]) == false ? int.Parse(objects[0]) : (int?)null,
                        Year = short.Parse(objects[1]),
                        TeamAbbreviation = objects[2],
                        TeamId = string.IsNullOrEmpty(objects[3]) == false ? int.Parse(objects[3]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[4]) == false ? int.Parse(objects[4]) : (int?)null,
                        InSeason = short.Parse(objects[5]),
                        Games = string.IsNullOrEmpty(objects[6]) == false ? short.Parse(objects[6]) : (short?)null,
                        Wins = string.IsNullOrEmpty(objects[7]) == false ? short.Parse(objects[7]) : (short?)null,
                        Losses = string.IsNullOrEmpty(objects[8]) == false ? short.Parse(objects[8]) : (short?)null,
                        TeamRank = string.IsNullOrEmpty(objects[9]) == false ? short.Parse(objects[9]) : (short?)null,
                        PlayerManager = string.IsNullOrEmpty(objects[10]) == false ? bool.Parse(objects[10]) : (bool?)null
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.Park":
                    return (T)Convert.ChangeType(new Park
                    {
                        ParkAlias = objects[0],
                        ParkKey = objects[1],
                        ParkName = objects[2],
                        City = objects[3],
                        State = objects[4],
                        Country = objects[5]
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.ParkStint":
                    return (T)Convert.ChangeType(new ParkStint
                    {
                        Year = string.IsNullOrEmpty(objects[0]) == false ? int.Parse(objects[0]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[1]) == false ? int.Parse(objects[1]) : (int?)null,
                        TeamAbbreviation = objects[2],
                        TeamId = string.IsNullOrEmpty(objects[3]) == false ? int.Parse(objects[3]) : (int?)null,
                        ParkKey = objects[4],
                        ParkId = string.IsNullOrEmpty(objects[5]) == false ? int.Parse(objects[5]) : (int?)null,
                        SpanFirst = objects[6],
                        SpanLast = objects[7],
                        Games = string.IsNullOrEmpty(objects[8]) == false ? int.Parse(objects[8]) : (int?)null,
                        Openings = string.IsNullOrEmpty(objects[9]) == false ? int.Parse(objects[9]) : (int?)null,
                        Attendance = string.IsNullOrEmpty(objects[10]) == false ? int.Parse(objects[10]) : (int?)null,
                        SpanFirstDate = string.IsNullOrEmpty(objects[11]) == false ? DateTime.Parse(objects[11]) : (DateTime?)null,
                        SpanLastDate = string.IsNullOrEmpty(objects[12]) == false ? DateTime.Parse(objects[12]) : (DateTime?)null,
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.Person":
                    return (T)Convert.ChangeType(new Person
                    {
                        PersonIdentifier = objects[0],
                        BirthYear = string.IsNullOrEmpty(objects[1]) == false ? int.Parse(objects[1]) : (int?)null,
                        BirthMonth = string.IsNullOrEmpty(objects[2]) == false ? int.Parse(objects[2]) : (int?)null,
                        BirthDay = string.IsNullOrEmpty(objects[3]) == false ? int.Parse(objects[3]) : (int?)null,
                        BirthCountry = objects[4],
                        BirthState = objects[5],
                        BirthCity = objects[6],
                        DeathYear = string.IsNullOrEmpty(objects[7]) == false ? int.Parse(objects[7]) : (int?)null,
                        DeathMonth = string.IsNullOrEmpty(objects[8]) == false ? int.Parse(objects[8]) : (int?)null,
                        DeathDay = string.IsNullOrEmpty(objects[9]) == false ? int.Parse(objects[9]) : (int?)null,
                        DeathCountry = objects[10],
                        DeathState = objects[11],
                        DeathCity = objects[12],
                        FirstName = objects[13],
                        LastName = objects[14],
                        GivenName = objects[15],
                        Weight = string.IsNullOrEmpty(objects[16]) == false ? int.Parse(objects[16]) : (int?)null,
                        Height = string.IsNullOrEmpty(objects[17]) == false ? int.Parse(objects[17]) : (int?)null,
                        Bats = objects[18],
                        Throws = objects[19],
                        Debut = objects[20],
                        FinalGame = objects[21],
                        RetroId = objects[22],
                        BbrefId = objects[23],
                        BirthDate = string.IsNullOrEmpty(objects[24]) == false ? DateTime.Parse(objects[24]) : (DateTime?)null,
                        DebutDate = string.IsNullOrEmpty(objects[25]) == false ? DateTime.Parse(objects[25]) : (DateTime?)null,
                        FinalGameDate = string.IsNullOrEmpty(objects[26]) == false ? DateTime.Parse(objects[26]) : (DateTime?)null,
                        DeathDate = string.IsNullOrEmpty(objects[27]) == false ? DateTime.Parse(objects[27]) : (DateTime?)null
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.PitchingPostseasonRound":
                    return (T)Convert.ChangeType(new PitchingPostseasonRound
                    {
                        PersonId = int.Parse(objects[0]),
                        Year = short.Parse(objects[1]),
                        Round = objects[2],
                        TeamAbbreviation = objects[3],
                        TeamId = string.IsNullOrEmpty(objects[4]) == false ? int.Parse(objects[4]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[5]) == false ? int.Parse(objects[5]) : (int?)null,
                        Wins = short.Parse(objects[6]),
                        Losses = short.Parse(objects[7]),
                        Games = short.Parse(objects[8]),
                        GamesStarted = short.Parse(objects[9]),
                        CompleteGames = short.Parse(objects[10]),
                        Shutouts = short.Parse(objects[11]),
                        Saves = short.Parse(objects[12]),
                        InningsPitchedOuts = int.Parse(objects[13]),
                        Hits = short.Parse(objects[14]),
                        EarnedRuns = short.Parse(objects[15]),
                        HomeRuns = short.Parse(objects[16]),
                        Walks = short.Parse(objects[17]),
                        Strikeouts = short.Parse(objects[18]),
                        OpponentBattingAverage = double.Parse(objects[19]),
                        EarnedRunAverage = double.Parse(objects[20]),
                        IntentionalWalks = short.Parse(objects[21]),
                        WildPitches = short.Parse(objects[22]),
                        HitBatters = short.Parse(objects[23]),
                        Balks = short.Parse(objects[24]),
                        BattersFaced = short.Parse(objects[25]),
                        GamesFinished = short.Parse(objects[26]),
                        Runs = short.Parse(objects[27]),
                        SacrificeHits = short.Parse(objects[28]),
                        SacrificeFlies = short.Parse(objects[29]),
                        InducedDoublePlays = short.Parse(objects[30])
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.PitchingStint":
                    return (T)Convert.ChangeType(new PitchingStint
                    {
                        PersonId = int.Parse(objects[0]),
                        Year = short.Parse(objects[1]),
                        Stint = short.Parse(objects[2]),
                        TeamAbbreviation = objects[3],
                        TeamId = string.IsNullOrEmpty(objects[4]) == false ? int.Parse(objects[4]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[5]) == false ? int.Parse(objects[5]) : (int?)null,
                        Wins = short.Parse(objects[6]),
                        Losses = short.Parse(objects[7]),
                        Games = short.Parse(objects[8]),
                        GamesStarted = short.Parse(objects[9]),
                        CompleteGames = short.Parse(objects[10]),
                        Shutouts = short.Parse(objects[11]),
                        Saves = short.Parse(objects[12]),
                        InningsPitchedOuts = int.Parse(objects[13]),
                        Hits = short.Parse(objects[14]),
                        EarnedRuns = short.Parse(objects[15]),
                        HomeRuns = short.Parse(objects[16]),
                        Walks = short.Parse(objects[17]),
                        Strikeouts = short.Parse(objects[18]),
                        OpponentBattingAverage = double.Parse(objects[19]),
                        EarnedRunAverage = double.Parse(objects[20]),
                        IntentionalWalks = short.Parse(objects[21]),
                        WildPitches = short.Parse(objects[22]),
                        HitBatters = short.Parse(objects[23]),
                        Balks = short.Parse(objects[24]),
                        BattersFaced = short.Parse(objects[25]),
                        GamesFinished = short.Parse(objects[26]),
                        Runs = short.Parse(objects[27]),
                        SacrificeHits = short.Parse(objects[28]),
                        SacrificeFlies = short.Parse(objects[29]),
                        InducedDoublePlays = short.Parse(objects[30])
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.PostseasonSeries":
                    return (T)Convert.ChangeType(new PostseasonSeries
                    {
                        Year = short.Parse(objects[0]),
                        Round = objects[1],
                        WinningTeamAbbreviation = objects[2],
                        WinningTeamLeagueId = string.IsNullOrEmpty(objects[3]) == false ? int.Parse(objects[3]) : (int?)null,
                        WinningTeamId = string.IsNullOrEmpty(objects[4]) == false ? int.Parse(objects[4]) : (int?)null,
                        LosingTeamAbbreviation = objects[5],
                        LosingTeamId = string.IsNullOrEmpty(objects[6]) == false ? int.Parse(objects[6]) : (int?)null,
                        LosingTeamLeagueId = string.IsNullOrEmpty(objects[7]) == false ? int.Parse(objects[7]) : (int?)null,
                        Wins = string.IsNullOrEmpty(objects[8]) == false ? short.Parse(objects[8]) : (short?)null,
                        Losses = string.IsNullOrEmpty(objects[9]) == false ? short.Parse(objects[9]) : (short?)null,
                        Ties = string.IsNullOrEmpty(objects[10]) == false ? short.Parse(objects[10]) : (short?)null
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.Salary":
                    return (T)Convert.ChangeType(new Salary
                    {
                        Year = short.Parse(objects[0]),
                        TeamAbbreviation = objects[1],
                        TeamId = string.IsNullOrEmpty(objects[2]) == false ? int.Parse(objects[2]) : (int?)null,
                        LeagueId = int.Parse(objects[3]),
                        PersonId = int.Parse(objects[4]),
                        SalaryAmount = string.IsNullOrEmpty(objects[5]) == false ? double.Parse(objects[5]) : (double?)null,
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.School":
                    return (T)Convert.ChangeType(new School
                    {
                        SchoolStringIdentifier = objects[0],
                        SchoolName = objects[1],
                        City = objects[2],
                        State = objects[3],
                        Country = objects[4]
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.Team":
                    return (T)Convert.ChangeType(new Team
                    {
                        Year = short.Parse(objects[0]),
                        LeagueId = string.IsNullOrEmpty(objects[1]) == false ? int.Parse(objects[1]) : (int?)null,
                        TeamAbbreviation = objects[2],
                        FranchiseId = string.IsNullOrEmpty(objects[3]) == false ? int.Parse(objects[3]) : (int?)null,
                        DivisionAbbreviation = objects[4],
                        DivisionId = string.IsNullOrEmpty(objects[5]) == false ? int.Parse(objects[5]) : (int?)null,
                        TeamRank = string.IsNullOrEmpty(objects[6]) == false ? short.Parse(objects[6]) : (short?)null,
                        Games = string.IsNullOrEmpty(objects[7]) == false ? short.Parse(objects[7]) : (short?)null,
                        HomeGames = string.IsNullOrEmpty(objects[8]) == false ? short.Parse(objects[8]) : (short?)null,
                        Wins = string.IsNullOrEmpty(objects[9]) == false ? short.Parse(objects[9]) : (short?)null,
                        Losses = string.IsNullOrEmpty(objects[10]) == false ? short.Parse(objects[10]) : (short?)null,
                        WonDivision = string.IsNullOrEmpty(objects[11]) == false ? bool.Parse(objects[11]) : (bool?)null,
                        WonWildCard = string.IsNullOrEmpty(objects[12]) == false ? bool.Parse(objects[12]) : (bool?)null,
                        WonLeague = string.IsNullOrEmpty(objects[13]) == false ? bool.Parse(objects[13]) : (bool?)null,
                        WonWorldSeries = string.IsNullOrEmpty(objects[14]) == false ? bool.Parse(objects[14]) : (bool?)null,
                        Runs = string.IsNullOrEmpty(objects[15]) == false ? short.Parse(objects[15]) : (short?)null,
                        AtBats = string.IsNullOrEmpty(objects[16]) == false ? short.Parse(objects[16]) : (short?)null,
                        Hits = string.IsNullOrEmpty(objects[17]) == false ? short.Parse(objects[17]) : (short?)null,
                        Doubles = string.IsNullOrEmpty(objects[18]) == false ? short.Parse(objects[18]) : (short?)null,
                        Triples = string.IsNullOrEmpty(objects[19]) == false ? short.Parse(objects[19]) : (short?)null,
                        HomeRuns = string.IsNullOrEmpty(objects[20]) == false ? short.Parse(objects[20]) : (short?)null,
                        Walks = string.IsNullOrEmpty(objects[21]) == false ? short.Parse(objects[21]) : (short?)null,
                        Strikeouts = string.IsNullOrEmpty(objects[22]) == false ? short.Parse(objects[22]) : (short?)null,
                        StolenBases = string.IsNullOrEmpty(objects[23]) == false ? short.Parse(objects[23]) : (short?)null,
                        CaughtStealing = string.IsNullOrEmpty(objects[24]) == false ? short.Parse(objects[24]) : (short?)null,
                        HitByPitch = string.IsNullOrEmpty(objects[25]) == false ? short.Parse(objects[25]) : (short?)null,
                        SacrificeFlies = string.IsNullOrEmpty(objects[26]) == false ? short.Parse(objects[26]) : (short?)null,
                        RunsAllowed = string.IsNullOrEmpty(objects[27]) == false ? short.Parse(objects[27]) : (short?)null,
                        EarnedRuns = string.IsNullOrEmpty(objects[28]) == false ? short.Parse(objects[28]) : (short?)null,
                        EarnedRunAverage = string.IsNullOrEmpty(objects[29]) == false ? double.Parse(objects[29]) : (double?)null,
                        CompleteGames = string.IsNullOrEmpty(objects[30]) == false ? short.Parse(objects[30]) : (short?)null,
                        Shutouts = string.IsNullOrEmpty(objects[31]) == false ? short.Parse(objects[31]) : (short?)null,
                        Saves = string.IsNullOrEmpty(objects[32]) == false ? short.Parse(objects[32]) : (short?)null,
                        InningsPitchedOuts = string.IsNullOrEmpty(objects[33]) == false ? int.Parse(objects[33]) : (int?)null,
                        HitsAllowed = string.IsNullOrEmpty(objects[34]) == false ? short.Parse(objects[34]) : (short?)null,
                        HomeRunsAllowed = string.IsNullOrEmpty(objects[35]) == false ? short.Parse(objects[35]) : (short?)null,
                        WalksAllowed = string.IsNullOrEmpty(objects[36]) == false ? short.Parse(objects[36]) : (short?)null,
                        StrikeoutsPitched = string.IsNullOrEmpty(objects[37]) == false ? short.Parse(objects[37]) : (short?)null,
                        Errors = string.IsNullOrEmpty(objects[38]) == false ? int.Parse(objects[38]) : (int?)null,
                        DoublePlays = string.IsNullOrEmpty(objects[39]) == false ? int.Parse(objects[39]) : (int?)null,
                        Fp = string.IsNullOrEmpty(objects[40]) == false ? double.Parse(objects[40]) : (double?)null,
                        Name = objects[41],
                        Park = objects[42],
                        Attendance = string.IsNullOrEmpty(objects[43]) == false ? int.Parse(objects[43]) : (int?)null,
                        Bpf = string.IsNullOrEmpty(objects[44]) == false ? int.Parse(objects[44]) : (int?)null,
                        Ppf = string.IsNullOrEmpty(objects[45]) == false ? int.Parse(objects[45]) : (int?)null,
                        TeamIdBr = objects[46],
                        TeamIdLahman45 = objects[47],
                        TeamIdRetro = objects[48]
                    }, typeof(T));
                default:
                    throw new ArgumentException($"Type {typeof(T).FullName} is not valid");
            }
        }
    }
}
