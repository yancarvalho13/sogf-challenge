namespace Solution.Application.TransferObjects;

public record RelatorioCombateResponse(long id,DateTime data, string resultado, string descricaoDeEventos, string pilotoVencedorId, string pilotoPerdedorId );