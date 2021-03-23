using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class Album
    {
        public Album()
        {
            GroupSuggestions = new HashSet<GroupSuggestion>();
            Tracks = new HashSet<Track>();
        }

        public Guid Id { get; set; }
        public string SpotifyId { get; set; }
        public Guid ArtistId { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Type { get; set; }
        public string SmallIcon { get; set; }
        public string LargeIcon { get; set; }

        public virtual Artist Artist { get; set; }
        public virtual ICollection<GroupSuggestion> GroupSuggestions { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
