using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.RepositoryContracts
{
    public interface ICartRepository
    {
        public Task<List<DishCart>> GetUserCartAsync(Guid userId);
        public Task AddDishToCartAsync(DishCart cartItem);
        public Task UpdateCartItemAsync(DishCart cartItem);
        public Task RemoveDishFromCartAsync(DishCart cartItem);
        public Task DeleteCartItemAsync(DishCart cartItem);
    }
}
