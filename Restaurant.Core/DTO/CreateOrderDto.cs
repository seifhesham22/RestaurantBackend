using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DTO
{
    public class CreateOrderDto
    {
        [Required]
        public DateTime DeliveryTime { get; set; }
        [Required]
        public string Address { get; set; } = string.Empty;
    }
}
