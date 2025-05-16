using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
namespace IdentityEntities;
public partial class AspNetUserClaim : IdentityUserClaim<Guid>
{
    public virtual AspNetUser User { get; set; } = null!;
}
