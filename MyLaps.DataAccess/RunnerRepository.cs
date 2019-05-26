using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyLaps.DataAccess.Entities;

namespace MyLaps.DataAccess
{
    class RunnerRepository : IRunnerRepository
    {
        private readonly MyLapsContext _context;
        public RunnerRepository(MyLapsContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task Save(IEnumerable<RunnerEntity> runners)
        {
            _context.Runners.AddRange(runners);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<RunnerEntity> GetAll()
        {
            return _context.Runners;
        }

        public async Task UpdateAllRunners(IEnumerable<RunnerEntity> runnerEntities)
        {
            _context.Runners.RemoveRange(_context.Runners);
            _context.AddRange(runnerEntities);
            await _context.SaveChangesAsync();
        }

        public void ResetDatabase()
        {
            _context.Database.ExecuteSqlCommand("DELETE FROM CORRALS");
            _context.Database.ExecuteSqlCommand("DELETE FROM RUNNERS");

            _context.SaveChanges();

            _context.Corrals.Add(new CorralEntity { Name = "A", StartBIBNumber = 1, MaxElements = 999 });
            _context.Corrals.Add(new CorralEntity { Name = "B", StartBIBNumber = 1000, MaxElements = 999 });
            _context.Corrals.Add(new CorralEntity { Name = "C", StartBIBNumber = 2000, MaxElements = 999 });
            _context.Corrals.Add(new CorralEntity { Name = "D", StartBIBNumber = 3000, MaxElements = 7000 });

            _context.SaveChanges();
        }
    }
}