using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class GroupSuggestionRating
    {
        public Guid Id { get; set; }
        public Guid GroupSuggestionId { get; set; }
        public decimal OverallRating { get; set; }
        public decimal? LyricsRating { get; set; }
        public decimal? VocalsRating { get; set; }
        public decimal? InstrumentalsRating { get; set; }
        public decimal? CompositionRating { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public Guid LastUpdatedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual GroupSuggestion GroupSuggestion { get; set; }
        public virtual User LastUpdatedByNavigation { get; set; }
    }
}
