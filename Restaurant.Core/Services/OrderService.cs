using AutoMapper;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.RepositoryContracts;
using Restaurant.Core.DTO;
using Restaurant.Core.Errors;
using Restaurant.Core.ServicesContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _db;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository db , IMapper mapper, ICartRepository cartRepository)
        {
            _db = db;
            _mapper = mapper;
            _cartRepository = cartRepository;
        }

        public async Task ConfirmOrderDelivery(Guid? orderId)
        {
            if (!orderId.HasValue)
                throw new ArgumentNullException(nameof(orderId), "Order ID is required.");

            Order? order = await _db.GetOrderInformationAsync(orderId.Value);
            if (order == null)
                throw new NotFoundException($"The order with {orderId} not found");

            order.status = 2;
            await _db.ConfirmOrderDeliveryAsync(order);
        }

        public async Task CreateOrder(Guid? userId)
        {
            if(!userId.HasValue)
                throw new ArgumentNullException(nameof(userId), "User ID is required.");

            var cart = await _cartRepository.GetUserCartAsync(userId.Value);
            if (cart == null)
                throw new NotFoundException($"No cart for the user {userId}");

            Order order = new Order() { }; // to be continud later. Add and Time handleing
        }

        public async Task<List<OrderDto?>> GetAllOrders(Guid? userId)
        {
            if(!userId.HasValue)
                throw new ArgumentNullException(nameof(userId), "User ID is required.");

            var orders = await _db.GetOrderListAsync(userId.Value);

            return _mapper.Map<List<OrderDto?>>(orders);
        }

        public async Task<OrderDto?> GetOrderInfo(Guid? orderId)
        {
            if (!orderId.HasValue)
                throw new ArgumentNullException(nameof(orderId), "Order ID is required.");

            var order = await _db.GetOrderInformationAsync(orderId.Value);
            if (order == null)
                throw new NotFoundException($"The order with order id {orderId} not found");

            return _mapper.Map<OrderDto>(order);
        }
    }
}
