using Chilli.Core.Infrastructure.Entities.Product;
using Chilli.Core.Infrastructure.Entities.Repositories;
using Chilli.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chilli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<ProductEntity> Get()
        {
            return _repo.GetProduct();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ProductEntity Get(int id)
        {
            return _repo.GetProduct(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public ProductEntity Post([FromBody] ProductEntity newProduct)
        {
            return _repo.AddProduct(newProduct);
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public ProductEntity Put([FromBody] ProductEntity product)
        {
            return _repo.EditProduct(product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ProductEntity Delete(int id)
        {
            return _repo.DeleteProduct(id);
        }
    }
}
