using Chilli.Core.Infrastructure.Entities.Order;
using Chilli.Core.Order.Models.Request;
using Chilli.Core.Order.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Infrastructure.Repositories
{
    public interface IOrderRepository
    {
        public Task<int> AddOrderAsync(AddOrderRequest newOrder);
        public Task<int> DeleteOrderAsync(int productId);
        public Task<OrderEntity> PutOrderAsync(PutOrderRequest updatedOrder);
        public Task<List<OrderEntity>> GetOrderAsync(GetOrderRequest request);
        public Task<List<OrderEntity>> GetOrderAsync();
    }
}
