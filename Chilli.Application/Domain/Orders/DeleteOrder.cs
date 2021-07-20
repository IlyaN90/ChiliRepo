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
    public class DeleteOrder : IDeleteOrder
    {
        private readonly IOrderRepository _repository;
        public DeleteOrder(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<DeleteOrderResponse> DeleteOrderDb(DeleteOrderRequest request)
        {
            var productId = await _repository.DeleteOrderAsync(request.Id);
            if (productId > 0)
            {
                return new DeleteOrderResponse(true, productId);
            }
            return new DeleteOrderResponse(false, 0);
        }
    }
}
