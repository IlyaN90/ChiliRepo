using Chilli.Application.MediatR.Queries;
using Chilli.Core.Infrastructure.Entities.Order;
using Chilli.Core.Infrastructure.Repositories;
using Chilli.Core.Order.Domain;
using Chilli.Core.Order.Models.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Chilli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IAddOrder _addOrder;
        private readonly IDeleteOrder _deleteOrder;
        private readonly IPutOrder _putOrder;
        
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator, IAddOrder addOrder, IDeleteOrder deleteOrder, IPutOrder putOrder)
        {
            _addOrder = addOrder;
            _deleteOrder = deleteOrder;
            _putOrder = putOrder;

            _mediator = mediator;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllOrdersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetOrderByIdQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddOrderRequest request)
        {
            var response = await _addOrder.AddOrderDb(request);
            if (!response.Success)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        // PUT api/<OrdersController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PutOrderRequest request)
        {
            var response = await _putOrder.PutOrderDb(request);
            if (!response.Success)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _deleteOrder.DeleteOrderDb(new DeleteOrderRequest(id));
            if (!response.Success)
            {
                return BadRequest();
            }
            return Ok(response);
        }
    }
}
