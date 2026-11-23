using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistRent.Application.DTOs;
using SistRent.Application.Services;

namespace SistRent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly PaymentMethodService _paymentMethodService;
        public PaymentMethodController(PaymentMethodService paymentService)
        {
            _paymentMethodService = paymentService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] PaymentMethodCreateDto request)
        {
            await _paymentMethodService.AddAsync(request);
            return Ok(new
            {
                msg = "PaymentMethod Created"
            });
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var users = await _paymentMethodService.GetByIdAsync(id);

            if (users is null)
            {
                return NotFound(new
                {
                    message = "PaymentMethod no encontrado"
                });
            }
            return Ok(users);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] PaymentMethodUpdateDto request)
        {
            await _paymentMethodService.UpdateAsync(request);
            return Ok(new { msg = "PaymentMethod updated" });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            await _paymentMethodService.DeleteAsync(id);
            return NoContent();
        }
    }
}
