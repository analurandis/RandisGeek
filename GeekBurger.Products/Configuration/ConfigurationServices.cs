using AutoMapper;
using GeekBurger.Products.Helper;
using GeekBurger.Products.Infra.Extension;
using GeekBurger.Products.Infra.Repository;
using GeekBurger.Products.Infra.Services;
using GeekBurger.Products.Infra.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GeekBurger.Products.Configuration
{
    public static  class ConfigurationServices
    {
        public static void ConfiguracaoDosServicos(IServiceCollection services)
        {
            services.AddDbContext<ProductsDbContext>(options => options.UseInMemoryDatabase(databaseName: "geekburger-products"));
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductChangedService, ProductChangedService>();
            services.AddScoped<IProductChangedEventRepository, ProductChangedEventRepository>();


            // Configure the HTTP request pipeline.
            var serviceProvider = services.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();

            services.AddAutoMapper(ac => {
                ac.AddProfile<AutomapperProfile>();
            });

            var productsDbContext = scope.ServiceProvider.GetRequiredService<ProductsDbContext>();

            productsDbContext.Seed();



            

        }
    }
}
