namespace SOGF.Shared.Result;

public record ValidationFailureResponse(string? propertyName, string? errorMessage, string? attemptedValue);