using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Text;

namespace SistRent.Application.Services
{
    public class TenantService(ITenantRepository _repo,IUserRepository _user)
    {
        public async Task<IEnumerable<TenantResponseDto>> GetAsync()
        {
            var tenants = await _repo.GetAsync();

            return tenants.Select(e => new TenantResponseDto(
                IdTenant: e.IdTenant,
                IdUser: e.IdUser,
                Status: e.Status,
                Dni:e.Dni,
                Phone:e.Phone,
                RegistrationDate:e.RegistrationDate,
                EmergencyContact: e.EmergencyContact 
                ));


        }

        public async Task<TenantResponseDto> GetByIdAsync(int id)
        {

            if (id == 0) throw new ValidationException("Tenant id is requeried");
            var tenant = await _repo.GetByIdAsync(id);

            if (tenant is null) throw new ValidationException("Tenant not found");

            return new TenantResponseDto(
                IdTenant: tenant.IdTenant,
                IdUser: tenant.IdUser,
                Status: tenant.Status,
                Dni: tenant.Dni,
                Phone: tenant.Phone,
                RegistrationDate: tenant.RegistrationDate,
                EmergencyContact: tenant.EmergencyContact
                );


        }


        public async Task<IEnumerable<TenantResponseDto>> GetByParameterAsync(string parameter)
        {
            var tenants = await _repo.GetByParameterAsync(parameter);

            return tenants.Select(e => new TenantResponseDto(
                IdTenant: e.IdTenant,
                IdUser: e.IdUser,
                Status: e.Status,
                Dni: e.Dni,
                Phone: e.Phone,
                RegistrationDate: e.RegistrationDate,
                EmergencyContact: e.EmergencyContact
                ));


        }

        public async Task AddAsync(TenantCreateDto tenant, UserCreateDto user)
        {

            if (string.IsNullOrEmpty(tenant.Dni)) throw new ValidationException("Full Name id is requeried");
            if (string.IsNullOrEmpty(tenant.Phone)) throw new ValidationException("Email id is requeried");


            var newUser = new User
            {
                FullName = user.FullName,
                Email = user.Email,
                IdRole = user.IdRole,
                PasswordHash = user.Email
            };

            await _user.AddAsync(newUser);

            var newTenant = new Tenant
            {
                IdUser =newUser.IdUser,
                Dni = tenant.Dni,
                Phone =tenant.Phone,
                EmergencyContact =tenant.EmergencyContact,
                Status= tenant.Status,
            };

            await _repo.AddAsync(newTenant);
        }
    }
}
