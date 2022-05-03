using BC.Bicycles.Repositories;
using BC.Bicycles.Repositories.Interfaces;
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
            throw new NotImplementedException();
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
