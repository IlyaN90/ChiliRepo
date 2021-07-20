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
    public class PutOrder : IPutOrder
    {
        private readonly IOrderRepository _repository;
        public PutOrder(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<PutOrderResponse> PutOrderDb(PutOrderRequest request)
        {
            var product = await _repository.PutOrderAsync(request);
            if (product != null)
            {
                return new PutOrderResponse(true, product.Id);
            }
            return new PutOrderResponse(false, 0);
        }
    }
}
