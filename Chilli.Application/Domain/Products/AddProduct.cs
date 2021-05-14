using Chilli.Core.Infrastructure.Entities.Repositories;
using Chilli.Core.Product.Domain;
using Chilli.Core.Product.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Application.Domain.Products
{
    public class AddProduct: IAddProduct
    {
        private readonly IProductRepository _repository;
        public AddProduct(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<AddProductResponse> AddProductDb(AddProductRequest request)
        {
            var productId = await _repository.AddProductAsync(request);
            if (productId > 0)
            {
                return new AddProductResponse(true, productId);
            }
            return new AddProductResponse(false, 0);
        }
    }
}
