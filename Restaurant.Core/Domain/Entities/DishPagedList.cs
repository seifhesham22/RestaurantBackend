using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class DishPagedList
    {
        public int Size { get; set; }
        public int TotalItems { get; set; }
        public int Current { get; set; }
        public List<Dish>? DishList { get; set; }
    }
}
