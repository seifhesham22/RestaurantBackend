﻿using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.RepositoryContracts
{
    public interface IRatingRepository
    {
        public Task AddRating(Rating rating);
        public Task<List<Rating>> GetDishRatings(Guid dishId);
        public Task<bool> CanUserRate(Guid userId , Guid dishId);
        public Task<Rating?> DidUserRate(Guid dishId, Guid userId);
        public Task UpdateRating(Rating rating);
    }
}
