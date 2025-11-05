using SOGF.Domain.Model;
using Solution.Application.Contracts.Mapping;
using Solution.Application.Dto;

namespace Solution.Application.Mappers;

public class NaveMapper : IMapper<Nave, CreateNaveRequest, NaveResponse>,INaveMapper
{
    public Nave ToEntity(CreateNaveRequest request) => new Nave(request.nome, request.classe, request.status);
    

    public NaveResponse ToDto(Nave entity) =>  new NaveResponse(entity.Id, entity.Nome, entity.Classe, entity.Status);


    public EnlistPilotResponse ToEnlistPilotDto(Nave naveEntity, Tripulante tripulanteEntity) =>
        new EnlistPilotResponse(naveEntity.Id, tripulanteEntity.Id, naveEntity.Nome, tripulanteEntity.Nome);

    public EnlistTripulanteResponse ToEnlistTripulantDto(Nave naveEntity) =>
        new EnlistTripulanteResponse(naveEntity.Id,
            naveEntity.Tripulantes.Select(t =>
                new TripulanteResponse(t.Id, t.Nome, t.Patente, t.Especialidade)).ToList());
}