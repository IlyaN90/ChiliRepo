using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace testApi
{
    public class Program
    {
        public static void Main(string[] args)
            =>CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel();
                    webBuilder.UseUrls("https://localhost:5001", "http://localhost:5000", "http://136.244.106.113:5000", "https://136.244.106.113:5001");
                });
    }
}
