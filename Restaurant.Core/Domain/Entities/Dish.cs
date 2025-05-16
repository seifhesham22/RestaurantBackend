using System;
using System.Collections.Generic;

namespace Entities;
public partial class Dish
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public string Image { get; set; } = null!;
    public bool IsVegetarian { get; set; }
    public double? AverageRating { get; set; }
    public int Category { get; set; }
    public DateTime CreateDateTime { get; set; }
    public DateTime ModifyDateTime { get; set; }
    public DateTime? DeleteDate { get; set; }
    public virtual ICollection<DishBasket> DishBaskets { get; set; } = new List<DishBasket>();
    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
