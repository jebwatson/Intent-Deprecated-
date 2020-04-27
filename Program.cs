﻿using System.IO;
using System.Threading.Tasks;
using Dapplo.Microsoft.Extensions.Hosting.AppServices;
using Dapplo.Microsoft.Extensions.Hosting.Wpf;
using Dapplo.Microsoft.Extensions.Hosting.CaliburnMicro;
using intent.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace intent
{
    public static class Program
    {
        private const string AppSettingsFilePrefix = "appsettings";
        private const string HostSettingsFile = "hostsettings.json";
        private const string Prefix = "PREFIX_";

        public static async Task Main(string[] args)
        {
            var host = new HostBuilder()
				// Do this as early as possible, this gives the UI thread time to start
                .ConfigureWpf()
                .ConfigureLogging()
                .ConfigureConfiguration(args)
				// Prevent this application from running multiple times
                .ConfigureSingleInstance(builder =>
                {
                    builder.MutexId = "{911b310c-21d7-45e9-9332-4f571791c4f5}";
                    builder.WhenNotFirstInstance = (hostingEnvironment, logger) =>
                    {
                        // This is called when an instance was already started, this is in the second instance
                        logger.LogWarning("Application {0} already running.", hostingEnvironment.ApplicationName);
                    };
                })
				// Setup CaliburnMicro
                .ConfigureCaliburnMicro<MainViewModel>()
				// Provide a view model
                .ConfigureServices(serviceCollection =>
                {
                    // Make OtherWindow available for DI to MainWindow
                    serviceCollection.AddTransient<OtherViewModel>();
                })
                .UseConsoleLifetime()
				// Make sure the application stops when the UI stops
                .UseWpfLifetime()
                .Build();

            await host.RunAsync();
        }

        /// <summary>
        /// Configure the loggers
        /// </summary>
        /// <param name="hostBuilder">IHostBuilder</param>
        /// <returns>IHostBuilder</returns>
        private static IHostBuilder ConfigureLogging(this IHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureLogging((hostContext, configLogging) =>
            {
                configLogging.AddConsole();
                configLogging.AddDebug();
            });
        }

        /// <summary>
        /// Configure the configuration
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private static IHostBuilder ConfigureConfiguration(this IHostBuilder hostBuilder, string[] args)
        {
            return hostBuilder.ConfigureHostConfiguration(configHost =>
            {
                configHost.SetBasePath(Directory.GetCurrentDirectory());
                configHost.AddJsonFile(HostSettingsFile, optional: true);
                configHost.AddEnvironmentVariables(prefix: Prefix);
                configHost.AddCommandLine(args);
            })
                .ConfigureAppConfiguration((hostContext, configApp) =>
                {
                    configApp.AddJsonFile(AppSettingsFilePrefix + ".json", optional: true);
                    if (!string.IsNullOrEmpty(hostContext.HostingEnvironment.EnvironmentName))
                    {
                        configApp.AddJsonFile(AppSettingsFilePrefix + $".{hostContext.HostingEnvironment.EnvironmentName}.json", optional: true);
                    }
                    configApp.AddEnvironmentVariables(prefix: Prefix);
                    configApp.AddCommandLine(args);
                });
        }
    }
}
