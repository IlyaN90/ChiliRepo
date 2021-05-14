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
    public class PutProduct: IPutProduct
    {
        private readonly IProductRepository _repository;
        public PutProduct(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<PutProductResponse> PutProductDb(PutProductRequest request)
        {
            var product = await _repository.PutProductAsync(request);
            if (product != null)
            {
                return new PutProductResponse(true, product.Id);
            }
            return new PutProductResponse(false, 0);
        }
    }
}
