using FantasyBaseball.Business.Services;
using GalaSoft.MvvmLight;

namespace FantasyBaseball.UI.ViewModels
{
    public class GameSelectorViewModel : ViewModelBase
    {
        private string _loadingVisibility { get; set; }
        public string LoadingVisibility
        {
            get { return _loadingVisibility; }
            set { _loadingVisibility = value; RaisePropertyChanged("LoadingVisibility"); }
        }

        public IDatabaseLoader DatabaseLoader { get; set; }

        public GameSelectorViewModel(IDatabaseLoader databaseLoader)
        {
            DatabaseLoader = databaseLoader;
            LoadingVisibility = "Hidden";
        }

        public void ToggleLoading()
        {
            LoadingVisibility = LoadingVisibility == "Visible" ? "Hidden" : "Visible";
        }

        public void LoadDatabaseForSingleGame()
        {
            DatabaseLoader.LoadDatabaseForSingleGame();
        }
    }
}
