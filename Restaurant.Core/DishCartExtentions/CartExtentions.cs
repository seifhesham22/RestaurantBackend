using Microsoft.AspNetCore.Http;
using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DishCartExtentions
{
    public static class CartExtentions
    {
        public static double GetTotalPrice(this IEnumerable<DishCart> cart)
        {
            if (cart == null)
                throw new ArgumentNullException(nameof(cart));

            return cart.Sum(x => x.Dish.Price * x.Quantity);
        }
    }
}
