using MyLaps.RunnerCorrals.Model.Settings;
using Newtonsoft.Json;

namespace MyLaps.RunnerCorrals.ConsoleApp
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
    }
}
