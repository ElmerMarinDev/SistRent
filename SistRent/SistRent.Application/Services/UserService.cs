using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SistRent.Application.Services
{
    public class UserService(IUserRepository _repo, IFileStorageService _fileStorageService)
    {
        public async Task<IEnumerable<UserResponseDto>> GeTAsync()
        {
            var users = await _repo.GetAsync();

            return users.Select(e => new UserResponseDto(
                IdUser: e.IdUser,
                Role: e.Role.Name,
                FullName: e.FullName,
                Dni:e.Dni,
                Email: e.Email,
                Status: e.Status,
                MustChangePassword: e.MustChangePassword,
                ImageSource: e.ImageSource,
                CreatedAt:e.CreatedAt
                ));


        }


        public async Task<UserResponseDto> GetByIdRole(int id)
        {

            if (id == 0) throw new ValidationException("User id is requeried");
            var user = await _repo.GetByRole(id);

            return new UserResponseDto(
                IdUser: user.IdUser,
                Role: user.Role.Name,
                FullName: user.FullName,
                Dni:user.Dni,
                Email: user.Email,
                Status: user.Status,
                MustChangePassword: user.MustChangePassword,
                ImageSource: user.ImageSource,
                CreatedAt: user.CreatedAt
                );


        }


        public async Task<UserResponseDto> GetByIdAsync(int id)
        {

            if (id == 0) throw new ValidationException("User id is requeried");
            var user = await _repo.GetByIdAsync(id);

            return new UserResponseDto(
                IdUser: user.IdUser,
                Dni:user.Dni,
                Role: user.Role.Name,
                FullName: user.FullName,
                Email: user.Email,
                Status:user.Status,
                MustChangePassword: user.MustChangePassword,
                ImageSource: user.ImageSource,
                CreatedAt: user.CreatedAt
                );


        }

        public async Task<UserResponseDto> LoginAsync(string Email,string Password)
        {

            if (string.IsNullOrEmpty(Email)) throw new ValidationException("Email id is requeried");
            if (string.IsNullOrEmpty(Password)) throw new ValidationException("Password id is requeried");

            var user = await _repo.LoginAsync(Email,Password);

            if(user is null)throw new ValidationException("User not found");

            return new UserResponseDto(
                IdUser: user.IdUser,
                Role: user.Role.Name,
                Dni:user.Dni,
                FullName: user.FullName,
                Email: user.Email,
                Status: user.Status,
                MustChangePassword: user.MustChangePassword,
                ImageSource: user.ImageSource,
                CreatedAt: user.CreatedAt
                );


        }


        public async Task ChangePasswordAsync(ChangePasswordDto data)
        {

            if (data.UserId==0) throw new ValidationException("Email id is requeried");
            var existingUser = await _repo.GetByIdAsync(data.UserId);

            if (existingUser is null) throw new ValidationException("User not found");

            existingUser.PasswordHash = data.NewPassword;
            existingUser.MustChangePassword = false;

            await _repo.EditAsync(existingUser);
        }

        public async Task AddAsync(UserCreateDto user)
        {

            if (string.IsNullOrEmpty(user.FullName)) throw new ValidationException("Full Name id is requeried");
            if (string.IsNullOrEmpty(user.Email)) throw new ValidationException("Email id is requeried");

            var newUser = new User
            {
                FullName = user.FullName,
                Dni=user.Dni,
                Email = user.Email,
                IdRole = user.IdRole,
                Phone=user.Phone,
                Status=user.Status,
                PasswordHash = user.Email
            };

            await _repo.AddAsync(newUser);
        }


        public async Task UpdateAsync(UserUpdateDto user)
        {
            if (user.UserId == 0) throw new ValidationException("User id is requeried");
            if (string.IsNullOrEmpty(user.FullName)) throw new ValidationException("Full Name id is requeried");
            if (string.IsNullOrEmpty(user.Email)) throw new ValidationException("Email id is requeried");

            var existingUser = await _repo.GetByIdAsync(user.UserId);

            if (existingUser is null) throw new ValidationException("User not found");

            if (existingUser.FullName != user.FullName)
                existingUser.FullName = user.FullName;

            if (existingUser.Email != user.Email)
                existingUser.Email = user.Email;

            if (existingUser.IdRole != user.IdRole)
                existingUser.IdRole = user.IdRole;

            if (existingUser.Phone != user.Phone)
                existingUser.Phone = user.Phone;

            if (user.ImageStream != null && !string.IsNullOrEmpty(user.ImageFileName))
            {
                var SourceImagen = "";
                SourceImagen = await _fileStorageService.SaveImageAsync(user.ImageStream,user.ImageFileName);

                if (!string.IsNullOrEmpty(existingUser.ImageSource))
                {

                    await _fileStorageService.DeletemageAsync(existingUser.ImageSource);
                }

                existingUser.ImageSource = SourceImagen;
            }

            if (existingUser.MustChangePassword != user.MustChangePassword)
                existingUser.MustChangePassword = user.MustChangePassword;

            await _repo.EditAsync(existingUser);
        }

        public async Task DeleteAsync(int id)
        {
            if (id == 0) throw new ValidationException("User id is requeried");
            await _repo.DeleteAsync(id);

        }

    }
}
