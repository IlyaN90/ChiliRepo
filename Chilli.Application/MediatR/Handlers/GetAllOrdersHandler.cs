using AutoMapper;
using Chilli.Application.MediatR.Queries;
using Chilli.Core.Order.Domain;
using Chilli.Core.Order.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chilli.Application.MediatR.Handlers
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, GetOrderResponse>
    {
        private readonly IGetOrder _getOrder;
        private readonly IMapper _mapper;

        public GetAllOrdersHandler(IGetOrder getOrder, IMapper mapper)
        {
            _getOrder = getOrder;
            _mapper = mapper;
        }
        public async Task<GetOrderResponse> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var products = await _getOrder.GetOrdersDb();
            //map here
            return products;
        }
    }
}
