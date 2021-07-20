using Chilli.Core.Order.Models.Request;
using Chilli.Core.Order.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Order.Domain
{
    public interface IGetOrder
    {
        public Task<GetOrderResponse> GetOrderDb(GetOrderRequest request);
        public Task<GetOrderResponse> GetOrdersDb();
    }
}
