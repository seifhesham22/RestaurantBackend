using Restaurant.Infrastructure;
using System;
using System.Collections.Generic;

namespace Entities;

public partial class Rating
{
    public Guid Id { get; set; }

    public int Value { get; set; }

    public Guid UserId { get; set; }

    public Guid DishId { get; set; }

    public DateTime CreateDateTime { get; set; }

    public DateTime ModifyDateTime { get; set; }

    public DateTime? DeleteDate { get; set; }

    public virtual Dish Dish { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
