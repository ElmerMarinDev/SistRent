using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.DTOs
{
    public class PaymentMethodDTOs
    {
        public record PaymentMethodCreateDto(
            string Name,
            string? Description
        );

        public record PaymentMethodUpdateDto(
            string Name,
            string? Description
        );

        public record PaymentMethodResponseDto(
            int IdPaymentMethod,
            string Name,
            string? Description
        );
    }
}
