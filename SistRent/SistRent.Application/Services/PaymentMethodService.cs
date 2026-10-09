using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;



namespace SistRent.Application.Services
{
    public class PaymentMethodService(IPaymentMethodRepository _repo)
    {

        public async Task<IEnumerable<PaymentMethodResponseDto>> GeTAsync()
        {
            var PaymentMethod = await _repo.GetAsync();

            return PaymentMethod.Select(e => new PaymentMethodResponseDto(
                IdPaymentMethod: e.IdPaymentMethod,
                Name: e.Name,
                Description: e.Description

                ));
        }

        public async Task AddAsync(PaymentMethodCreateDto PaymentMethod)
        {

            var newPaymentMethod = new PaymentMethod
            {
                Name= PaymentMethod.Name,
                Description= PaymentMethod.Description
            };

            await _repo.AddAsync(newPaymentMethod);
        }


        public PaymentMethod UpdateData(PaymentMethodUpdateDto user, PaymentMethod existingPayment)
        {
            if (existingPayment.Name != user.Name)
                existingPayment.Name = user.Name;

            if (existingPayment.Description != user.Description)
                existingPayment.Description = user.Description;


            return existingPayment;

        }

        public async Task UpdateAsync(PaymentMethodUpdateDto PaymentMethod)
        {
            if (string.IsNullOrEmpty(PaymentMethod.Name)) throw new ValidationException("Full Name id is requeried");
            if (string.IsNullOrEmpty(PaymentMethod.Description)) throw new ValidationException("Email id is requeried");

            var existingPaymentMethod = await _repo.GetByIdAsync(PaymentMethod.IdPaymentMethod);

            if (existingPaymentMethod is null) throw new ValidationException("User not found");

            UpdateData(PaymentMethod, existingPaymentMethod);

            await _repo.EditAsync(existingPaymentMethod);
        }
    }
}
