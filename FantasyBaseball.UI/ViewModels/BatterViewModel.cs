using FantasyBaseball.Entities.Models;
using GalaSoft.MvvmLight;
using System;

namespace FantasyBaseball.UI.ViewModels
{
    public class BatterViewModel : ViewModelBase, IPlayerViewModel
    {
        public int StintId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public short Year { get; set; }

        public string TeamShortName { get; set; }

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

        public double BattingAverage => AtBats > 0 ? Math.Round(Hits / (double)AtBats, 3) : .000;

        public double OnBasePercentage => AtBats > 0 ? Math.Round((Hits + Walks + HitByPitch) / (double)AtBats, 3) : .000;

        public double SluggingPercentage => AtBats > 0 ? Math.Round((Hits + Doubles + Triples*2 + HomeRuns*3) / (double)AtBats, 3) : .000;

        public PlayerStint PlayerStint { get; set; }

        public BatterViewModel(PlayerStint playerStint)
        {
            throw new NotImplementedException();
        }

        public int CurrentGameAtBats { get; set; }

        public int CurrentGameHits { get; set; }

        public int CurrentGameRuns { get; set; }

        public int CurrentGameRunsBattedIn { get; set; }

        public int CurrentGameHomeRuns { get; set; }

        public int CurrentGameWalks { get; set; }
    }
}
