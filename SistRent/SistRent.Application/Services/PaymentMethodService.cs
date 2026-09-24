using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Services
{
    public class PaymentMethodService(IContractStatusRepository _repo)
    {

        public async Task<IEnumerable<ContractStatusResponseDto>> GeTAsync()
        {
            var contracts = await _repo.GetAsync();

            return contracts.Select(e => new ContractStatusResponseDto(
                IdContractStatus: e.IdContractStatus,
                Name: e.Name,
                Description: e.Description

                ));
        }
    }
}
