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
                msg = "Room Created"
            });
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _RoomTypeService.GeTAsync();
            return Ok(rooms);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var rooms = await _RoomTypeService.GetByIdAsync(id);

            if (rooms is null)
            {
                return NotFound(new
                {
                    message = "Room no encontrado"
                });
            }
            return Ok(rooms);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] RoomTypeUpdateDto request)
        {
            await _RoomTypeService.UpdateAsync(request);
            return Ok(new { msg = "Room updated" });
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _RoomTypeService.DeleteAsync(id);
            return NoContent();
        }
    }
}
