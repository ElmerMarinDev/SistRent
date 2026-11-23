using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistRent.Application.DTOs;
using SistRent.Application.Services;

namespace SistRent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;
        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] PaymentCreateDto request)
        {
            await _paymentService.AddAsync(request);
            return Ok(new
            {
                msg = "Payment Created"
            });
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var users = await _paymentService.GetByIdAsync(id);

            if (users is null)
            {
                return NotFound(new
                {
                    message = "Payment no encontrado"
                });
            }
            return Ok(users);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] PaymentUpdateDto request)
        {
            await _paymentService.UpdateAsync(request);
            return Ok(new { msg = "Payment updated" });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            await _paymentService.DeleteAsync(id);
            return NoContent();
        }
    }
}
