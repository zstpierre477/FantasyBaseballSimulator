using System;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using FantasyBaseball.Business.Services;
using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Linq;

namespace FantasyBaseball.UI.ViewModels
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly IServiceProvider ServiceProvider;

        public ViewModelFactory(IServiceProvider serviceProvider)
        {
            // yay anti-patterns
            ServiceProvider = serviceProvider;
        }

        public INotifyPropertyChanged GetViewModel(string viewType, IEnumerable<ViewModelBase> viewModels = null)
        {
            switch (viewType)
            {
                case "FantasyBaseball.UI.Views.BatterSearchView":
                    return new BatterSearchViewModel(ServiceProvider.GetService<IPlayerSearchServiceFactory>());
                case "FantasyBaseball.UI.Views.PitcherSearchView":
                    return new PitcherSearchViewModel(ServiceProvider.GetService<IPlayerSearchServiceFactory>());
                case "FantasyBaseball.UI.Views.SingleGameSetupView":
                    return new SingleGameSetupViewModel(ServiceProvider.GetService<IRandomPlayerSelectorService>(), ServiceProvider.GetService<IHistoricalTeamService>());
                case "FantasyBaseball.UI.Views.SingleGameView":
                    return new SingleGameViewModel(ServiceProvider.GetService<ISingleGameService>(), viewModels);
                case "FantasyBaseball.UI.Views.SingleGameTeamSelectorView":
                    return new SingleGameTeamSelectorViewModel();
                case "FantasyBaseball.UI.Views.SingleGameTeamLineupEditorView":
                    return new SingleGameTeamLineupEditorViewModel((TeamViewModel)viewModels.First());
                case "FantasyBaseball.UI.Views.SingleGameTeamBullpenEditorView":
                    return new SingleGameTeamBullpenEditorViewModel((TeamViewModel)viewModels.First());
                default:
                    throw new ArgumentOutOfRangeException($"View {viewType} does not have a corresponding View Model");
            }
        }
    }
}
