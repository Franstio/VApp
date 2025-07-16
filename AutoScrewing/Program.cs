using AutoScrewing.Database.Repository;
using System.Configuration;

namespace AutoScrewing
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            System.Threading.Timer timer = new System.Threading.Timer((_) =>
            {
                LogRepository logRepo = new LogRepository();

            });
            ApplicationConfiguration.Initialize();
            Application.Run(new DashboardForm());
        }
    }
}