using BC.Bicycles.Repositories;
using BC.Bicycles.Repositories.Interfaces;
using BC.Bicycles.Services;
using BC.Bicycles.Services.Interfaces;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace BC.Bicycles.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBicycleRepository, BicycleRepository>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBicycleService, BicycleService>();
        }

        public static void AddBCMessaging(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            if (isDevelopment)
            {
                services.AddMassTransit(x =>
                {
                    x.AddConsumer<UserUpdatedConsumer>();
                    x.AddConsumer<UserDeletedConsumer>();

                    x.UsingRabbitMq((context, config) =>
                    {
                        config.Host("localhost", "/", h =>
                        {
                            h.Username("guest");
                            h.Password("guest");
                        });

                        config.ConfigureEndpoints(context);
                    });
                });

                return;
            }

            services.AddMassTransit(x =>
            {
                x.AddConsumer<UserUpdatedConsumer>();
                x.AddConsumer<UserDeletedConsumer>();

                x.UsingAzureServiceBus((context, config) =>
                {
                    config.Host(configuration.GetConnectionString("AzureServiceBusConnection"));

                    config.ConfigureEndpoints(context);
                });
            });
        }

        public static void ConfigureCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BC.Bicycles",
                    Description = "Microservice to manage bicycles",
                });
            });
    }
}
