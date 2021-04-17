using Chilli.Core.Infrastructure.Entities.Repositories;
using Chilli.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace Chilli.Infrastructure
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
