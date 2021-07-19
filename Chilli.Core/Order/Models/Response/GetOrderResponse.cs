using Chilli.Core.Order.Models.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Order.Models.Response
{
    public class GetOrderResponse
    {
        public GetOrderResponse()
        {

        }
        public GetOrderResponse(bool success, List<OrderModel> orders)
        {
            Success = success;
            Orders = orders;
        }
        public bool Success { get; set; }
        public List<OrderModel> Orders { get; set; }

    }
}
