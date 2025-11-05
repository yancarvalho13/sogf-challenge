using Solution.Application.Contracts.Persistence;
using Solution.Application.Contracts.Service;
using Solution.Application.Dto;
using Solution.Application.Mappers;

namespace Solution.Application.Service.Nave;

public class NaveService : GenericService<SOGF.Domain.Model.Nave, CreateNaveRequest, NaveResponse>, INaveService
{
    private readonly INaveRepository _naveRepository;
    private readonly ITripulanteRepository _tripulanteRepository;
    private readonly INaveMapper _naveMapper;
    public NaveService(INaveRepository naveRepository, NaveMapper mapper, ITripulanteRepository tripulanteRepository, INaveMapper naveMapper) 
        : base(naveRepository, mapper)
    {
        _naveRepository = naveRepository;
        _tripulanteRepository = tripulanteRepository;
        _naveMapper = naveMapper;
    }

    public async Task<EnlistPilotResponse> EnlistPilot(long pilotId, long naveId)
    {
        var tripulanteEntitie = await _tripulanteRepository.GetByIdAsync(pilotId);
        var naveEntitie = await _naveRepository.GetByIdAsync(naveId);

        if (tripulanteEntitie is null || naveEntitie is null) throw new NullReferenceException();

        return _naveMapper.ToEnlistPilotDto(naveEntitie, tripulanteEntitie);
    }
   

    public async Task<EnlistTripulanteResponse> EnlistTripulante(long tripulanteId, long naveId)
    {
        var tripulanteDb = await _tripulanteRepository.GetByIdAsync(tripulanteId);
        var naveDb = await _naveRepository.GetByIdAsync(naveId);

        if (tripulanteDb is null || naveDb is null) throw new NullReferenceException();
        
        naveDb.EnlistTripulante(tripulanteDb);

        await _naveRepository.UpdateAsync(naveDb);
        

        return _naveMapper.ToEnlistTripulantDto(naveDb);
    }
}