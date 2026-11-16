using SistRent.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginUserDto request);

        Task ForgotPasswordAsync(ForgotPasswordDto request);

        Task ResetPasswordWithTokenAsync(ResetPasswordWithTokenDto request);

        Task ChangePasswordAsync(int userId,ChangePasswordDto request);

        Task ResetPasswordAsync(int userId,ResetPasswordDto request);
    }
}
