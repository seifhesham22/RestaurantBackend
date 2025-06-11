using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.RepositoryContracts;
using Restaurant.Core.Enums;
using Restaurant.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly RestaurantDbContext _db;
        public DishRepository(RestaurantDbContext db)
        {
            _db = db;
        }
        public async Task<DishPagedList> GetAllDishesAsync(DishFilterParams filter)
        {
            IQueryable<Dish> dishes = _db.Set<Dish>();

            if(filter.Categories != null && filter.Categories.Any() == true)
            {
                dishes = dishes.Where(d => filter.Categories.Contains(d.Category));
            }

            if(filter.Vegetarian == true)
            {
                dishes = dishes.Where(x => x.IsVegetarian);
            }

            var totalItems = await dishes.CountAsync();

            dishes = ApplySorting(dishes , filter.Sorting);
            dishes = ApplyPagination(dishes, filter.Page, filter.PageSize);
            
            var dishesList = await dishes.ToListAsync();
            return new DishPagedList
            {
                DishList = dishesList,
                TotalItems = totalItems,
                CurrentPage = filter.Page,
                PageSize = filter.PageSize
            };
        }

        private IQueryable<Dish> ApplySorting(IQueryable<Dish> dishes , DishSortingOptions sortingOptions)
        {
            return sortingOptions switch
            {
                DishSortingOptions.NameAsc => dishes.OrderBy(x => x.Name),
                DishSortingOptions.NameDesc => dishes.OrderByDescending(x => x.Name),
                DishSortingOptions.PriceDesc => dishes.OrderByDescending(x => x.Price),
                DishSortingOptions.PriceAsc => dishes.OrderBy(x => x.Price),
                DishSortingOptions.RatingAsc => dishes.OrderBy(x => x.Rating),
                DishSortingOptions.RatingDesc => dishes.OrderByDescending(x => x.Rating),
                _ => dishes.OrderBy(_ => _.Name),
            };
        }

        private IQueryable<Dish> ApplyPagination(IQueryable<Dish> query, int page , int pageSize)
        {
            return query
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
        }

        public async Task<Dish?> GetDishInfoAsync(Guid dishId)
        {
            return await _db.Dishes.FirstOrDefaultAsync(x => x.Id == dishId);
        }

        public async Task UpdateDishAvgRatingAsync(Dish dish)
        {
            _db.Dishes.Update(dish);
            await _db.SaveChangesAsync();
        }
    }
}
