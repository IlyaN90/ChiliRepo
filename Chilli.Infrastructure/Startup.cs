
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Design;
using Chilli.Infrastructure.Repositories;
using Chilli.Core.Infrastructure.Entities.Repositories;
using Chilli.Core.Infrastructure.Repositories;

namespace Chilli.Infrastructure
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}
