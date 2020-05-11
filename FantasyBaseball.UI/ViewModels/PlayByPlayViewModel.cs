namespace FantasyBaseball.UI.ViewModels
{
    public class PlayByPlayViewModel
    {
        public string Play { get; set; }

        public int Inning { get; set; }

        public int Outs { get; set; }

        public string Score { get; set; }

        public PlayByPlayViewModel(string play, int inning, int outs, string score)
        {
            Play = play;
            Inning = inning;
            Outs = outs;
            Score = score;
        }
    }
}
