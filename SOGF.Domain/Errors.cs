using SOGF.Domain.Exception;

namespace SOGF.Domain;

public static class Errors
{
    public static Error NaveNotFound { get; } = new("NaveNotFound", ErrorType.NotFound, "Nave não enontrada.");
    
    public static Error PilotoNotFound { get; } = new("PilotoNotFound", ErrorType.NotFound, "Piloto não enontrado.");
    public static Error MissaoNotFound { get; } = new("MissaoNotFound", ErrorType.NotFound, "Missao não encontrada.");

    public static Error PilotoInMission { get; } = new("PilotoInMission", ErrorType.BadRequest, "O piloto ja está em missão");
    
    public static Error TripulanteInMission { get; } = new ("TripulanteInMission", ErrorType.BadRequest, "O tripulante ja está em missão");
    public static Error NaveInMission { get; } = new ("NaveInMission", ErrorType.BadRequest, "A nave ja está em missão");

    public static Error MissaoCompletada { get; } =
        new("Missaocompletada", ErrorType.BadRequest, "A missão ja foi concluida");

    public static Error AiModelComunicationFailure { get; } =
        new("AiModelComunicationFailure", ErrorType.BadRequest, "Falha de comunicação com o AiModel");

    public static Error InvalidCredentials { get; } =
        new("InvalidCredentials", ErrorType.Unauthorized, "Credenciais Inválidas");

    public static Error RecurseNotFound { get; } =
        new("RecurseNotFound", ErrorType.NotFound, "Recurso na encontado na base de dados");
}