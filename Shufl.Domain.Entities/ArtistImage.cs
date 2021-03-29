using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class ArtistImage
    {
        public Guid Id { get; set; }
        public Guid ArtistId { get; set; }
        public short Width { get; set; }
        public short Height { get; set; }
        public string Uri { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
