using Microsoft.Extensions.DependencyInjection;
using Solution.Application.Service;
using Solution.Application.Service.Nave;

namespace Solution.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<INaveService, NaveService>();
        return services;
    }
}