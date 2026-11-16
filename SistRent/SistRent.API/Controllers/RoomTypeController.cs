using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistRent.Application.DTOs;
using SistRent.Application.Services;

namespace SistRent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly RoomTypeService _RoomTypeService;

        public RoomTypeController(RoomTypeService RoomTypeService)
        {
            _RoomTypeService = RoomTypeService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] RoomTypeCreateDto request)
        {
            await _RoomTypeService.AddAsync(request);
            return Ok(new
            {
                msg = "User Created"
            });
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _RoomTypeService.GeTAsync();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var users = await _RoomTypeService.GetByIdAsync(id);

            if (users is null)
            {
                return NotFound(new
                {
                    message = "Usuario no encontrado"
                });
            }
            return Ok(users);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] RoomTypeUpdateDto request)
        {
            await _RoomTypeService.UpdateAsync(request);
            return Ok(new { msg = "user updated" });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _RoomTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
