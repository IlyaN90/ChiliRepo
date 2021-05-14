using Chilli.Core.Infrastructure.Entities.Product;
using Chilli.Core.Infrastructure.Entities.Repositories;
using Chilli.Core.Product.Domain;
using Chilli.Core.Product.Models;
using Chilli.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chilli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IAddProduct _addProduct;
        private readonly IDeleteProduct _deleteProduct;
        private readonly IPutProduct _putProduct;
        private readonly IGetProduct _getProduct;

        public ProductsController(IAddProduct addProduct, IGetProduct getProduct, IPutProduct putProduct, IDeleteProduct deleteProduct)
        {
            _addProduct = addProduct;
            _getProduct = getProduct;
            _deleteProduct = deleteProduct;
            _putProduct = putProduct;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _getProduct.GetProductsDb();
            if (!response.Success)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _getProduct.GetProductDb(new GetProductRequest(id));
            if (!response.Success)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddProductRequest request)
        {
            var response = await _addProduct.AddProductDb(request);
            if (!response.Success)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PutProductRequest product)
        {
            var response = await _putProduct.PutProductDb(product);
            if (!response.Success)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _deleteProduct.DeleteProductDb(new DeleteProductRequest(id));
            if (!response.Success)
            {
                return BadRequest();
            }
            return Ok(response);
        }
    }
}
