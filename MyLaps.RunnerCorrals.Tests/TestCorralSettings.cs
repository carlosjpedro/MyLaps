using MyLaps.RunnerCorrals.Model.Settings;

namespace MyLaps.RunnerCorrals.Tests
{
    internal class TestCorralSettings : ICorralSettings
    {
        public string Name { get; set; }
        public int StartBIBNumber { get; set; }
        public int MaxElements { get; set; }
    }
}
