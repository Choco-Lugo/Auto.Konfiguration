using Auto.Konfiguration.APresentation.Navigation;
using Auto.Konfiguration.APresentation.ViewModels;
using Auto.Konfiguration.BApplication.BusinessLogic;
using Auto.Konfiguration.BApplication.Interface;
using Auto.Konfiguration.Domain.Interfaces;
using Auto.Konfiguration.Infrastructure.Daten;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Auto.Konfiguration
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider? Services { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            //DB
            //using (var db = new AppDbContext())
            //{
            //    db.Database.EnsureCreated();
            //    db.InsertDB();
            //}

            //base.OnStartup(e);

            //var services = new ServiceCollection();

            //// NavigationService
            //services.AddSingleton<INavigationService, NavigationService>();

            //// ViewModels
            //services.AddSingleton<MainWindowModel>();
            //services.AddTransient<CarKonfigurationModel>();
            //services.AddTransient<CarCompleteModel>();

            //// Application Services + Interfaces
            //services.AddTransient<IAppDbContextService, AppDbContext>();
            //services.AddTransient<ICalculatePrice, CalculatePrice>();

            //// UI
            //services.AddSingleton<MainWindow>();

            //Services = services.BuildServiceProvider();

            //var mainWindow = Services.GetRequiredService<MainWindow>();
            //mainWindow.DataContext = Services.GetRequiredService<MainWindowModel>();
            //mainWindow.Show();


            base.OnStartup(e);

            var services = new ServiceCollection();

            //------------------------------------------------
            // DATABASE (gleich wie Blazor)
            //------------------------------------------------
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=carconfig.db"));

            services.AddTransient<IAppDbContextService, AppDbContext>();

            //------------------------------------------------
            // SERVICES
            //------------------------------------------------
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddTransient<ICalculatePrice, CalculatePrice>();

            //------------------------------------------------
            // VIEWMODELS
            //------------------------------------------------
            services.AddSingleton<MainWindowModel>();
            services.AddTransient<CarKonfigurationModel>();
            services.AddTransient<CarCompleteModel>();

            //------------------------------------------------
            // WINDOWS
            //------------------------------------------------
            services.AddSingleton<MainWindow>();

            Services = services.BuildServiceProvider();

            //------------------------------------------------
            // DB ERSTELLEN + SEED
            //------------------------------------------------
            using (var scope = Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                db.Database.EnsureCreated();
                db.InsertDB();
            }

            //------------------------------------------------
            // START APP
            //------------------------------------------------
            var mainWindow = Services.GetRequiredService<MainWindow>();
            mainWindow.DataContext =
                Services.GetRequiredService<MainWindowModel>();

            mainWindow.Show();
        }
    }
}
