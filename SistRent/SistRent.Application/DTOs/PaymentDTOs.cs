using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.DTOs
{

        public record PaymentCreateDto(
            int IdContract,
            int IdPaymentMethod,
            DateTime PaymentDate,
            DateTime PeriodStart,
            DateTime PeriodEnd,
            decimal Amount,
            decimal LateFee,
            string Status,
            string? Notes
        );

        public record PaymentUpdateDto(
            int IdPaymentMethod,
            DateTime PaymentDate,
            DateTime PeriodStart,
            DateTime PeriodEnd,
            decimal Amount,
            decimal LateFee,
            decimal TotalAmount,
            string Status,
            string? Notes
        );

        public record PaymentResponseDto(
            int IdPayment,
            int IdContract,
            int IdPaymentMethod,
            DateTime PaymentDate,
            DateTime PeriodStart,
            DateTime PeriodEnd,
            decimal Amount,
            decimal LateFee,
            decimal TotalAmount,
            string Status,
            string? Notes,
            DateTimeOffset CreatedAt
        );
}

