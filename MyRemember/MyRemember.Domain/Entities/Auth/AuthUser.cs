using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRemember.Domain.Entities.Auth
{
    public class AuthUser : BaseEntity<Guid>
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int IdRole { get; set; }
        public bool IsActive { get; set; }
        public bool IsPasswordSet { get; set; }
        public Guid UserTenantId { get; set; }

        public virtual AuthRole IdRoleNavigation { get; set; } = null!;
        public virtual ICollection<AuthUserRefreshToken>? AuthUserRefreshTokens { get; set; }
    }
}
