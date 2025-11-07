using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Solution.Api.Contracts;
using Solution.Api.Controllers.Faccao;
using Solution.Api.Controllers.Missao;
using Solution.Api.Controllers.Nave;
using Solution.Api.Controllers.PilotoController;
using Solution.Api.Controllers.Tripulante;
using Solution.Application.Service.Tripulante;

namespace Solution.Api;

public static class DenpendencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection service)
    {
        service.AddScoped<INaveController, NaveController>();
        service.AddScoped<ITripulanteController, TripulanteController>();
        service.AddScoped<IFaccaoController, FaccaoController>();
        service.AddScoped<IMissaoController, MissaoController>();
        service.AddScoped<IPilotoController, PilotoController>();
        
        service.AddOpenApi(options =>
        {
            options.AddDocumentTransformer((document, context, cancellationToken) =>
            {
                document.Components ??= new();
                document.Components.SecuritySchemes = new Dictionary<string, OpenApiSecurityScheme>
                {
                    [JwtBearerDefaults.AuthenticationScheme] = new()
                    {
                        Type = SecuritySchemeType.Http,
                        Scheme = JwtBearerDefaults.AuthenticationScheme,
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Enter your JWT token"
                    }
                };
        
                document.SecurityRequirements = new List<OpenApiSecurityRequirement>
                {
                    new()
                    {
                        [new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        }] = Array.Empty<string>()
                    }
                };
        
                return Task.CompletedTask;
            });
        });
        
        return service;
    }
}