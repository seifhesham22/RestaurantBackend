using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.RepositoryContracts
{
    public interface IDishBasketRepository
    {
        /// <summary>
        /// Retrieves the user cart items.
        /// </summary>
        /// <param name="UserId">The unique identifier of the user.</param>
        /// <returns>An IEnumerable collection of DishBasket object.</returns>
        Task<IEnumerable<DishBasket>> GetUserCart(Guid UserId);
        /// <summary>
        /// Adds a dish to the current user's basket. If the dish already exists, increases the quantity.
        /// </summary>
        /// <param name="DishId">The unique identifier of the user.</param>
        /// <returns></returns>
        Task AddDishToBasket(Guid DishId);
        /// <summary>
        ///  Removes a dish from the user's basket. If DecreaseOnly is true, decreases quantity by one;otherwise, removes the item entirely.
        /// </summary>
        /// <param name="DishId">The unique identifier of the dish to remove.</param>
        /// <param name="DecreaseOnly">If true, only decrease the count; if false, remove the item entirely.</param>
        /// <returns></returns>
        Task DeleteDishFromBasket(Guid DishId, bool DecreaseOnly);
    }
}
