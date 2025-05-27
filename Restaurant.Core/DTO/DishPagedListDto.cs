using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DTO
{
    public class DishPagedListDto
    {
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public List<DishDto>? DishList { get; set; }
    }
}
