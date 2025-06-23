using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.RepositoryContracts;
using Restaurant.Core.Services;
using Restaurant.Core.ServicesContracts;
using RestaurantBackend.ServiceTests.CustomFixtureConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBackend.ServiceTests
{
    public class CartServiceTest
    {
        private readonly ICartService _cartService;
        
        private readonly Mock<ICartRepository> _cartRepositoryMock;
        private readonly Mock<IDishRepository> _dishRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        private readonly IFixture _fixture;

        public CartServiceTest()
        {
            _cartRepositoryMock = new Mock<ICartRepository>();
            _dishRepositoryMock = new Mock<IDishRepository>();
            _mapperMock = new Mock<IMapper>();
            
            _fixture = FixtureFactory.Create();

            _cartService = new CartService(
                _cartRepositoryMock.Object,
                _mapperMock.Object,
                _dishRepositoryMock.Object
            );
        }

        [Fact]
        public async Task AddDishToCart_ShouldAddNewDish_WhenNotInCart()
        {
            var userId = Guid.NewGuid();
            var dishId = Guid.NewGuid();
            var dish = _fixture.Build<Dish>()
                               .With(x => x.Id , dishId)
                               .Create();
            
            _dishRepositoryMock.Setup(x => x.GetDishInfoAsync(dishId))
                .ReturnsAsync(dish);

            _cartRepositoryMock.Setup(x => x.GetUserCartItemsAsync(userId))
                .ReturnsAsync(new List<DishCart>());

            _cartRepositoryMock.Setup(x => x.AddDishToCartAsync(It.IsAny<DishCart>()))
                .Returns(Task.CompletedTask);

            await _cartService.AddDishToCart(dishId, userId);

            _cartRepositoryMock.Verify(r => r.AddDishToCartAsync(It.Is<DishCart>(x =>
                x.DishId == dishId &&
                x.UserId == userId &&
                x.Quantity == 1)), Times.Once());

        }

        [Fact]
        public async Task AddDishToCart_ShouldIncrementQuantity_WhenDishAlreadyInCart()
        {
            var userId = Guid.NewGuid();
            var dishId = Guid.NewGuid();
            var dish = _fixture.Build<Dish>().With(d => d.Id, dishId).Create();
            var existingCartItem = _fixture.Build<DishCart>()
                                           .With(c => c.DishId, dishId)
                                           .With(c => c.UserId, userId)
                                           .With(c => c.Quantity, 1)
                                           .Create();

            _dishRepositoryMock.Setup(r => r.GetDishInfoAsync(dishId))
                .ReturnsAsync(dish);

            _cartRepositoryMock.Setup(r => r.GetUserCartItemsAsync(userId))
                .ReturnsAsync(new List<DishCart> { existingCartItem });

            _cartRepositoryMock.Setup(r => r.UpdateCartItemAsync(existingCartItem))
                .Returns(Task.CompletedTask);

            await _cartService.AddDishToCart(dishId, userId);

            existingCartItem.Quantity.Should().Be(2);
            _cartRepositoryMock.Verify(r => r.UpdateCartItemAsync(existingCartItem), Times.Once);
        }

        [Fact]
        public async Task RemoveDishFromCart_ShouldDecrementQuantity_WhenQuantityIsGreaterThanOne()
        {
            var userId = Guid.NewGuid();
            var dishId = Guid.NewGuid();
            var dish = _fixture.Build<Dish>().With(d => d.Id, dishId).Create();
            var existingCartItem = _fixture.Build<DishCart>()
                                           .With(c => c.DishId, dishId)
                                           .With(c => c.UserId, userId)
                                           .With(c => c.Quantity, 2)
                                           .Create();

            _dishRepositoryMock.Setup(r => r.GetDishInfoAsync(dishId))
                .ReturnsAsync(dish);

            _cartRepositoryMock.Setup(r => r.GetUserCartItemsAsync(userId))
                .ReturnsAsync(new List<DishCart> { existingCartItem });

            _cartRepositoryMock.Setup(r => r.UpdateCartItemAsync(existingCartItem))
                .Returns(Task.CompletedTask);

            await _cartService.RemoveDishFromCart(dishId, userId);

            existingCartItem.Quantity.Should().Be(1);
            _cartRepositoryMock.Verify(r => r.UpdateCartItemAsync(existingCartItem), Times.Once);
        }

        [Fact]
        public async Task RemoveDishFromCart_ShouldRemoveItem_WhenQuantityIsOne()
        {
            var userId = Guid.NewGuid();
            var dishId = Guid.NewGuid();
            var dish = _fixture.Build<Dish>().With(d => d.Id, dishId).Create();
            var existingCartItem = _fixture.Build<DishCart>()
                                           .With(c => c.DishId, dishId)
                                           .With(c => c.UserId, userId)
                                           .With(c => c.Quantity, 1)
                                           .Create();

            _dishRepositoryMock.Setup(r => r.GetDishInfoAsync(dishId))
                .ReturnsAsync(dish);

            _cartRepositoryMock.Setup(r => r.GetUserCartItemsAsync(userId))
                .ReturnsAsync(new List<DishCart> { existingCartItem });

            _cartRepositoryMock.Setup(r => r.UpdateCartItemAsync(existingCartItem))
                .Returns(Task.CompletedTask);

            await _cartService.RemoveDishFromCart(dishId, userId);

            _cartRepositoryMock.Verify(r => r.DeleteCartItemAsync(existingCartItem), Times.Once);
        }
    }
}
