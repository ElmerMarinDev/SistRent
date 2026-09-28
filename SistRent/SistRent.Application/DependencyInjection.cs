using Microsoft.Extensions.DependencyInjection;
using SistRent.Application.Interfaces;
using SistRent.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrasEstructureServices(this IServiceCollection services)
        {
            services.AddScoped<UserService>();

            return services;

        }

    }
}
