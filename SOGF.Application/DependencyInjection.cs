using Microsoft.Extensions.DependencyInjection;
using SOGF.Domain.Model;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto;
using Solution.Application.Mappers;
using Solution.Application.Service;
using Solution.Application.Service.Faccao;
using Solution.Application.Service.MissaoService;
using Solution.Application.Service.Nave;
using Solution.Application.Service.Piloto;
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
        services.AddScoped<IFaccaoMapper, FaccaoMapper>();
        services.AddScoped<FaccaoMapper>();
        services.AddScoped<IFaccaoService, FaccaoService>();
        services.AddScoped<IMissaoMapper, MissaoMapper>();
        services.AddScoped<MissaoMapper>();
        services.AddScoped<IMissaoService, MissaoService>();
        services.AddScoped<IPilotoMapper, PilotoMapper>();
        services.AddScoped<PilotoMapper>();
        services.AddScoped<IPilotoService, PilotoService>();

        
        return services;
    }
}