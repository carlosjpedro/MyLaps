namespace MyLaps.RunnerCorrals.Model.Settings
{
    public interface ICorralSettings
    {
        string Name { get; }
        int StartBIBNumber { get; }
        int MaxElements { get; }
    }
}