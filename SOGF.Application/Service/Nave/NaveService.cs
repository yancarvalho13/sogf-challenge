using Solution.Application.Contracts.Persistence;
using Solution.Application.Dto;

namespace Solution.Application.Service.Nave;

public class NaveService : INaveService
{
    private readonly INaveRepository _naveRepository;
    private readonly ITripulanteRepository _tripulanteRepository;

    public NaveService(INaveRepository naveRepository, ITripulanteRepository tripulanteRepository)
    {
        _naveRepository = naveRepository;
        _tripulanteRepository = tripulanteRepository;
    }

  

    public async Task<NaveResponse> GetByIdAsync(long id)
    {
        var entity = await _naveRepository.GetByIdAsync(id);
        if (entity is null) throw new NullReferenceException();
        return new NaveResponse(entity.Nome, entity.Classe, entity.Status);

    }

    public async Task<NaveResponse> CreateAsync(CreateNaveRequest request)
    {
        var entity = new SOGF.Domain.Model.Nave(request.nome, request.classe, request.status);
        await _naveRepository.CreateAsync(entity);
        return new NaveResponse(entity.Nome, entity.Classe, entity.Status);
    }

    public async Task<GetAllNavesResponse> GetAllAsync()
    {
        var naves = await _naveRepository.GetAllAsync();
        var dto = naves.Select(nv => new NaveResponse(nv.Nome, nv.Classe, nv.Status))
            .ToList();
        
        return new GetAllNavesResponse(dto);
    }

    public async Task<bool> DeleteByIdAsync(long id)
    {
        var entity = await _naveRepository.GetByIdAsync(id);

        if (entity is null) throw new NullReferenceException();
        await _naveRepository.DeleteAsync(entity);
        return true;
    }

    public async Task<EnlistPilotResponse> EnlistPilot(long pilotId, long naveId)
    {
        var tripulanteDb = await _tripulanteRepository.GetByIdAsync(pilotId);
        var naveDb = await _naveRepository.GetByIdAsync(naveId);

        if (tripulanteDb is null || naveDb is null) throw new NullReferenceException();
        
        naveDb.EnlistPilot(tripulanteDb);
        await _naveRepository.CreateAsync(naveDb);

        return new EnlistPilotResponse(naveDb.Id, tripulanteDb.Id, naveDb.Nome, tripulanteDb.Nome);
    }

    public async Task<EnlistTripulanteResponse> EnlistTripulante(long tripulanteId, long naveId)
    {
        var tripulanteDb = await _tripulanteRepository.GetByIdAsync(tripulanteId);
        var naveDb = await _naveRepository.GetByIdAsync(naveId);

        if (tripulanteDb is null || naveDb is null) throw new NullReferenceException();
        
        naveDb.EnlistTripulante(tripulanteDb);

        await _naveRepository.CreateAsync(naveDb);
        var tripulanteDtoList =
            naveDb.Tripulantes.Select(t =>
                new TripulanteResponse(t.Id, t.Nome, t.Patente, t.Especialidade)).ToList();

        return new EnlistTripulanteResponse(naveDb.Id, tripulanteDtoList);
    }
}