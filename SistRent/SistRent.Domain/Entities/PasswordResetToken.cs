using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Domain.Entities
{
    public class PasswordResetToken
    {
        public int IdPasswordResetToken { get; set; }

        public int IdUser { get; set; }

        public string TokenHash { get; set; } = string.Empty;

        public DateTimeOffset ExpiresAt { get; set; }

        public DateTimeOffset? UsedAt { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public User User { get; set; } = null!;
    }
}
