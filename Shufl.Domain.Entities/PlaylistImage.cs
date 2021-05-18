using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class PlaylistImage
    {
        public Guid Id { get; set; }
        public Guid PlaylistId { get; set; }
        public short Width { get; set; }
        public short Height { get; set; }
        public string Url { get; set; }

        public virtual Playlist Playlist { get; set; }
    }
}
