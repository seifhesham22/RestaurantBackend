﻿using Restaurant.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.ServicesContracts
{
    public interface IOrderService
    {
        public Task<OrderDto?> GetOrderInfo(Guid? orderId);
        public Task<List<OrderInfoDto?>> GetAllOrders(Guid? userId);
        public Task CreateOrder(Guid? userId , CreateOrderDto createOrder);
        public Task ConfirmOrderDelivery(Guid? OrderId);
    }
}
