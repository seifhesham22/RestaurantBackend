using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Domain.Entities;
using Restaurant.Core.Domain.RepositoryContracts;
using Restaurant.Infrastructure.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantDbContext _db;
        public OrderRepository(RestaurantDbContext db)
        {
            _db = db;
        }
        public async Task ConfirmOrderDeliveryAsync(Order order)
        {
            _db.Orders.Update(order);
            await _db.SaveChangesAsync();
        }

        public async Task CreateOrderAsync(Order order)
        {
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Order>> GetOrderListAsync(Guid userId)
        {
            return await _db.Orders.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<Order?> GetOrderInformationAsync(Guid orderId)
        {
            return await _db.Orders.FirstOrDefaultAsync(x => x.Id == orderId);
        }
    }
}
