using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Text;

namespace SistRent.Application.Services
{
    public class UserService(IUserRepository _repo)
    {
        public async Task<IEnumerable<UserResponseDto>> GeTAsync()
        {
            var users = await _repo.GetAsync();

            return users.Select(e => new UserResponseDto(
                IdUser: e.IdUser,
                IdRole: e.IdRole,
                FullName: e.FullName,
                Email: e.Email,
                Status: e.Status,
                MustChangePassword: e.MustChangePassword,
                ImageSource: e.ImageSource,
                CreatedAt:e.CreatedAt
                ));


        }


        public async Task<UserResponseDto> GetByIdAsync(int id)
        {

            if (id == 0) throw new ValidationException("User id is requeried");
            var user = await _repo.GetByIdAsync(id);

            return new UserResponseDto(
                IdUser: user.IdUser,
                IdRole: user.IdRole,
                FullName: user.FullName,
                Email: user.Email,
                Status:user.Status,
                MustChangePassword: user.MustChangePassword,
                ImageSource: user.ImageSource,
                CreatedAt: user.CreatedAt
                );


        }

        public async Task<UserResponseDto> LoginAsync(int id)
        {

            if (id == 0) throw new ValidationException("User id is requeried");
            var user = await _repo.GetByIdAsync(id);

            return new UserResponseDto(
                IdUser: user.IdUser,
                IdRole: user.IdRole,
                FullName: user.FullName,
                Email: user.Email,
                Status: user.Status,
                MustChangePassword: user.MustChangePassword,
                ImageSource: user.ImageSource,
                CreatedAt: user.CreatedAt
                );


        }

    }
}
