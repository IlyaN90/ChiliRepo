using Chilli.Core.Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Product.Domain
{
    public interface IAddProduct
    {
        public Task<AddProductResponse> AddProductDb(AddProductRequest request);
    }
}
