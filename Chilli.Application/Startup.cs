using Chilli.Application.Domain.Orders;
using Chilli.Application.Domain.Products;
using Chilli.Application.Validaiton;
using Chilli.Core.Order.Domain;
using Chilli.Core.Product.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chilli.Application
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IAddProduct, AddProduct>();
            services.AddScoped<IPutProduct, PutProduct>();
            services.AddScoped<IDeleteProduct, DeleteProduct>();
            services.AddScoped<IGetProduct, GetProduct>();
            services.AddScoped<IUploadImage, UploadImage>();

            services.AddScoped<IAddOrder, AddOrder>();
            services.AddScoped<IPutOrder, PutOrder>();
            services.AddScoped<IDeleteOrder, DeleteOrder>();
            services.AddScoped<IGetOrder, GetOrder>();

            services.AddScoped<IImageValidator, ImageValidator>();
        }
    }
}
