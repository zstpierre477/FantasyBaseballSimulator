using FantasyBaseball.Entities.Enums;
using FantasyBaseball.Entities.Helpers;
using FantasyBaseball.Entities.Models;
using GalaSoft.MvvmLight;
using System;

namespace FantasyBaseball.UI.ViewModels
{
    public class PitcherViewModel : ViewModelBase, IPlayerViewModel
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

        public Handedness ThrowingHandedness { get; set; }

        private string _throwingHand { get; set; }
        public string ThrowingHand
        {
            get { return _throwingHand; }
            set
            {
                _throwingHand = value; RaisePropertyChanged("ThrowingHand");
                ThrowingHandedness = HandednessHelperFunctions.StringToHandedness(_throwingHand);
                RaisePropertyChanged("ThrowingHandedness");
            }
        }

        public short Wins { get; set; }
        
        public short Losses { get; set; }
        
        public short Games { get; set; }
        
        public short GamesStarted { get; set; }
                
        public short Saves { get; set; }
        
        public int InningsPitchedOuts { get; set; }
        
        public short Hits { get; set; }
        
        public short EarnedRuns { get; set; }
        
        public short HomeRuns { get; set; }
        
        public short Walks { get; set; }
        
        public short Strikeouts { get; set; }
        
        public double OpponentBattingAverage { get; set; }

        public double EarnedRunAverage => Math.Round(((double)EarnedRuns * 9) / IP, 2);
                
        public short HitBatters { get; set; }
                
        public double IP => Math.Round((double)InningsPitchedOuts / 3, 1);

        public double AverageIP => IP / Games;

        public double WHIP => IP > 0 ? Math.Round(((Walks + Hits + HitBatters) / IP), 2) : 0;

        public PlayerStint PlayerStint { get; set; }

        public PitcherViewModel(PlayerStint playerStint)
        {
            PlayerStint = playerStint;
            FirstName = playerStint.Person.FirstName;
            LastName = playerStint.Person.LastName;
            Year = playerStint.PitchingStint.Year;
            TeamShortName = playerStint.Team.TeamIdBr;
            Wins = playerStint.PitchingStint.Wins;
            Losses = playerStint.PitchingStint.Losses;
            Games = playerStint.PitchingStint.Games;
            GamesStarted = playerStint.PitchingStint.GamesStarted;
            Saves = playerStint.PitchingStint.Saves;
            InningsPitchedOuts = playerStint.PitchingStint.InningsPitchedOuts;
            Hits = playerStint.PitchingStint.Hits;
            EarnedRuns = playerStint.PitchingStint.EarnedRuns;
            HomeRuns = playerStint.PitchingStint.HomeRuns;
            Walks = playerStint.PitchingStint.Walks;
            Strikeouts = playerStint.PitchingStint.Strikeouts;
            OpponentBattingAverage = playerStint.PitchingStint.OpponentBattingAverage;
            HitBatters = playerStint.PitchingStint.HitBatters;
            ThrowingHand = playerStint.Person.Throws;
            RaisePropertyChanged("PlayerInfoString");
            RemovedFromGame = false;
        }

        private int _currentGameStrikeouts { get; set; }
        public int CurrentGameStrikeouts
        {
            get { return _currentGameStrikeouts; }
            set { _currentGameStrikeouts = value; RaisePropertyChanged("CurrentGameStrikeouts"); }
        }

        private int _currentGameWalks { get; set; }
        public int CurrentGameWalks
        {
            get { return _currentGameWalks; }
            set { _currentGameWalks = value; RaisePropertyChanged("CurrentGameWalks"); }
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

        private int _currentGameEarnedRuns { get; set; }
        public int CurrentGameEarnedRuns
        {
            get { return _currentGameEarnedRuns; }
            set { _currentGameEarnedRuns = value; RaisePropertyChanged("CurrentGameEarnedRuns"); }
        }

        private int _currentGameErrors { get; set; }
        public int CurrentGameErrors
        {
            get { return _currentGameErrors; }
            set { _currentGameErrors = value; RaisePropertyChanged("CurrentGameErrors"); }
        }

        private int _currentGameInningsPitchedOuts { get; set; }
        public int CurrentGameInningsPitchedOuts
        {
            get { return _currentGameInningsPitchedOuts; }
            set { _currentGameInningsPitchedOuts = value; RaisePropertyChanged("CurrentGameInningsPitched"); RaisePropertyChanged("CurrentGameStatus"); }
        }

        private double _currentGameInningsPitched => Math.Round((double)CurrentGameInningsPitchedOuts / 3, 1);
        public double CurrentGameInningsPitched
        {
            get { return _currentGameInningsPitched; }
        }

        public bool CurrentGameIsTired => CurrentGameInningsPitched > Math.Round(AverageIP, 0, MidpointRounding.ToPositiveInfinity);

        private string _currentGameStatus => CurrentGameIsTired ? "Tired" : "Not Tired";
        public string CurrentGameStatus
        {
            get { return _currentGameStatus; }
        }

        public int? BullpenIndex { get; set; }

        public bool RemovedFromGame { get; set; }

        public string _playerInfoString => $"{FirstName} {LastName} {Year} {TeamShortName}";
        public string PlayerInfoString
        {
            get { return _playerInfoString; }
        }
    }
}
