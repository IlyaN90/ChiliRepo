using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Order.Models.Request
{
    public class DeleteOrederRequest
    {
        public DeleteOrederRequest(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
