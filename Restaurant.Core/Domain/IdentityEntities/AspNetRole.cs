using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace IdentityEntities;

public partial class AspNetRole : IdentityRole<Guid>
{
    public Guid Id { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime ModifyDateTime { get; set; }

    public DateTime? DeleteDate { get; set; }

  

    public virtual ICollection<AspNetRoleClaim> AspNetRoleClaims { get; set; } = new List<AspNetRoleClaim>();

    public virtual ICollection<AspNetUser> Users { get; set; } = new List<AspNetUser>();
}
