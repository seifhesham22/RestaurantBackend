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
        public Task<DishDto?> GetDishInfoAsync(Guid? dishId);
        public Task<DishPagedListDto> GetDishPagedListAsync(DishFilterParams filter);
        public Task UpdateDishAvgRatingService(Guid? dishId);
    }
}
