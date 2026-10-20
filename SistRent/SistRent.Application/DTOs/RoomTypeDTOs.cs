using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.DTOs
{
    public record RoomTypeCreateDto(
        string Name,
        string? Description
    );

    public record RoomTypeUpdateDto(
        int IdRoomType,
        string Name,
        string? Description
    );

    public record RoomTypeResponseDto(
        int IdRoomType,
        string Name,
        string? Description
    );
}
