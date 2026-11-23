using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using SistRent.Application.Services;

namespace SistRent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly ContractService _contractService;
        public ContractController(ContractService contractService)
        {
            _contractService = contractService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] ContractCreateDto request)
        {
            await _contractService.AddAsync(request);
            return Ok(new
            {
                msg = "Contract Created"
            });
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetAll()
        {
            var contracts = await _contractService.GeTAsync();
            return Ok(contracts);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var contract = await _contractService.GetByIdAsync(id);

            if (contract is null)
            {
                return NotFound(new
                {
                    message = "Contract no encontrado"
                });
            }
            return Ok(contract);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] ContractUpdateDto request)
        {
            await _contractService.UpdateAsync(request);
            return Ok(new { msg = "Contract updated" });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contractService.DeleteAsync(id);
            return NoContent();
        }


    }
}

