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
        return service;
    }
}