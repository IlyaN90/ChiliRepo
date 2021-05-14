using AutoMapper;
using Chilli.Core.Infrastructure.Entities.Product;
using Chilli.Core.Infrastructure.Entities.Repositories;
using Chilli.Core.Product.Domain;
using Chilli.Core.Product.Models;
using Chilli.Core.Product.Models.DBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Application.Domain.Products
{
    public class GetProduct : IGetProduct
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public GetProduct(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetProductResponse> GetProductDb(GetProductRequest request)
        {
            var product = await _repository.GetProductAsync(request);
            if (product!=null)
            {
                return new GetProductResponse(true, new ProductModel(product.Id, product.Name, product.Description, product.Cost, product.Size));
            }
            return new GetProductResponse(true, new ProductModel());
        }
        public async Task<GetProductResponse> GetProductsDb()
        {
            var products = await _repository.GetProductsAsync();
            List<ProductModel> productModels = new List<ProductModel>();
            foreach(ProductEntity p in products)
            {
                productModels.Add(new ProductModel(p.Id, p.Name, p.Description, p.Cost, p.Size));
            }
            return new GetProductResponse(true, productModels);
        }
    }
}
