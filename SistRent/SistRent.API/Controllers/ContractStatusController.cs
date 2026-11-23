using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistRent.Application.DTOs;
using SistRent.Application.Services;

namespace SistRent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractStatusController : ControllerBase
    {
        private readonly ContractStatusService _contractStatusService;
        public ContractStatusController(ContractStatusService contractStatusService)
        {
            _contractStatusService = contractStatusService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] ContractStatusCreateDto request)
        {
            await _contractStatusService.AddAsync(request);
            return Ok(new
            {
                msg = "ContractStatus Created"
            });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var contract = await _contractStatusService.GetByIdAsync(id);

            if (contract is null)
            {
                return NotFound(new
                {
                    message = "ContractStatus no encontrado"
                });
            }
            return Ok(contract);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] ContractStatusUpdateDto request)
        {
            await _contractStatusService.UpdateAsync(request);
            return Ok(new { msg = "ContractStatus updated" });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contractStatusService.DeleteAsync(id);
            return NoContent();
        }
    }
}
