using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.RepositoryContracts
{
    public interface IDishRepository
    {
        public Task<DishPagedList> GetAlldishesAsync(DishFilterParams dish);
        public Task<Dish?> GetDishInformationAsync(Guid dishId);
        public Task UpdateDishAvgRatingAsync(Dish dish);
    }
}
