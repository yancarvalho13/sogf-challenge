using SOGF.Domain.Model;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Dto.Piloto;

namespace Solution.Application.Mappers;

public class PilotoMapper : IMapper<Piloto, PilotoRequest, PilotoResponse>, IPilotoMapper
{
    public Piloto ToEntity(PilotoRequest request) =>
        new Piloto(request.nome, request.patente);
    

    public PilotoResponse ToDto(Piloto entity) =>
        new PilotoResponse(entity.Id, entity.Nome, entity.Patente);
    
}