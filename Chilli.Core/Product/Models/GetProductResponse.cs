using Chilli.Core.Product.Models.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Product.Models
{
    public class GetProductResponse
    {
        public GetProductResponse(bool success)
        {
            Success = success;
        }
        public GetProductResponse(bool success, ProductModel product)
        {
            Success = success;
            Product = product;
        }

        public GetProductResponse(bool success, List<ProductModel> products)
        {
            Success = success;
            Products = products;
        }

        public bool Success { get; set; }
        public ProductModel Product { get; set; }
        public List<ProductModel> Products { get; set; }
    }
}
