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
       private Fake _db;
       public ProductRepository()
        {
            _db = new Fake();
        }

        public ProductEntity AddProduct(ProductEntity newProduct)
        {
            _db.Products.Add(newProduct);
            return newProduct;
        }

        public ProductEntity DeleteProduct(int productId)
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

        public ProductEntity GetProduct(int productId)
        {
            return _db.Products.Where(p => p.Id == productId).FirstOrDefault();
        }

        public List<ProductEntity> GetProduct()
        {
            return _db.Products;
        }
    }
}
