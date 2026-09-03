using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Services
{
    public class TenantService(ITenantRepository _repo)
    {
        public async Task<IEnumerable<TenantResponseDto>> GeTAsync()
        {
            var tenants = await _repo.GetAsync();

            return tenants.Select(e => new TenantResponseDto(
                IdTenant: e.IdTenant,
                IdUser: e.IdUser,
                Status: e.Status,
                Dni:e.Dni,
                Phone:e.Phone,
                RegistrationDate:e.RegistrationDate,
                EmergencyContact: e.EmergencyContact 
                ));


        }
    }
}
