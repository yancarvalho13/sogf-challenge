

using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Solution.Api;
using Solution.Api.Contracts;
using Solution.Api.Controllers;
using Solution.Api.Controllers.Nave;
using Solution.Api.Controllers.Tripulante;
using Solution.Application;
using Solution.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddWebServices();

//builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
    });
}


app.MapControllers();
app.Run();

