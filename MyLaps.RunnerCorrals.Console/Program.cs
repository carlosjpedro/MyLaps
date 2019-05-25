using System;

using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MyLaps.RunnerCorrals.Console.Settings;
using MyLaps.RunnerCorrals.Model.Settings;
using Newtonsoft.Json;

namespace MyLaps.RunnerCorrals.Console
{
    namespace Settings
    {
        public class CoralSettings : ICorralSettings
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("startBibNumber")]
            public int StartBIBNumber { get; set; }
            [JsonProperty("maxElements")]
            public int MaxElements { get; set; }
        }
        [JsonObject("corralSettingsCollection")]
        public class CorralSettingsCollection
        {
            [JsonProperty("settings")]
            public CoralSettings[] Settings { get; set; }
        }
    }

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
            //serviceProvider.AddSingleton<ICorralSettings, CoralSettings>();

            serviceProvider.AddSingleton<CorralSettingsCollection>(corralSettingsCollection);
            serviceProvider.AddSingleton<IRaceWorkflow, App>();

            // serviceProvider.Configure<CorralSettingsCollection>(config);

            serviceProvider.BuildServiceProvider().GetService<IRaceWorkflow>().Run();
        }
    }


    public interface IRaceWorkflow
    {
        void Run();
    }

    internal class App : IRaceWorkflow
    {
        private readonly CorralSettingsCollection _settingsCollection;

        public App(CorralSettingsCollection settingsCollection)
        {
            _settingsCollection = settingsCollection;
        }

        public void Run()
        {
            System.Console.WriteLine($"Corral\tMax Elements");
            foreach (var settings in _settingsCollection.Settings)
            {
                System.Console.WriteLine($"{settings.Name}\t{settings.MaxElements}");
            }

            NewConsoleLine(4);
        }

        static void NewConsoleLine(int count = 1)
        {
            for (var i = 0; i < count; i++)
                System.Console.WriteLine();
        }
    }
}
