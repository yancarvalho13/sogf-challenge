using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Solution.Api;
using Solution.Api.Contracts;
using Solution.Application.Contracts.Persistence;
using Solution.Persistence.Contexts;
using Solution.Persistence.Repositories;


namespace Solution.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)

    {
        var connectionString = configuration.GetConnectionString("SOGFConnection");
        services.AddDbContext<SogfDbContext>(ctx => ctx.UseSqlServer(connectionString));
        services.AddScoped<INaveRepository, NaveRepository>();
        services.AddScoped<ITripulanteRepository, TripulanteRepository>();
        services.AddScoped<IMissaoRepository, MissaoRepository>();
        services.AddScoped<IFaccaoRepository, FaccaoRepository>();
        services.AddScoped<IPilotoRepository, PilotoRepository>();
        services.AddScoped<IRelatorioCombateRepository, RelatorioCombateRepository>();
        services.AddScoped<ILlMAdapter, GeminiAdapter>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}