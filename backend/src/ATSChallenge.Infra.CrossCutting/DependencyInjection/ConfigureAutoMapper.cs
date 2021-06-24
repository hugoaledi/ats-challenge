using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ATSChallenge.Infra.CrossCutting.Mappings;

namespace ATSChallenge.Infra.CrossCutting.DependencyInjection
{
    public class ConfigureAutoMapper
    {
        public static void ConfigureDependencies(IServiceCollection serviceCollection)
        {
            var config = new AutoMapper.MapperConfiguration(x =>
            {
                x.AddProfile(new EntityToModelProfile());
            });
            IMapper mapper = config.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }
    }
}
