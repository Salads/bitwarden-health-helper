using Microsoft.Extensions.DependencyInjection;
using PasswordBreachChecker.Services;
using System.Configuration;
using System.Data;
using System.Windows;

namespace PasswordBreachChecker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
        }

        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<IFileSelectorService, FileSelectorNET>();
            services.AddSingleton<IHashService, HashServiceSHA_1>();
            services.AddSingleton<IPasswordBreachCheckService, HaveIBeenPwnedService>();

            return services.BuildServiceProvider();
        }
    }

}
