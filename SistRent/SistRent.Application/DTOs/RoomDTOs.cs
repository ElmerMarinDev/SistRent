using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.DTOs
{
    public record RoomCreateDto(
        int IdProperty,
        int IdRoomType,
        string RoomNumber,
        string? Floor,
        decimal MonthlyPrice,
        string Status,
        string? Description
    );


    public record RoomDetailDto(
        int IdRoom,
        string PropertyName,
        string RoomTypeName,
        string RoomNumber,
        string? Floor,
        decimal MonthlyPrice,
        string Status,
        string? Description

    );

    public record RoomUpdateDto(
        int IdRoom,
        int IdProperty,
        int IdRoomType,
        string RoomNumber,
        string? Floor,
        decimal MonthlyPrice,
        string Status,
        string? Description
    );

    public record RoomResponseDto(
        int IdRoom,
        string PropertyName,
        string RoomTypeName,
        string RoomNumber,
        string? Floor,
        decimal MonthlyPrice,
        string Status,
        string? Description
    );
}
