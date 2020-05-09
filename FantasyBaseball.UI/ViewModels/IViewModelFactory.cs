using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.ComponentModel;

namespace FantasyBaseball.UI.ViewModels
{
    public interface IViewModelFactory
    {
        public INotifyPropertyChanged GetViewModel(string viewType, IEnumerable<ViewModelBase> viewModels = null);
    }
}
