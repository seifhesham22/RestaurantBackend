using AutoMapper;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.RepositoryContracts;
using Restaurant.Core.DTO;
using Restaurant.Core.ServicesContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Core.Errors;

namespace Restaurant.Core.Services
{
    public class DishService : IDishService
    {
        private readonly IDishRepository _db;
        private readonly IMapper _mapper;
        private readonly IRatingRepository _rating;
        public DishService(IDishRepository db , IMapper mapper , IRatingRepository rating)
        {
            _db = db;
            _mapper = mapper;
            _rating = rating;
        }
        public async Task<DishDto?> GetDishInfo(Guid? dishId)
        {
            if(!dishId.HasValue)
                throw new ArgumentNullException("dishId is required");

            Dish? Dish = await _db.GetDishInfoAsync(dishId.Value);
            if (Dish == null)
                throw new NotFoundException($"Dish with Id {dishId} not found");
            
            return _mapper.Map<DishDto>(Dish);
        }

        public async Task<DishPagedListDto> GetDishPagedList(DishFilterParams filter)
        {
            var pagedList = await _db.GetAllDishesAsync(filter);

            return _mapper.Map<DishPagedListDto>(pagedList);
        }

        public async Task UpdateDishAvgRating(Guid? dishId)
        {
            if (!dishId.HasValue) 
                throw new ArgumentNullException("Dish Id is required");

            Dish? dish = await _db.GetDishInfoAsync(dishId.Value);
            if (dish == null)
                throw new NotFoundException($"dish with Id {dishId} not found");

            List<Rating> ratings = await _rating.GetDishRatings(dishId.Value);

            float avg = (float) ratings.Average(x => x.Value);
            dish.AverageRating = avg;

            await _db.UpdateDishAvgRatingAsync(dish);
        }
    }
}
