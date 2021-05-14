using Chilli.Core.Infrastructure.Entities.Order;
using Chilli.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chilli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderRepository _repo;

        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<OrderEntity> Get()
        {
            return _repo.GetOrder();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public OrderEntity Get(int id)
        {
            return _repo.GetOrder(id);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public IActionResult Post([FromBody] OrderEntity newOrder)
        {
            OrderEntity response =  _repo.AddOrder(newOrder);
            if (!response.Success)
            {
                return BadRequest();
            }
            return Created("", response);
        }

        // PUT api/<OrdersController>/5
        [HttpPut]
        public OrderEntity Put([FromBody] OrderEntity product)
        {
            return _repo.EditOrder(product);
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public OrderEntity Delete(int id)
        {
            return _repo.DeleteOrder(id);
        }
    }
}
