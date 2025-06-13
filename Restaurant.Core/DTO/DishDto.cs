using Restaurant.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DTO
{
    public class DishDto
    {
        public Guid ID { get; set; }
        [Required]
        [MinLength(1)]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        [Required]
        public double Price { get; set; }
        public string Image { get; set; } = null!;
        public bool IsVegetarian { get; set; }
        public float AverageRating { get; set; }
        public DishCategory Category { get; set; }
    }
}
