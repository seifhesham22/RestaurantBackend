using IdentityEntities;
using System;
using System.Collections.Generic;

namespace Entities;

public partial class DishBasket
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid DishId { get; set; }
    public int Count { get; set; }
    public Guid? OrderId { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime ModifyDateTime { get; set; }
    public DateTime? DeleteDate { get; set; }
    public virtual Dish Dish { get; set; } = null!;
    public virtual Order? Order { get; set; }
    public virtual AspNetUser User { get; set; } = null!;
}
