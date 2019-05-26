using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MyLaps.DataAccess.Entities
{
    public class CorralEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxElements { get; set; }
        public int StartBIBNumber { get; set; }
        public CriteriaTypeEntity CriteriaType { get; set; }
        public int? MaxRaceTime { get; set; }
        public int? MinRaceTime { get; set; }
        public int? MaxAge { get; set; }
        public int? MinAge { get; set; }
        public GenderEntity? Gender { get; set; }
        public int RunnerCount { get; set; }
    }

    public enum CriteriaTypeEntity
    {
        FreeForAll = 0,
        Age = 1,
        RaceTime = 2,
        Gender = 3
    }
}
