using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistRent.Application.Interfaces;
using SistRent.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SistRent.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrasEstructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("cadenaSQL")));

            services.AddScoped<IUserRepository, IUserRepository>();

            return services;

        }
    }
}
