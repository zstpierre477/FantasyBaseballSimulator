using FantasyBaseball.Entities.Enums;
using FantasyBaseball.Entities.Helpers;
using FantasyBaseball.Entities.Models;
using GalaSoft.MvvmLight;
using System;
using System.Linq;

namespace FantasyBaseball.UI.ViewModels
{
    public class BatterViewModel : ViewModelBase, IPlayerViewModel
    {
        private string _firstName { get; set; }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; RaisePropertyChanged("PlayerInfoString"); RaisePropertyChanged("FirstName"); }
        }

        private string _lastName { get; set; }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; RaisePropertyChanged("PlayerInfoString"); RaisePropertyChanged("LastName"); }
        }

        private short _year { get; set; }
        public short Year
        {
            get { return _year; }
            set { _year = value; RaisePropertyChanged("PlayerInfoString"); RaisePropertyChanged("Year"); }
        }

        private string _teamShortName { get; set; }
        public string TeamShortName
        {
            get { return _teamShortName; }
            set { _teamShortName = value; RaisePropertyChanged("PlayerInfoString"); RaisePropertyChanged("TeamShortName"); }
        }

        public short Games { get; set; }

        public short AtBats { get; set; }

        public short Runs { get; set; }

        public short Hits { get; set; }

        public short Doubles { get; set; }

        public short Triples { get; set; }

        public short HomeRuns { get; set; }

        public short RunsBattedIn { get; set; }

        public short StolenBases { get; set; }

        public short CaughtStealing { get; set; }

        public short Walks { get; set; }

        public short HitByPitch { get; set; }

        public short SacrificeFlies { get; set; }

        public Handedness BattingHandedness { get; set; }

        private string _battingHand { get; set; }
        public string BattingHand
        {
            get { return _battingHand; }
            set
            {
                _battingHand = value; RaisePropertyChanged("BattingHand");
                BattingHandedness = HandednessHelperFunctions.StringToHandedness(_battingHand);
                RaisePropertyChanged("BattingHandedness");
            }
        }

        public double BattingAverage => AtBats > 0 ? Math.Round(Hits / (double)AtBats, 3) : .000;

        public double OnBasePercentage { get; set; }

        public double SluggingPercentage { get; set; }

        public double OnBasePlusSlugging { get; set; }

        public PlayerStint PlayerStint { get; set; }

        public BatterViewModel(PlayerStint playerStint)
        {
            PlayerStint = playerStint;
            FirstName = playerStint.Person.FirstName;
            LastName = playerStint.Person.LastName;
            Year = playerStint.BattingStint.Year;
            TeamShortName = playerStint.Team.TeamIdBr;
            Games = playerStint.BattingStint.Games;
            AtBats = playerStint.BattingStint.AtBats;
            Runs = playerStint.BattingStint.Runs;
            Hits = playerStint.BattingStint.Hits;
            Doubles = playerStint.BattingStint.Doubles;
            Triples = playerStint.BattingStint.Triples;
            HomeRuns = playerStint.BattingStint.HomeRuns;
            RunsBattedIn = playerStint.BattingStint.RunsBattedIn;
            StolenBases = playerStint.BattingStint.StolenBases;
            CaughtStealing = playerStint.BattingStint.CaughtStealing;
            Walks = playerStint.BattingStint.Walks;
            HitByPitch = playerStint.BattingStint.HitByPitch;
            SacrificeFlies = playerStint.BattingStint.SacrificeFlies;
            BattingHand = playerStint.Person.Bats;
            OnBasePercentage = playerStint.BattingStint.OnBasePercentage ?? .000;
            SluggingPercentage = playerStint.BattingStint.SluggingPercentage ?? .000;
            OnBasePlusSlugging = playerStint.BattingStint.OnBasePlusSlugging ?? .000;
            RaisePropertyChanged("PlayerInfoString");
            RemovedFromGame = false;
        }

        private int _currentGameAtBats { get; set; }
        public int CurrentGameAtBats
        {
            get { return _currentGameAtBats; }
            set { _currentGameAtBats = value; RaisePropertyChanged("CurrentGameAtBats"); }
        }

        private int _currentGameHits { get; set; }
        public int CurrentGameHits
        {
            get { return _currentGameHits; }
            set { _currentGameHits = value; RaisePropertyChanged("CurrentGameHits"); }
        }

        private int _currentGameRuns { get; set; }
        public int CurrentGameRuns
        {
            get { return _currentGameRuns; }
            set { _currentGameRuns = value; RaisePropertyChanged("CurrentGameRuns"); }
        }

        private int _currentGameRunsBattedIn { get; set; }
        public int CurrentGameRunsBattedIn
        {
            get { return _currentGameRunsBattedIn; }
            set { _currentGameRunsBattedIn = value; RaisePropertyChanged("CurrentGameRunsBattedIn"); }
        }

        private int _currentGameHomeRuns { get; set; }
        public int CurrentGameHomeRuns
        {
            get { return _currentGameHomeRuns; }
            set { _currentGameHomeRuns = value; RaisePropertyChanged("CurrentGameHomeRuns"); }
        }

        private int _currentGameWalks { get; set; }
        public int CurrentGameWalks
        {
            get { return _currentGameWalks; }
            set { _currentGameWalks = value; RaisePropertyChanged("CurrentGameWalks"); }
        }

        private int _currentGameErrors { get; set; }
        public int CurrentGameErrors
        {
            get { return _currentGameErrors; }
            set { _currentGameErrors = value; RaisePropertyChanged("CurrentGameErrors"); }
        }

        private int _currentGameStolenBases { get; set; }
        public int CurrentGameStolenBases
        {
            get { return _currentGameStolenBases; }
            set { _currentGameStolenBases = value; RaisePropertyChanged("CurrentGameStolenBases"); }
        }

        public PositionType CurrentGamePositionType { get; private set; }

        private string _currentGamePosition { get; set; }
        public string CurrentGamePosition
        {
            get { return _currentGamePosition; }
            set 
            { 
                _currentGamePosition = value; RaisePropertyChanged("CurrentGamePosition"); 
                CurrentGamePositionType = PositionTypeHelperFunctions.PositionAbbreviationStringToPositionType(_currentGamePosition); 
                RaisePropertyChanged("CurrentGamePositionType"); RaisePropertyChanged("CurrentGamePositionFieldingPercentage");
            }
        }

        private double _currentGamePositionFieldingPercentage => GetCurrentGamePositionFieldingPercentage();
        public double CurrentGamePositionFieldingPercentage
        {
            get { return _currentGamePositionFieldingPercentage; }
        }

        private double GetCurrentGamePositionFieldingPercentage()
        {
            var fp = PlayerStint.FieldingStints.SingleOrDefault(s => s.PositionType == CurrentGamePositionType)?.FieldingPercentage;
            if (fp == null) 
            {
                if (CurrentGamePositionType == PositionType.LeftFielder || CurrentGamePositionType == PositionType.CenterFielder || CurrentGamePositionType == PositionType.RightFielder)
                {
                    fp = PlayerStint.FieldingStints.SingleOrDefault(s => s.PositionType == PositionType.OutFielder)?.FieldingPercentage;
                }
            }
            return fp ?? .000;
        }

        private int? _currentGameLineupIndex { get; set; }
        public int? CurrentGameLineupIndex
        {
            get { return _currentGameLineupIndex; }
            set { _currentGameLineupIndex = value; RaisePropertyChanged("CurrentGameBattingOrder"); }
        }

        public int? CurrentGameBattingOrder
        {
            get { return _currentGameLineupIndex + 1; }
        }

        public int? CurrentGameBenchIndex { get; set; }

        public bool RemovedFromGame { get; set; }

        public string _allPositionsString => GetAllPositionsString();
        public string AllPositionsString
        {
            get { return _allPositionsString; }
        }

        private string GetAllPositionsString()
        {
            var allPositions = "";
            foreach(var f in PlayerStint.FieldingStints)
            {
                allPositions += f.Position + " ";
            }
            if (string.IsNullOrWhiteSpace(allPositions))
            {
                return "None";
            }
            return allPositions.Trim();
        }

        public string _allPositionsAndFieldingPercentageString => GetAllPositionsAndFieldingPercentageString();
        public string AllPositionsAndFieldingPercentageString
        {
            get { return _allPositionsAndFieldingPercentageString; }
        }

        private string GetAllPositionsAndFieldingPercentageString()
        {
            var allPositions = "";
            foreach (var f in PlayerStint.FieldingStints)
            {
                allPositions += f.Position + ": " + f.FieldingPercentage + " ";
            }
            if (string.IsNullOrWhiteSpace(allPositions))
            {
                return "None";
            }
            return allPositions.Trim();
        }

        public string _playerInfoString => $"{FirstName} {LastName} {Year} {TeamShortName}";
        public string PlayerInfoString
        {
            get { return _playerInfoString; }
        }
    }
}
