using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.RepositoryContracts;
using Restaurant.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly RestaurantDbContext _db;
        public CartRepository(RestaurantDbContext db)
        {
            _db = db;
        }

        public async Task AddDishToCartAsync(DishCart cartItem)
        {
           await _db.DishesCarts.AddAsync(cartItem);
           await _db.SaveChangesAsync();
        }

        public async Task<List<DishCart>> GetUserCartAsync(Guid userId)
        {
            return await _db.DishesCarts.Where(x => x.Id == userId && x.OrderId == null).Include(x => x.Dish).ToListAsync();
        }

        public async Task RemoveDishFromCartAsync(DishCart cartItem)
        {
            _db.DishesCarts.Remove(cartItem);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateCartItemAsync(DishCart cartItem)
        {
            _db.DishesCarts.Update(cartItem);
            await _db.SaveChangesAsync();
        }
    }
}
