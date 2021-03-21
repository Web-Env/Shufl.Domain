using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class PasswordReset
    {
        public Guid Id { get; set; }
        public string ResetIdentifier { get; set; }
        public Guid UserId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string RequesterAddress { get; set; }
        public bool? Active { get; set; }
        public DateTime? UsedOn { get; set; }
        public string UsedByAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastUpdatedOn { get; set; }

        public virtual User User { get; set; }
    }
}
