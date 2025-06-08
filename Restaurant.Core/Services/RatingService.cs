using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.RepositoryContracts;
using Restaurant.Core.Errors;
using Restaurant.Core.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

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

        public async Task AddRating(Guid? dishId, int rating, Guid userId)
        {
            if (!dishId.HasValue)
                throw new ArgumentNullException($"Dish id{dishId} is null");

            Dish? dish = await _dish.GetDishInfoAsync(dishId.Value);

            if(dish == null)
                throw new NotFoundException($"Dish with {dishId} not found");

            var existingRate = await _rating.DidUserRate(dishId.Value, userId);

            if(existingRate is not null)
            {
                await UpdateRating(existingRate , rating);
            }
            else
            {
                await AddNewRating(dishId.Value, rating, userId);
            }
        }

        public async Task<bool> CanUserRate(Guid? userId, Guid? dishId)
        {
            if (!userId.HasValue)
                throw new ArgumentNullException($"{nameof(userId)} is required");

            if (!dishId.HasValue)
                throw new ArgumentNullException($"DishId is required");

            return await _rating.CanUserRate(userId.Value, dishId.Value);
        }

        private async Task UpdateRating(Rating rating , int score)
        {
            rating.Value = score;
            await _rating.UpdateRating(rating);
        }

        private async Task AddNewRating(Guid dishId, int score, Guid userId)
        {
            var rating = new Rating
            {
                Id = Guid.NewGuid(),
                DishId = dishId,
                UserId = userId,
                Value = score
            };

            await _rating.AddRating(rating);
        }
    }
}
