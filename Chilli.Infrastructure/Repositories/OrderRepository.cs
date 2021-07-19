using Chilli.Core.Infrastructure.Entities.Order;
using Chilli.Core.Infrastructure.Repositories;
using Chilli.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PostgreSQL_context _db;
        public OrderRepository(PostgreSQL_context db)
        {
            _db = db;
        }

        public async Task<OrderEntity> AddOrder(OrderEntity newOrder)
        {
            _db.Orders.Add(newOrder);
            return newOrder;
        }

        public async Task<OrderEntity> DeleteOrder(int productId)
        {
            var toDelete = _db.Orders.Where(p => p.Id == productId).FirstOrDefault();
            _db.Orders.Remove(toDelete);
            return toDelete;
        }

        public async Task<OrderEntity> EditOrder(OrderEntity updatedOrder)
        {
            var oldOrder = _db.Orders.Where(p => p.Id == updatedOrder.Id).FirstOrDefault();
            oldOrder = updatedOrder;
            return _db.Orders.Where(p => p.Id == updatedOrder.Id).FirstOrDefault();
        }

        public async Task<OrderEntity> GetOrder(int productId)
        {
            return _db.Orders.Where(p => p.Id == productId).FirstOrDefault();
        }

        public async Task<List<OrderEntity>> GetOrder()
        {
            return await _db.Orders.ToListAsync();
        }
    }
}
