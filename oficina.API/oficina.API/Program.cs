using Microsoft.EntityFrameworkCore;
using FluentValidation;
using oficina.API.Data;
using oficina.API.Services;
using oficina.API.Validators;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<OficinaDbContext>(options =>
    options.UseInMemoryDatabase("OficinaDb"));

builder.Services.AddScoped<IOrcamentoService, OrcamentoService>();
builder.Services.AddValidatorsFromAssemblyContaining<CriarOrcamentoRequestValidator>();

builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
