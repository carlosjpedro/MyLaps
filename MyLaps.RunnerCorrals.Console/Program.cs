using System;

using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyLaps.RunnerCorrals.ConsoleApp.Settings;
using MyLaps.RunnerCorrals.DependencyInjection;
using MyLaps.RunnerCorrals.Model.Settings;

namespace MyLaps.RunnerCorrals.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();

            var corralSettingsCollection = new CorralSettingsCollection();
            config.Bind("corralSettingsCollection", corralSettingsCollection);

            var serviceProvider = new ServiceCollection();
            serviceProvider.AddSingleton(corralSettingsCollection);
            serviceProvider.AddSingleton<IEnumerable<ICorralSettings>>(corralSettingsCollection.Settings);
            serviceProvider.AddSingleton<App>();
            serviceProvider.RegisterRunnerCorralDependencies();
            serviceProvider.BuildServiceProvider().GetService<App>().Run();
        }
    }
}
