using System;
using System.ComponentModel;

namespace FantasyBaseball.UI.ViewModels
{
    public interface IViewModelFactory
    {
        public INotifyPropertyChanged GetViewModel(string viewType);
    }
}
