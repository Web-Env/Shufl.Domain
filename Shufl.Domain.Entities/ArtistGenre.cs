using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class ArtistGenre
    {
        public Guid Id { get; set; }
        public Guid ArtistId { get; set; }
        public Guid GenreId { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
