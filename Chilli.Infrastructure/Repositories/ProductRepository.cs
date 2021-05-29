using AutoMapper;
using Chilli.Core.Infrastructure.Entities.Media;
using Chilli.Core.Infrastructure.Entities.Product;
using Chilli.Core.Infrastructure.Entities.Repositories;
using Chilli.Core.Product.Models;
using Chilli.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
       private readonly PostgreSQL_context _db;
       private readonly IMapper _mapper;
       public ProductRepository(PostgreSQL_context db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> AddProductAsync(AddProductRequest request)
        {
            ProductEntity product = new ProductEntity()
                {
                    Name = request.Name,
                    Description = request.Description,
                    Cost = request.Cost,
                    Size=request.Size
                };
                await _db.Products.AddAsync(product);
                await _db.SaveChangesAsync();
                return product.Id;
        }

        public async Task<int> DeleteProductAsync(DeleteProductRequest request)
        {
            var toDelete = _db.Products.Where(p=>p.Id == request.ProductId).FirstOrDefault();
            if (toDelete != null)
            {
                _db.Products.Remove(toDelete);
                await _db.SaveChangesAsync();
                return toDelete.Id;
            }
            return 0;
        }

        public async Task<ProductEntity> PutProductAsync(PutProductRequest request)
        {
            var product = await _db.Products.Where(p => p.Id == request.Id).FirstOrDefaultAsync();
            product = _mapper.Map<ProductEntity>(request);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task<List<ProductEntity>> GetProductAsync(GetProductRequest request)
        {
            var product = await _db.Products.Include(p=>p.Media).Where(p=>p.Id==request.ProductId).FirstOrDefaultAsync();
            List<ProductEntity> productList = new List<ProductEntity>
            {
                product
            };
            return productList;
        }

        public async Task<List<ProductEntity>> GetProductsAsync()
        {
            var products = await _db.Products.Include(p=>p.Media).ToListAsync();
            return products;
        }

        public async Task<UploadProductImageResponse> UploadProductImageAsync(UploadProductImageRequest request, string path)
        {
            var product = await _db.Products.FindAsync(request.ProductId);
            if (product != null)
            {
                MediaEntity media = new MediaEntity() 
                {
                    Path = path
                };
                product.Media = media;
                await _db.SaveChangesAsync();
                return new UploadProductImageResponse(true, path);
            }
            return new UploadProductImageResponse(false, path);
        }
    }
}
