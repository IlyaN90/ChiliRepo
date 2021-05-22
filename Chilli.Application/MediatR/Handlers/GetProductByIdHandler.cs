using AutoMapper;
using Chilli.Application.MediatR.Queries;
using Chilli.Core.Product.Domain;
using Chilli.Core.Product.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Chilli.Application.MediatR.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, GetProductResponse>
    {
        private readonly IGetProduct _getProduct;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IGetProduct getProduct, IMapper mapper)
        {
            _getProduct = getProduct;
            _mapper = mapper;
        }
        public async Task<GetProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _getProduct.GetProductDb(new GetProductRequest(request.Id));
            return response;
        }
    }
}
