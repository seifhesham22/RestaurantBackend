using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.RepositoryContracts;
using Restaurant.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly RestaurantDbContext _db;
        public RatingRepository(RestaurantDbContext db)
        {
            _db = db;
        }

        public async Task AddRating(Rating rating)
        {
            _db.Ratings.Add(rating);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> CanUserRate(Guid userId , Guid dishId)
        {
            return await _db.DishesCarts.AnyAsync(x => x.DishId == dishId && x.UserId == userId && x.OrderId != null);
        }

        public async Task<List<Rating>> GetDishRatings(Guid dishId)
        {
            return await _db.Ratings.Where(x => x.DishId == dishId).ToListAsync();
        }
    }
}
