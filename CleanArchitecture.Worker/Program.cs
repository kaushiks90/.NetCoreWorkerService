using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Services;
using CleanArchitecture.Core.Settings;
using CleanArchitecture.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CleanArchitecture.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
                    services.AddSingleton<IEntryPointService, EntryPointService>();
                    services.AddSingleton<IServiceLocator, ServiceScopeFactoryLocator>();


                    // Infrastructure.ContainerSetup
                    services.AddImages();
                    services.AddUrlCheckingServices();

                    var entryPointSettings = new EntryPointSettings();
                    hostContext.Configuration.Bind(nameof(EntryPointSettings), entryPointSettings);
                    services.AddSingleton(entryPointSettings);

                    var workerSettings = new WorkerSettings();
                    hostContext.Configuration.Bind(nameof(WorkerSettings), workerSettings);
                    services.AddSingleton(workerSettings);

                    services.AddHostedService<Worker>();

                });
    }
}
 