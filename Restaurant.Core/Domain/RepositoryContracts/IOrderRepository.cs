using Restaurant.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.RepositoryContracts
{
    public interface IOrderRepository
    {
        public Task<Order?> GetOrderInformationAsync(Guid id);
        public Task<List<Order>> GetListOfOrdersAsync(Guid userId);
        public Task CreateOrderAsync(Order order);
        public Task ConfirmOrderDeliveryAsync(Order order);
    }
}
