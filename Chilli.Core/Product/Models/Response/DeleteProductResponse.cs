using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Product.Models
{
    public class DeleteProductResponse
    {
        public DeleteProductResponse(bool success, int id)
        {
            Success = success;
            ProductId = id;
        }
        public bool Success { get; set; }
        public int ProductId { get; set; }
    }
}
