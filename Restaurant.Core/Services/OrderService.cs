using AutoMapper;
using Restaurant.Core.DishCartExtentions;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.RepositoryContracts;
using Restaurant.Core.DTO;
using Restaurant.Core.Enums;
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

            if (order.Status == OrderStatus.Delivered)
                throw new ArgumentException($"the order with the id {orderId} is already delivered");

            order.Status = OrderStatus.Delivered;
            await _db.ConfirmOrderDeliveryAsync(order);
        }

        public async Task CreateOrder(Guid? userId , CreateOrderDto createOrder)
        {
            if(!userId.HasValue)
                throw new ArgumentNullException(nameof(userId), "User ID is required.");

            if (createOrder.DeliveryTime < DateTime.UtcNow)
                throw new ArgumentException("delivery time can't be in past");

            if(createOrder.DeliveryTime < DateTime.UtcNow.AddMinutes(60))
                throw new ArgumentException("Delivery time must be at least 60 minutes from now.");

            var cart = await _cartRepository.GetUserCartItemsAsync(userId.Value);
            if (cart == null)
                throw new NotFoundException($"No cart for the user {userId}");

            double totalPrice = cart.GetTotalPrice();

            var orderId = Guid.NewGuid();
            foreach(var item in cart)
            {
                item.OrderId = orderId;
            }

            var status = Enums.OrderStatus.InProcess;

            Order order = new Order()
            {
                Id = orderId,
                DeliveryTime = createOrder.DeliveryTime,
                CreateDateTime = DateTime.UtcNow,
                Address = createOrder.Address,
                Price = totalPrice,
                Status = status,
                UserId = userId.Value,
                DishCarts = cart,
            }; 

            await _db.CreateOrderAsync(order);
        }

        public async Task<List<OrderInfoDto?>> GetAllOrders(Guid? userId)
        {
            if(!userId.HasValue)
                throw new ArgumentNullException(nameof(userId), "User ID is required.");

            var orders = await _db.GetOrderListAsync(userId.Value);

            return _mapper.Map<List<OrderInfoDto?>>(orders);
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
