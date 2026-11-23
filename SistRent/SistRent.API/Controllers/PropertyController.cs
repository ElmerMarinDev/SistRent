using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistRent.Application.DTOs;
using SistRent.Application.Services;

namespace SistRent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly PropertyService _propertyService;
        public PropertyController(PropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] PropertyCreateDto request)
        {
            await _propertyService.AddAsync(request);
            return Ok(new
            {
                msg = "Property Created"
            });
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var users = await _propertyService.GetByIdAsync(id);

            if (users is null)
            {
                return NotFound(new
                {
                    message = "Property no encontrado"
                });
            }
            return Ok(users);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] PropertyUpdateDto request)
        {
            await _propertyService.UpdateAsync(request);
            return Ok(new { msg = "Property updated" });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            await _propertyService.DeleteAsync(id);
            return NoContent();
        }
    }
}
