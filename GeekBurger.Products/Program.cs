using GeekBurger.Products.Configuration;
using GeekBurger.Products.Infra.Extension;
using GeekBurger.Products.Infra.Repository;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<ProductsDbContext>(options =>
    options.UseInMemoryDatabase(databaseName: "geekburger-products"));
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
var app = builder.Build();


ConfigurationServices.ConfiguracaoDosServicos(builder.Services);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
