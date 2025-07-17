using AutoScrewing.Database.Repository;
using AutoScrewing.Dialogue;
using AutoScrewing.Lib;
using Microsoft.Extensions.DependencyInjection;
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
            ServiceCollection services = new ServiceCollection();
            services.addCommonServices();
            ServiceProvider = services.BuildServiceProvider();
            ApplicationConfiguration.Initialize();
            Application.Run(new DashboardForm());
        }
        private static void addCommonServices(this IServiceCollection serviceCollection)
        {
            Type[] types = [typeof(MESHController), typeof(KilewController),typeof(PLCController)];
            for (int i = 0; i < types.Length; i++)
                serviceCollection.AddScoped(types[i]);

        }
        public static IServiceProvider ServiceProvider { get; private set; } = null!;
    }
}