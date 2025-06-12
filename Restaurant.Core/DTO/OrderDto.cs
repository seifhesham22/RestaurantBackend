using Restaurant.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DTO
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime DeliveryTime { get; set; }
        [Required]
        public DateTime CreateDateTime { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public double Price { get; set; }
        public string Address { get; set; } = null!;
        [Required]
        public List<DishCartDto> Dishes { get; set; } = null!;
    }
}
