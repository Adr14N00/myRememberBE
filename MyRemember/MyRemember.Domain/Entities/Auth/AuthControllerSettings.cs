using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRemember.Domain.Entities.Auth
{
    public class AuthControllerSettings : BaseEntity<int>
    {
        public string? Name { get; set; }
        public string? Config { get; set; }
    }
}
