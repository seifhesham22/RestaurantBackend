using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace IdentityEntities;
public partial class AspNetUserToken : IdentityUserToken<Guid>
{
    public virtual AspNetUser User { get; set; } = null!;
}
