namespace SOGF.Domain.Exception;

public record Error(string Id, ErrorType Type, string Description);
