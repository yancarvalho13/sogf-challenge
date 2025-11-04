using Solution.Application.TransferObjects.Tripulante;

namespace Solution.Application.TransferObjects.Nave;

public record AncorarNaveResponse(long id, string nome, string tipoNave, long pilotoId,List<TripulanteResponse> tripulantes,string statusOperacional);