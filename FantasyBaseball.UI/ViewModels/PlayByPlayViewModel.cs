using System.Drawing;

namespace FantasyBaseball.UI.ViewModels
{
    public class PlayByPlayViewModel
    {
        public string Play { get; set; }

        public string InningString { get; set; }

        public int Outs { get; set; }

        public string Score { get; set; }

        public string Color { get; set; }

        public PlayByPlayViewModel(string play, string inningString, int outs, string score, string color)
        {
            Play = play;
            InningString = inningString;
            Outs = outs;
            Score = score;
            Color = color;
        }
    }
}
