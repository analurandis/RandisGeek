using GeekBurger.Products.Infra.Extension;
using GeekBurger.Products.Infra.Repository;

namespace GeekBurger.Products.Configuration
{
    public static  class ConfigurationServices
    {
        public static void ConfiguracaoDosServicos(IServiceCollection services)
        {
            // Configure the HTTP request pipeline.
            var serviceProvider = services.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            var productsDbContext = scope.ServiceProvider.GetRequiredService<ProductsDbContext>();

            productsDbContext.Seed();
        }
    }
}
