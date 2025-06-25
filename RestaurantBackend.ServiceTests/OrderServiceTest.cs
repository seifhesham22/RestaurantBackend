using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Moq;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.RepositoryContracts;
using Restaurant.Core.DTO;
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

    public class OrderServiceTest
    {
        private readonly IOrderService _orderService;

        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly Mock<ICartRepository> _cartRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;

        private readonly IFixture _fixture;

        public OrderServiceTest()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _cartRepositoryMock = new Mock<ICartRepository>();
            _mapperMock = new Mock<IMapper>();

            _fixture = FixtureFactory.Create();

            _orderService = new OrderService(
                _orderRepositoryMock.Object,
                _mapperMock.Object,
                _cartRepositoryMock.Object
            );
        }

        [Fact]
        public async Task ConfirmOrderDelivery_ShouldSetStatusToDelivered_WhenOrderIsNotDelivered()
        {
            var orderId = Guid.NewGuid();
            var inProcess = Restaurant.Core.Enums.OrderStatus.InProcess;
            var delivered = Restaurant.Core.Enums.OrderStatus.Delivered;
            var order = _fixture.Build<Order>()
                                .With(x => x.Id, orderId)
                                .With(x => x.Status, inProcess)
                                .Create();

            _orderRepositoryMock.Setup(x => x.GetOrderInformationAsync(orderId))
                .ReturnsAsync(order);

            _orderRepositoryMock.Setup(x => x.ConfirmOrderDeliveryAsync(order))
                .Returns(Task.CompletedTask);

            //Act
            await _orderService.ConfirmOrderDelivery(orderId);

            //Assert
            order.Status.Should().Be(delivered);
            _orderRepositoryMock.Verify(x => x.ConfirmOrderDeliveryAsync(order), Times.Once);
        }

        [Fact]
        public async Task ConfirmOrderDelivery_ShouldThrowArgumentException_WhenOrderAlreadyDelivered()
        {
            var orderId = Guid.NewGuid();
            var delivered = Restaurant.Core.Enums.OrderStatus.Delivered;
            var order = _fixture.Build<Order>()
                                .With(x => x.Id, orderId)
                                .With(x => x.Status , delivered)
                                .Create();
            _orderRepositoryMock.Setup(x => x.GetOrderInformationAsync(orderId))
                .ReturnsAsync(order);

            //Act
            Func<Task> act = async () => await _orderService.ConfirmOrderDelivery(orderId);

            //Assert
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage($"the order with the id {orderId} is already delivered");
        }

        [Fact]
        public async Task CreateOrder_ShouldThrowArgumentException_WhenDeliveryTimeIsLessThan60MinutesFromNow()
        {
            var userId = Guid.NewGuid();
            var deliveryTime = DateTime.UtcNow.AddMinutes(10);
            var address = "kosom elsisi 3a , cairo";
            var createOrder = _fixture.Build<CreateOrderDto>()
                                      .With(x => x.DeliveryTime, deliveryTime)
                                      .With(x => x.Address, address)
                                      .Create();

            Func<Task> act = async () => await _orderService.CreateOrder(userId,createOrder); 
            
            await act.Should().ThrowAsync<ArgumentException>()
                .WithMessage("Delivery time must be at least 60 minutes from now.");
        }

        [Fact]
        public async Task GetOrderInfo_ShouldReturnOrderDto_WhenOrderExists()
        {
            var orderId = Guid.NewGuid();
            var order = _fixture.Build<Order>()
                                .With(o => o.Id, orderId)
                                .Create();

            var orderDto = _fixture.Create<OrderDto>();

            _orderRepositoryMock.Setup(r => r.GetOrderInformationAsync(orderId))
                                .ReturnsAsync(order);

            _mapperMock.Setup(m => m.Map<OrderDto>(order))
                       .Returns(orderDto);

            var result = await _orderService.GetOrderInfo(orderId);

            result.Should().Be(orderDto);
        }
    }
}
