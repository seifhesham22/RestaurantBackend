using Restaurant.Core.Domain.Entities;
using Restaurant.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.ServicesContracts
{
    public interface ICartService
    {
        public Task<List<DishCartDto>> GetUserCart(Guid userId);
        public Task AddDishToCart(Guid? dishId , Guid userId);
        public Task RemoveDishFromCart(Guid? dishId , Guid userId);
    }
}
