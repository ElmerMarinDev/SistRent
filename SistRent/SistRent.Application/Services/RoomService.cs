using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistRent.Application.Services
{
    public class RoomService(IRoomRepository _repo)
    {
        public async Task<IEnumerable<RoomResponseDto>> GeTAsync()
        {
            var rooms = await _repo.GetAsync();

            return rooms.Select(e => new RoomResponseDto(
                IdRoom: e.IdRoom,
                PropertyName: e.Property.Name,
                RoomNumber:e.RoomNumber,
                Floor:e.Floor,
                MonthlyPrice:e.MonthlyPrice,
                Description:e.Description,
                Status:e.Status,
                RoomTypeName:e.RoomType.Name

                ));


        }

        public async Task<RoomDetailDto> GetByIdAsync(int id)
        {

            if (id == 0) throw new ValidationException("User id is requeried");
            var room = await _repo.GetByIdAsync(id);

            return new RoomDetailDto(
                IdRoom: room.IdRoom,
                PropertyName: room.Property.Name,
                RoomNumber:room.RoomNumber,
                Floor:room.Floor,
                MonthlyPrice:room.MonthlyPrice,
                Description:room.Description,
                Status:room.Status,
                RoomTypeName:room.RoomType.Name

                );


        }






        public async Task AddAsync(RoomCreateDto room)
        {

            if (string.IsNullOrEmpty(room.RoomNumber)) throw new ValidationException("Full Name id is requeried");
            if (string.IsNullOrEmpty(room.Floor)) throw new ValidationException("Email id is requeried");

            var newRoom = new Room
            {
                IdProperty = room.IdProperty,
                IdRoomType = room.IdRoomType,
                RoomNumber = room.RoomNumber,
                Floor = room.Floor,
                MonthlyPrice= room.MonthlyPrice,
                Status = room.Status,
                Description = room.Description
            };

            await _repo.AddAsync(newRoom);
        }


        public Room UpdateData(RoomUpdateDto room, Room existingRoom)
        {

            if (existingRoom.RoomNumber != room.RoomNumber)
                existingRoom.RoomNumber = room.RoomNumber;

            if (existingRoom.Floor != room.Floor)
                existingRoom.Floor = room.Floor;

            if (existingRoom.MonthlyPrice != room.MonthlyPrice)
                existingRoom.MonthlyPrice = room.MonthlyPrice;

            if (existingRoom.Status != room.Status)
                existingRoom.Status = room.Status;

            if (existingRoom.Description != room.Description)
                existingRoom.Description = room.Description;

            return existingRoom;

        }








        public async Task UpdateAsync(RoomUpdateDto room)
        {
            if (room.IdRoom == 0) throw new ValidationException("Room id is requeried");
            if (string.IsNullOrEmpty(room.RoomNumber)) throw new ValidationException("Full Name id is requeried");
            if (string.IsNullOrEmpty(room.Floor)) throw new ValidationException("Email id is requeried");

            var existingRoom = await _repo.GetByIdAsync(room.IdRoom);

            if (existingRoom is null) throw new ValidationException("User not found");

            UpdateData(room, existingRoom);

            await _repo.EditAsync(existingRoom);
        }

        public async Task DeleteAsync(int id)
        {
            if (id == 0) throw new ValidationException("User id is requeried");
            await _repo.DeleteAsync(id);

        }

    }
}

