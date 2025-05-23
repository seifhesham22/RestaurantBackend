using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class Dish
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }
        public string Image { get; set; } = null!;
        public bool IsVegetarian { get; set; }
        public float AverageRating { get; set; }
        public int Category {  get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public DateTime DeleteDate { get; set; }
        public virtual ICollection<DishCart> DishCarts { get; set; } = new List<DishCart>();
        public virtual ICollection<Rating> Rating { get; set; } = new List<Rating>();
    }
}
