using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistRent.Application.Services
{
   public class RoleService(IRoleRepository _repo)
    {
        public async Task<IEnumerable<RoleResponseDto>> GeTAsync()
        {
            var rols = await _repo.GetAsync();

            return rols.Select(e => new RoleResponseDto(
                IdRole:e.IdRole,
                Name:e.Name,
                Description:e.Description,
                RegistrationDate:e.CreatedAt
                
                ));


        }

        public async Task<RoleResponseDto> GetByIdAsync(int id)
        {

            if (id == 0) throw new ValidationException("User id is requeried");
            var role = await _repo.GetByIdAsync(id);

            return new RoleResponseDto(
                IdRole:role.IdRole,
                Name:role.Name,
                Description:role.Description,
                RegistrationDate:role.CreatedAt
                
                );

        }



        public async Task AddAsync(RoleCreateDto rol)
        {

            if (string.IsNullOrEmpty(rol.Name)) throw new ValidationException("Full Name id is requeried");
            if (string.IsNullOrEmpty(rol.Description)) throw new ValidationException("Email id is requeried");

            var newRol = new Role
            {
                Name=rol.Name,
                Description=rol.Description
            };

            await _repo.AddAsync(newRol);
        }


        public Role UpdateData(RoleUpdateDto rol, Role existingRol)
        {

            if (existingRol.Name != rol.Name)
                existingRol.Name = rol.Name;

            if (existingRol.Description != rol.Description)
                existingRol.Description= rol.Description;



            return existingRol;

        }








        public async Task UpdateAsync(RoleUpdateDto rol)
        {
            if (rol.IdRole == 0) throw new ValidationException("User id is requeried");
            if (string.IsNullOrEmpty(rol.Name)) throw new ValidationException("Full Name id is requeried");
            if (string.IsNullOrEmpty(rol.Description)) throw new ValidationException("Email id is requeried");

            var existingRol = await _repo.GetByIdAsync(rol.IdRole);

            if (existingRol is null) throw new ValidationException("Rol not found");

            UpdateData(rol, existingRol);


            await _repo.EditAsync(existingRol);
        }

        public async Task DeleteAsync(int id)
        {
            if (id == 0) throw new ValidationException("Rol id is requeried");
            await _repo.DeleteAsync(id);

        }

    }
}

