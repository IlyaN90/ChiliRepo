using Chilli.Core.Order.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Application.MediatR.Queries
{
    public class GetOrderByIdQuery : IRequest<GetOrderResponse>
    {
        public int Id { get; set; }
        public GetOrderByIdQuery(int id)
        {
            Id = id;
        }
    }
}
