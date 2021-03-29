using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class AlbumImage
    {
        public Guid Id { get; set; }
        public Guid AlbumId { get; set; }
        public short Width { get; set; }
        public short Height { get; set; }
        public string Uri { get; set; }

        public virtual Album Album { get; set; }
    }
}
