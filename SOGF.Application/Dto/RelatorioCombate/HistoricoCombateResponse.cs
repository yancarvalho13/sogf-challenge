namespace Solution.Application.Dto.RelatorioCombate;

public record HistoricoCombateResponse(List<RelatorioCombateResponse> vitorias,
    List<RelatorioCombateResponse> derrotas);