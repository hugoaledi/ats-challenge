using Microsoft.Extensions.DependencyInjection;
using ATSChallenge.Domain.Interfaces.Services;
using ATSChallenge.Service.Services;

namespace ATSChallenge.Infra.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ILogService, LogService>();
            serviceCollection.AddTransient<IJobService, JobService>();
        }
    }
}
