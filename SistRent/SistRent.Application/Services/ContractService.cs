using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Text;

namespace SistRent.Application.Services
{
    public class ContractService(IContractRepository _repo)
    {
        public async Task<IEnumerable<ContractResponseDto>> GeTAsync()
        {
            var contracts = await _repo.GetAsync();

            return contracts.Select(e => new ContractResponseDto(
                IdContract: e.IdContract,
                FullName: e.User.FullName,
                RoomNumber: e.Room.RoomNumber,
                ContractStatus: e.ContractStatus.Name,
                StartDate: e.StartDate,
                EndDate:e.EndDate,
                MonthlyAmount:e.MonthlyAmount,
                SecurityDeposit:e.SecurityDeposit,
                RegistrationDate:e.RegistrationDate
                ));


        }

        public async Task<ContractDetailDto> GetByIdAsync(int id)
        {

            if (id == 0) throw new ValidationException("User id is requeried");
            var contract = await _repo.GetByIdAsync(id);

            if (contract is null) throw new ValidationException("Contract not found");

            return new ContractDetailDto(
                IdContract: contract.IdContract,
                FullName: contract.User.FullName,
                RoomNumber: contract.Room.RoomNumber,
                ContractStatus: contract.ContractStatus.Name,
                StartDate: contract.StartDate,
                EndDate: contract.EndDate,
                MonthlyAmount: contract.MonthlyAmount,
                SecurityDeposit: contract.SecurityDeposit,
                RegistrationDate: contract.RegistrationDate,
                Payments: contract.Payments.Select(c => new PaymentResponseDto(
                            IdPayment: c.IdPayment,
                            IdContract: c.IdContract,
                            PaymentMethod: c.PaymentMethod.Name,
                            PaymentDate: c.PaymentDate,
                            PeriodStart: c.PeriodStart,
                            PeriodEnd: c.PeriodEnd,
                            Amount: c.Amount,
                            LateFee: c.LateFee,
                            TotalAmount: c.TotalAmount,
                            Status: c.Status,
                            CreatedAt: c.CreatedAt
                    )).ToList()
                );


        }

        public async Task AddAsync(ContractCreateDto contract)
        {

            if ((contract.IdUser==0)) throw new ValidationException("User id is requeried");
         

            var newContract = new Contract
            {

                IdUser=contract.IdUser,
                IdRoom=contract.IdRoom,
                IdContractStatus=contract.IdContractStatus,
                StartDate=contract.StartDate,
                EndDate=contract.EndDate,
                MonthlyAmount=contract.MonthlyAmount,
                SecurityDeposit=contract.SecurityDeposit,
                Notes=contract.Notes
            };

            await _repo.AddAsync(newContract);
        }

    }
}
