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
    public class RoomController : ControllerBase
    {
        private readonly RoomService _roomService;
        public RoomController(RoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] RoomCreateDto request)
        {
            await _roomService.AddAsync(request);
            return Ok(new
            {
                msg = "User Created"
            });
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var users = await _roomService.GetByIdAsync(id);

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
        public async Task<IActionResult> Update([FromBody] RoomUpdateDto request)
        {
            await _roomService.UpdateAsync(request);
            return Ok(new { msg = "user updated" });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roomService.DeleteAsync(id);
            return NoContent();
        }

    }
}
