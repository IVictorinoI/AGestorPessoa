using System;
using System.Collections.Generic;
using System.Text;
using Application.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Application.Config
{
    public static class DatabaseConfig
    {
        public static IServiceCollection ConnectOnDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<DataContext>(opt =>
                    {
                        opt.UseNpgsql(configuration.GetConnectionString("MyWebApiConnection"));
                        opt.EnableSensitiveDataLogging(true);
                        opt.EnableDetailedErrors(true);
                        opt.UseLazyLoadingProxies();
                    }
                    );

            return services;
        }
    }
}
