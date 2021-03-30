using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class Album
    {
        public Album()
        {
            AlbumArtists = new HashSet<AlbumArtist>();
            AlbumImages = new HashSet<AlbumImage>();
            GroupSuggestions = new HashSet<GroupSuggestion>();
            Tracks = new HashSet<Track>();
        }

        public Guid Id { get; set; }
        public string SpotifyId { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public byte Type { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }

        public virtual ICollection<AlbumArtist> AlbumArtists { get; set; }
        public virtual ICollection<AlbumImage> AlbumImages { get; set; }
        public virtual ICollection<GroupSuggestion> GroupSuggestions { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
