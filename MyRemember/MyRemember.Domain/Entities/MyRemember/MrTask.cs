using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRemember.Domain.Entities.MyRemember
{
    public class MrTask: BaseEntity<Guid>
    {
        public string? Topic { get; set; }
        public string? Description { get; set; }
    }
}
