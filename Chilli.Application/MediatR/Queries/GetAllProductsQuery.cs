using Chilli.Core.Infrastructure.Entities.Product;
using Chilli.Core.Product.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chilli.API.Queries
{
    public class GetAllProductsQuery:IRequest<GetProductResponse>
    {

    }
}
