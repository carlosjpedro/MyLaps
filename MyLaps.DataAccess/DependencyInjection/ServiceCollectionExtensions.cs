using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MyLaps.DataAccess.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccessServices(this IServiceCollection service)
        {
            service.AddScoped<IRunnerRepository, RunnerRepository>();
            service.AddScoped<ICorralRepository, CorralRepository>();
            service.AddSingleton<DbContextOptions>(new DbContextOptionsBuilder<MyLapsContext>()
                .UseSqlite("DataSource=mylaps.db")
                .Options);
            service.AddSingleton<MyLapsContext>();
        }
    }
}