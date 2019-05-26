#define _A
using Microsoft.EntityFrameworkCore;
using MyLaps.DataAccess.Entities;

namespace MyLaps.DataAccess
{
    public class MyLapsContext : DbContext
    {

#if _A
        public MyLapsContext(DbContextOptions options) : base(options)
        { }
#else
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = mylaps.db");
        }
#endif

        public DbSet<RunnerEntity> Runners { get; set; }
        public DbSet<CorralEntity> Corrals { get; set; }
    }
}
