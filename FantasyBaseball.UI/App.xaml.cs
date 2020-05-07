using FantasyBaseball.Business.Services;
using FantasyBaseball.Repository;
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
            services.AddSingleton<IPlayerSearchServiceFactory, PlayerSearchServiceFactory>();
            services.AddSingleton<IBattingStintRepository, BattingStintRepository>();
            services.AddSingleton<IPitchingStintRepository, PitchingStintRepository>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = ServiceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
