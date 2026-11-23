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
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;
        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] RoleCreateDto request)
        {
            await _roleService.AddAsync(request);
            return Ok(new
            {
                msg = "Role Created"
            });
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _roleService.GeTAsync();
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var users = await _roleService.GetByIdAsync(id);

            if (users is null)
            {
                return NotFound(new
                {
                    message = "Role no encontrado"
                });
            }
            return Ok(users);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] RoleUpdateDto request)
        {
            await _roleService.UpdateAsync(request);
            return Ok(new { msg = "Role updated" });
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleService.DeleteAsync(id);
            return NoContent();
        }

    }
}
