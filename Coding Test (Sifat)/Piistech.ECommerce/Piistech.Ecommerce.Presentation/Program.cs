using Microsoft.EntityFrameworkCore;
using Piistech.Ecommerce.Application;
using Piistech.Ecommerce.Application.Products.Commands.Push;
using Piistech.Ecommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PisstechEcommerceDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("PisstechEcommerceDbConnectionString"));
    if (builder.Environment.IsDevelopment())
    {
        o.EnableDetailedErrors();
        o.EnableSensitiveDataLogging();
    }
});

builder.Services.AddScoped<IEcommerceDbContext, PisstechEcommerceDbContext>();



builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ProductHandler).Assembly));
var app = builder.Build();

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
