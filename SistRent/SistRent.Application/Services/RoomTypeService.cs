using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistRent.Application.Services
{
    public class RoomTypeService(IRoomTypeRepository _repo)
    {
        public async Task<IEnumerable<RoomTypeResponseDto>> GeTAsync()
        {
            var roomType = await _repo.GetAsync();

            return roomType.Select(e => new RoomTypeResponseDto(
                IdRoomType: e.IdRoomType,
                Name: e.Name,
                Description: e.Description

                ));


        }

        public async Task<RoomTypeResponseDto> GetByIdAsync(int id)
        {

            if (id == 0) throw new ValidationException("User id is requeried");
            var roomType = await _repo.GetByIdAsync(id);

            return new RoomTypeResponseDto(
                IdRoomType: roomType.IdRoomType,
                Name: roomType.Name,
                Description: roomType.Description
                );

        }



        public async Task AddAsync(RoleCreateDto rol)
        {

            if (string.IsNullOrEmpty(rol.Name)) throw new ValidationException("Full Name id is requeried");
            if (string.IsNullOrEmpty(rol.Description)) throw new ValidationException("Email id is requeried");

            var newRoomType = new RoomType
            {
                Name = rol.Name,
                Description = rol.Description
            };

            await _repo.AddAsync(newRoomType);
        }


        public RoomType UpdateData(RoomTypeUpdateDto rol, RoomType existingRoomType)
        {

            if (existingRoomType.Name != rol.Name)
                existingRoomType.Name = rol.Name;

            if (existingRoomType.Description != rol.Description)
                existingRoomType.Description = rol.Description;



            return existingRoomType;

        }








        public async Task UpdateAsync(RoomTypeUpdateDto roomType)
        {
            if (roomType.IdRoomType== 0) throw new ValidationException("User id is requeried");
            if (string.IsNullOrEmpty(roomType.Name)) throw new ValidationException("Full Name id is requeried");
            if (string.IsNullOrEmpty(roomType.Description)) throw new ValidationException("Email id is requeried");

            var existingRoomType = await _repo.GetByIdAsync(roomType.IdRoomType);

            if (existingRoomType is null) throw new ValidationException("Rol not found");

            UpdateData(roomType, existingRoomType);


            await _repo.EditAsync(existingRoomType);
        }

        public async Task DeleteAsync(int id)
        {
            if (id == 0) throw new ValidationException("Rol id is requeried");
            await _repo.DeleteAsync(id);

        }

    }
}

