using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace IdentityEntities;

public partial class AspNetRoleClaim :IdentityRoleClaim<Guid>
{
    public virtual AspNetRole Role { get; set; } = null!;
}
