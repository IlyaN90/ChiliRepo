using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Product.Models
{
    public class DeleteProductRequest
    {
        public DeleteProductRequest(int id)
        {
            ProductId = id;
        }
        public int ProductId { get; set; }
    }
}
