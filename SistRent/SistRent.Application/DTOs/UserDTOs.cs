using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.DTOs
{
    public record UserDTO(int UserId,string FullName,string Email,string Role,bool ResetPassword);
    public record LoginUserDTO(string Email, string Password);
    public record ChangePasswordUserDTO(int UserId, string Password);
    public record CreateUserDTO(string FullName, string Email, string Role,string Password);
    public record UpdateUserDTO(int UserId, string FullName, string Email, string Role, bool ResetPassword);
}
