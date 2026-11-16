using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using System.Security.Claims;

namespace SistRent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto request)
        {
            try
            {
                var userIdValue = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (!int.TryParse(userIdValue, out int userId))
                    return Unauthorized();

                await _authService.ChangePasswordAsync(userId,request);

                return NoContent();
            }
            catch (UnauthorizedAccessException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
