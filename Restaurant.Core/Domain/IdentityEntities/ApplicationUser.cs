using Microsoft.AspNetCore.Identity;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.IdentityEntities
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        public string FullName { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; } = null!;
        public DateTime CreateDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public DateTime? DeleteDate { get; set; }
        public virtual ICollection<DishCart> DishBaskets { get; set; } = new List<DishCart>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
        public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
