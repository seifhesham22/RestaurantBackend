using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace IdentityEntities;

public partial class AspNetUserLogin : IdentityUserLogin<Guid>
{
    public virtual AspNetUser User { get; set; } = null!;
}
