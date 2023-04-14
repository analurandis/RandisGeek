using GeekBurger.Products.Configuration;
using GeekBurger.Products.Infra.Extension;
using GeekBurger.Products.Infra.Repository;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigurationServices.ConfiguracaoDosServicos(builder.Services);

var app = builder.Build();




if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
