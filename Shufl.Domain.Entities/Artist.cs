using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class Artist
    {
        public Artist()
        {
            AlbumArtists = new HashSet<AlbumArtist>();
            ArtistImages = new HashSet<ArtistImage>();
            TrackArtists = new HashSet<TrackArtist>();
        }

        public Guid Id { get; set; }
        public string SpotifyId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AlbumArtist> AlbumArtists { get; set; }
        public virtual ICollection<ArtistImage> ArtistImages { get; set; }
        public virtual ICollection<TrackArtist> TrackArtists { get; set; }
    }
}
