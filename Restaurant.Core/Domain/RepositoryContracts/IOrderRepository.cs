using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Domain.RepositoryContracts
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Retrives information about concrete order
        /// </summary>
        /// <param name="Id">The unique identifier of the dish.</param>
        /// <returns>The matching dish object; otherwise, null.</returns>
        Task<Order> GetOrderById(Guid Id);
        /// <summary>
        /// Retrieves all orders the user made.
        /// </summary>
        /// <param name="UserId">The unique identifier of the user.</param>
        /// <returns>An IEnumerable collection of Order object.</returns>
        Task<IEnumerable<Order>> GetAllOrders(Guid UserId);
        /// <summary>
        /// Creates an order from dishes in basket
        /// </summary>
        /// <param name="DeliveryDate"></param>
        /// <param name="Address"></param>
        /// <returns></returns>
        Task CreateOrderFrombasket(DateTime DeliveryDate , string Address);
        /// <summary>
        /// Changes the Order status to delivered. 
        /// </summary>
        /// <param name="OrderId">The unique identifier of the order</param>
        /// <returns></returns>
        Task ConfirmDelivery(Guid OrderId);
    }
}
