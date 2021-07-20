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
        public GetProduct(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetProductResponse> GetProductDb(GetProductRequest request)
        {
            var product = await _repository.GetProductAsync(request);
            if (product.Any()) 
            { 
                List<ProductModel> productModels = new List<ProductModel>();
                foreach (ProductEntity p in product)
                {
                    if (p.Media != null)
                    {
                        productModels.Add(new ProductModel(p.Id, p.Name, p.Description, p.Cost, p.Size, p.Media.Title, p.Media.Path));
                    }
                    else productModels.Add(new ProductModel(p.Id, p.Name, p.Description, p.Cost, p.Size, "", null));
                }
                return new GetProductResponse(true, productModels);
            }
            return new GetProductResponse(false, null);
        }
        public async Task<GetProductResponse> GetProductsDb()
        {
            var products = await _repository.GetProductsAsync();
            List<ProductModel> productModels = new List<ProductModel>();
            foreach(ProductEntity p in products)
            {
                if (p.Media != null)
                {
                    productModels.Add(new ProductModel(p.Id, p.Name, p.Description, p.Cost, p.Size, p.Media.Title, p.Media.Path));
                }else productModels.Add(new ProductModel(p.Id, p.Name, p.Description, p.Cost, p.Size, "", ""));
            }
            return new GetProductResponse(true, productModels);
        }
    }
}
