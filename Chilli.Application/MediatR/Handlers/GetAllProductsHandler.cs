using AutoMapper;
using Chilli.API.Queries;
using Chilli.Core.Product.Domain;
using Chilli.Core.Product.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Chilli.Application.MediatR.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, GetProductResponse>
    {
        private readonly IGetProduct _getProduct;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IGetProduct getProduct, IMapper mapper)
        {
            _getProduct = getProduct;
            _mapper = mapper;
        }
        public async Task<GetProductResponse> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _getProduct.GetProductsDb();
            //map here
            return products;
        }
    }
}
