using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLaps.RunnerCorrals.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRunnerCorralDependencies(this IServiceCollection services)
        {
            services.AddScoped<IWorkflowEngine, WorkflowEngine>();
            services.AddScoped<ICriteriaFactory, CriteriaFactory>();
            services.AddScoped<IRunnerGenerator, RunnerGenerator>();

            return services;
        }
    }
}
