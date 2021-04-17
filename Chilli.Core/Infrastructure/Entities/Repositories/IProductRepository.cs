using Chilli.Core.Infrastructure.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Core.Infrastructure.Entities.Repositories
{
    public interface IProductRepository
    {
        public ProductEntity AddProduct(ProductEntity newProduct);
        public ProductEntity EditProduct(ProductEntity oldProduct);
        public ProductEntity GetProduct(int productId);
        public List<ProductEntity> GetProduct();
        public ProductEntity DeleteProduct(int productId);
    }
}
