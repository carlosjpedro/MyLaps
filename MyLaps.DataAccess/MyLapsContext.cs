
using Microsoft.EntityFrameworkCore;
using MyLaps.DataAccess.Entities;

namespace MyLaps.DataAccess
{
    public class MyLapsContext : DbContext
    {
        public MyLapsContext(DbContextOptions options) : base(options)
        { }

        public DbSet<RunnerEntity> Runners { get; set; }
        public DbSet<CorralEntity> Corrals { get; set; }
    }
}
