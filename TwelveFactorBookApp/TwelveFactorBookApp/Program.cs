using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwelveFactorBookApp
{
    // TODO
    // https://www.c-sharpcorner.com/article/microservice-using-asp-net-core/
    // https://www.c-sharpcorner.com/article/entity-framework-core-with-sql-server-in-docker-container/
    // https://docs.microsoft.com/en-us/archive/msdn-magazine/2019/april/data-points-ef-core-in-a-docker-containerized-app
    // https://docs.microsoft.com/en-us/archive/msdn-magazine/2017/july/data-points-on-the-fly-sql-servers-with-docker
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
