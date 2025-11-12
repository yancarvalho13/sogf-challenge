using SOGF.Domain.Model;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Dto;

namespace Solution.Application.Mappers;

public class NaveMapper : IMapper<Nave, NaveRequest, NaveResponse>,INaveMapper
{
    public Nave ToEntity(NaveRequest request) =>
        new Nave(request.nome,
            request.classe,
            request.capacidadeTripulacao,
            request.status,
            request.faccaoId);
    

    public NaveResponse ToDto(Nave entity) =>  new NaveResponse(entity.Id,
        entity.Nome,
        entity.Classe,
        entity.CapacidadeTripulacao,
        entity.Status,
        entity.FaccaoId);
    
}