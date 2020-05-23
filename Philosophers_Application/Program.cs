using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Philosophers_Application.Data;

namespace Philosophers_Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logConfig =>
                {
                    logConfig.ClearProviders();
                    var configBuild = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddCommandLine(args).Build();
                    logConfig.AddConfiguration(configBuild);
                    logConfig.AddConsole();
                    logConfig.AddDebug();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
