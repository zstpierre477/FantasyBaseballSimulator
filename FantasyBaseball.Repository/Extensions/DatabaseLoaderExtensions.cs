using System;
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
                        AllStarId = int.Parse(objects[0]),
                        PersonId = int.Parse(objects[1]),
                        Year = short.Parse(objects[2]),
                        GameNumber = short.Parse(objects[3]),
                        GameId = objects[4],
                        TeamAbbreviation = objects[5],
                        TeamId = string.IsNullOrEmpty(objects[6]) == false ? int.Parse(objects[6]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[7]) == false ? int.Parse(objects[7]) : (int?)null,
                        GamesPlayed = string.IsNullOrEmpty(objects[8]) == false ? short.Parse(objects[8]) : (short?)null,
                        StartingPositionId = string.IsNullOrEmpty(objects[9]) == false ? short.Parse(objects[9]) : (short?)null
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.Appearances":
                    return (T)Convert.ChangeType(new Appearances
                    {
                        AppearancesId = int.Parse(objects[0]),
                        Year = short.Parse(objects[1]),
                        TeamAbbreviation = objects[2],
                        TeamId = string.IsNullOrEmpty(objects[3]) == false ? int.Parse(objects[3]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[4]) == false ? int.Parse(objects[4]) : (int?)null,
                        PersonId = int.Parse(objects[5]),
                        Games = string.IsNullOrEmpty(objects[6]) == false ? short.Parse(objects[6]) : (short?)null,
                        GamesStarted = string.IsNullOrEmpty(objects[7]) == false ? short.Parse(objects[7]) : (short?)null,
                        GamesBatted = string.IsNullOrEmpty(objects[8]) == false ? short.Parse(objects[8]) : (short?)null,
                        GamesCatcher = string.IsNullOrEmpty(objects[9]) == false ? short.Parse(objects[9]) : (short?)null,
                        GamesFirstBase = string.IsNullOrEmpty(objects[10]) == false ? short.Parse(objects[10]) : (short?)null,
                        GamesSecondBase = string.IsNullOrEmpty(objects[11]) == false ? short.Parse(objects[11]) : (short?)null,
                        GamesThirdBase = string.IsNullOrEmpty(objects[12]) == false ? short.Parse(objects[12]) : (short?)null,
                        GamesShortStop = string.IsNullOrEmpty(objects[13]) == false ? short.Parse(objects[13]) : (short?)null,
                        GamesLeftfield = string.IsNullOrEmpty(objects[14]) == false ? short.Parse(objects[14]) : (short?)null,
                        GamesCenterfield = string.IsNullOrEmpty(objects[15]) == false ? short.Parse(objects[15]) : (short?)null,
                        GamesRightfield = string.IsNullOrEmpty(objects[16]) == false ? short.Parse(objects[16]) : (short?)null,
                        GamesOutfield = string.IsNullOrEmpty(objects[17]) == false ? short.Parse(objects[17]) : (short?)null,
                        GamesDesignatedHitter = string.IsNullOrEmpty(objects[18]) == false ? short.Parse(objects[18]) : (short?)null,
                        GamesPinchHitter = string.IsNullOrEmpty(objects[19]) == false ? short.Parse(objects[19]) : (short?)null,
                        GamesPinchRunner = string.IsNullOrEmpty(objects[20]) == false ? short.Parse(objects[20]) : (short?)null
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.Award":
                    return (T)Convert.ChangeType(new Award
                    {
                        AwardId = int.Parse(objects[0]),
                        PersonId = int.Parse(objects[1]),
                        AwardName = objects[2],
                        Year = short.Parse(objects[3]),
                        LeagueId = int.Parse(objects[4]),
                        Tie = string.IsNullOrEmpty(objects[5]) == false && int.Parse(objects[5]) == 1,
                        Notes = objects[6]
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.AwardVoting":
                    return (T)Convert.ChangeType(new AwardVoting
                    {
                        AwardVotingId = int.Parse(objects[0]),
                        AwardName = objects[1],
                        Year = short.Parse(objects[2]),
                        LeagueId = int.Parse(objects[3]),
                        PersonId = int.Parse(objects[4]),
                        PointsWon = string.IsNullOrEmpty(objects[5]) == false ? double.Parse(objects[5]) : (double?)null,
                        PointsMax = string.IsNullOrEmpty(objects[6]) == false ? double.Parse(objects[6]) : (double?)null,
                        VotesFirst = string.IsNullOrEmpty(objects[7]) == false ? double.Parse(objects[7]) : (double?)null,
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.BattingPostseasonRound":
                    return (T)Convert.ChangeType(new BattingPostseasonRound
                    {
                        BattingPostseasonRoundId = int.Parse(objects[0]),
                        Year = short.Parse(objects[1]),
                        Round = objects[2],
                        PersonId = int.Parse(objects[3]),
                        TeamAbbreviation = objects[4],
                        TeamId = string.IsNullOrEmpty(objects[5]) == false ? int.Parse(objects[5]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[6]) == false ? int.Parse(objects[6]) : (int?)null,
                        Games = string.IsNullOrEmpty(objects[7]) == false ? short.Parse(objects[7]) : (short)0,
                        AtBats = string.IsNullOrEmpty(objects[8]) == false ? short.Parse(objects[8]) : (short)0,
                        Runs = string.IsNullOrEmpty(objects[9]) == false ? short.Parse(objects[9]) : (short)0,
                        Hits = string.IsNullOrEmpty(objects[10]) == false ? short.Parse(objects[10]) : (short)0,
                        Doubles = string.IsNullOrEmpty(objects[11]) == false ? short.Parse(objects[11]) : (short)0,
                        Triples = string.IsNullOrEmpty(objects[12]) == false ? short.Parse(objects[12]) : (short)0,
                        HomeRuns = string.IsNullOrEmpty(objects[13]) == false ? short.Parse(objects[13]) : (short)0,
                        RunsBattedIn = string.IsNullOrEmpty(objects[14]) == false ? short.Parse(objects[14]) : (short)0,
                        StolenBases = string.IsNullOrEmpty(objects[15]) == false ? short.Parse(objects[15]) : (short)0,
                        CaughtStealing = string.IsNullOrEmpty(objects[16]) == false ? short.Parse(objects[16]) : (short)0,
                        Walks = string.IsNullOrEmpty(objects[17]) == false ? short.Parse(objects[17]) : (short)0,
                        Strikeouts = string.IsNullOrEmpty(objects[18]) == false ? short.Parse(objects[18]) : (short)0,
                        IntentionalWalks = string.IsNullOrEmpty(objects[19]) == false ? short.Parse(objects[19]) : (short)0,
                        HitByPitch = string.IsNullOrEmpty(objects[20]) == false ? short.Parse(objects[20]) : (short)0,
                        SacrificeHits = string.IsNullOrEmpty(objects[21]) == false ? short.Parse(objects[21]) : (short)0,
                        SacrificeFlies = string.IsNullOrEmpty(objects[22]) == false ? short.Parse(objects[22]) : (short)0,
                        GroundedIntoDoublePlays = string.IsNullOrEmpty(objects[23]) == false ? short.Parse(objects[23]) : (short)0
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.BattingStint":
                    return (T)Convert.ChangeType(new BattingStint
                    {
                        BattingStintId = int.Parse(objects[0]),
                        PersonId = int.Parse(objects[1]),
                        Year = short.Parse(objects[2]),
                        Stint = short.Parse(objects[3]),
                        TeamAbbreviation = objects[4],
                        TeamId = string.IsNullOrEmpty(objects[5]) == false ? int.Parse(objects[5]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[6]) == false ? int.Parse(objects[6]) : (int?)null,
                        Games = string.IsNullOrEmpty(objects[7]) == false ? short.Parse(objects[7]) : (short)0,
                        GamesBatted = string.IsNullOrEmpty(objects[8]) == false ? short.Parse(objects[8]) : (short)0,
                        AtBats = string.IsNullOrEmpty(objects[9]) == false ? short.Parse(objects[9]) : (short)0,
                        Runs = string.IsNullOrEmpty(objects[10]) == false ? short.Parse(objects[10]) : (short)0,
                        Hits = string.IsNullOrEmpty(objects[11]) == false ? short.Parse(objects[11]) : (short)0,
                        Doubles = string.IsNullOrEmpty(objects[12]) == false ? short.Parse(objects[12]) : (short)0,
                        Triples = string.IsNullOrEmpty(objects[13]) == false ? short.Parse(objects[13]) : (short)0,
                        HomeRuns = string.IsNullOrEmpty(objects[14]) == false ? short.Parse(objects[14]) : (short)0,
                        RunsBattedIn = string.IsNullOrEmpty(objects[15]) == false ? short.Parse(objects[15]) : (short)0,
                        StolenBases = string.IsNullOrEmpty(objects[16]) == false ? short.Parse(objects[16]) : (short)0,
                        CaughtStealing = string.IsNullOrEmpty(objects[17]) == false ? short.Parse(objects[17]) : (short)0,
                        Walks = string.IsNullOrEmpty(objects[18]) == false ? short.Parse(objects[18]) : (short)0,
                        Strikeouts = string.IsNullOrEmpty(objects[19]) == false ? short.Parse(objects[19]) : (short)0,
                        IntentionalWalks = string.IsNullOrEmpty(objects[20]) == false ? short.Parse(objects[20]) : (short)0,
                        HitByPitch = string.IsNullOrEmpty(objects[21]) == false ? short.Parse(objects[21]) : (short)0,
                        SacrificeHits = string.IsNullOrEmpty(objects[22]) == false ? short.Parse(objects[22]) : (short)0,
                        SacrificeFlies = string.IsNullOrEmpty(objects[23]) == false ? short.Parse(objects[23]) : (short)0,
                        GroundedIntoDoublePlay = string.IsNullOrEmpty(objects[24]) == false ? short.Parse(objects[24]) : (short)0
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.CollegeStint":
                    return (T)Convert.ChangeType(new CollegeStint
                    {
                        CollegeStintId = int.Parse(objects[0]),
                        PersonId = int.Parse(objects[1]),
                        SchoolId = string.IsNullOrEmpty(objects[2]) == false ? int.Parse(objects[2]) : (int?)null,
                        Year = string.IsNullOrEmpty(objects[3]) == false ? short.Parse(objects[3]) : (short?)null
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.Division":
                    return (T)Convert.ChangeType(new Division
                    {
                        DivisionId = int.Parse(objects[0]),
                        DivisionAbbreviation = objects[1],
                        LeagueId = int.Parse(objects[2]),
                        DivisionName = objects[3],
                        Active = string.IsNullOrEmpty(objects[4]) == false && int.Parse(objects[4]) == 1,
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.FieldingOutfieldStint":
                    return (T)Convert.ChangeType(new FieldingOutfieldStint
                    {
                        FieldingOutfieldStintId = int.Parse(objects[0]),
                        PersonId = int.Parse(objects[1]),
                        Year = short.Parse(objects[2]),
                        Stint = short.Parse(objects[3]),
                        GamesLeftfield = string.IsNullOrEmpty(objects[4]) == false ? short.Parse(objects[4]) : (short?)null,
                        GamesCenterField = string.IsNullOrEmpty(objects[5]) == false ? short.Parse(objects[5]) : (short?)null,
                        GamesRightField = string.IsNullOrEmpty(objects[6]) == false ? short.Parse(objects[6]) : (short?)null
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.FieldingPostseasonRound":
                    return (T)Convert.ChangeType(new FieldingPostseasonRound
                    {
                        FieldingPostseasonRoundId = int.Parse(objects[0]),
                        PersonId = int.Parse(objects[1]),
                        Year = short.Parse(objects[2]),
                        TeamAbbreviation = objects[3],
                        TeamId = string.IsNullOrEmpty(objects[4]) == false ? int.Parse(objects[4]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[5]) == false ? int.Parse(objects[5]) : (int?)null,
                        Round = objects[6],
                        Position = objects[7],
                        Games = string.IsNullOrEmpty(objects[8]) == false ? short.Parse(objects[8]) : (short)0,
                        GamesStarted = string.IsNullOrEmpty(objects[9]) == false ? short.Parse(objects[9]) : (short)0,
                        InningsPlayedOuts = string.IsNullOrEmpty(objects[10]) == false ? short.Parse(objects[10]) : (short)0,
                        Putouts = string.IsNullOrEmpty(objects[11]) == false ? short.Parse(objects[11]) : (short)0,
                        Assists = string.IsNullOrEmpty(objects[12]) == false ? short.Parse(objects[12]) : (short)0,
                        Errors = string.IsNullOrEmpty(objects[13]) == false ? short.Parse(objects[13]) : (short)0,
                        DoublePlays = string.IsNullOrEmpty(objects[14]) == false ? short.Parse(objects[14]) : (short)0,
                        PassedBalls = string.IsNullOrEmpty(objects[15]) == false ? short.Parse(objects[15]) : (short)0,
                        WildPitches = string.IsNullOrEmpty(objects[16]) == false ? short.Parse(objects[16]) : (short)0,
                        StolenBases = string.IsNullOrEmpty(objects[17]) == false ? short.Parse(objects[17]) : (short)0,
                        CaughtStealing = string.IsNullOrEmpty(objects[18]) == false ? short.Parse(objects[18]) : (short)0,
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.FieldingStint":
                    return (T)Convert.ChangeType(new FieldingStint
                    {
                        FieldingStintId = int.Parse(objects[0]),
                        PersonId = int.Parse(objects[1]),
                        Year = short.Parse(objects[2]),
                        Stint = short.Parse(objects[3]),
                        TeamAbbreviation = objects[4],
                        TeamId = string.IsNullOrEmpty(objects[5]) == false ? int.Parse(objects[5]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[6]) == false ? int.Parse(objects[6]) : (int?)null,
                        Position = objects[7],
                        Games = string.IsNullOrEmpty(objects[8]) == false ? short.Parse(objects[8]) : (short)0,
                        GamesStarted = string.IsNullOrEmpty(objects[9]) == false ? short.Parse(objects[9]) : (short)0,
                        InningsPlayedOuts = string.IsNullOrEmpty(objects[10]) == false ? short.Parse(objects[10]) : (short)0,
                        Putouts = string.IsNullOrEmpty(objects[11]) == false ? short.Parse(objects[11]) : (short)0,
                        Assists = string.IsNullOrEmpty(objects[12]) == false ? short.Parse(objects[12]) : (short)0,
                        Errors = string.IsNullOrEmpty(objects[13]) == false ? short.Parse(objects[13]) : (short)0,
                        DoublePlays = string.IsNullOrEmpty(objects[14]) == false ? short.Parse(objects[14]) : (short)0,
                        PassedBalls = string.IsNullOrEmpty(objects[15]) == false ? short.Parse(objects[15]) : (short)0,
                        WildPitches = string.IsNullOrEmpty(objects[16]) == false ? short.Parse(objects[16]) : (short)0,
                        StolenBases = string.IsNullOrEmpty(objects[17]) == false ? short.Parse(objects[17]) : (short)0,
                        CaughtStealing = string.IsNullOrEmpty(objects[18]) == false ? short.Parse(objects[18]) : (short)0,
                        ZoneRating = string.IsNullOrEmpty(objects[19]) == false ? short.Parse(objects[19]) : (short)0
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.Franchise":
                    return (T)Convert.ChangeType(new Franchise
                    {
                        FranchiseId = int.Parse(objects[0]),
                        FranchiseAbbreviation = objects[1],
                        FranchiseName = objects[2],
                        Active = string.IsNullOrEmpty(objects[3]) == false && int.Parse(objects[3]) == 1,
                        NationalAssociation = objects[4]
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.HallOfFameMember":
                    return (T)Convert.ChangeType(new HallOfFameMember
                    {
                        HallOfFameMemberId = int.Parse(objects[0]),
                        PersonId = int.Parse(objects[1]),
                        Year = short.Parse(objects[2]),
                        VotedBy = objects[3],
                        Ballots = string.IsNullOrEmpty(objects[4]) == false ? short.Parse(objects[4]) : (short?)null,
                        Needed = string.IsNullOrEmpty(objects[5]) == false ? short.Parse(objects[5]) : (short?)null,
                        Votes = string.IsNullOrEmpty(objects[6]) == false ? short.Parse(objects[6]) : (short?)null,
                        Inducted = string.IsNullOrEmpty(objects[7]) == false && int.Parse(objects[7]) == 1,
                        Category = objects[8],
                        NeededNote = objects[9]
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.League":
                    return (T)Convert.ChangeType(new League
                    {
                        LeagueId = int.Parse(objects[0]),
                        LeagueAbbreviation = objects[1],
                        LeagueName = objects[2],
                        Active = string.IsNullOrEmpty(objects[3]) == false && int.Parse(objects[3]) == 1,
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.ManagerStint":
                    return (T)Convert.ChangeType(new ManagerStint
                    {
                        ManagerStintId = int.Parse(objects[0]),
                        PersonId = string.IsNullOrEmpty(objects[1]) == false ? int.Parse(objects[1]) : (int?)null,
                        Year = short.Parse(objects[2]),
                        TeamAbbreviation = objects[3],
                        TeamId = string.IsNullOrEmpty(objects[4]) == false ? int.Parse(objects[4]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[5]) == false ? int.Parse(objects[5]) : (int?)null,
                        InSeason = short.Parse(objects[6]),
                        Games = string.IsNullOrEmpty(objects[7]) == false ? short.Parse(objects[7]) : (short?)null,
                        Wins = string.IsNullOrEmpty(objects[8]) == false ? short.Parse(objects[8]) : (short?)null,
                        Losses = string.IsNullOrEmpty(objects[9]) == false ? short.Parse(objects[9]) : (short?)null,
                        TeamRank = string.IsNullOrEmpty(objects[10]) == false ? short.Parse(objects[10]) : (short?)null,
                        PlayerManager = string.IsNullOrEmpty(objects[11]) == false && int.Parse(objects[11]) == 1
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.Park":
                    return (T)Convert.ChangeType(new Park
                    {
                        ParkId = int.Parse(objects[0]),
                        ParkAlias = objects[1],
                        ParkKey = objects[2],
                        ParkName = objects[3],
                        City = objects[4],
                        State = objects[5],
                        Country = objects[6]
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.ParkStint":
                    return (T)Convert.ChangeType(new ParkStint
                    {
                        ParkStintId = int.Parse(objects[0]),
                        Year = string.IsNullOrEmpty(objects[1]) == false ? int.Parse(objects[1]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[2]) == false ? int.Parse(objects[2]) : (int?)null,
                        TeamAbbreviation = objects[3],
                        TeamId = string.IsNullOrEmpty(objects[4]) == false ? int.Parse(objects[4]) : (int?)null,
                        ParkKey = objects[5],
                        ParkId = string.IsNullOrEmpty(objects[6]) == false ? int.Parse(objects[6]) : (int?)null,
                        SpanFirst = objects[7],
                        SpanLast = objects[8],
                        Games = string.IsNullOrEmpty(objects[9]) == false ? int.Parse(objects[9]) : (int?)null,
                        Openings = string.IsNullOrEmpty(objects[10]) == false ? int.Parse(objects[10]) : (int?)null,
                        Attendance = string.IsNullOrEmpty(objects[11]) == false ? int.Parse(objects[11]) : (int?)null,
                        SpanFirstDate = string.IsNullOrEmpty(objects[12]) == false ? DateTime.Parse(objects[12]) : (DateTime?)null,
                        SpanLastDate = string.IsNullOrEmpty(objects[13]) == false ? DateTime.Parse(objects[13]) : (DateTime?)null,
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.Person":
                    return (T)Convert.ChangeType(new Person
                    {
                        PersonId = int.Parse(objects[0]),
                        PersonIdentifier = objects[1],
                        BirthYear = string.IsNullOrEmpty(objects[2]) == false ? int.Parse(objects[2]) : (int?)null,
                        BirthMonth = string.IsNullOrEmpty(objects[3]) == false ? int.Parse(objects[3]) : (int?)null,
                        BirthDay = string.IsNullOrEmpty(objects[4]) == false ? int.Parse(objects[4]) : (int?)null,
                        BirthCountry = objects[5],
                        BirthState = objects[6],
                        BirthCity = objects[7],
                        DeathYear = string.IsNullOrEmpty(objects[8]) == false ? int.Parse(objects[8]) : (int?)null,
                        DeathMonth = string.IsNullOrEmpty(objects[9]) == false ? int.Parse(objects[9]) : (int?)null,
                        DeathDay = string.IsNullOrEmpty(objects[10]) == false ? int.Parse(objects[10]) : (int?)null,
                        DeathCountry = objects[11],
                        DeathState = objects[12],
                        DeathCity = objects[13],
                        FirstName = objects[14],
                        LastName = objects[15],
                        GivenName = objects[16],
                        Weight = string.IsNullOrEmpty(objects[17]) == false ? int.Parse(objects[17]) : (int?)null,
                        Height = string.IsNullOrEmpty(objects[18]) == false ? int.Parse(objects[18]) : (int?)null,
                        Bats = objects[19],
                        Throws = objects[20],
                        Debut = objects[21],
                        FinalGame = objects[22],
                        RetroId = objects[23],
                        BbrefId = objects[24],
                        BirthDate = string.IsNullOrEmpty(objects[25]) == false ? DateTime.Parse(objects[25]) : (DateTime?)null,
                        DebutDate = string.IsNullOrEmpty(objects[26]) == false ? DateTime.Parse(objects[26]) : (DateTime?)null,
                        FinalGameDate = string.IsNullOrEmpty(objects[27]) == false ? DateTime.Parse(objects[27]) : (DateTime?)null,
                        DeathDate = string.IsNullOrEmpty(objects[28]) == false ? DateTime.Parse(objects[28]) : (DateTime?)null
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.PitchingPostseasonRound":
                    return (T)Convert.ChangeType(new PitchingPostseasonRound
                    {
                        PitchingPostseasonRoundId = int.Parse(objects[0]),
                        PersonId = int.Parse(objects[1]),
                        Year = short.Parse(objects[2]),
                        Round = objects[3],
                        TeamAbbreviation = objects[4],
                        TeamId = string.IsNullOrEmpty(objects[5]) == false ? int.Parse(objects[5]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[6]) == false ? int.Parse(objects[6]) : (int?)null,
                        Wins = string.IsNullOrEmpty(objects[7]) == false ? short.Parse(objects[7]) : (short)0,
                        Losses = string.IsNullOrEmpty(objects[8]) == false ? short.Parse(objects[8]) : (short)0,
                        Games = string.IsNullOrEmpty(objects[9]) == false ? short.Parse(objects[9]) : (short)0,
                        GamesStarted = string.IsNullOrEmpty(objects[10]) == false ? short.Parse(objects[10]) : (short)0,
                        CompleteGames = string.IsNullOrEmpty(objects[11]) == false ? short.Parse(objects[11]) : (short)0,
                        Shutouts = string.IsNullOrEmpty(objects[12]) == false ? short.Parse(objects[12]) : (short)0,
                        Saves = string.IsNullOrEmpty(objects[13]) == false ? short.Parse(objects[13]) : (short)0,
                        InningsPitchedOuts = string.IsNullOrEmpty(objects[14]) == false ? int.Parse(objects[14]) : 0,
                        Hits = string.IsNullOrEmpty(objects[15]) == false ? short.Parse(objects[15]) : (short)0,
                        EarnedRuns = string.IsNullOrEmpty(objects[16]) == false ? short.Parse(objects[16]) : (short)0,
                        HomeRuns = string.IsNullOrEmpty(objects[17]) == false ? short.Parse(objects[17]) : (short)0,
                        Walks = string.IsNullOrEmpty(objects[18]) == false ? short.Parse(objects[18]) : (short)0,
                        Strikeouts = string.IsNullOrEmpty(objects[19]) == false ? short.Parse(objects[19]) : (short)0,
                        OpponentBattingAverage = string.IsNullOrEmpty(objects[20]) == false ? double.Parse(objects[20]) : 0,
                        EarnedRunAverage = string.IsNullOrEmpty(objects[21]) == false ? double.Parse(objects[21]) : 0,
                        IntentionalWalks = string.IsNullOrEmpty(objects[22]) == false ? short.Parse(objects[22]) : (short)0,
                        WildPitches = string.IsNullOrEmpty(objects[23]) == false ? short.Parse(objects[23]) : (short)0,
                        HitBatters = string.IsNullOrEmpty(objects[24]) == false ? short.Parse(objects[24]) : (short)0,
                        Balks = string.IsNullOrEmpty(objects[25]) == false ? short.Parse(objects[25]) : (short)0,
                        BattersFaced = string.IsNullOrEmpty(objects[26]) == false ? short.Parse(objects[26]) : (short)0,
                        GamesFinished = string.IsNullOrEmpty(objects[27]) == false ? short.Parse(objects[27]) : (short)0,
                        Runs = string.IsNullOrEmpty(objects[28]) == false ? short.Parse(objects[28]) : (short)0,
                        SacrificeHits = string.IsNullOrEmpty(objects[29]) == false ? short.Parse(objects[29]) : (short)0,
                        SacrificeFlies = string.IsNullOrEmpty(objects[30]) == false ? short.Parse(objects[30]) : (short)0,
                        InducedDoublePlays = string.IsNullOrEmpty(objects[31]) == false ? short.Parse(objects[31]) : (short)0
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.PitchingStint":
                    return (T)Convert.ChangeType(new PitchingStint
                    {
                        PitchingStintId = int.Parse(objects[0]),
                        PersonId = int.Parse(objects[1]),
                        Year = short.Parse(objects[2]),
                        Stint = short.Parse(objects[3]),
                        TeamAbbreviation = objects[4],
                        TeamId = string.IsNullOrEmpty(objects[5]) == false ? int.Parse(objects[5]) : (int?)null,
                        LeagueId = string.IsNullOrEmpty(objects[6]) == false ? int.Parse(objects[6]) : (int?)null,
                        Wins = string.IsNullOrEmpty(objects[7]) == false ? short.Parse(objects[7]) : (short)0,
                        Losses = string.IsNullOrEmpty(objects[8]) == false ? short.Parse(objects[8]) : (short)0,
                        Games = string.IsNullOrEmpty(objects[9]) == false ? short.Parse(objects[9]) : (short)0,
                        GamesStarted = string.IsNullOrEmpty(objects[10]) == false ? short.Parse(objects[10]) : (short)0,
                        CompleteGames = string.IsNullOrEmpty(objects[11]) == false ? short.Parse(objects[11]) : (short)0,
                        Shutouts = string.IsNullOrEmpty(objects[12]) == false ? short.Parse(objects[12]) : (short)0,
                        Saves = string.IsNullOrEmpty(objects[13]) == false ? short.Parse(objects[13]) : (short)0,
                        InningsPitchedOuts = string.IsNullOrEmpty(objects[14]) == false ? int.Parse(objects[14]) : 0,
                        Hits = string.IsNullOrEmpty(objects[15]) == false ? short.Parse(objects[15]) : (short)0,
                        EarnedRuns = string.IsNullOrEmpty(objects[16]) == false ? short.Parse(objects[16]) : (short)0,
                        HomeRuns = string.IsNullOrEmpty(objects[17]) == false ? short.Parse(objects[17]) : (short)0,
                        Walks = string.IsNullOrEmpty(objects[18]) == false ? short.Parse(objects[18]) : (short)0,
                        Strikeouts = string.IsNullOrEmpty(objects[19]) == false ? short.Parse(objects[19]) : (short)0,
                        OpponentBattingAverage = string.IsNullOrEmpty(objects[20]) == false ? double.Parse(objects[20]) : 0,
                        EarnedRunAverage = string.IsNullOrEmpty(objects[21]) == false ? double.Parse(objects[21]) : 0,
                        IntentionalWalks = string.IsNullOrEmpty(objects[22]) == false ? short.Parse(objects[22]) : (short)0,
                        WildPitches = string.IsNullOrEmpty(objects[23]) == false ? short.Parse(objects[23]) : (short)0,
                        HitBatters = string.IsNullOrEmpty(objects[24]) == false ? short.Parse(objects[24]) : (short)0,
                        Balks = string.IsNullOrEmpty(objects[25]) == false ? short.Parse(objects[25]) : (short)0,
                        BattersFaced = string.IsNullOrEmpty(objects[26]) == false ? short.Parse(objects[26]) : (short)0,
                        GamesFinished = string.IsNullOrEmpty(objects[27]) == false ? short.Parse(objects[27]) : (short)0,
                        Runs = string.IsNullOrEmpty(objects[28]) == false ? short.Parse(objects[28]) : (short)0,
                        SacrificeHits = string.IsNullOrEmpty(objects[29]) == false ? short.Parse(objects[29]) : (short)0,
                        SacrificeFlies = string.IsNullOrEmpty(objects[30]) == false ? short.Parse(objects[30]) : (short)0,
                        InducedDoublePlays = string.IsNullOrEmpty(objects[31]) == false ? short.Parse(objects[31]) : (short)0
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.PostseasonSeries":
                    return (T)Convert.ChangeType(new PostseasonSeries
                    {
                        PostseasonSeriesId = int.Parse(objects[0]),
                        Year = short.Parse(objects[1]),
                        Round = objects[2],
                        WinningTeamAbbreviation = objects[3],
                        WinningTeamLeagueId = string.IsNullOrEmpty(objects[4]) == false ? int.Parse(objects[4]) : (int?)null,
                        WinningTeamId = string.IsNullOrEmpty(objects[5]) == false ? int.Parse(objects[5]) : (int?)null,
                        LosingTeamAbbreviation = objects[6],
                        LosingTeamId = string.IsNullOrEmpty(objects[7]) == false ? int.Parse(objects[7]) : (int?)null,
                        LosingTeamLeagueId = string.IsNullOrEmpty(objects[8]) == false ? int.Parse(objects[8]) : (int?)null,
                        Wins = string.IsNullOrEmpty(objects[9]) == false ? short.Parse(objects[9]) : (short?)null,
                        Losses = string.IsNullOrEmpty(objects[10]) == false ? short.Parse(objects[10]) : (short?)null,
                        Ties = string.IsNullOrEmpty(objects[11]) == false ? short.Parse(objects[11]) : (short?)null
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.Salary":
                    return (T)Convert.ChangeType(new Salary
                    {
                        SalaryId = int.Parse(objects[0]),
                        Year = short.Parse(objects[1]),
                        TeamAbbreviation = objects[2],
                        TeamId = string.IsNullOrEmpty(objects[3]) == false ? int.Parse(objects[3]) : (int?)null,
                        LeagueId = int.Parse(objects[4]),
                        PersonId = int.Parse(objects[5]),
                        SalaryAmount = string.IsNullOrEmpty(objects[6]) == false ? double.Parse(objects[6]) : (double?)null,
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.School":
                    return (T)Convert.ChangeType(new School
                    {
                        SchoolId = int.Parse(objects[0]),
                        SchoolStringIdentifier = objects[1],
                        SchoolName = objects[2],
                        City = objects[3],
                        State = objects[4],
                        Country = objects[5]
                    }, typeof(T));
                case "FantasyBaseball.Entities.Models.Team":
                    return (T)Convert.ChangeType(new Team
                    {
                        TeamId = int.Parse(objects[0]),
                        Year = short.Parse(objects[1]),
                        LeagueId = string.IsNullOrEmpty(objects[2]) == false ? int.Parse(objects[2]) : (int?)null,
                        TeamAbbreviation = objects[3],
                        FranchiseId = string.IsNullOrEmpty(objects[4]) == false ? int.Parse(objects[4]) : (int?)null,
                        DivisionAbbreviation = objects[5],
                        DivisionId = string.IsNullOrEmpty(objects[6]) == false ? int.Parse(objects[6]) : (int?)null,
                        TeamRank = string.IsNullOrEmpty(objects[7]) == false ? short.Parse(objects[7]) : (short?)null,
                        Games = string.IsNullOrEmpty(objects[8]) == false ? short.Parse(objects[8]) : (short?)null,
                        HomeGames = string.IsNullOrEmpty(objects[9]) == false ? short.Parse(objects[9]) : (short?)null,
                        Wins = string.IsNullOrEmpty(objects[10]) == false ? short.Parse(objects[10]) : (short?)null,
                        Losses = string.IsNullOrEmpty(objects[11]) == false ? short.Parse(objects[11]) : (short?)null,
                        WonDivision = string.IsNullOrEmpty(objects[12]) == false && int.Parse(objects[12]) == 1,
                        WonWildCard = string.IsNullOrEmpty(objects[13]) == false && int.Parse(objects[13]) == 1,
                        WonLeague = string.IsNullOrEmpty(objects[14]) == false && int.Parse(objects[14]) == 1,
                        WonWorldSeries = string.IsNullOrEmpty(objects[15]) == false && int.Parse(objects[15]) == 1,
                        Runs = string.IsNullOrEmpty(objects[16]) == false ? short.Parse(objects[16]) : (short?)null,
                        AtBats = string.IsNullOrEmpty(objects[17]) == false ? short.Parse(objects[17]) : (short?)null,
                        Hits = string.IsNullOrEmpty(objects[18]) == false ? short.Parse(objects[18]) : (short?)null,
                        Doubles = string.IsNullOrEmpty(objects[19]) == false ? short.Parse(objects[19]) : (short?)null,
                        Triples = string.IsNullOrEmpty(objects[20]) == false ? short.Parse(objects[20]) : (short?)null,
                        HomeRuns = string.IsNullOrEmpty(objects[21]) == false ? short.Parse(objects[21]) : (short?)null,
                        Walks = string.IsNullOrEmpty(objects[22]) == false ? short.Parse(objects[22]) : (short?)null,
                        Strikeouts = string.IsNullOrEmpty(objects[23]) == false ? short.Parse(objects[23]) : (short?)null,
                        StolenBases = string.IsNullOrEmpty(objects[24]) == false ? short.Parse(objects[24]) : (short?)null,
                        CaughtStealing = string.IsNullOrEmpty(objects[25]) == false ? short.Parse(objects[25]) : (short?)null,
                        HitByPitch = string.IsNullOrEmpty(objects[26]) == false ? short.Parse(objects[26]) : (short?)null,
                        SacrificeFlies = string.IsNullOrEmpty(objects[27]) == false ? short.Parse(objects[27]) : (short?)null,
                        RunsAllowed = string.IsNullOrEmpty(objects[28]) == false ? short.Parse(objects[28]) : (short?)null,
                        EarnedRuns = string.IsNullOrEmpty(objects[29]) == false ? short.Parse(objects[29]) : (short?)null,
                        EarnedRunAverage = string.IsNullOrEmpty(objects[30]) == false ? double.Parse(objects[30]) : (double?)null,
                        CompleteGames = string.IsNullOrEmpty(objects[31]) == false ? short.Parse(objects[31]) : (short?)null,
                        Shutouts = string.IsNullOrEmpty(objects[32]) == false ? short.Parse(objects[32]) : (short?)null,
                        Saves = string.IsNullOrEmpty(objects[33]) == false ? short.Parse(objects[33]) : (short?)null,
                        InningsPitchedOuts = string.IsNullOrEmpty(objects[34]) == false ? int.Parse(objects[34]) : (int?)null,
                        HitsAllowed = string.IsNullOrEmpty(objects[35]) == false ? short.Parse(objects[35]) : (short?)null,
                        HomeRunsAllowed = string.IsNullOrEmpty(objects[36]) == false ? short.Parse(objects[36]) : (short?)null,
                        WalksAllowed = string.IsNullOrEmpty(objects[37]) == false ? short.Parse(objects[37]) : (short?)null,
                        StrikeoutsPitched = string.IsNullOrEmpty(objects[38]) == false ? short.Parse(objects[38]) : (short?)null,
                        Errors = string.IsNullOrEmpty(objects[39]) == false ? int.Parse(objects[39]) : (int?)null,
                        DoublePlays = string.IsNullOrEmpty(objects[40]) == false ? int.Parse(objects[40]) : (int?)null,
                        Fp = string.IsNullOrEmpty(objects[41]) == false ? double.Parse(objects[41]) : (double?)null,
                        Name = objects[42],
                        Park = objects[43],
                        Attendance = string.IsNullOrEmpty(objects[44]) == false ? int.Parse(objects[44]) : (int?)null,
                        Bpf = string.IsNullOrEmpty(objects[45]) == false ? int.Parse(objects[45]) : (int?)null,
                        Ppf = string.IsNullOrEmpty(objects[46]) == false ? int.Parse(objects[46]) : (int?)null,
                        TeamIdBr = objects[47],
                        TeamIdLahman45 = objects[48],
                        TeamIdRetro = objects[49]
                    }, typeof(T));
                default:
                    throw new ArgumentException($"Type {typeof(T).FullName} is not valid");
            }
        }
    }
}
