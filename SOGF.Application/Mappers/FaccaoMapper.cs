using SOGF.Domain.Model;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Dto;
using Solution.Application.Dto.Faccao;

namespace Solution.Application.Mappers;

public class FaccaoMapper : IMapper<Faccao, FaccaoRequest, FaccaoResponse>, IFaccaoMapper
{
    public Faccao ToEntity(FaccaoRequest request) =>
        new Faccao(request.nome,
            request.statusDiplomatico,
            request.nivelAmeaca);

    public FaccaoResponse ToDto(Faccao entity) =>
        new FaccaoResponse(entity.Id,
            entity.Nome,
            entity.StatusDiplomatico,
            entity.NivelAmeaca,
            entity.Naves.Select(n =>
                new NaveResponse(n.Id, n.Nome, n.Classe, n.Status, n.FaccaoId)).ToList());
}