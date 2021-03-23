using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class GroupSuggestionRating
    {
        public Guid Id { get; set; }
        public Guid GroupSuggestionId { get; set; }
        public byte OverallRating { get; set; }
        public byte LyricsRating { get; set; }
        public byte VocalsRating { get; set; }
        public byte InstrumentalsRating { get; set; }
        public byte CompositionRating { get; set; }
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
