using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRemember.Domain.Entities
{
    public abstract class BaseEntity<TId>
        where TId : struct, IEquatable<TId>
    {
        public TId Id { get; set; }
        public DateTimeOffset CreateDateTime { get; set; }
        public DateTimeOffset CreateBy { get; set; }
        public DateTimeOffset? UpdateDateTime { get; set; }
        public DateTimeOffset? UpdateBy { get; set; }
        public int RecordVersion { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
