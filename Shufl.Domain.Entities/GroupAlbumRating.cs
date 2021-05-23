using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class GroupAlbumRating
    {
        public Guid Id { get; set; }
        public Guid GroupAlbumId { get; set; }
        public decimal OverallRating { get; set; }
        public decimal? LyricsRating { get; set; }
        public decimal? VocalsRating { get; set; }
        public decimal? InstrumentalsRating { get; set; }
        public decimal? StructureRating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public Guid LastUpdatedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual GroupAlbum GroupAlbum { get; set; }
        public virtual User LastUpdatedByNavigation { get; set; }
    }
}
