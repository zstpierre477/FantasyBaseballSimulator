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
            services.AddScoped<IViewModelFactory, ViewModelFactory>();
            services.AddScoped<IBattingStintRepository, BattingStintRepository>();
            services.AddSingleton<IPitchingStintRepository, PitchingStintRepository>();
            services.AddSingleton<IPlayerSearchServiceFactory, PlayerSearchServiceFactory>();
            services.AddSingleton<ITeamRepository, TeamRepository>();
            services.AddScoped<ISingleGameService, SingleGameService>();
            services.AddScoped<IRandomPlayerSelectorService, RandomPlayerSelectorService>();
            services.AddScoped<IHistoricalTeamService, HistoricalTeamService>();
            services.AddTransient<MainView>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = ServiceProvider.GetService<MainView>();
            mainWindow.Show();
        }
    }
}
