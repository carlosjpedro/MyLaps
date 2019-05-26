using System;
using System.Linq;
using System.Threading.Tasks;
using MyLaps.DataAccess.Entities;
using Xunit;

namespace MyLaps.DataAccess.IntegrationTests
{
    public class RunnerRepositoryTests : RepositoryTestBase
    {
        private IRunnerRepository _repository;

        public RunnerRepositoryTests()
        {
            _repository = new RunnerRepository(_context);
        }

        [Fact]
        public async Task RepositoryWritesItemsToDatabase()
        {
            var entity = new RunnerEntity
            {
                Age = 10,
                Gender = GenderEntity.Male,
                RaceTime = 87654732
            };
            var entities = Enumerable.Repeat(entity, 1);
            await _repository.Save(entities);

            var storedRunner = _context.Runners.Single();

            Assert.Same(entity, storedRunner);
        }
    }
}
