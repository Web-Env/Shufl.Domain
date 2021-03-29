using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class AlbumArtist
    {
        public Guid Id { get; set; }
        public Guid AlbumId { get; set; }
        public Guid ArtistId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }

        public virtual Album Album { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
