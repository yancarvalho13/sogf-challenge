using Microsoft.Extensions.DependencyInjection;
using SOGF.Domain.Model;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto;
using Solution.Application.Mappers;
using Solution.Application.Service;
using Solution.Application.Service.Nave;
using Solution.Application.Service.Tripulante;

namespace Solution.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<INaveMapper, NaveMapper>();
        services.AddScoped<NaveMapper>();
        services.AddScoped<INaveService, NaveService>();
        services.AddScoped<ITripulanteMapper, TripulanteMapper>();
        services.AddScoped<TripulanteMapper>();
        services.AddScoped<ITripulanteService,TripulanteService>();
        

        
        return services;
    }
}