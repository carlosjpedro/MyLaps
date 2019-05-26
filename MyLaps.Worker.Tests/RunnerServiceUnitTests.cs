using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using MyLaps.DataAccess;
using MyLaps.Worker.Model;
using Xunit;

namespace MyLaps.Worker.Tests
{
    public class RunnerServiceUnitTests
    {

        //  The use of empty enumerators int his unit tests avoids the generating of sample data
        //  and we are only verifying if the correct objects are being used not their actual contents 
        [Fact]
        public async Task CreateRunnersWillGenerateRunnersAndSaveThenInRepository()
        {
            var runners = Enumerable.Empty<Runner>();
            var generatorMock = new Mock<IRunnerGenerator>();
            var repositoryMock = new Mock<IRunnerRepository>();
            var mapperMock = new Mock<IMapper>();
            var mappedRunners = Enumerable.Empty<DataAccess.Entities.RunnerEntity>();


            generatorMock.Setup(x => x.Generate(5000))
                .Returns(runners);
            mapperMock.Setup(x => x.Map<IEnumerable<DataAccess.Entities.RunnerEntity>>(runners))
                .Returns(mappedRunners);


            await new RunnerService(generatorMock.Object, repositoryMock.Object, mapperMock.Object)
                   .CreateRunners();

            generatorMock.Verify(x => x.Generate(5000), Times.Once);
        }
    }
}
