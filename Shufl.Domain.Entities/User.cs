using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            GroupAlbumCreatedByNavigations = new HashSet<GroupAlbum>();
            GroupAlbumLastUpdatedByNavigations = new HashSet<GroupAlbum>();
            GroupAlbumRatingCreatedByNavigations = new HashSet<GroupAlbumRating>();
            GroupAlbumRatingLastUpdatedByNavigations = new HashSet<GroupAlbumRating>();
            GroupCreatedByNavigations = new HashSet<Group>();
            GroupInviteCreatedByNavigations = new HashSet<GroupInvite>();
            GroupInviteLastUpdatedByNavigations = new HashSet<GroupInvite>();
            GroupLastUpatedByNavigations = new HashSet<Group>();
            GroupMemberCreatedByNavigations = new HashSet<GroupMember>();
            GroupMemberLastUpdatedByNavigations = new HashSet<GroupMember>();
            GroupMemberUsers = new HashSet<GroupMember>();
            GroupPlaylistCreatedByNavigations = new HashSet<GroupPlaylist>();
            GroupPlaylistLastUpdatedByNavigations = new HashSet<GroupPlaylist>();
            GroupPlaylistRatingCreatedByNavigations = new HashSet<GroupPlaylistRating>();
            GroupPlaylistRatingLastUpdatedByNavigations = new HashSet<GroupPlaylistRating>();
            PlaylistCreatedByNavigations = new HashSet<Playlist>();
            PlaylistLastUpdatedByNavigations = new HashSet<Playlist>();
            UserImages = new HashSet<UserImage>();
            UserVerifications = new HashSet<UserVerification>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string UserSecret { get; set; }
        public bool IsVerified { get; set; }
        public bool IsAdmin { get; set; }
        public string SpotifyRefreshToken { get; set; }
        public string SpotifyUsername { get; set; }
        public string SpotifyMarket { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public Guid? LastUpdatedBy { get; set; }

        public virtual ICollection<GroupAlbum> GroupAlbumCreatedByNavigations { get; set; }
        public virtual ICollection<GroupAlbum> GroupAlbumLastUpdatedByNavigations { get; set; }
        public virtual ICollection<GroupAlbumRating> GroupAlbumRatingCreatedByNavigations { get; set; }
        public virtual ICollection<GroupAlbumRating> GroupAlbumRatingLastUpdatedByNavigations { get; set; }
        public virtual ICollection<Group> GroupCreatedByNavigations { get; set; }
        public virtual ICollection<GroupInvite> GroupInviteCreatedByNavigations { get; set; }
        public virtual ICollection<GroupInvite> GroupInviteLastUpdatedByNavigations { get; set; }
        public virtual ICollection<Group> GroupLastUpatedByNavigations { get; set; }
        public virtual ICollection<GroupMember> GroupMemberCreatedByNavigations { get; set; }
        public virtual ICollection<GroupMember> GroupMemberLastUpdatedByNavigations { get; set; }
        public virtual ICollection<GroupMember> GroupMemberUsers { get; set; }
        public virtual ICollection<GroupPlaylist> GroupPlaylistCreatedByNavigations { get; set; }
        public virtual ICollection<GroupPlaylist> GroupPlaylistLastUpdatedByNavigations { get; set; }
        public virtual ICollection<GroupPlaylistRating> GroupPlaylistRatingCreatedByNavigations { get; set; }
        public virtual ICollection<GroupPlaylistRating> GroupPlaylistRatingLastUpdatedByNavigations { get; set; }
        public virtual ICollection<Playlist> PlaylistCreatedByNavigations { get; set; }
        public virtual ICollection<Playlist> PlaylistLastUpdatedByNavigations { get; set; }
        public virtual ICollection<UserImage> UserImages { get; set; }
        public virtual ICollection<UserVerification> UserVerifications { get; set; }
    }
}
