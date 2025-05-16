using Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace IdentityEntities;

public partial class AspNetUser : IdentityUser<Guid>
{
    public string FullName { get; set; } = null!;
    public DateTime? BirthDate { get; set; }
    public int Gender { get; set; }
    public string Address { get; set; } = null!;
    public DateTime CreateDateTime { get; set; }
    public DateTime ModifyDateTime { get; set; }
    public DateTime? DeleteDate { get; set; }
    public virtual ICollection<DishBasket> DishBaskets { get; set; } = new List<DishBasket>();
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    public virtual ICollection<AspNetRole> Roles { get; set; } = new List<AspNetRole>();
}
