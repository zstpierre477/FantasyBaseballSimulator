using FantasyBaseball.Business.Services;
using FantasyBaseball.Repository;
using FantasyBaseball.UI.ViewModels;
using FantasyBaseball.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace FantasyBaseball.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public readonly IServiceProvider ServiceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IViewModelFactory, ViewModelFactory>();
            services.AddTransient<IBattingStintRepository, BattingStintRepository>();
            services.AddTransient<IPitchingStintRepository, PitchingStintRepository>();
            services.AddTransient<IPlayerSearchServiceFactory, PlayerSearchServiceFactory>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<ISingleGameService, SingleGameService>();
            services.AddTransient<IRandomPlayerSelectorService, RandomPlayerSelectorService>();
            services.AddTransient<IHistoricalTeamService, HistoricalTeamService>();
            services.AddTransient<IDatabaseLoader, DatabaseLoader>();
            services.AddTransient<IDatabaseLoaderRepository, DatabaseLoaderRepository>();
            services.AddTransient<MainView>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = ServiceProvider.GetService<MainView>();
            mainWindow.Show();
        }
    }
}
