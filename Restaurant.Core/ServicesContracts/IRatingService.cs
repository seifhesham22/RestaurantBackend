using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.ServicesContracts
{
    public interface IRatingService
    {
        public Task AddRating(Guid? dishId , int rating);
        public Task<bool> CanUserRate(Guid? userId, Guid? dishId);
    }
}
