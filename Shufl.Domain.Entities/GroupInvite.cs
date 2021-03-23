using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class GroupInvite
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public string Identifier { get; set; }
        public DateTime ExpiryDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime LastUpdatedOn { get; set; }
        public Guid LastUpdatedBy { get; set; }

        public virtual User CreatedByNavigation { get; set; }
        public virtual Group Group { get; set; }
        public virtual User LastUpdatedByNavigation { get; set; }
    }
}
