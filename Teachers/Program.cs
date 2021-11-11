using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Teachers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder =>
        //        {
        //            webBuilder.UseStartup<Startup>();
        //        });

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
         WebHost.CreateDefaultBuilder(args)
             .UseIISIntegration()
              .ConfigureLogging((hostingContext ,logBuilder) =>
              {
                  logBuilder.ClearProviders(); // removes all providers from LoggerFactory
                  logBuilder.AddConsole();
                  logBuilder.AddTraceSource("Information, ActivityTracing");
                  logBuilder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                  logBuilder.AddConsole();
                  logBuilder.AddDebug();
                  logBuilder.AddEventSourceLogger();// Add Trace listener provider
              })

                .UseStartup<Startup>();
    }
}
