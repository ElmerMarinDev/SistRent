using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendPasswordResetAsync(string email,string resetLink);
    }
}
