using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.RepositoryContracts;
using Restaurant.Core.Errors;
using Restaurant.Core.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _rating;
        private readonly IDishRepository _dish;

        public RatingService(IRatingRepository rating, IDishRepository dish)
        {
            _rating = rating;
            _dish = dish;
        }

        public async Task AddRating(Guid? dishId, int rating)
        {
            if (!dishId.HasValue)
                throw new ArgumentNullException($"Dish id{dishId} is null");

            Dish? dish = await _dish.GetDishInfoAsync(dishId.Value);
            if(dish == null)
                throw new NotFoundException($"Dish with {dishId} not found");

            Rating NewRating = new Rating()
            {
                DishId = dishId.Value,
                Value = rating,
                Id = Guid.NewGuid()
            };

            await _rating.AddRating(NewRating);
        }

        public async Task<bool> CanUserRate(Guid? userId, Guid? dishId)
        {
            if (!userId.HasValue)
                throw new ArgumentNullException($"{nameof(userId)} is required");

            if (!dishId.HasValue)
                throw new ArgumentNullException($"DishId is required");

            return await _rating.CanUserRate(userId.Value, dishId.Value);
        }
    }
}
