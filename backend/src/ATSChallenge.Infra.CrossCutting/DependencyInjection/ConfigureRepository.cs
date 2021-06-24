using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ATSChallenge.Domain.Interfaces;
using ATSChallenge.Infra.Data.Context;
using ATSChallenge.Infra.Data.Repository;
using ATSChallenge.Domain.ConfigurationObjects;
using ATSChallenge.Domain.Interfaces.Repositories;

namespace ATSChallenge.Infra.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(
            IServiceCollection serviceCollection, DatabaseConfigurations configurations)
        {
            serviceCollection.AddDbContext<MyContext>(
                options => options.UseSqlServer(configurations.Connection)
            );

            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceCollection.AddScoped<ILogRepository, LogRepository>();
            serviceCollection.AddScoped<IJobRepository, JobRepository>();
        }
    }
}
