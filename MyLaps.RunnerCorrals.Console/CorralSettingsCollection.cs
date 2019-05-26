using Newtonsoft.Json;

namespace MyLaps.RunnerCorrals.ConsoleApp
{
    namespace Settings
    {
        [JsonObject("corralSettingsCollection")]
        public class CorralSettingsCollection
        {
            [JsonProperty("settings")]
            public CoralSettings[] Settings { get; set; }
        }
    }
}
