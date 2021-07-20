using AutoMapper;
using Chilli.Core.Infrastructure.Entities.Order;
using Chilli.Core.Infrastructure.Repositories;
using Chilli.Core.Order.Models.Request;
using Chilli.Core.Order.Models.Response;
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
        private readonly IMapper _mapper;

        public OrderRepository(PostgreSQL_context db, IMapper mapper)
        {
            _db = db;
            _mapper=mapper;
        }

        public async Task<int> AddOrderAsync(AddOrderRequest newOrder)
        {
            OrderEntity order = new OrderEntity()
            {
                Customer = newOrder.Customer,
                Products = newOrder.Products,
                OrderDate = newOrder.OrderDate,
                Deadline = newOrder.Deadline,
                TotalPrice = newOrder.TotalPrice,
                Success = true
            };
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
            return order.Id;
        }

        public async Task<int> DeleteOrderAsync(int productId)
        {
            var toDelete = await _db.Orders.Where(p => p.Id == productId).FirstOrDefaultAsync();
            if (toDelete != null)
            {
                _db.Orders.Remove(toDelete);
                await _db.SaveChangesAsync();
                return toDelete.Id;
            }
            return 0;
        }

        public async Task<OrderEntity> PutOrderAsync(PutOrderRequest updatedOrder)
        {
            var order = await _db.Orders.Where(p => p.Id == updatedOrder.Id).FirstOrDefaultAsync();
            order = _mapper.Map<OrderEntity>(updatedOrder);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task<List<OrderEntity>> GetOrderAsync(GetOrderRequest request)
        {
            var order = await _db.Orders.Where(p => p.Id == request.OrderId).FirstOrDefaultAsync();
            List<OrderEntity> orderList = new List<OrderEntity>
            {
                order
            };
            return orderList;
        }

        public async Task<List<OrderEntity>> GetOrderAsync()
        {
            var orders = await _db.Orders.ToListAsync();
            return orders;
        }
    }
}
