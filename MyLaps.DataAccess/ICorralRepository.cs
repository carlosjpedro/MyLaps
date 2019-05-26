using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyLaps.DataAccess.Entities;

namespace MyLaps.DataAccess
{
    public interface ICorralRepository
    {
        Task<IEnumerable<CorralEntity>> GetCorrals();
        Task Save(CorralEntity existing);
    }

    class CorralRepository : ICorralRepository
    {
        private MyLapsContext _context;

        public CorralRepository(MyLapsContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<IEnumerable<CorralEntity>> GetCorrals()
        {
            return _context.Corrals.AsEnumerable();
        }
        public async Task Save(CorralEntity newCorral)
        {
            var existing = await _context.Corrals
                .FirstOrDefaultAsync(x => x.Id == newCorral.Id);

            existing.Name = newCorral.Name;
            existing.MaxElements = newCorral.MaxElements;
            existing.StartBIBNumber = newCorral.StartBIBNumber;
            existing.CriteriaType = newCorral.CriteriaType;
            existing.MaxRaceTime = newCorral.MaxRaceTime;
            existing.MinRaceTime = newCorral.MinRaceTime;
            existing.MaxAge = newCorral.MaxAge;
            existing.MinAge = newCorral.MinAge;
            existing.Gender = newCorral.Gender;

            _context.SaveChanges();
        }
    }
}
