using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Roker.Web.Common.StartupExtensions;
using Serilog;
using System;
using System.IO;

namespace Roker.Permit.Api
{
    public class Program
    {
        public static readonly string Namespace = typeof(Program).Namespace;

        public static readonly string AppName = Namespace.Split(".")[Namespace.Split(".").Length - 1];

        public static IConfiguration Configuration { get; set; }

        public static void Main(string[] args)
        {
            var configuration = GetConfiguration();

            Log.Logger = configuration.CreateSerilogLogger(AppName);

            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .SetBasePath(GetContentRootPath())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            BuildWebHost(args).Run();
        }

        private static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddEnvironmentVariables();
            return builder.Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static string GetContentRootPath()
        {

            var relativePathToHostProject =
            Directory.GetCurrentDirectory();

            return relativePathToHostProject;
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseSerilog()
                .UseConfiguration(Configuration)
                .Build();
    }
}