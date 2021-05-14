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
    public class DeleteProduct : IDeleteProduct
    {
        private readonly IProductRepository _repository;
        public DeleteProduct(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<DeleteProductResponse> DeleteProductDb(DeleteProductRequest request)
        {
            var productId = await _repository.DeleteProductAsync(request);
            if (productId > 0)
            {
                return new DeleteProductResponse(true, productId);
            }
            return new DeleteProductResponse(false, 0);
        }
    }
}
