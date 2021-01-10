using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;



namespace Web.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            CreateWebHostBuilder(args).Build().Run();
            Log.Logger = new LoggerConfiguration()
                    .Enrich.FromLogContext()
                    .WriteTo.File("C:\\Serilog\\TimeTableManagement\\logs.txt")
                    .CreateLogger();

            //var configuration = new ConfigurationBuilder()
            //             .SetBasePath(Directory.GetCurrentDirectory())
            //             .AddJsonFile("appsettings.json")
            //             .Build();
            //Log.Logger = new LoggerConfiguration()
            //             .ReadFrom.Configuration(configuration)
            //             .WriteTo
            //                 .Map("0", "Other-Other", (name, wt) => wt.File($"C:\\Serilog\\{name.Split('-')[0]}\\{name.Split('-')[1]}.txt", rollingInterval: RollingInterval.Day))
            //             .CreateLogger();

            try
            {
                Log.Information("Starting up");
                CreateWebHostBuilder(args).Build().Run();
                // BuildWebHost(args).Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
            
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
