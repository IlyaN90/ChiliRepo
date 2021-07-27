using AutoMapper;
using Chilli.Application.MediatR.Queries;
using Chilli.Core.Order.Domain;
using Chilli.Core.Order.Models.Request;
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
    class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, GetOrderResponse>
    {
        private readonly IGetOrder _getOrder;
        private readonly IMapper _mapper;

        public GetOrderByIdHandler(IGetOrder getOrder, IMapper mapper)
        {
            _getOrder = getOrder;
            _mapper = mapper;
        }
        public async Task<GetOrderResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _getOrder.GetOrderDb(new GetOrderRequest(request.Id));
            return response;
        }
    }
}
