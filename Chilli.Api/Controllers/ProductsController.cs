using Chilli.API.Queries;
using Chilli.Application.MediatR.Handlers;
using Chilli.Application.MediatR.Queries;
using Chilli.Core.Infrastructure.Entities.Product;
using Chilli.Core.Infrastructure.Entities.Repositories;
using Chilli.Core.Product.Domain;
using Chilli.Core.Product.Models;
using Chilli.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chilli.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IAddProduct _addProduct;
        private readonly IDeleteProduct _deleteProduct;
        private readonly IPutProduct _putProduct;
        private readonly IUploadImage _uploadImage;

        private readonly IMediator _mediator;


        public ProductsController(IMediator mediator, IUploadImage uploadImage, IAddProduct addProduct, IPutProduct putProduct, IDeleteProduct deleteProduct)
        {
            _addProduct = addProduct;
            _deleteProduct = deleteProduct;
            _putProduct = putProduct;
            _uploadImage = uploadImage;
            _mediator = mediator;
        }

        [HttpPost("ProductImage")]
        public async Task<IActionResult> ProductImage([FromBody] UploadProductImageRequest request)
        {
            var result = await _uploadImage.UploadImageDb(request);
            if (!result.Success)
            {
                return BadRequest();
            }
            return Created("", result);
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllProductsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query);
            if (!result.Success)
            {
                return BadRequest();
            }
            return Ok(result);
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
