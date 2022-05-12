﻿using Onion.Contrants;
using Onion.LoggerService;

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
        }
    }
}
