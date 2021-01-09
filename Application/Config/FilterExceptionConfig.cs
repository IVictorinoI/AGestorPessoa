using System;
using System.Collections.Generic;
using System.Text;
using Application.Config.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Config
{
    public static class FilterExceptionConfig
    {
        public static IServiceCollection AddCustomFilterExceptions(this IServiceCollection services)
        {
            services.AddControllers(options =>
                options.Filters.Add(new HttpResponseExceptionFilter()));

            return services;
        }
    }
}
