using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.DbContextInterface
{
    public interface IApplicationDbContext
    {
        //DbSet<Order> Orders { get; }
        //DbSet<Dish> Dishes { get; }
        //DbSet<Rating> Ratings { get; }
        //DbSet<DishCart> DishesCarts { get; }
        //Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
