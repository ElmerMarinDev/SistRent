using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.DTOs
{
    public record ContractStatusCreateDto(
        string Name,
        string? Description
    );

    public record ContractStatusUpdateDto(
        string Name,
        string? Description
    );

    public record ContractStatusResponseDto(
        int IdContractStatus,
        string Name,
        string? Description
    );
}
