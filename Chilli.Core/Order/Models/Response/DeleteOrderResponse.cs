using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Order.Models.Response
{
    public class DeleteOrderResponse
    {
        public DeleteOrderResponse(bool success, int id)
        {
            Success = success;
            Id = id;
        }
        public bool Success { get; set; }
        public int Id { get; set; }
    }
}