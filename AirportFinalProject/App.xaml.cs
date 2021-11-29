using Airport.Data;
using Airport.Services;
using AirportFinalProject.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AirportFinalProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlServer("Server=DESKTOP-EKQUKID;Database=AirportData;Trusted_Connection=True;").Options;
            ProjectContext context = new ProjectContext(options);
            context.Database.Migrate();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(context)
            };
            MainWindow.Show();
        }
    }
}
