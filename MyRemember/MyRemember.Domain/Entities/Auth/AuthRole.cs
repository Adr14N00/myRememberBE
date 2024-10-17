using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRemember.Domain.Entities.Auth
{
    public class AuthRole: BaseEntity<int>
    {
        public string Name { get; set; } = null!;

        public virtual ICollection<AuthUser> AuthUsers { get; set; }
    }
}
