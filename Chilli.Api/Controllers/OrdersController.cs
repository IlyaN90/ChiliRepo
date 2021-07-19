using Chilli.Core.Infrastructure.Entities.Order;
using Chilli.Core.Infrastructure.Repositories;
using Chilli.Infrastructure.Repositories;
using MediatR;
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
        private readonly IOrderRepository _repo;
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator, IOrderRepository repo)
        {
            _mediator = mediator;
            _repo = repo;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderEntity newOrder)
        {
            throw new NotImplementedException();
        }

        // PUT api/<OrdersController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] OrderEntity product)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
