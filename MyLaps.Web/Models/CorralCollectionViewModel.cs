using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyLaps.Worker.Model;

namespace MyLaps.Web.Models
{
    public class CorralListViewModel
    {
        public IEnumerable<CorralViewModel> Corrals { get; set; }
        public bool IsProcessed { get; set; }

    }

    public class CorralViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CriteriaTypeViewModel CriteriaType { get; set; }
        public int StartBIBNumber { get; set; }
        public int MaxElements { get; set; }
        [Display(Name = "Minimum Age")]
        public int MinAge { get; set; }
        [Display(Name = "Maximum Age")]
        public int? MaxAge { get; set; }
        [Display(Name = "Maximum Race Time")]
        public int? MaxRaceTime { get; set; }
        [Display(Name = "Minimum Race Time")]
        public int? MinRaceTime { get; set; }
        public Gender Gender { get; set; }
    }

    public enum CriteriaTypeViewModel
    {
        [Display(Name = "Default")]
        FreeForAll = 0,
        [Display(Name = "Age")]
        Age = 1,
        [Display(Name = "Race Time")]
        RaceTime = 2,
        [Display(Name = "Gender")]
        Gender = 3
    }
}
