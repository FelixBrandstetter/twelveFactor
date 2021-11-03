using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TwelveFactorBookApp.DBContexts;
using TwelveFactorBookApp.Extensions;
using Microsoft.Extensions.Logging;

namespace TwelveFactorBookApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().MigrateDatabase<BookContext>().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .ConfigureLogging(logging =>
                 {
                     logging.ClearProviders();
                     logging.AddConsole();
                 })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
