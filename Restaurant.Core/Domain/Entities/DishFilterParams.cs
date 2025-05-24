using Restaurant.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.Entities
{
    public class DishFilterParams
    {
        public List<DishCategory>? Categories { get; set; }
        public bool? Vegetarian { get; set; } = false;
        public DishSortingOptions Sorting { get; set; } = DishSortingOptions.NameAsc;
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
