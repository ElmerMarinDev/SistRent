using System;
using System.Collections.Generic;
using System.Text;

namespace SistRent.Domain.Entities
{
    public class RefreshToken
    {
        public int IdRefreshToken { get; set; }

        public int IdUser { get; set; }

        // Se almacena el hash, no el token original.
        public string TokenHash { get; set; } = string.Empty;

        public DateTimeOffset ExpiresAt { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset? RevokedAt { get; set; }

        public string? ReplacedByTokenHash { get; set; }

        public User User { get; set; } = null!;
    }
}
