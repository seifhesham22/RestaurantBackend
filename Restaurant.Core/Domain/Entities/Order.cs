using Restaurant.Core.Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime DeliveryTime { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public DateTime? DeleteDate { get; set; }
        public double Price { get; set; }
        public int status { get; set; } 
        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!; // nav property
        public virtual ICollection<DishCart> DishCarts { get; set; } = new List<DishCart>();
    }
}
