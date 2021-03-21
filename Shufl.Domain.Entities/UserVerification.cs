using System;
using System.Collections.Generic;

#nullable disable

namespace Shufl.Domain.Entities
{
    public partial class UserVerification
    {
        public Guid Id { get; set; }
        public string VerificationIdentifier { get; set; }
        public Guid UserId { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool? Active { get; set; }
        public string RequesterAddress { get; set; }
        public DateTime? UsedOn { get; set; }
        public string UsedByAddress { get; set; }

        public virtual User User { get; set; }
    }
}
