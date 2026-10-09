using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistRent.Application.Services
{
    public class PaymentService(IPaymentRepository _repo)
    {
        public async Task<IEnumerable<PaymentResponseDto>> GeTAsync()
        {
            var PaymentMethod = await _repo.GetAsync();

            return PaymentMethod.Select(e => new PaymentResponseDto(
                IdPayment:e.IdPayment,
                IdContract:e.IdContract,
                PaymentMethod: e.PaymentMethod.Name,
                PaymentDate:e.PaymentDate,
                PeriodStart:e.PeriodStart,
                PeriodEnd:e.PeriodEnd,
                Amount:e.Amount,
                LateFee:e.LateFee,
                TotalAmount:e.TotalAmount,
                Status:e.Status,
                CreatedAt:e.CreatedAt
                ));
        }

        public async Task AddAsync(PaymentCreateDto Payment)
        {
            var newPaymentMethod = new Payment
            {
                IdContract = Payment.IdContract,
                IdPaymentMethod=Payment.IdPaymentMethod,
                PaymentDate=Payment.PaymentDate,
                PeriodStart=Payment.PeriodStart,
                PeriodEnd=Payment.PeriodEnd,
                Amount=Payment.Amount,
                LateFee=Payment.LateFee,
                Status=Payment.Status,
                Notes=Payment.Notes
            };

            await _repo.AddAsync(newPaymentMethod);
        }


        public Payment UpdateData(PaymentUpdateDto payment, Payment existingPayment)
        {
            if (existingPayment.PaymentDate != payment.PaymentDate)
                existingPayment.PaymentDate = payment.PaymentDate;

            if (existingPayment.PeriodEnd != payment.PeriodEnd)
                existingPayment.PeriodEnd = payment.PeriodEnd;

            if (existingPayment.Amount != payment.Amount)
                existingPayment.Amount = payment.Amount;

            if (existingPayment.LateFee != payment.LateFee)
                existingPayment.LateFee = payment.LateFee;

            if (existingPayment.TotalAmount != payment.TotalAmount)
                existingPayment.TotalAmount = payment.TotalAmount;

            if (existingPayment.Status != payment.Status)
                existingPayment.Status = payment.Status;

            if (existingPayment.Notes != payment.Notes)
                existingPayment.Notes = payment.Notes;


            return existingPayment;

        }

        public async Task UpdateAsync(PaymentUpdateDto Payment)
        {
            if (Payment.IdPayment== 0) throw new ValidationException("User id is requeried");

            var existingPaymentMethod = await _repo.GetByIdAsync(Payment.IdPaymentMethod);

            if (existingPaymentMethod is null) throw new ValidationException("User not found");

            await _repo.EditAsync(existingPaymentMethod);
        }
    }
}
