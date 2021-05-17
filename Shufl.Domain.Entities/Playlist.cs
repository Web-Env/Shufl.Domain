using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class Playlist
    {
        public Playlist()
        {
            GroupPlaylists = new HashSet<GroupPlaylist>();
            PlaylistImages = new HashSet<PlaylistImage>();
        }

        public Guid Id { get; set; }
        public string SpotifyId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public Guid LastUpdatedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User LastUpdatedByNavigation { get; set; }
        public virtual ICollection<GroupPlaylist> GroupPlaylists { get; set; }
        public virtual ICollection<PlaylistImage> PlaylistImages { get; set; }
    }
}
