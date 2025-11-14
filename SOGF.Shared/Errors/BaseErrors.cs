using SOGF.Shared.Exception;

namespace SOGF.Shared.Errors;

public class BaseErrors
{
    public static Error InvalidCredentials { get; } =
        new("InvalidCredentials", ErrorType.Unauthorized, "Credenciais Inválidas");

    public static Error RecurseNotFound { get; } =
        new("RecurseNotFound", ErrorType.NotFound, "Recurso na encontado na base de dados");
    
    public static Error InvalidPageNUmber { get; } =  new("InvalidPageNumber", ErrorType.NotFound, "Pagina Inválida");
}