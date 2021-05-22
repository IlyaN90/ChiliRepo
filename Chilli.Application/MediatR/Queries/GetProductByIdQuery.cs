using Chilli.Core.Product.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Application.MediatR.Queries
{
    public class GetProductByIdQuery : IRequest<GetProductResponse>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
