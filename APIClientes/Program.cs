using APIClientes.Context;
using APIClientes.DataAccess;
using APIClientes.Interfaces;
using APIClientes.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Data access
builder.Services.AddDbContext<ClientesContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("constring")));

//Dependency Inyection
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ClienteDA>();

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
