using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class GroupPlaylistRating
    {
        public Guid Id { get; set; }
        public Guid GroupPlaylistId { get; set; }
        public decimal OverallRating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public Guid LastUpdatedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual GroupPlaylist GroupPlaylist { get; set; }
        public virtual User LastUpdatedByNavigation { get; set; }
    }
}
