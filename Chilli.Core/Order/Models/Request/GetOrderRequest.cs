using Chilli.Core.Order.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Order.Models.Request
{
    public class GetOrderRequest : IRequest<GetOrderResponse>
    {
        public GetOrderRequest()
        {

        }
        public GetOrderRequest(int id)
        {
            OrderId = id;
        }
        public int OrderId { get; set; }
    }
}
