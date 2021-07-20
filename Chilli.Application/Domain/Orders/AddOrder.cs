using Chilli.Core.Infrastructure.Repositories;
using Chilli.Core.Order.Domain;
using Chilli.Core.Order.Models.Request;
using Chilli.Core.Order.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Application.Domain.Orders
{
    public class AddOrder : IAddOrder
    {
        private readonly IOrderRepository _repository;
        public AddOrder(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<AddOrderResponse> AddOrderDb(AddOrderRequest request)
        {
            var orderId = await _repository.AddOrderAsync(request);
            if (orderId > 0)
            {
                return new AddOrderResponse(true, orderId);
            }
            return new AddOrderResponse(false, 0);
        }
    }
}
