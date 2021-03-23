using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class User
    {
        public User()
        {
            GroupCreatedByNavigations = new HashSet<Group>();
            GroupInviteCreatedByNavigations = new HashSet<GroupInvite>();
            GroupInviteLastUpdatedByNavigations = new HashSet<GroupInvite>();
            GroupLastUpatedByNavigations = new HashSet<Group>();
            GroupMemberCreatedByNavigations = new HashSet<GroupMember>();
            GroupMemberLastUpdatedByNavigations = new HashSet<GroupMember>();
            GroupMemberUsers = new HashSet<GroupMember>();
            GroupSuggestionCreatedByNavigations = new HashSet<GroupSuggestion>();
            GroupSuggestionLastUpdatedByNavigations = new HashSet<GroupSuggestion>();
            PasswordResets = new HashSet<PasswordReset>();
            UserVerifications = new HashSet<UserVerification>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PictureUrl { get; set; }
        public string Password { get; set; }
        public bool? IsVerified { get; set; }
        public bool IsAdmin { get; set; }
        public string SpotifyToken { get; set; }
        public string SpotifyUsername { get; set; }
        public string SpotifyUrl { get; set; }
        public string SpotifyMarket { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public Guid? LastUpdatedBy { get; set; }

        public virtual ICollection<Group> GroupCreatedByNavigations { get; set; }
        public virtual ICollection<GroupInvite> GroupInviteCreatedByNavigations { get; set; }
        public virtual ICollection<GroupInvite> GroupInviteLastUpdatedByNavigations { get; set; }
        public virtual ICollection<Group> GroupLastUpatedByNavigations { get; set; }
        public virtual ICollection<GroupMember> GroupMemberCreatedByNavigations { get; set; }
        public virtual ICollection<GroupMember> GroupMemberLastUpdatedByNavigations { get; set; }
        public virtual ICollection<GroupMember> GroupMemberUsers { get; set; }
        public virtual ICollection<GroupSuggestion> GroupSuggestionCreatedByNavigations { get; set; }
        public virtual ICollection<GroupSuggestion> GroupSuggestionLastUpdatedByNavigations { get; set; }
        public virtual ICollection<PasswordReset> PasswordResets { get; set; }
        public virtual ICollection<UserVerification> UserVerifications { get; set; }
    }
}
