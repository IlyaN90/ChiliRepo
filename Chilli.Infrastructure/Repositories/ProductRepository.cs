using Chilli.Core.Infrastructure.Entities.Product;
using Chilli.Core.Infrastructure.Entities.Repositories;
using Chilli.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
       private PostgreSQL_context _db;
       public ProductRepository(PostgreSQL_context db)
        {
            _db = db;
        }

        public async Task<ProductEntity> AddProduct(ProductEntity newProduct)
        {
            await _db.Products.AddAsync(newProduct);
            await _db.SaveChangesAsync();
            return newProduct;
        }

        public async Task<ProductEntity> DeleteProduct(int productId)
        {
            var toDelete = _db.Products.Where(p=>p.Id == productId).FirstOrDefault();
            _db.Products.Remove(toDelete);
            return toDelete;
        }

        public ProductEntity EditProduct(ProductEntity updatedProduct)
        {
            var oldProduct = _db.Products.Where(p => p.Id == updatedProduct.Id).FirstOrDefault();
            oldProduct = updatedProduct;
            return _db.Products.Where(p => p.Id == updatedProduct.Id).FirstOrDefault();
        }

        public async Task<ProductEntity> GetProduct(int productId)
        {
            return _db.Products.Where(p => p.Id == productId).FirstOrDefault();
        }

        public List<ProductEntity> GetProduct()
        {
            return _db.Products;
        }
    }
}
