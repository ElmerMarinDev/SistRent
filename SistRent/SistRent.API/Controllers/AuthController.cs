using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistRent.Application.DTOs;
using SistRent.Application.Interfaces;
using SistRent.Infrastructure.Repositories;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SistRent.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/Auth/Login
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserDto request)
        { 
            try
            {
                var result = await _authService.LoginAsync(request);

                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new
                {
                    message = ex.Message
                });
            }
        }

        [HttpPost("ForgotPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto request)
        {
            await _authService.ForgotPasswordAsync(request);

            return Ok(new
            {
                message = "Si el correo está registrado, recibirás instrucciones para recuperar tu contraseña."
            });
        }

        [HttpPost("ResetPassword/{id:int}")]
        public async Task<IActionResult> ResetPassword(int id,[FromBody] ResetPasswordDto request)
        {
            try
            {
                await _authService.ResetPasswordAsync(id, request);

                return NoContent();
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

        [AllowAnonymous]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordWithTokenDto request)
        {
            await _authService.ResetPasswordWithTokenAsync(request);

            return Ok(new
            {
                Message = "Contraseña actualizada correctamente."
            });
        }
    }

}
