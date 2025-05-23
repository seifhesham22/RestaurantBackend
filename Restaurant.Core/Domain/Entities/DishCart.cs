using Restaurant.Core.Domain.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class DishCart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DishId { get; set; }
        public Guid? OrderId { get; set; }
        public int Quantity { get; set; }   
        public DateTime CreateDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public DateTime? DeleteDate { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;
        public virtual Dish Dish { get; set; } = null!;
        public virtual Order? Order { get; set; }
    }
}
