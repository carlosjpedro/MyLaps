using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace MyLaps.Worker.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddWorkerServices(this IServiceCollection service)
        {
            service.AddScoped<IRunnerGenerator, RunnerGenerator>();
            service.AddScoped<IRunnerService, RunnerService>();

            service.AddScoped<ICorralService, CorralService>();
            service.AddScoped<IRunnerAssigner, RunnerAssigner>();
            service.AddScoped<ICriteriaFactory, CriteriaFactory>();
        }
    }
}
