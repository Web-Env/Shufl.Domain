using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class Group
    {
        public Group()
        {
            GroupAlbums = new HashSet<GroupAlbum>();
            GroupInvites = new HashSet<GroupInvite>();
            GroupMembers = new HashSet<GroupMember>();
            GroupPlaylists = new HashSet<GroupPlaylist>();
        }

        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public bool? IsPrivate { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public Guid LastUpatedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual User LastUpatedByNavigation { get; set; }
        public virtual ICollection<GroupAlbum> GroupAlbums { get; set; }
        public virtual ICollection<GroupInvite> GroupInvites { get; set; }
        public virtual ICollection<GroupMember> GroupMembers { get; set; }
        public virtual ICollection<GroupPlaylist> GroupPlaylists { get; set; }
    }
}
