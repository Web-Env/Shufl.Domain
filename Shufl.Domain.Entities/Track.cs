using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class Track
    {
        public Guid Id { get; set; }
        public string SpotifyId { get; set; }
        public Guid AlbumId { get; set; }
        public string Name { get; set; }
        public short TrackNumber { get; set; }
        public byte DiscNumber { get; set; }
        public int Duration { get; set; }

        public virtual Album Album { get; set; }
    }
}
