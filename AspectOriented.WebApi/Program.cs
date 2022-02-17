using AspectOriented.Business.Services;
using AspectOriented.Business.Extensions;
using AspectOriented.Business.Shared.Services;
using AspectOriented.CrossCutting.Proxy;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(serviceProvider =>
{
    return TransparentProxy<IProductServiceAspect>.Create(new ProductServiceAspect());
});
builder.Services.AddScoped<IProductService, ProductService>();
//builder.Services.DecorateWithDispatchProxy();

WebApplication? app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
