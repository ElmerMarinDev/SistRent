using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistRent.Application.Interfaces;
using SistRent.Application.Services;
using SistRent.Domain.Entities;
using SistRent.Infrastructure.DataBase;
using SistRent.Infrastructure.Repositories;
using SistRent.Infrastructure.Services;
using SistRent.Infrastructure.Settings;
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

            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IContractStatusRepository, ContractStatusRepository>();

            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();

            services.AddScoped<IUserRepository,UserRepository>();

            services.AddScoped<IFileStorageService, FileStorageService>();

            services.AddScoped<IPasswordResetTokenRepository,PasswordResetTokenRepository>();

            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            return services;

        }
    }
}
