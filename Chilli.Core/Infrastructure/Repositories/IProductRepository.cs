using Chilli.Core.Infrastructure.Entities.Product;
using Chilli.Core.Product.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Infrastructure.Entities.Repositories
{
    public interface IProductRepository
    {
        public Task<int> AddProductAsync(AddProductRequest request);
        public Task<ProductEntity> PutProductAsync(PutProductRequest request);
        public Task<List<ProductEntity>> GetProductsAsync();
        public Task<List<ProductEntity>> GetProductAsync(GetProductRequest request);
        public Task<int> DeleteProductAsync(DeleteProductRequest request);
        public Task<UploadProductImageResponse> UploadProductImageAsync(UploadProductImageRequest request, string path);
    }
}
