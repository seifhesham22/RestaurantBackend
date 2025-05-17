using Entities;
using Restaurant.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.RepositoryContracts
{
    public interface IDishRepository
    {
        /// <summary>
        /// Retrieves all dishes from the data store (full menu).
        /// </summary>
        /// <returns>An IEnumerable collection of Dish object.</returns>
        Task<IEnumerable<Dish>> GetAllDishes(IEnumerable<CategoryOptions> Categories , bool IsVegetarian ,IEnumerable<SortingOptions> Sorting, int Page);
        /// <summary>
        /// Gets a dish by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the dish.</param>
        /// <returns>The matching dish object if found; otherwise, null.</returns>
        Task<Dish> GetDishById(Guid id);
    }
}
