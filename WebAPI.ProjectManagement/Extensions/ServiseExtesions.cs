using Microsoft.EntityFrameworkCore;
using Onion.Business.Contracts;
using Onion.Business.Repository;
using Onion.Contrants;
using Onion.LoggerService;
using Onion.Repository;

namespace WebAPI.ProjectManagement.Extensions
{
    public static class ServiseExtesions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                 builder
                 .AllowAnyOrigin() //Tum originden gelen istekleri kabul eder.
                 .AllowAnyMethod()  //Tum metotlar kabul ediliyor.
                 .AllowAnyHeader()); //Tum HTTP isteklerinin başlıklarını kabul eder.
            });
        }

        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerManager>();
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IServiceManager, ServiceManager>();
        }

        public static void ConfigureSqlConnection(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                    project => project.MigrationsAssembly("Onion.WebAPI"));
            });
        }
    }
}
