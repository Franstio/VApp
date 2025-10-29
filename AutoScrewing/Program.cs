using AutoScrewing.Database.Models;
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
            //var TransactionRepository = ServiceProvider.GetRequiredService<TransactionRepository>();
            //var item = new TransactionModel() { Scan_ID = "12312", Scan_ID2 = "1920924", OperationId = Settings1.Default.OPERATION_ID, WorkNumber = "BM1131331" };
            //TransactionRepository.CreateTransaction(item).Wait();
            ApplicationConfiguration.Initialize();
            Application.Run(new DashboardForm());
        }
        private static void addCommonServices(this IServiceCollection serviceCollection)
        {
            Type[] types = [typeof(MESHController), typeof(KilewController),typeof(PLCController),typeof(TransactionRepository),typeof(ConfigRepository),typeof(LogRepository),typeof(QtyRepository)];
            for (int i = 0; i < types.Length; i++)
                serviceCollection.AddScoped(types[i]);
            serviceCollection.AddHttpClient().ConfigureHttpClientDefaults(config =>
            {
                config.AddHttpMessageHandler<MESHController.MESH_HTTP_HANDLER>();
            });
            serviceCollection.AddTransient<MESHController.MESH_HTTP_HANDLER>();
        }
        public static IServiceProvider ServiceProvider { get; private set; } = null!;
    }
}