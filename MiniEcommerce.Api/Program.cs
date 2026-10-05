using Microsoft.EntityFrameworkCore;
using MiniEcommerce.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//DB InMemory
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseInMemoryDatabase("EcommerceDb"));

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
