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

    public record RoomUpdateDto(
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
        int IdProperty,
        string PropertyName,
        int IdRoomType,
        string RoomTypeName,
        string RoomNumber,
        string? Floor,
        decimal MonthlyPrice,
        string Status,
        string? Description
    );
}
