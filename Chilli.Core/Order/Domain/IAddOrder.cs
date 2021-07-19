using Chilli.Core.Order.Models.Request;
using Chilli.Core.Order.Models.Response;
using System.Threading.Tasks;

namespace Chilli.Core.Order.Domain
{
    public interface IAddOrder
    {
        public Task<AddOrderResponse> AddOrderDb(AddOrderRequest request);
    }
}
