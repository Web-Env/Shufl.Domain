using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class UserImage
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public short Width { get; set; }
        public short Height { get; set; }
        public string Uri { get; set; }

        public virtual User User { get; set; }
    }
}
