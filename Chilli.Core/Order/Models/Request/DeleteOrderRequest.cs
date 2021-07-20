using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Order.Models.Request
{
    public class DeleteOrderRequest
    {
        public DeleteOrderRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
