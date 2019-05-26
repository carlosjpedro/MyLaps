using System.ComponentModel.DataAnnotations;

namespace MyLaps.Worker.Model
{
    public class Corral
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxElements { get; set; }
        public int StartBIBNumber { get; set; }
        public CriteriaType CriteriaType { get; set; }
        public int? MaxRaceTime { get; set; }
        public int? MinRaceTime { get; set; }
        public int? MaxAge { get; set; }
        public int? MinAge { get; set; }
        public Gender Gender { get; set; }
        public int RunnerCount { get; set; }
    }
}
