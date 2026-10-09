using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using SistRent.Application.Services;

namespace SistRent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody]UserCreateDto request) 
        {
            await _userService.AddAsync(request);
            return Ok(new
            {
                msg = "User Created"
            });
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users=await _userService.GeTAsync();
            return Ok(users);
        }

        [HttpGet("{id:int}")]   
        public async Task<IActionResult> Get(int id)
        {
            var users = await _userService.GetByIdAsync(id);
            return Ok(users);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] UserUpdateDto request)
        {
            await _userService.UpdateAsync(request);
            return Ok(new {msg="user updated"} );
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
