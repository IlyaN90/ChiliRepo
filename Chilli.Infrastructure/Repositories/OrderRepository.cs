using Chilli.Core.Infrastructure.Entities.Order;
using Chilli.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Infrastructure.Repositories
{
    public class OrderRepository
    {
        private readonly Fake _db;

        public OrderRepository()
        {
            _db = new Fake();
        }

        public OrderEntity AddOrder(OrderEntity newOrder)
        {
            _db.Orders.Add(newOrder);
            return newOrder;
        }

        public OrderEntity DeleteOrder(int productId)
        {
            var toDelete = _db.Orders.Where(p => p.Id == productId).FirstOrDefault();
            _db.Orders.Remove(toDelete);
            return toDelete;
        }

        public OrderEntity EditOrder(OrderEntity updatedOrder)
        {
            var oldOrder = _db.Orders.Where(p => p.Id == updatedOrder.Id).FirstOrDefault();
            oldOrder = updatedOrder;
            return _db.Orders.Where(p => p.Id == updatedOrder.Id).FirstOrDefault();
        }

        public OrderEntity GetOrder(int productId)
        {
            return _db.Orders.Where(p => p.Id == productId).FirstOrDefault();
        }

        public List<OrderEntity> GetOrder()
        {
            return _db.Orders;
        }
    }
}
