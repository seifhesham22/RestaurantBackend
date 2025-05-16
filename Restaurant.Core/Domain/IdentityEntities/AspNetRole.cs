using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace IdentityEntities;

public partial class AspNetRole : IdentityRole<Guid>
{
    public DateTime CreateDateTime { get; set; }
    public DateTime ModifyDateTime { get; set; }
    public DateTime? DelteDate { get; set; }
    public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; set; } = new List<AspNetRoleClaim>();
    public virtual ICollection<AspNetUser> Users { get; set; } = new List<AspNetUser>();
}
