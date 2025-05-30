using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.RepositoryContracts;
using Restaurant.Core.DTO;
using Restaurant.Core.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cart;
        private readonly IMapper _mapper;
        private readonly IDishRepository _dish;

        public CartService(ICartRepository cart, IMapper mapper , IDishRepository dish)
        {
            _cart = cart;
            _mapper = mapper;
            _dish = dish;
        }

        public async Task AddDishToCart(Guid? dishId, Guid userId)
        {
            if(dishId == null)
                throw new ArgumentNullException($"DishId is required{nameof(dishId)}");

            var dish = await _dish.GetDishInfoAsync(dishId.Value);
            if (dish == null)
                throw new ArgumentNullException("Invalid dish Id");

            var cartItems = await _cart.GetUserCartAsync(userId);
            
            var excestingItem = cartItems.FirstOrDefault(x => x.DishId == dishId);
            if(excestingItem != null)
            {
                excestingItem.Quantity += 1;
                await _cart.UpdateCartItemAsync(excestingItem);
            }
            else
            {

                var cart = new DishCart
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    DishId = dishId.Value,
                    CreateDateTime = DateTime.Now,
                    Quantity = 1
                };

                await _cart.AddDishToCartAsync(cart);
            }
        }

        public async Task<List<DishCartDto>> GetUserCart(Guid userId)
        {
            var cart = await _cart.GetUserCartAsync(userId);

            return _mapper.Map<List<DishCartDto>>(cart);
        }

        public async Task RemoveDishFromCart(Guid? dishId , Guid userId)
        {
            if (dishId == null)
                throw new ArgumentNullException($"DishId is required{nameof(dishId)}");

            var dish = await _dish.GetDishInfoAsync(dishId.Value);
            if (dish == null)
                throw new ArgumentNullException("Invalid dish Id");

            var cartItems = await _cart.GetUserCartAsync(userId);

            var existingItem = cartItems.FirstOrDefault(x => x.DishId == dishId);

            if (existingItem == null)
                throw new InvalidOperationException("The dish doesn't exist in the cart.");

            if (existingItem.Quantity > 1)
            {
                existingItem.Quantity--;
                await _cart.UpdateCartItemAsync(existingItem);
            }
            else
            {
                await _cart.DeleteCartItemAsync(existingItem);
            }
        }
    }
}
