using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class Genre
    {
        public Genre()
        {
            ArtistGenres = new HashSet<ArtistGenre>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<ArtistGenre> ArtistGenres { get; set; }
    }
}
