using Microsoft.Extensions.DependencyInjection;
using Solution.Application.Service;
using Solution.Application.Service.Nave;
using Solution.Application.Service.Tripulante;

namespace Solution.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<INaveService, NaveService>();
        services.AddScoped<ITripulanteService, TripulanteService>();
        return services;
    }
}