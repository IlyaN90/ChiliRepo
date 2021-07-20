﻿using Chilli.Core.Infrastructure.Repositories;
using Chilli.Core.Order.Domain;
using Chilli.Core.Order.Models.DBO;
using Chilli.Core.Order.Models.Request;
using Chilli.Core.Order.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chilli.Application.Domain.Orders
{
    public class GetOrder : IGetOrder
    {
        private readonly IOrderRepository _repository;
        public GetOrder(IOrderRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetOrderResponse> GetOrderDb(GetOrderRequest request)
        {
            var product = await _repository.GetOrderAsync(request);
            if (product.Any())
            {
                List<OrderModel> productModels = new List<OrderModel>();

                return new GetOrderResponse(true, productModels);
            }
            return new GetOrderResponse(false, null);
        }
        public async Task<GetOrderResponse> GetOrdersDb()
        {
            var orderModelList = await _repository.GetOrderAsync();
            return new GetOrderResponse(true, orderModelList);
        }
    }
}
