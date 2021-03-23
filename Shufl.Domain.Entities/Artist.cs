using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
        }

        public Guid Id { get; set; }
        public string SpotifyId { get; set; }
        public string Name { get; set; }
        public string SmallIcon { get; set; }
        public string LargeIcon { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
