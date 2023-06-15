using Airports.Data.Service;
using Airports.TestWpf.Data;
using Airports.TestWpf.Services;
using Airports.TestWpf.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Windows;
using YandexAPI.Service;

namespace Airports.TestWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string ZipPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\..\\..\\Tests\\TestConsole\\Airports.zip");
        private static IHost __Host;
        public static IHost Host => __Host 
            ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Host.Services;

        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
            .AddDatabase(host.Configuration.GetSection("Database"))
            .AddReadCsvServices(ZipPath)
            .AddServices()
            .AddViewModels()
            .AddMapYandexServices()
            ;

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;
            using(var scope = Services.CreateScope())
            {
              scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync().Wait();
            }
            base.OnStartup(e);
            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }
    }
}
