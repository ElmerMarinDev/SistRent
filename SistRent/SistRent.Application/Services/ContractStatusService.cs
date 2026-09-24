using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SistRent.Application.Services
{
    public class ContractStatusService(IContractStatusRepository _repo)
    {
        public async Task<IEnumerable<ContractStatusResponseDto>> GeTAsync()
        {
            var contracts = await _repo.GetAsync();

            return contracts.Select(e => new ContractStatusResponseDto(
                IdContractStatus: e.IdContractStatus,
                Name: e.Name,
                Description:e.Description

                ));
        }

        public async Task AddAsync(ContractStatusCreateDto contractStatus)
        {
            var newContractStatus = new ContractStatus
            {
                Name= contractStatus.Name,
                Description=contractStatus.Description,

            };

            await _repo.AddAsync(newContractStatus);
        }


        public ContractStatus UpdateData(ContractStatusUpdateDto contractStatus, ContractStatus existingUser)
        {

            if (existingUser.Name != contractStatus.Name)
                existingUser.Name = contractStatus.Name;

            if (existingUser.Description != contractStatus.Description)
                existingUser.Description = contractStatus.Description;

            return existingUser;

        }

        public async Task UpdateAsync(ContractStatusUpdateDto contractStatus)
        {
            if (contractStatus.IdContractStatus == 0) throw new ValidationException("Id is requeried");
            if (string.IsNullOrEmpty(contractStatus.Name)) throw new ValidationException("Full Name id is requeried");
            if (string.IsNullOrEmpty(contractStatus.Description)) throw new ValidationException("Description id is requeried");

            var existingContractStatus = await _repo.GetByIdAsync(contractStatus.IdContractStatus);

            if (existingContractStatus is null) throw new ValidationException("User not found");

            UpdateData(contractStatus, existingContractStatus);

            await _repo.EditAsync(existingContractStatus);
        }

        public async Task DeleteAsync(int id)
        {
            if (id == 0) throw new ValidationException("Id is Requeried");
            await _repo.DeleteAsync(id);

        }

    }
}
