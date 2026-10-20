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
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
       
            services.AddScoped<ContractService>();
            services.AddScoped<ContractStatusService>();
            services.AddScoped<PaymentService>();
            services.AddScoped<PaymentMethodService>();
            services.AddScoped<PropertyService>();    
            services.AddScoped<RoomService>();
            services.AddScoped<RoomTypeService>();
            services.AddScoped<RoleService>();  
            services.AddScoped<UserService>();

            return services;

        }

    }
}
