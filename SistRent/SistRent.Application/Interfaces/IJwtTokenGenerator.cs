using SistRent.Application.DTOs;
using SistRent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface IJwtTokenGenerator
    {
        LoginTokenDto GenerateToken(JwtUserDto user);
    }
}
