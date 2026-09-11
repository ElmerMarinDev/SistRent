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
    public class TenantService(ITenantRepository _repo,IUserRepository _user,IFileStorageService _fileStorageService)
    {
        public async Task<IEnumerable<TenantResponseDto>> GetAsync()
        {
            var tenants = await _repo.GetAsync();

            return tenants.Select(e => new TenantResponseDto(
                IdTenant: e.IdTenant,
                ImageSource:e.User.ImageSource,
                fullname:e.User.FullName,
                Password:e.User.PasswordHash,
                Email:e.User.Email,
                Dni:e.Dni,
                Phone:e.Phone,
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
                ImageSource: tenant.User.ImageSource,
                fullname: tenant.User.FullName,
                Password: tenant.User.PasswordHash,
                Email: tenant.User.Email,
                Dni: tenant.Dni,
                Phone: tenant.Phone,
                EmergencyContact: tenant.EmergencyContact
             );


        }


        public async Task<IEnumerable<TenantResponseDto>> GetByParameterAsync(string parameter)
        {
            var tenants = await _repo.GetByParameterAsync(parameter);

            return tenants.Select(e => new TenantResponseDto(
                IdTenant: e.IdTenant,
                ImageSource: e.User.ImageSource,
                fullname:e.User.FullName,
                Password:e.User.PasswordHash,
                Email: e.User.Email,
                Dni: e.Dni,
                Phone: e.Phone,
                EmergencyContact: e.EmergencyContact
                ));


        }

        public async Task AddAsync(TenantCreateDto tenant)
        {

            if (string.IsNullOrEmpty(tenant.Dni)) throw new ValidationException("Full Name id is requeried");
            if (string.IsNullOrEmpty(tenant.Phone)) throw new ValidationException("Email id is requeried");


            var newUser = new User
            {
                FullName = tenant.Fullname,
                Email = tenant.Email,
                IdRole = 2,
                PasswordHash =tenant.Email,
                Status= tenant.Status
            };

           

            var newTenant = new Tenant
            {
                User =newUser,
                Dni = tenant.Dni,
                Phone =tenant.Phone,
                EmergencyContact =tenant.EmergencyContact
            };

            await _repo.AddAsync(newTenant);
        }


        public async Task UpdateAsync(TenantUpdateDto tenant)
        {
            if (tenant.TenantId == 0) throw new ValidationException("User id is requeried");
            if (string.IsNullOrEmpty(tenant.Dni)) throw new ValidationException("Full Name id is requeried");
            if (string.IsNullOrEmpty(tenant.Phone)) throw new ValidationException("Email id is requeried");

            var existingTenant = await _repo.GetByIdAsync(tenant.TenantId);

            if (existingTenant is null) throw new ValidationException("User not found");

            var UserID = existingTenant.IdUser;
            var existingUser = await _user.GetByIdAsync(UserID);

            if (existingUser.FullName != tenant.fullname)
                existingUser.FullName = tenant.fullname;

            if (existingUser.PasswordHash != tenant.Password)
                existingUser.PasswordHash = tenant.Password;

            if (existingUser.Status != tenant.Status)
                existingUser.Status = tenant.Status;

            if (existingUser.ImageSource!=null && !string.IsNullOrEmpty(existingUser.ImageSource))
            {
                var SourceImagen = "";
                SourceImagen = await _fileStorageService.SaveImageAsync(tenant.ImageStream, tenant.ImageFileName);            
                
                if (!string.IsNullOrEmpty(existingUser.ImageSource))
                {
                
                await _fileStorageService.DeletemageAsync(existingUser.ImageSource);
                }

                existingUser.ImageSource= SourceImagen;
            }

            await _user.EditAsync(existingUser);



            if (existingTenant.Dni != tenant.Dni)
                existingTenant.Dni = tenant.Dni;

            if (existingTenant.Phone != tenant.Phone)
                existingTenant.Phone = tenant.Phone;

            if (existingTenant.EmergencyContact != tenant.EmergencyContact)
                existingTenant.EmergencyContact = tenant.EmergencyContact;

            await _repo.EditAsync(existingTenant);
        }
    }
}
