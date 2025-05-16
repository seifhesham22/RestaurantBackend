using IdentityEntities;
using System;
using System.Collections.Generic;
namespace Entities;
public partial class Order
{
    public Guid Id { get; set; }
    public string Address { get; set; } = null!;
    public DateTime DeliveryTime { get; set; }
    public decimal Price { get; set; }
    public int Status { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime ModifyDateTime { get; set; }
    public DateTime? DeleteDate { get; set; }
    public virtual ICollection<DishBasket> DishBaskets { get; set; } = new List<DishBasket>();
    public virtual AspNetUser User { get; set; } = null!;
}
