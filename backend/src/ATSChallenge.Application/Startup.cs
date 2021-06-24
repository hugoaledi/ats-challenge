using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ATSChallenge.Domain.CustomExceptions;
using ATSChallenge.Domain.Interfaces.Services;
using ATSChallenge.Domain.ConfigurationObjects;
using ATSChallenge.Infra.CrossCutting.DependencyInjection;
using ATSChallenge.Infra.Data.Context;

namespace ATSChallenge.Application
{
    public class Startup
    {
        public const string CorsPolicyName = "gaiacorspolicynovaforma";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var databaseConfigurations = new DatabaseConfigurations();
            new ConfigureFromConfigurationOptions<DatabaseConfigurations>(
                Configuration.GetSection("DatabaseConfigurations"))
                    .Configure(databaseConfigurations);
            services.AddSingleton(databaseConfigurations);

            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services, databaseConfigurations);
            ConfigureAutoMapper.ConfigureDependencies(services);

            services.AddCors();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();

                    if (exceptionHandlerPathFeature?.Error is Exception exception)
                    {
                        var message = "Ocorreu um erro ao executar a ação";

                        if (exception is SqlException)
                        {
                            // Salvar log em arquivo
                        }
                        else
                        {
                            if (exception is DataValidationException)
                            {
                                message = exception.Message;
                            }
                            else
                            {
                                if (exception is NotFoundException)
                                {
                                    message = exception.Message;
                                }

                                using (var service = app.ApplicationServices
                                    .GetRequiredService<IServiceScopeFactory>()
                                    .CreateScope())
                                {
                                    using (var logService = service.ServiceProvider.GetService<ILogService>())
                                    {
                                        logService.CriarLogErro(context.Request?.Path, exception)
                                            .GetAwaiter()
                                            .GetResult();
                                    }
                                }
                            }
                        }

                        var result = JsonConvert.SerializeObject(new
                        {
                            error = true,
                            message = message
                        });
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync(result);
                    }
                });
            });

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var service = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                if (service.ServiceProvider.GetService<DatabaseConfigurations>().Migrate)
                {
                    using (var context = service.ServiceProvider.GetService<MyContext>())
                    {
                        context.Database.Migrate();
                    }
                }
            }
        }
    }
}
