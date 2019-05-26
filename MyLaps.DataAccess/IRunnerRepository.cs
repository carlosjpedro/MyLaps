using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyLaps.DataAccess.Entities;

namespace MyLaps.DataAccess
{
    public interface IRunnerRepository
    {
        Task Save(IEnumerable<RunnerEntity> runners);
        IEnumerable<RunnerEntity> GetAll();
        Task UpdateAllRunners(IEnumerable<RunnerEntity> runnerEntities);
        void ResetDatabase();
    }
}
