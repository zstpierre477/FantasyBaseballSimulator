using System;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using FantasyBaseball.Business.Services;

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

        public INotifyPropertyChanged GetViewModel(string viewType)
        {
            switch (viewType)
            {
                case "BatterSearch":
                    return new BatterSearchViewModel(ServiceProvider.GetService<IPlayerSearchServiceFactory>());
                case "PitcherSearch":
                    return new PitcherSearchViewModel(ServiceProvider.GetService<IPlayerSearchServiceFactory>());
                case "SingleGameViewModel":

                case "SingleGameTeamSelector":
                    return new SingleGameTeamsModel();
                default:
                    throw new ArgumentOutOfRangeException($"View {viewType} does not have a corresponding View Model");
            }
        }
    }
}
