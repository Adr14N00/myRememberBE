using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRemember.Domain.Entities.Auth
{
    public class AuthUserRefreshToken: BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public string Token { get; set; } = null!;
        public bool IsActive { get; set; }
        public DateTime Expires { get; set; }
        public string CreatedByIp { get; set; } = null!;
        public bool IsRevoked { get; set; }
        public DateTime? Revoked { get; set; }
        public string? RevokedByIp { get; set; }
        public string? ReasonRevoked { get; set; }
        public string? ReplacedByToken { get; set; }

        public virtual AuthUser UserIdNavigation { get; set; } = null!;
    }
}
