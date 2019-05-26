using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyLaps.DataAccess.Entities
{
    public class RunnerEntity
    {
        [Key]
        public int Id { get; set; }
        public int RaceTime { get; set; }
        public int Age { get; set; }
        public GenderEntity Gender { get; set; }

        [ForeignKey("Corral")]
        public int? CorralId { get; set; }
        public string CorralName { get; set; }
        public int BIBNumber { get; set; }
    }
}