namespace Solution.Application.TransferObjects.Tripulante;

public record TripulanteResponse(long id, string nome, string patente, string especialidade, List<RelatorioCombateResponse> historicoDeCombates);