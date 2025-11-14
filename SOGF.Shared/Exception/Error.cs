namespace SOGF.Shared.Exception;

public record Error(string Id, ErrorType Type, string Description);
