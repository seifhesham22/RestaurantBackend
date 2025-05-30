using Restaurant.Core.Domain.Entities;
using Restaurant.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.ServicesContracts
{
    public interface IDishService
    {
        public Task<DishDto?> GetDishInfo(Guid? dishId);
        public Task<DishPagedListDto> GetDishPagedList(DishFilterParams filter);
        public Task UpdateDishAvgRating(Guid? dishId);
    }
}
